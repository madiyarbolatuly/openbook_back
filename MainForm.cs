
using DocumentFormat.OpenXml.Spreadsheet;
using gq_kp_client.Helpers;

namespace gq_kp_client
{
    public partial class MainForm : Form
    {
        private readonly HttpHelper _apiService = new HttpHelper();
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new ImportForm())
            {
                form.ShowDialog();
            }
        }

        private async void btn_search_ClickAsync(object sender, EventArgs e)
        {
            string searchTerm = txb_search.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
                return;

            try
            {
                var products = await _apiService.SearchProductAsync(searchTerm);

                if (products.Count == 0)
                {
                    MessageBox.Show("Не найдено.");
                    return;
                }

                dataGridView1.DataSource = products;

                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["BrandId"].Visible = false;
                dataGridView1.Columns["BrandName"].HeaderText = "Бренд";
                dataGridView1.Columns["SkuCode"].HeaderText = "Артикул";
                dataGridView1.Columns["AgskCode"].HeaderText = "Код АГСК";
                dataGridView1.Columns["ProductName"].HeaderText = "Наименование";
                dataGridView1.Columns["UoM"].HeaderText = "Ед. измерения";
                dataGridView1.Columns["PriceExVat"].HeaderText = "Цены без НДС";
                dataGridView1.Columns["PriceIncVat"].HeaderText = "Цены с НДС";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void txb_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_search.PerformClick();
            }
        }
    }
}
