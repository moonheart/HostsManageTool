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

        /// <summary>
        /// 取消点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
            EnableControl(sender);
        }

        /// <summary>
        /// 启用控件
        /// </summary>
        /// <param name="s"></param>
        private void EnableControl(object s)
        {
            ExtentionClass.EnableControl(s);
        }

        /// <summary>
        /// 确认点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (Source == null)
                    Source = new HostsSource();

                var r = new Uri(txtUrl.Text);
                Source.Url = r.ToString();
                Source.Name = txtName.Text.Trim();
                DialogResult = DialogResult.OK;
                Close();
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

        /// <summary>
        /// 数据加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
