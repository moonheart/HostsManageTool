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
        private List<HostName> _hostNames = new List<HostName>();
        private List<HostName> _hostNamesSerch = new List<HostName>();

        private List<HostIp> _hostIps = new List<HostIp>();
        private List<HostIp> _hostIpsSearch = new List<HostIp>();


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
        private void LoadHostNameData(int selectedvalue = 0)
        {
            var list = UserHostManager.Instance.GetAllHostNames();
            if (list != null)
            {
                _hostNames.Clear();
                _hostNames.AddRange(list);

                _hostNamesSerch.Clear();
                _hostNamesSerch.AddRange(list.OrderBy(d => d.Name));
                SetHostNameBinding(_hostNamesSerch);
                lstHostName.SelectedValue = selectedvalue;
            }
            else
            {
                Message("加载数据出错");
            }
        }

        private void SetHostNameBinding(List<HostName> list)
        {
            lstHostName.DataSource = null;
            lstHostName.ResetBindings();
            //lstHostName.DisplayMember = "Name";
            //lstHostName.ValueMember = "Id";
            lstHostName.DataSource = list;
            lstHostName.DisplayMember = "Name";
            lstHostName.ValueMember = "Id";
        }

        /// <summary>
        /// 加载Ip列表
        /// </summary>
        private void LoadHostIpData(int selectedvalue = 0)
        {
            List<HostIp> list = UserHostManager.Instance.GetAllHostIps();
            if (list != null)
            {
                _hostIps.Clear();
                _hostIps.AddRange(list);
                _hostIpsSearch.Clear();
                _hostIpsSearch.AddRange(list.OrderBy(d => d.IpAddress).ToList());
                SetHostIpBinding(_hostIpsSearch);
                lstIp.SelectedValue = selectedvalue;
            }
        }

        private void SetHostIpBinding(List<HostIp> list)
        {
            lstIp.DataSource = null;
            lstIp.ResetBindings();
            //lstIp.DisplayMember = "IpAddress";
            //lstIp.ValueMember = "Id";
            lstIp.DataSource = list;
            lstIp.DisplayMember = "IpAddress";
            lstIp.ValueMember = "Id";
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
            if (!name.IsNullOrWhiteSpace())
            {
                var h = new HostName();
                h.Name = name;

                try
                {
                    var n = UserHostManager.Instance.AddHostName(h);
                    if (n != null)
                    {
                        LoadHostNameData(n.Id);
                        txtHostNameFilter.Focus();
                        txtHostNameFilter.SelectAll();
                    }
                    else
                    {
                        Message("添加出错");
                        txtHostNameFilter.Focus();
                        txtHostNameFilter.SelectAll();
                    }
                }
                catch (Exception ex)
                {
                    Message(ex.Message);
                    txtHostNameFilter.Focus();
                    txtHostNameFilter.SelectAll();
                }
            }
            else
            {
                txtHostNameFilter.Focus();
            }
            EnableControl(sender);
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

            var hostip = UserHostManager.Instance.FindRedirectByHostName(name);
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
            if (!ip.IsNullOrWhiteSpace())
            {
                if (ip.IsIpAddress())
                {
                    var hostname = lstHostName.SelectedItem as HostName;
                    try
                    {
                        if (hostname == null)
                        {
                            var hostip = UserHostManager.Instance.AddHostIp(new HostIp() { IpAddress = ip });
                            if (hostip != null)
                            {
                                LoadHostIpData(hostip.Id);
                            }
                            else
                            {
                                Message("添加失败");
                            }
                        }
                        else
                        {
                            var n = UserHostManager.Instance.AddHostIpToHostName(hostname, ip);
                            if (n > 0)
                            {
                                LoadHostNameData(hostname.Id);
                                var iip = UserHostManager.Instance.FindRedirectByHostName(hostname);
                                LoadHostIpData(iip.Id);
                            }
                            else
                            {
                                Message("添加指向失败");
                            }
                        }
                    }
                    catch (ItemNotFoundException ex)
                    {
                        Message(ex.Message);
                    }
                    catch (ItemOperationFaildException ex)
                    {
                        Message(ex.Message);
                    }
                }
                else
                {
                    Message("请输入正确的Ip地址");
                    txtIpFilter.Focus();
                    txtIpFilter.SelectAll();
                }
            }
            else
            {
                txtIpFilter.Focus();
            }
            EnableControl(sender);
        }

        private void btnClearHostName_Click(object sender, EventArgs e)
        {
            txtHostNameFilter.Clear();
            txtHostNameFilter.Focus();
            EnableControl(sender);
        }

        private void btnClearIp_Click(object sender, EventArgs e)
        {
            txtIpFilter.Clear();
            txtIpFilter.Focus();
            EnableControl(sender);
        }

        private void btnDirect_Click(object sender, EventArgs e)
        {
            var curr = txtCurrent.Text.Trim();
            if (curr.IsNullOrWhiteSpace())
            {
                //添加指向
                var hostip = lstIp.SelectedItem as HostIp;
                var hostname = lstHostName.SelectedItem as HostName;
                if (hostname == null)
                {
                    Message("请选择主机名");
                }
                else if (hostip == null)
                {
                    Message("请选择Ip");
                }
                else
                {
                    var n = UserHostManager.Instance.AddHostDirect(hostname, hostip);
                    if (n > 0)
                    {
                        LoadHostNameData(hostname.Id);
                    }
                    else
                    {
                        Message("添加失败");
                    }
                }
            }
            else
            {
                // 取消指向
                var hostname = lstHostName.SelectedItem as HostName;
                if (hostname != null)
                {
                    UserHostManager.Instance.RemoveHostDirect(hostname);
                    LoadHostNameData(hostname.Id);
                }
                else
                {
                    Message("取消失败");
                }
            }
            EnableControl(sender);
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
            EnableControl(sender);
        }

        private void EnableControl(object s)
        {
            var sender = s as Control;
            if (sender != null) sender.Enabled = true;
        }

        private void btnDeleteHostName_Click(object sender, EventArgs e)
        {
            var hostname = lstHostName.SelectedItem as HostName;
            if (hostname != null)
            {
                var n = UserHostManager.Instance.RemoveHostName(hostname);
                if (n == 0)
                {
                    Message("移除失败");
                }
                else
                {
                    LoadHostNameData();
                }
            }
            EnableControl(sender);
        }

        private void btnDeleteIp_Click(object sender, EventArgs e)
        {

            EnableControl(sender);
        }

        private void txtHostNameFilter_TextChanged(object sender, EventArgs e)
        {
            var txt = txtHostNameFilter.Text.Trim();
            _hostNamesSerch.Clear();
            if (txt.IsNullOrWhiteSpace())
            {
                _hostNamesSerch.AddRange(_hostNames.OrderBy(d => d.Name));
            }
            else
            {
                _hostNamesSerch.AddRange(_hostNames.Where(d => d.Name.Contains(txt)));
            }
            SetHostNameBinding(_hostNamesSerch);

        }

        private void txtIpFilter_TextChanged(object sender, EventArgs e)
        {
            var txt = txtIpFilter.Text.Trim();
            _hostIpsSearch.Clear();
            if (txt.IsNullOrWhiteSpace())
            {
                _hostIpsSearch.AddRange(_hostIps.OrderBy(d => d.IpAddress));
            }
            else
            {
                _hostIpsSearch.AddRange(_hostIps.Where(d => d.IpAddress.Contains(txt)));
            }
            SetHostIpBinding(_hostIpsSearch);
        }

        private void txtIpFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
