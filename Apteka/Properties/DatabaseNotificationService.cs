using Apteka.BaseClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Apteka.Properties
{
	internal class DatabaseNotificationService : IDisposable
	{
		private readonly NpgsqlConnection _connection;
		private readonly ConcurrentDictionary<string, ConcurrentBag<Action<JObject>>> _subscribers = new();
		private CancellationTokenSource _cts;
		private Task _listenerTask;

		public DatabaseNotificationService(string connectionString)
		{
			NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder(connectionString)
			{
				Pooling = false
			};

			_connection = new NpgsqlConnection(builder.ConnectionString);
			_connection.Open();
			_connection.Notification += _connection_Notification;
			_cts = new CancellationTokenSource();
		}

		public void StartListening()
		{
			_listenerTask = Task.Run(async () =>
			{
				while (!_cts.IsCancellationRequested)
				{
					try
					{
						await _connection.WaitAsync(_cts.Token).ConfigureAwait(false);
					}
					catch (OperationCanceledException)
					{
						break;
					}
					catch (TimeoutException)
					{
						continue;
					}
					catch (Exception ex)
					{
						Debug.WriteLine($"Ошибка слушания: {ex.Message}");
						await Task.Delay(1000);
					}
				}
			}, _cts.Token);
		}

		public void StopListening()
		{
			_cts?.Cancel();
			try
			{
				_listenerTask?.Wait();
			}
			catch (Exception)
			{

			}
			_cts = new CancellationTokenSource();
		}

		public void Subscribe<T>(string tableName, Action<JObject> handler) where T : FormWithNotification
		{
			try
			{
				var channel = $"{tableName}_updates";

				_subscribers.AddOrUpdate(channel,
			_ =>
						{
							if (_listenerTask != null) StopListening();

							// Если канала нет - создаем новую подписку в БД
							using var cmd = new NpgsqlCommand($"LISTEN {channel}", _connection);
							cmd.ExecuteNonQuery();

							StartListening();

							var bag = new ConcurrentBag<Action<JObject>>
							{
								handler
							};
							return bag;
						},
			(_, existingBag) =>
						{
							// Если канал есть - просто добавляем обработчик
							existingBag.Add(handler);
							return existingBag;
						});
			}
			catch (NpgsqlException ex)
			{
				Debug.WriteLine($"Ошибка подписи: {ex.Message}");
				if (_connection.State == System.Data.ConnectionState.Closed)
					_connection.Open();
				Subscribe<T>(tableName, handler);
			}
		}

		public void Dispose()
		{
			StopListening();
			_connection?.Close();
			_connection?.Dispose();
		}

		private void _connection_Notification(object sender, NpgsqlNotificationEventArgs e)
		{
			if (_subscribers.TryGetValue(e.Channel, out var handlers))
			{
				var data = JsonConvert.DeserializeObject<dynamic>(e.Payload);
				foreach (var handler in handlers)
				{
					try
					{
						handler(data);
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Ошибка в обработчике: {ex.Message}");
					}
				}
			}
		}
	}
}
