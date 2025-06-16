using Apteka.Model;
using System.Data;

namespace Apteka.View.MedicineV
{
	public partial class ExtendedSearchMedicneProducts : Form
	{
		public ExtendedSearchMedicneProducts()
		{
			InitializeComponent();
			TopMost = true;
		}

		/// <summary>
		/// Устанавливает значения элементов формы
		/// </summary>
		/// <param name="strParams">Обязательны следующие параметры: SerialNumber,
		/// MedicineForm, WayEnter, PackagingForm, Producer, PharmGroup, ConditionRelease,
		/// Component, ComponentMeasure, Decommissioned, Expired</param>
		/// <param name="doParams">Обязательны следующие параметры: DateReleaseMin, 
		/// DateReleaseMax, DateExpirationMin, DateExpirationMax</param>
		internal void SetParameters(string[] strParams, DateOnly?[] doParams)
		{
			tbSerialNumber.Text = strParams[0];

			cbMedicineForm.SelectedIndex = -1;
			cbMedicineForm.SelectedItem = strParams[1];
			cbWayEnter.SelectedIndex = -1;
			cbWayEnter.SelectedItem = strParams[2];
			cbPackagingForm.SelectedIndex = -1;
			cbPackagingForm.SelectedItem = strParams[3];
			cbProducer.SelectedIndex = -1;
			cbProducer.SelectedItem = strParams[4];

			tbPharmGroup.Text = strParams[5];
			tbConditionStorage.Text = strParams[6];
			tbConditionRelease.Text = strParams[7];
			tbComponent.Text = strParams[8];
			tbComponentMeasure.Text = strParams[9];

			cbDecommissioned.SelectedIndex = -1;
			cbDecommissioned.SelectedItem = strParams[10];

			cbExpired.SelectedIndex = -1;
			cbExpired.SelectedItem = strParams[11];

			dtpDateReleaseMin.Value = new DateTime(doParams[0] ?? new(), new TimeOnly());
			dtpDateReleaseMax.Value = new DateTime(doParams[1] ?? new(), new TimeOnly());
			dtpDateExpirationMin.Value = new DateTime(doParams[2] ?? new(), new TimeOnly());
			dtpDateExpirationMax.Value = new DateTime(doParams[3] ?? new(), new TimeOnly());
		}

		private List<string> GetListWithEmptyItem(List<string> ls)
		{
			List<string> tempList = [""];
			tempList.AddRange(ls);
			return tempList;
		}

		internal void SetDataSourceToComboBoxes(List<MedicineForm> mf, List<MedicineWayEnter> mwe,
			List<MedicinePackagingForm> mpf, List<MedicineProducer> mp)
		{
			cbMedicineForm.DataSource = GetListWithEmptyItem(mf.Select(f => f.Form).ToList());
			cbWayEnter.DataSource = GetListWithEmptyItem(mwe.Select(f => f.WayEnter).ToList());
			cbPackagingForm.DataSource = GetListWithEmptyItem(mpf.Select(f => f.PackagingForm).ToList());
			cbProducer.DataSource = GetListWithEmptyItem(mp.Select(f => f.Producer).ToList());
		}

		internal string[] GetStrParameters()
		{
			return [tbSerialNumber.Text, cbMedicineForm.Text, cbWayEnter.Text,
							cbPackagingForm.Text, cbProducer.Text, tbPharmGroup.Text, tbConditionStorage.Text,
							tbConditionRelease.Text, tbComponent.Text, tbComponentMeasure.Text, cbDecommissioned.Text, cbExpired.Text];
		}

		internal DateOnly[] GetDoParameters()
		{
			return [DateOnly.FromDateTime(dtpDateReleaseMin.Value), DateOnly.FromDateTime(dtpDateReleaseMax.Value),
				DateOnly.FromDateTime(dtpDateExpirationMin.Value), DateOnly.FromDateTime(dtpDateExpirationMax.Value)];
		}
	}
}
