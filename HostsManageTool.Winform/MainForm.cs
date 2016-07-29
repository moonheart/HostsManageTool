using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HostsManageTool.Winform.Bll;
using HostsManageTool.Winform.Model;

namespace HostsManageTool.Winform
{
    public partial class MainForm : Form
    {


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
            LoadHostNameData();
            LoadHostIpData();
        }

        /// <summary>
        /// 加载主机名列表
        /// </summary>
        private void LoadHostNameData()
        {
            var list = Manager.Instance.GetAllHostNames();
            if (list != null)
            {
                lstHostName.DataSource = list;
                lstHostName.DisplayMember = "Name";
                lstHostName.ValueMember = "Id";
            }
            else
            {
                Message("加载数据出错");
            }
        }

        /// <summary>
        /// 加载Ip列表
        /// </summary>
        private void LoadHostIpData()
        {
            List<HostIp> list = Manager.Instance.GetAllHostIps();
            if (list != null)
            {
                lstIp.DataSource = list;
                lstIp.DisplayMember = "IpAddress";
                lstIp.ValueMember = "Id";
            }
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
        /// 添加主机名点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddHostName_Click(object sender, EventArgs e)
        {
            var name = txtHostNameFilter.Text.Trim();
            if (name.IsNullOrWhiteSpace())
            {
                return;
            }
            var h = new HostName();
            h.Name = name;

            try
            {
                var n = Manager.Instance.AddHostName(h);
                if (n > 0)
                {
                    LoadHostNameData();
                }
                else
                {
                    Message("添加出错");
                }
            }
            catch (Exception ex)
            {
                Message(ex.Message);
            }
        }


        /// <summary>
        /// 主机名列表选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstHostName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = lstHostName.SelectedItem as HostName;
            if (name == null)
                return;

            //var list = Manager.Instance.FindHostIpListByHostName(name);
            //if (list == null)
            //    return;

            //LoadHostIpData(list);
            var hostip = Manager.Instance.FindEnabledForHostName(name);
            if (hostip != null)
            {
                txtCurrent.Text = hostip.IpAddress;
            }
            else
            {
                txtCurrent.Text = "";
            }
        }

        /// <summary>
        /// Ip列表改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddIp_Click(object sender, EventArgs e)
        {
            var ip = txtIpFilter.Text.Trim();
            if (ip.IsNullOrWhiteSpace())
            {
                return;
            }
            if (!ip.IsIpAddress())
            {
                Message("请输入正确的Ip地址");
                return;
            }

            var hostname = lstHostName.SelectedItem as HostName;
            //if (hostname == null)
            //{
            //    Message("请选择需要指向的主机名");
            //    return;
            //}

            try
            {
                if (hostname == null)
                {
                    var hostip = Manager.Instance.AddHostIp(new HostIp() { IpAddress = ip });
                    if (hostip != null)
                    {
                        LoadHostIpData();
                    }
                    else
                    {
                        Message("添加失败");
                    }
                }
                else
                {
                    var n = Manager.Instance.AddHostIpToHostName(hostname, ip);
                    if (n > 0)
                    {
                        LoadHostNameData();
                    }
                    else
                    {
                        Message("添加指向失败");
                    }
                }
            }
            catch (Exception ex)
            {
                Message(ex.Message);
            }
        }

        private void btnClearHostName_Click(object sender, EventArgs e)
        {
            txtHostNameFilter.Clear();
        }

        private void btnClearIp_Click(object sender, EventArgs e)
        {
            txtIpFilter.Clear();
        }

        private void btnDirect_Click(object sender, EventArgs e)
        {
            var curr = txtCurrent.Text.Trim();
            if (curr.IsNullOrWhiteSpace())
            {
                //添加指向
                var hostip = lstIp.SelectedItem as HostIp;
                var hostname = lstHostName.SelectedItem as HostName;
                if (hostip != null && hostname != null)
                {
                    var n = Manager.Instance.AddHostToIp(hostname, hostip);
                    if (n > 0)
                    {
                        LoadHostNameData();
                    }
                    else
                    {
                        Message("添加失败");
                    }
                }
            }
            else
            {
                // todo 取消指向

            }
        }

        private void txtCurrent_TextChanged(object sender, EventArgs e)
        {
            var curr = txtCurrent.Text.Trim();
            if (curr.IsNullOrWhiteSpace())
            {
                btnDirect.Text = "指向选中Ip";
            }
            else
            {
                btnDirect.Text = "取消指向Ip";
            }
        }
    }
}
