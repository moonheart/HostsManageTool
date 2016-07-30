using System;
using System.Windows.Forms;
using HostsManageTool.Winform.Model;

namespace HostsManageTool.Winform
{
    public partial class SourceEditForm : Form
    {
        public HostsSource Source;

        public SourceEditForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            EnableControl(sender);
        }

        private void EnableControl(object s)
        {
            ExtentionClass.EnableControl(s);
        }

        private void btnConfirm_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (Source == null)
                    Source = new HostsSource();

                var r = new Uri(txtUrl.Text);
                Source.Url = r.ToString();
                Source.Name = txtName.Text.Trim();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (UriFormatException)
            {
                Message("Url格式不正确");
            }
            EnableControl(sender);
        }


        /// <summary>
        /// 弹出消息框
        /// </summary>
        /// <param name="message"></param>
        private void Message(string message)
        {
            MessageBox.Show(message);
        }

        private void SourceEditForm_Load(object sender, EventArgs e)
        {
            if (Source != null)
            {
                txtName.Text = Source.Name;
                txtUrl.Text = Source.Url;
            }
        }
    }
}
