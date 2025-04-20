namespace DM2GM
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            txtOutput.Text = MenuConverter.Convert(txtInput.Text, txtMMap.Text);
        }

        private void btnImportMMap_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "ӳ���txt�ļ�|*.txt",
                Multiselect = false // ����Ϊ����ѡ�񵥸��ļ�
            };
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileContent = File.ReadAllText(dialog.FileName);
                txtMMap.Text = fileContent;
            }
        }

        private void btnImportDM_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "DM�˵�yml�ļ�|*.yml",
                Multiselect = false // ����Ϊ����ѡ�񵥸��ļ�
            };
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileContent = File.ReadAllText(dialog.FileName);
                txtInput.Text = fileContent;
            }
        }
    }
}
