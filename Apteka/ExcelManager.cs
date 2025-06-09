using Apteka.Model;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Apteka
{
	internal class ExcelManager
	{
		public static void ExportToExcel<T>(List<T> data, string filePath)
		{
			ExcelPackage.License.SetNonCommercialOrganization("Grant");

			using var package = new ExcelPackage();
			var worksheet = package.Workbook.Worksheets.Add("Отчёт");

			// Получаем свойства класса
			var properties = typeof(T).GetProperties();

			// Заголовки (используем атрибут [DisplayName] или имя свойства)
			for (int i = 0; i < properties.Length; i++)
			{
				var displayNameAttr = properties[i].GetCustomAttribute<DisplayNameAttribute>();
				worksheet.Cells[1, i + 1].Value = displayNameAttr?.DisplayName ?? properties[i].Name;
			}

			// Данные
			for (int i = 0; i < data.Count; i++)
			{
				for (int j = 0; j < properties.Length; j++)
				{
					worksheet.Cells[i + 2, j + 1].Value = properties[j].GetValue(data[i]);
				}
			}

			worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
			try
			{
				File.WriteAllBytes(filePath, package.GetAsByteArray());
			}
			catch (Exception)
			{
				MessageBox.Show($"Не получилось сформировать отчет. Пожалуйста, закройте открытый файл отчета",
					"Отчет о наличии ЛП в конце дня",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public static void ExportWithChart(List<MedicineProductSales> data, string filePath)
		{
			ExcelPackage.License.SetNonCommercialOrganization("Grant");

			using var package = new ExcelPackage();
			// Создаем лист с данными
			var worksheet = package.Workbook.Worksheets.Add("Отчет");

			// Заголовки
			worksheet.Cells["A1"].Value = "Месяц";
			worksheet.Cells["B1"].Value = "Количество";

			// Данные
			for (int i = 0; i < data.Count; i++)
			{
				worksheet.Cells[i + 2, 1].Value = data[i].Month;
				worksheet.Cells[i + 2, 2].Value = data[i].Quantity;
			}

			// Создаем график
			var chart = worksheet.Drawings.AddChart("salesChart", eChartType.ColumnClustered);

			// Указываем диапазоны данных
			var xAxis = worksheet.Cells[2, 1, data.Count + 1, 1]; // Месяцы (ось X)
			var yAxis1 = worksheet.Cells[2, 2, data.Count + 1, 2]; // Количество (серия 1)

			// Добавляем серии данных
			var series1 = chart.Series.Add(yAxis1, xAxis);
			series1.Header = "Количество";

			// Настройка графика
			chart.SetPosition(0, 0, 3, 0); // Позиция на листе
			chart.SetSize(800, 400); // Размер графика
			chart.Title.Text = "Продажи по месяцам";

			try
			{
				// Сохранение
				package.SaveAs(new FileInfo(filePath));
			}
			catch (Exception)
			{
				MessageBox.Show($"Не получилось сформировать отчет. Пожалуйста, закройте открытый файл отчета",
					"Отчет о наличии ЛП в конце дня",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public static void OpenExcelFile(string filePath)
		{
			try
			{
				var process = new Process
				{
					StartInfo = new ProcessStartInfo(filePath)
					{
						UseShellExecute = true // Ключевой параметр!
					}
				};
				process.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Не удалось открыть файл: {ex.Message}", "Отчет о наличии ЛП в конце дня",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}
