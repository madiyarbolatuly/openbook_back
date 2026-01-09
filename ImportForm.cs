using gq_kp_client.Dto;
using gq_kp_client.Helpers;
using gq_kp_client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gq_kp_client
{
    public partial class ImportForm : Form
    {
        private readonly HttpHelper _apiService = new HttpHelper();
        public ImportForm()
        {
            InitializeComponent();
        }

        private async void btn_import_ClickAsync(object sender, EventArgs e)
        {
            btn_select.Enabled = false;
            btn_import.Enabled = false;
            btn_cancel.Enabled = false;

            // Get Excel file path
            string filePath = textBox1.Text;

            label1.Text = "Статус: Чтение из файла...";

            // Reset progress bar
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;

            // Create progress reporter
            var progress = new Progress<int>(percent =>
            {
                // This runs on the UI thread automatically
                progressBar1.Value = Math.Min(percent, 100);
            });

            // Run Excel reading in background to avoid UI freeze
            List<ProductDto> products = await Task.Run(() =>
                ImportHelper.ReadProductsFromExcel(filePath, progress)
            );

            // Get Brands List from api
            var brands = await _apiService.GetBrandsAsync();
            BrandHelper.Initialize(brands);

            // Reset progress bar
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = products.Count;

            label1.Text = $"Статус: Импорт записей в базу данных...";

            // Send Products to api
            foreach (var product in products)
            {
                if (string.IsNullOrEmpty(product.BrandName)) continue;

                Product p = new Product();

                p.BrandId = (int)BrandHelper.GetBrandId(product.BrandName);
                p.SkuCode = product.SkuCode;
                p.AgskCode = product.AgskCode;
                p.ProductName = product.ProductName;
                p.PriceExVat = product.PriceExVat;
                p.PriceIncVat = product.PriceIncVat;
                p.UoM = product.UoM;

                var success = await _apiService.CreateProductAsync(p);
                if (success)
                {
                    Debug.WriteLine($"{p.SkuCode} added");
                }
                else
                {
                    Debug.WriteLine($"{p.SkuCode} NOT added");
                }

                // Update progress bar
                progressBar1.Value += 1;
            }

            label1.Text = $"Статус: Импорт завершен!";
            MessageBox.Show($"Импорт завершен!");

            btn_select.Enabled = true;
            btn_import.Enabled = true;
            btn_cancel.Enabled = true;

            this.Close();
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Выбрать файл";
            openFileDialog1.Filter = "Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls|All Files (*.*)|*.*";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string filePath = openFileDialog1.FileName;

                // Show it in the textbox
                textBox1.Text = filePath;
            }

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
