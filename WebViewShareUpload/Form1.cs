using System.Data;

namespace WebViewShareUpload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = QueryWebView.Instance.GetListHTMLShared();
        }

        private void BtnDelete_Click_1(object sender, EventArgs e)
        {
            int selectedCellCount = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int index = Convert.ToInt32(row.Cells[0].Value);
                    if (!QueryWebView.Instance.DeleteWebViewItem(index, out string exeption))
                    {
                        SaveLogFileError.SaveLogFile(exeption);
                        MessageBox.Show(exeption, "Lỗi");
                    }
                }
            }
            dataGridView1.DataSource = QueryWebView.Instance.GetListHTMLShared();
        }
    }
}