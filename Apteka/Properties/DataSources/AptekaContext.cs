using Apteka.Model;
using Microsoft.EntityFrameworkCore;

namespace Apteka.Properties.DataSources;

public partial class AptekaContext : DbContext
{
	public AptekaContext()
	{
	}

	public AptekaContext(DbContextOptions<AptekaContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Department> Departments { get; set; }

	public virtual DbSet<Employee> Employees { get; set; }

	public virtual DbSet<EmployeeAccount> EmployeeAccounts { get; set; }

	public virtual DbSet<EmployeeFired> EmployeeFireds { get; set; }

	public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }

	public virtual DbSet<HistorySale> HistorySales { get; set; }

	public virtual DbSet<HistorySaleMedicineProduct> HistorySaleMedicineProducts { get; set; }

	public virtual DbSet<MeasureMeasurability> MeasureMeasurabilities { get; set; }

	public virtual DbSet<Medicine> Medicines { get; set; }

	public virtual DbSet<MedicineCost> MedicineCosts { get; set; }

	public virtual DbSet<MedicineForm> MedicineForms { get; set; }

	public virtual DbSet<MedicinePackagingForm> MedicinePackagingForms { get; set; }

	public virtual DbSet<MedicineProducer> MedicineProducers { get; set; }

	public virtual DbSet<MedicineProduct> MedicineProducts { get; set; }

	public virtual DbSet<MedicineProductDecommissioned> MedicineProductDecommissioneds { get; set; }

	public virtual DbSet<MedicineTypeForm> MedicineTypeForms { get; set; }

	public virtual DbSet<MedicineWayEnter> MedicineWayEnters { get; set; }

	public virtual DbSet<OrderAssign> OrderAssigns { get; set; }

	public virtual DbSet<Post> Posts { get; set; }

	public virtual DbSet<StorageMedicineProduct> StorageMedicineProducts { get; set; }

	public virtual DbSet<StoragePharmacy> StoragePharmacies { get; set; }

	public virtual DbSet<StoragePlace> StoragePlaces { get; set; }

	public virtual DbSet<Supplier> Suppliers { get; set; }

	public virtual DbSet<Waybill> Waybills { get; set; }

	public virtual DbSet<WaybillMedicineProduct> WaybillMedicineProducts { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
		=> optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Apteka;Username=postgres;Password=напиши свой");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder
			.HasPostgresExtension("btree_gin")
			.HasPostgresExtension("pg_trgm")
			.HasPostgresExtension("pgcrypto")
			.HasPostgresExtension("uuid-ossp")
			.HasAnnotation("Npgsql:CollationDefinition:public.russian_month", "ru-RU-u-ca-gregory,ru-RU-u-ca-gregory,icu,True");

		modelBuilder.Entity<Department>(entity =>
		{
			entity.HasKey(e => e.IdDepartment).HasName("department_pkey");

			entity.ToTable("department");

			entity.Property(e => e.IdDepartment).HasColumnName("id_department");
			entity.Property(e => e.Name)
				.HasColumnType("character varying")
				.HasColumnName("name");
		});

		modelBuilder.Entity<Employee>(entity =>
		{
			entity.HasKey(e => e.IdEmployee).HasName("employee_pkey");

			entity.ToTable("employee");

			entity.Property(e => e.IdEmployee)
				.HasDefaultValueSql("uuid_generate_v4()")
				.HasColumnName("id_employee");
			entity.Property(e => e.Address)
				.HasColumnType("character varying")
				.HasColumnName("address");
			entity.Property(e => e.Birthday).HasColumnName("birthday");
			entity.Property(e => e.IdDepartment).HasColumnName("id_department");
			entity.Property(e => e.IdPost).HasColumnName("id_post");
			entity.Property(e => e.Name)
				.HasMaxLength(50)
				.HasColumnName("name");
			entity.Property(e => e.Patronymic)
				.HasMaxLength(50)
				.HasColumnName("patronymic");
			entity.Property(e => e.Surname)
				.HasMaxLength(50)
				.HasColumnName("surname");

			entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.Employees)
				.HasForeignKey(d => d.IdDepartment)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("employee_id_department_fkey");

			entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Employees)
				.HasForeignKey(d => d.IdPost)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("employee_id_post_fkey");
		});

		modelBuilder.Entity<EmployeeAccount>(entity =>
		{
			entity
				.HasNoKey()
				.ToTable("employee_account");

			entity.HasIndex(e => e.IdEmployee, "employee_account_id_employee_key").IsUnique();

			entity.Property(e => e.IdEmployee).HasColumnName("id_employee");
			entity.Property(e => e.Login)
				.HasMaxLength(60)
				.HasColumnName("login");
			entity.Property(e => e.Online)
				.HasDefaultValue(false)
				.HasColumnName("online");
			entity.Property(e => e.Password)
				.HasMaxLength(60)
				.HasColumnName("password");
			entity.Property(e => e.Roles).HasColumnName("roles");

			entity.HasOne(d => d.IdEmployeeNavigation).WithOne()
				.HasForeignKey<EmployeeAccount>(d => d.IdEmployee)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("employee_account_id_employee_fkey");
		});

		modelBuilder.Entity<EmployeeFired>(entity =>
		{
			entity
				.HasNoKey()
				.ToTable("employee_fired");

			entity.HasIndex(e => e.IdEmployee, "employee_fired_id_employee_key").IsUnique();

			entity.Property(e => e.DateFired)
				.HasDefaultValueSql("(now())::date")
				.HasColumnName("date_fired");
			entity.Property(e => e.IdEmployee).HasColumnName("id_employee");
			entity.Property(e => e.Reason).HasColumnName("reason");

			entity.HasOne(d => d.IdEmployeeNavigation).WithOne()
				.HasForeignKey<EmployeeFired>(d => d.IdEmployee)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("employee_fired_id_employee_fkey");
		});

		modelBuilder.Entity<EmployeeRole>(entity =>
		{
			entity.HasKey(e => e.IdRole).HasName("employee_role_pkey");

			entity.ToTable("employee_role");

			entity.HasIndex(e => e.Name, "employee_role_name_key").IsUnique();

			entity.Property(e => e.IdRole).HasColumnName("id_role");
			entity.Property(e => e.Name)
				.HasColumnType("character varying")
				.HasColumnName("name");
		});

		modelBuilder.Entity<HistorySale>(entity =>
		{
			entity.HasKey(e => e.IdSale).HasName("history_sale_pkey");

			entity.ToTable("history_sale");

			entity.Property(e => e.IdSale)
				.HasDefaultValueSql("uuid_generate_v4()")
				.HasColumnName("id_sale");
			entity.Property(e => e.DateSale)
				.HasDefaultValueSql("now()")
				.HasColumnType("timestamp without time zone")
				.HasColumnName("date_sale");
			entity.Property(e => e.IdDepartment).HasColumnName("id_department");
			entity.Property(e => e.IdEmployee)
				.HasDefaultValueSql("get_current_employee()")
				.HasColumnName("id_employee");

			entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.HistorySales)
				.HasForeignKey(d => d.IdDepartment)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("history_sale_id_department_fkey");

			entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.HistorySales)
				.HasForeignKey(d => d.IdEmployee)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("history_sale_id_employee_fkey");
		});

		modelBuilder.Entity<HistorySaleMedicineProduct>(entity =>
		{
			entity
				.HasNoKey()
				.ToTable("history_sale_medicine_product");

			entity.Property(e => e.Amount).HasColumnName("amount");
			entity.Property(e => e.Cost).HasColumnName("cost");
			entity.Property(e => e.IdMedicineProduct).HasColumnName("id_medicine_product");
			entity.Property(e => e.IdPlace).HasColumnName("id_place");
			entity.Property(e => e.IdSale).HasColumnName("id_sale");
			entity.Property(e => e.IdStorage).HasColumnName("id_storage");
			entity.Property(e => e.Measure)
				.HasColumnType("character varying")
				.HasColumnName("measure");

			entity.HasOne(d => d.IdMedicineProductNavigation).WithMany()
				.HasForeignKey(d => d.IdMedicineProduct)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("history_sale_medicine_product_id_medicine_product_fkey");

			entity.HasOne(d => d.IdPlaceNavigation).WithMany()
				.HasForeignKey(d => d.IdPlace)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("history_sale_medicine_product_id_place_fkey");

			entity.HasOne(d => d.IdSaleNavigation).WithMany()
				.HasForeignKey(d => d.IdSale)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("history_sale_medicine_product_id_sale_fkey");

			entity.HasOne(d => d.IdStorageNavigation).WithMany()
				.HasForeignKey(d => d.IdStorage)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("history_sale_medicine_product_id_storage_fkey");

			entity.HasOne(d => d.MeasureNavigation).WithMany()
				.HasForeignKey(d => d.Measure)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("history_sale_medicine_product_measure_fkey");
		});

		modelBuilder.Entity<MeasureMeasurability>(entity =>
		{
			entity.HasKey(e => e.Measure).HasName("measure_measurability_pkey");

			entity.ToTable("measure_measurability");

			entity.Property(e => e.Measure)
				.HasColumnType("character varying")
				.HasColumnName("measure");
		});

		modelBuilder.Entity<Medicine>(entity =>
		{
			entity.HasKey(e => e.IdMedicine).HasName("medicine_pkey");

			entity.ToTable("medicine");

			entity.HasIndex(e => e.ConditionRelease, "idx_medicine_condition_release");

			entity.HasIndex(e => e.Mnn, "idx_medicine_mnn_trgm")
				.HasMethod("gin")
				.HasOperators(new[] { "gin_trgm_ops" });

			entity.HasIndex(e => e.Name, "idx_medicine_name_trgm")
				.HasMethod("gin")
				.HasOperators(new[] { "gin_trgm_ops" });

			entity.HasIndex(e => e.PharmGroup, "idx_medicine_pharm_group");

			entity.Property(e => e.IdMedicine).HasColumnName("id_medicine");
			entity.Property(e => e.ConditionRelease).HasColumnName("condition_release");
			entity.Property(e => e.Mnn)
				.HasColumnType("character varying")
				.HasColumnName("mnn");
			entity.Property(e => e.Name)
				.HasColumnType("character varying")
				.HasColumnName("name");
			entity.Property(e => e.PharmGroup)
				.HasColumnType("character varying")
				.HasColumnName("pharm_group");
		});

		modelBuilder.Entity<MedicineCost>(entity =>
		{
			entity
				.HasNoKey()
				.ToTable("medicine_cost");

			entity.HasIndex(e => new { e.IdMedicine, e.PackagingForm }, "idx_medicine_cost");

			entity.HasIndex(e => new { e.IdMedicine, e.PackagingForm }, "medicine_cost_not_unique").IsUnique();

			entity.Property(e => e.Cost).HasColumnName("cost");
			entity.Property(e => e.IdMedicine).HasColumnName("id_medicine");
			entity.Property(e => e.PackagingForm)
				.HasColumnType("character varying")
				.HasColumnName("packaging_form");

			entity.HasOne(d => d.IdMedicineNavigation).WithMany()
				.HasForeignKey(d => d.IdMedicine)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("medicine_cost_id_medicine_fkey");

			entity.HasOne(d => d.PackagingFormNavigation).WithMany()
				.HasForeignKey(d => d.PackagingForm)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("medicine_cost_packaging_form_fkey");
		});

		modelBuilder.Entity<MedicineForm>(entity =>
		{
			entity.HasKey(e => e.Form).HasName("medicine_form_pkey");

			entity.ToTable("medicine_form");

			entity.Property(e => e.Form)
				.HasColumnType("character varying")
				.HasColumnName("form");
			entity.Property(e => e.TypeForm)
				.HasColumnType("character varying")
				.HasColumnName("type_form");

			entity.HasOne(d => d.TypeFormNavigation).WithMany(p => p.MedicineForms)
				.HasForeignKey(d => d.TypeForm)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("medicine_form_type_form_fkey");
		});

		modelBuilder.Entity<MedicinePackagingForm>(entity =>
		{
			entity.HasKey(e => e.PackagingForm).HasName("medicine_packaging_form_pkey");

			entity.ToTable("medicine_packaging_form");

			entity.Property(e => e.PackagingForm)
				.HasColumnType("character varying")
				.HasColumnName("packaging_form");
		});

		modelBuilder.Entity<MedicineProducer>(entity =>
		{
			entity.HasKey(e => e.Producer).HasName("medicine_producer_pkey");

			entity.ToTable("medicine_producer");

			entity.Property(e => e.Producer)
				.HasColumnType("character varying")
				.HasColumnName("producer");
		});

		modelBuilder.Entity<MedicineProduct>(entity =>
		{
			entity.HasKey(e => e.IdMedicineProduct).HasName("medicine_product_pkey");

			entity.ToTable("medicine_product");

			entity.HasIndex(e => new { e.Name, e.Decommissioned }, "idx_med_prod_search_often2")
				.HasMethod("gin")
				.HasOperators(["gin_trgm_ops", null]);

			entity.HasIndex(e => new { e.Name, e.Form, e.Decommissioned }, "idx_med_prod_search_often3")
				.HasMethod("gin")
				.HasOperators(["gin_trgm_ops", null, null]);

			entity.HasIndex(e => e.SerialNumber, "medicine_product_serial_number_key").IsUnique();

			entity.Property(e => e.IdMedicineProduct)
				.HasDefaultValueSql("uuid_generate_v4()")
				.HasColumnName("id_medicine_product");
			entity.Property(e => e.Amount).HasColumnName("amount");
			entity.Property(e => e.Analogues).HasColumnName("analogues");
			entity.Property(e => e.Components)
				.HasColumnType("jsonb")
				.HasColumnName("components");
			entity.Property(e => e.DateExpiration).HasColumnName("date_expiration");
			entity.Property(e => e.DateRelease).HasColumnName("date_release");
			entity.Property(e => e.Decommissioned)
				.HasDefaultValue(false)
				.HasColumnName("decommissioned");
			entity.Property(e => e.DosageMode).HasColumnName("dosage_mode");
			entity.Property(e => e.Form)
				.HasColumnType("character varying")
				.HasColumnName("form");
			entity.Property(e => e.IdMedicine).HasColumnName("id_medicine");
			entity.Property(e => e.Name)
				.HasColumnType("character varying")
				.HasColumnName("name");
			entity.Property(e => e.PackagingForm)
				.HasColumnType("character varying")
				.HasColumnName("packaging_form");
			entity.Property(e => e.Producer)
				.HasColumnType("character varying")
				.HasColumnName("producer");
			entity.Property(e => e.SerialNumber)
				.HasColumnType("character varying")
				.HasColumnName("serial_number");
			entity.Property(e => e.StorageCondition).HasColumnName("storage_condition");
			entity.Property(e => e.WayEnter)
				.HasColumnType("character varying")
				.HasColumnName("way_enter");

			entity.HasOne(d => d.FormNavigation).WithMany(p => p.MedicineProducts)
				.HasForeignKey(d => d.Form)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("medicine_product_form_fkey");

			entity.HasOne(d => d.IdMedicineNavigation).WithMany(p => p.MedicineProducts)
				.HasForeignKey(d => d.IdMedicine)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("medicine_product_id_medicine_fkey");

			entity.HasOne(d => d.PackagingFormNavigation).WithMany(p => p.MedicineProducts)
				.HasForeignKey(d => d.PackagingForm)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("medicine_product_packaging_form_fkey");

			entity.HasOne(d => d.ProducerNavigation).WithMany(p => p.MedicineProducts)
				.HasForeignKey(d => d.Producer)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("medicine_product_producer_fkey");

			entity.HasOne(d => d.WayEnterNavigation).WithMany(p => p.MedicineProducts)
				.HasForeignKey(d => d.WayEnter)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("medicine_product_way_enter_fkey");
		});

		modelBuilder.Entity<MedicineProductDecommissioned>(entity =>
		{
			entity
				.HasNoKey()
				.ToTable("medicine_product_decommissioned");

			entity.HasIndex(e => e.IdMedicineProduct, "medicine_product_decommissioned_id_medicine_product_key").IsUnique();

			entity.Property(e => e.Amount).HasColumnName("amount");
			entity.Property(e => e.DateDecommission)
				.HasDefaultValueSql("now()")
				.HasColumnType("timestamp without time zone")
				.HasColumnName("date_decommission");
			entity.Property(e => e.IdMedicineProduct).HasColumnName("id_medicine_product");
			entity.Property(e => e.Measure)
				.HasColumnType("character varying")
				.HasColumnName("measure");
			entity.Property(e => e.Reason)
				.HasColumnType("character varying")
				.HasColumnName("reason");

			entity.HasOne(d => d.IdMedicineProductNavigation).WithOne()
				.HasForeignKey<MedicineProductDecommissioned>(d => d.IdMedicineProduct)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("medicine_product_decommissioned_id_medicine_product_fkey");

			entity.HasOne(d => d.MeasureNavigation).WithMany()
				.HasForeignKey(d => d.Measure)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("medicine_product_decommissioned_measure_fkey");
		});

		modelBuilder.Entity<MedicineTypeForm>(entity =>
		{
			entity.HasKey(e => e.TypeForm).HasName("medicine_type_form_pkey");

			entity.ToTable("medicine_type_form");

			entity.Property(e => e.TypeForm)
				.HasColumnType("character varying")
				.HasColumnName("type_form");
		});

		modelBuilder.Entity<MedicineWayEnter>(entity =>
		{
			entity.HasKey(e => e.WayEnter).HasName("medicine_way_enter_pkey");

			entity.ToTable("medicine_way_enter");

			entity.Property(e => e.WayEnter)
				.HasColumnType("character varying")
				.HasColumnName("way_enter");
		});

		modelBuilder.Entity<OrderAssign>(entity =>
		{
			entity.HasKey(e => e.IdOrder).HasName("order_assign_pkey");

			entity.ToTable("order_assign");

			entity.Property(e => e.IdOrder)
				.ValueGeneratedNever()
				.HasColumnName("id_order");
			entity.Property(e => e.DateAssign)
				.HasDefaultValueSql("now()")
				.HasColumnName("date_assign");
			entity.Property(e => e.IdEmployee).HasColumnName("id_employee");
			entity.Property(e => e.IdNewPost).HasColumnName("id_new_post");
			entity.Property(e => e.IdOldPost).HasColumnName("id_old_post");
			entity.Property(e => e.Reason).HasColumnName("reason");

			entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.OrderAssigns)
				.HasForeignKey(d => d.IdEmployee)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("order_assign_id_employee_fkey");

			entity.HasOne(d => d.IdNewPostNavigation).WithMany(p => p.OrderAssignIdNewPostNavigations)
				.HasForeignKey(d => d.IdNewPost)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("order_assign_id_new_post_fkey");

			entity.HasOne(d => d.IdOldPostNavigation).WithMany(p => p.OrderAssignIdOldPostNavigations)
				.HasForeignKey(d => d.IdOldPost)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("order_assign_id_old_post_fkey");
		});

		modelBuilder.Entity<Post>(entity =>
		{
			entity.HasKey(e => e.IdPost).HasName("post_pkey");

			entity.ToTable("post");

			entity.Property(e => e.IdPost).HasColumnName("id_post");
			entity.Property(e => e.Name)
				.HasColumnType("character varying")
				.HasColumnName("name");
			entity.Property(e => e.Salary).HasColumnName("salary");
		});

		modelBuilder.Entity<StorageMedicineProduct>(entity =>
		{
			entity.HasKey(e => new { e.IdDepartment, e.IdStorage, e.IdPlace, e.IdMedicineProduct }).HasName("storage_pkey");

			entity.ToTable("storage_medicine_product");

			entity.HasIndex(e => new { e.IdMedicineProduct, e.IdDepartment }, "idx_storage_medicine_product_main");

			entity.Property(e => e.IdDepartment).HasColumnName("id_department");
			entity.Property(e => e.IdStorage).HasColumnName("id_storage");
			entity.Property(e => e.IdPlace).HasColumnName("id_place");
			entity.Property(e => e.IdMedicineProduct).HasColumnName("id_medicine_product");
			entity.Property(e => e.Amount).HasColumnName("amount");
			entity.Property(e => e.Measure)
				.HasColumnType("character varying")
				.HasColumnName("measure");

			entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.StorageMedicineProducts)
				.HasForeignKey(d => d.IdDepartment)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("storage_medicine_product_id_department_fkey");

			entity.HasOne(d => d.IdMedicineProductNavigation).WithMany(p => p.StorageMedicineProducts)
				.HasForeignKey(d => d.IdMedicineProduct)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("storage_medicine_product_id_medicine_product_fkey");

			entity.HasOne(d => d.IdPlaceNavigation).WithMany(p => p.StorageMedicineProducts)
				.HasForeignKey(d => d.IdPlace)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("storage_medicine_product_id_place_fkey");

			entity.HasOne(d => d.IdStorageNavigation).WithMany(p => p.StorageMedicineProducts)
				.HasForeignKey(d => d.IdStorage)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("storage_medicine_product_id_storage_fkey");

			entity.HasOne(d => d.MeasureNavigation).WithMany(p => p.StorageMedicineProducts)
				.HasForeignKey(d => d.Measure)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("storage_medicine_product_measure_fkey");
		});

		modelBuilder.Entity<StoragePharmacy>(entity =>
		{
			entity.HasKey(e => e.IdStorage).HasName("storage_pharmacy_pkey");

			entity.ToTable("storage_pharmacy");

			entity.HasIndex(e => e.Name, "storage_pharmacy_name_key").IsUnique();

			entity.Property(e => e.IdStorage).HasColumnName("id_storage");
			entity.Property(e => e.Name)
				.HasColumnType("character varying")
				.HasColumnName("name");
		});

		modelBuilder.Entity<StoragePlace>(entity =>
		{
			entity.HasKey(e => e.IdPlace).HasName("storage_place_pkey");

			entity.ToTable("storage_place");

			entity.HasIndex(e => e.Name, "storage_place_name_key").IsUnique();

			entity.Property(e => e.IdPlace).HasColumnName("id_place");
			entity.Property(e => e.Name)
				.HasColumnType("character varying")
				.HasColumnName("name");
		});

		modelBuilder.Entity<Supplier>(entity =>
		{
			entity.HasKey(e => e.IdSupplier).HasName("supplier_pkey");

			entity.ToTable("supplier");

			entity.HasIndex(e => e.Name, "supplier_name_key").IsUnique();

			entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");
			entity.Property(e => e.Name)
				.HasColumnType("character varying")
				.HasColumnName("name");
		});

		modelBuilder.Entity<Waybill>(entity =>
		{
			entity.HasKey(e => e.IdWaybill).HasName("waybill_pkey");

			entity.ToTable("waybill");

			entity.Property(e => e.IdWaybill)
				.ValueGeneratedNever()
				.HasColumnName("id_waybill");
			entity.Property(e => e.DateWaybill).HasColumnName("date_waybill");
			entity.Property(e => e.IdDepartment).HasColumnName("id_department");
			entity.Property(e => e.IdEmployee)
				.HasDefaultValueSql("get_current_employee()")
				.HasColumnName("id_employee");
			entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");

			entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.Waybills)
				.HasForeignKey(d => d.IdDepartment)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("waybill_id_department_fkey");

			entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Waybills)
				.HasForeignKey(d => d.IdEmployee)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("waybill_id_employee_fkey");

			entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.Waybills)
				.HasForeignKey(d => d.IdSupplier)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("waybill_id_supplier_fkey");
		});

		modelBuilder.Entity<WaybillMedicineProduct>(entity =>
		{
			entity
				.HasNoKey()
				.ToTable("waybill_medicine_product");

			entity.Property(e => e.Amount).HasColumnName("amount");
			entity.Property(e => e.Cost).HasColumnName("cost");
			entity.Property(e => e.IdMedicineProduct).HasColumnName("id_medicine_product");
			entity.Property(e => e.IdWaybill).HasColumnName("id_waybill");
			entity.Property(e => e.Measure)
				.HasColumnType("character varying")
				.HasColumnName("measure");

			entity.HasOne(d => d.IdMedicineProductNavigation).WithMany()
				.HasForeignKey(d => d.IdMedicineProduct)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("waybill_medicine_product_id_medicine_product_fkey");

			entity.HasOne(d => d.IdWaybillNavigation).WithMany()
				.HasForeignKey(d => d.IdWaybill)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("waybill_medicine_product_id_waybill_fkey");

			entity.HasOne(d => d.MeasureNavigation).WithMany()
				.HasForeignKey(d => d.Measure)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("waybill_medicine_product_measure_fkey");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
