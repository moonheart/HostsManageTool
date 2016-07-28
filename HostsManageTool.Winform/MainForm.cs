using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostsManageTool.Winform
{
    public partial class MainForm : Form
    {
        private List<UserHosts> UserHostsList;


        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载初始数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            UserHostsList = UserHostsManager.GetAllHosts();
            if (UserHostsList != null)
            {
                if (UserHostsList.Count > 0)
                {
                    var list = UserHostsList.GroupBy((hosts => hosts.HostsName)).Select(d => new { d.Key }).ToList();
                }
            }
            else
            {
                Message("加载数据出错");
            }
        }

        private void Message(string message)
        {
            MessageBox.Show(message);
        }

        private void btnAddHostName_Click(object sender, EventArgs e)
        {
            var name = txtHostNameFilter.Text.Trim();
            if (name.IsNullOrWhiteSpace())
            {
                return;
            }
            var h = new UserHosts();
            h.HostsName = name;

            var n = UserHostsManager.InsertUserHosts(h);
            if (n > 0)
            {
                LoadData();
            }
            else
            {
                Message("添加出错");
            }
        }
    }
}
