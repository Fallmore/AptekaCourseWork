using Apteka.ViewModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace Apteka.BaseClasses
{
	public class FormWithNotification : Form
	{
		public event EventHandler OnTableUpdated = null!;

		internal void RefreshDataSimple<T>(Action<List<T>> setter, GeneralViewModel general) where T : class
		{
			Invoke(() =>
			{
				var newData = general.AptekaContext.Set<T>().AsNoTracking().ToList();
				setter(newData);
				OnTableUpdated?.Invoke(this, new PropertyChangedEventArgs(typeof(T).Name));
			});
		}

		internal void RefreshData<T>(List<T> collection, Action<List<T>> setter, JObject data,
			Action? dgvUpdate = null) where T : UnionId
		{
			try
			{
				string operation = data["operation"].ToString();

				switch (operation)
				{
					case "INSERT":
						Insert(collection, setter, data);
						break;
					case "UPDATE":
						Update(collection, setter, data);
						break;
					case "DELETE":
						Delete(collection, setter, data);
						break;
				}

				if (dgvUpdate != null)
				{
					if (InvokeRequired)
						Invoke(dgvUpdate);
					else
						dgvUpdate();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка обработки {typeof(T).Name} уведомлений: {ex.Message}");
			}
		}

		private void Insert<T>(List<T> collection, Action<List<T>> setter, JToken payload)
		{
			var newItem = JsonConvert.DeserializeObject<T>(payload["new"].ToString().Replace("_", ""));
			collection.Add(newItem);
			setter(collection);
		}

		private void Update<T>(List<T> collection, Action<List<T>> setter, JToken payload) where T : UnionId
		{
			T? oldItem = JsonConvert.DeserializeObject<T>(payload["old"].ToString().Replace("_", ""));
			T? existing = collection.FirstOrDefault(x => x.GetId().Equals(oldItem.GetId()));
			T? updatedItem = JsonConvert.DeserializeObject<T>(payload["new"].ToString().Replace("_", ""));

			if (existing != null)
			{
				collection.Remove(existing);
				collection.Add(updatedItem);
				setter(collection);
			}
		}

		private void Delete<T>(List<T> collection, Action<List<T>> setter, JToken payload) where T : UnionId
		{
			T? dItem = JsonConvert.DeserializeObject<T>(payload["old"].ToString().Replace("_", ""));
			T? deletedItem = collection.FirstOrDefault(x => x.GetId().Equals(dItem.GetId()));

			if (deletedItem != null)
			{
				collection.Remove(deletedItem);
				setter(collection);
			}
		}
	}
}
