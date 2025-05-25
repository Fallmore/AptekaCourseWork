using Apteka.Model;
using Apteka.Properties;
using Apteka.Properties.DataSources;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;

namespace Apteka.ViewModel
{
	internal sealed class GeneralViewModel
	{
		private static readonly Lazy<GeneralViewModel> _instance = new(() => new GeneralViewModel());

		private AptekaContext _aptekaContext;
		private DatabaseNotificationService _databaseNotificationService;
		private int _millisecondsWait = 1000;
		// Хранит все открытые формы
		private FormCollection _fc;

		#region Данные таблиц БД
		private List<Medicine> _medicines = [];
		private List<MedicineProduct> _medicineProducts = [];
		private List<MedicineCost> _medicineCosts = [];
		private List<StorageMedicineProduct> _storageMedicineProducts = [];
		private List<HistorySale> _historySales = [];
		private List<MedicineProductDecommissioned> _medicineProductDecommissioneds = [];
		private List<Employee> _employees = [];
		private List<EmployeeFired> _employeeFireds = [];

		private List<Department> _departments = [];
		private List<MeasureMeasurability> _measureMeasurabilities = [];
		private List<MedicineForm> _medicineForms = [];
		private List<MedicinePackagingForm> _medicinePackagingForms = [];
		private List<MedicineProducer> _medicineProducers = [];
		private List<MedicineTypeForm> _medicineTypeForms = [];
		private List<MedicineWayEnter> _medicineWayEnters = [];
		private List<OrderAssign> _orderAssigns = [];
		private List<Post> _posts = [];
		private List<StoragePharmacy> _storagePharmacies = [];
		private List<StoragePlace> _storagePlaces = [];
		private List<Supplier> _suppliers = [];
		#endregion

		// Guid препаратов с истекшим сроком годности
		private List<Guid> _medicineProductsExpired = [];
		private TimeSpan _criticalDaysOfExpiration = TimeSpan.FromDays(31);
		// Препараты на складе с критическим количеством
		private List<StorageMedicineProduct> _medicineProductsCriticalAmount = [];
		private float _criticalAmount = 5;
		internal static GeneralViewModel Instance => _instance.Value;
		internal AptekaContext AptekaContext => _aptekaContext;
		internal DatabaseNotificationService DatabaseNotificationService { get => _databaseNotificationService; set => _databaseNotificationService = value; }

		#region Инкапсулированные поля данных таблиц БД
		internal List<Medicine> Medicines
		{
			get => _medicines = LoadIfEmpty(_medicines, _aptekaContext.Medicines);
			set => _medicines = value;
		}

		internal List<MedicineProduct> MedicineProducts
		{
			get => _medicineProducts = LoadIfEmpty(_medicineProducts, _aptekaContext.MedicineProducts);
			set => _medicineProducts = value;
		}

		internal List<MedicineCost> MedicineCosts
		{
			get => _medicineCosts = LoadIfEmpty(_medicineCosts, _aptekaContext.MedicineCosts);
			set => _medicineCosts = value;
		}

		internal List<StorageMedicineProduct> StorageMedicineProducts
		{
			get => _storageMedicineProducts = LoadIfEmpty(_storageMedicineProducts, _aptekaContext.StorageMedicineProducts);
			set => _storageMedicineProducts = value;
		}

		internal List<HistorySale> HistorySales
		{
			get => _historySales = LoadIfEmpty(_historySales, _aptekaContext.HistorySales);
			set => _historySales = value;
		}

		internal List<MedicineProductDecommissioned> MedicineProductDecommissioneds
		{
			get => _medicineProductDecommissioneds = LoadIfEmpty(_medicineProductDecommissioneds, _aptekaContext.MedicineProductDecommissioneds);
			set => _medicineProductDecommissioneds = value;
		}

		internal List<Employee> Employees
		{
			get => _employees = LoadIfEmpty(_employees, _aptekaContext.Employees);
			set => _employees = value;
		}

		internal List<Department> Departments
		{
			get => _departments = LoadIfEmpty(_departments, _aptekaContext.Departments);
			set => _departments = value;
		}

		internal List<EmployeeFired> EmployeeFireds
		{
			get => _employeeFireds = LoadIfEmpty(_employeeFireds, _aptekaContext.EmployeeFireds);
			set => _employeeFireds = value;
		}

		internal List<MeasureMeasurability> MeasureMeasurabilities
		{
			get => _measureMeasurabilities = LoadIfEmpty(_measureMeasurabilities, _aptekaContext.MeasureMeasurabilities);
			set => _measureMeasurabilities = value;
		}

		internal List<MedicineForm> MedicineForms
		{
			get => _medicineForms = LoadIfEmpty(_medicineForms, _aptekaContext.MedicineForms);
			set => _medicineForms = value;
		}

		internal List<MedicinePackagingForm> MedicinePackagingForms
		{
			get => _medicinePackagingForms = LoadIfEmpty(_medicinePackagingForms, _aptekaContext.MedicinePackagingForms);
			set => _medicinePackagingForms = value;
		}

		internal List<MedicineProducer> MedicineProducers
		{
			get => _medicineProducers = LoadIfEmpty(_medicineProducers, _aptekaContext.MedicineProducers);
			set => _medicineProducers = value;
		}

		internal List<MedicineTypeForm> MedicineTypeForms
		{
			get => _medicineTypeForms = LoadIfEmpty(_medicineTypeForms, _aptekaContext.MedicineTypeForms);
			set => _medicineTypeForms = value;
		}

		internal List<MedicineWayEnter> MedicineWayEnters
		{
			get => _medicineWayEnters = LoadIfEmpty(_medicineWayEnters, _aptekaContext.MedicineWayEnters);
			set => _medicineWayEnters = value;
		}

		internal List<OrderAssign> OrderAssigns
		{
			get => _orderAssigns = LoadIfEmpty(_orderAssigns, _aptekaContext.OrderAssigns);
			set => _orderAssigns = value;
		}

		internal List<Post> Posts
		{
			get => _posts = LoadIfEmpty(_posts, _aptekaContext.Posts);
			set => _posts = value;
		}

		internal List<StoragePharmacy> StoragePharmacies
		{
			get => _storagePharmacies = LoadIfEmpty(_storagePharmacies, _aptekaContext.StoragePharmacies);
			set => _storagePharmacies = value;
		}

		internal List<StoragePlace> StoragePlaces
		{
			get => _storagePlaces = LoadIfEmpty(_storagePlaces, _aptekaContext.StoragePlaces);
			set => _storagePlaces = value;
		}

		internal List<Supplier> Suppliers
		{
			get => _suppliers = LoadIfEmpty(_suppliers, _aptekaContext.Suppliers);
			set => _suppliers = value;
		}
		#endregion

		internal List<Guid> MedicineProductsExpired { get => _medicineProductsExpired; set => _medicineProductsExpired = value; }
		internal List<StorageMedicineProduct> MedicineProductsCriticalAmount { get => _medicineProductsCriticalAmount; set => _medicineProductsCriticalAmount = value; }
		internal TimeSpan CriticalTimeOfExpiration { get => _criticalDaysOfExpiration; set => _criticalDaysOfExpiration = value; }
		internal float CriticalAmount { get => _criticalAmount; set => _criticalAmount = value; }
		public int MillisecondsWait { get => _millisecondsWait; set => _millisecondsWait = value; }

		private GeneralViewModel() { }

		public async void Initialize()
		{
			_aptekaContext = new();
			_aptekaContext.Database.EnsureCreated();
			_databaseNotificationService = new(_aptekaContext.Database.GetConnectionString() ?? "");
			_fc = Application.OpenForms;
			await ExecuteDailyFunctions();
		}

		private async Task ExecuteDailyFunctions()
		{
			await CheckDateExpiration();
			await CheckCriticalAmount();
			await ClearMedicineProductSales();
			await ClearEmployeeData();
		}

		private async Task CheckDateExpiration()
		{
			await using var localContext = new AptekaContext();
			_medicineProductsExpired = await localContext.Database
					.SqlQueryRaw<Guid>("SELECT * FROM check_expired_medicine_product({0})", _criticalDaysOfExpiration)
					.ToListAsync();
			return;
		}

		private async Task CheckCriticalAmount()
		{
			await using var localContext = new AptekaContext();
			_medicineProductsCriticalAmount = await localContext.StorageMedicineProducts
					.FromSqlRaw("SELECT * FROM check_critical_amount_medicine_product({0})", _criticalAmount)
					.ToListAsync();
			return;
		}

		private async Task ClearMedicineProductSales()
		{
			await using var localContext = new AptekaContext();
			localContext.Database.ExecuteSql($"CALL clear_medicine_product_sales()");
			return;
		}

		private async Task ClearEmployeeData()
		{
			await using var localContext = new AptekaContext();
			localContext.Database
				   .ExecuteSql($"CALL clear_employee_data()");
			return;
		}

		private List<T> LoadIfEmpty<T>(List<T> privateList, IQueryable<T> dbSet) where T : class
		{
			if (privateList.Count == 0)
			{
				try
				{
					return dbSet.AsNoTracking().ToList();
				}
				catch (Exception ex)
				{
					Debug.WriteLine($"Ошибка загрузки данных {typeof(T).Name}: {ex.Message}");
					return privateList;
				}
			}
			return privateList;
		}

		internal void LoadTableForWrite<T>()
		{
			switch (typeof(T).Name)
			{
				case "MedicineProduct":
					_medicineProducts = _aptekaContext.MedicineProducts.ToList();
					break;
				case "StorageMedicineProduct":
					_storageMedicineProducts = _aptekaContext.StorageMedicineProducts.ToList();
					break;
				case "HistorySale":
					_historySales = _aptekaContext.HistorySales.ToList();
					break;
				case "MedicineProductDecommissioned":
					_medicineProductDecommissioneds = _aptekaContext.MedicineProductDecommissioneds.ToList();
					break;
				case "Employee":
					_employees = _aptekaContext.Employees.ToList();
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Настройка внешнего вида таблицы
		/// </summary>
		/// <param name="dgv"></param>
		internal void SetDefaultSettingsToDGV(DataGridView dgv)
		{
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
			dgv.RowsDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
			dgv.EnableHeadersVisualStyles = false;
			dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
			dgv.AllowUserToOrderColumns = true;
		}

		/// <summary>
		/// Настройка имен столбцов DataGridView
		/// </summary>
		/// <typeparam name="T">Класс таблицы БД</typeparam>
		/// <param name="dgv"></param>
		internal void ConfigureGrid<T>(DataGridView dgv)
		{
			// Получаем свойства модели с атрибутами Display
			var properties = typeof(T).GetProperties()
				.Where(p => p.GetCustomAttribute<DisplayAttribute>() != null);

			foreach (var prop in properties)
			{
				var displayAttr = prop.GetCustomAttribute<DisplayAttribute>();

				dgv.Columns.Add(new DataGridViewTextBoxColumn
				{
					HeaderText = displayAttr != null
								? displayAttr.Name // Берем название из атрибута
								: prop.Name,
					DataPropertyName = prop.Name,  // Привязка к свойству
					Name = prop.Name               // Техническое имя столбца
				});
			}
		}

		internal T? GetActivatedForm<T>() where T : Form
		{
			foreach (Form frm in _fc)
				if (frm.Name == typeof(T).Name)
				{
					frm.Activate();
					return frm as T;
				}
			return default;
		}

		internal List<T> GetListWithEmptyItem<T>(List<T> ls, T emptyItem)
		{
			List<T> tempList = [emptyItem];
			tempList.AddRange(ls);
			return tempList;
		}
	}

	internal class ComboBoxItem
	{
		public string Name { get; set; } = "";
		public int Id { get; set; } = -1;
	}
}
