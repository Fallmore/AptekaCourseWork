using Apteka.BaseClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using System.Collections.Concurrent;

namespace Apteka.Properties
{
	internal class DatabaseNotificationService : IDisposable
	{
		private readonly NpgsqlConnection _connection;
		private readonly Dictionary<string, Action<JObject>> _handlers = [];
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
					catch (Exception)
					{
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

				if (_listenerTask != null) StopListening();

				using var cmd = new NpgsqlCommand($"LISTEN {channel}", _connection);
				cmd.ExecuteNonQuery();

				StartListening();

				_handlers[typeof(T).Name + ":" + channel] = handler;
			}
			catch (NpgsqlException)
			{
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
			foreach (string key in _handlers.Keys)
			{
				if (key.Contains(":" + e.Channel))
					if (_handlers.TryGetValue(key, out var handler))
					{
						try
						{
							var data = JsonConvert.DeserializeObject<dynamic>(e.Payload);
							handler(data);
						}
						catch (Exception ex)
						{
							Console.WriteLine($"Ошибка в обработчике уведомлений: {ex.Message}");
						}
					}
			}
		}
	}
}
