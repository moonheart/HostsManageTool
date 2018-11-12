using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using HostsManageTool.Nirvana.Models;
using HostsManageTool.Nirvana.Properties;

namespace HostsManageTool.Nirvana
{
    public partial class MainForm : Form
    {
        private DataContext _db = new DataContext();

        public MainForm()
        {
            InitializeComponent();
        }

        private List<Host> _hosts;
        private List<Ip> _ips;

        /// <summary>
        /// 加载初始数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadHostData();
                LoadHostIpData();
            }
            catch (Exception ex)
            {
                Message(ex.Message);
                Message(ex.StackTrace);
                Application.Exit();
            }
        }

        #region 列表加载

        private void LoadAllData()
        {
            LoadHostData();
            LoadHostIpData();
        }

        /// <summary>
        /// 加载主机名列表
        /// </summary>
        /// <param name="selectedvalue">要选中的项Id</param>
        private void LoadHostData(string select = null)
        {
            var list = _hosts = _db.Hosts.ToList();
            SetHostBinding(list);
            if (select != null)
                lstHostName.SelectedValue = select;
        }

        /// <summary>
        /// 加载Ip列表
        /// <param name="selectedvalue">要选中的项Id</param>
        /// </summary>
        private void LoadHostIpData(string select = null)
        {
            var list = _ips = _db.Ips.ToList();
            SetIpBinding(list);
            if (select != null)
                lstIp.SelectedValue = select;
        }

        #endregion

        #region 列表绑定

        /// 设置主机名列表绑定
        private void SetHostBinding(List<Host> list)
        {
            lstHostName.DataSource = null;
            lstHostName.ResetBindings();
            lstHostName.DataSource = list;
            lstHostName.DisplayMember = nameof(Host.HostName);
            lstHostName.ValueMember = nameof(Host.HostName);
        }

        /// Ip列表
        private void SetIpBinding(List<Ip> list)
        {
            lstIp.DataSource = null;
            lstIp.ResetBindings();
            lstIp.DataSource = list;
            lstIp.DisplayMember = nameof(Ip.IpAddress);
            lstIp.ValueMember = nameof(Ip.IpAddress);
        }

        #endregion

        #region 公用操作
        /// <summary>
        /// 启用控件
        /// </summary>
        /// <param name="s"></param>
        private void EnableControl(object s)
        {
            var sender = s as Control;
            if (sender != null)
            {
                if (sender.InvokeRequired)
                {
                    sender.Invoke(new MethodInvoker(() =>
                    {
                        sender.Enabled = true;
                    }));
                }
                else
                {
                    sender.Enabled = true;
                }
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

        #endregion

        #region 主机名操作
        /// <summary>
        /// 主机名列表快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstHostName_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control && !e.Alt && !e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        btnDeleteHostName_Click(null, null);
                        e.Handled = true;
                        break;

                }
            }
        }

        /// <summary>
        /// 主机名快速过滤快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHostNameFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control && !e.Alt && !e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        btnAddHostName_Click(null, null);
                        e.Handled = true;
                        break;

                }
            }
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
                var host = new Host { HostName = name };

                try
                {
                    _db.Hosts.Add(host);
                    _db.SaveChanges();
                    LoadHostData(name);
                }
                catch (Exception ex)
                {
                    Message(ex.Message);
                }
                txtHostNameFilter.Focus();
                txtHostNameFilter.SelectAll();

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
            var host = lstHostName.SelectedItem as Host;
            if (host == null)
                return;

            //host = _db.Hosts.Attach(host);

            var ip = host.Ips?.FirstOrDefault();
            txtCurrent.Text = ip != null ? ip.IpAddress : "";
        }

        /// <summary>
        /// 主机名清除按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearHostName_Click(object sender, EventArgs e)
        {
            txtHostNameFilter.Clear();
            txtHostNameFilter.Focus();
            EnableControl(sender);
        }

        /// <summary>
        /// 主机名列表快速过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHostNameFilter_TextChanged(object sender, EventArgs e)
        {
            var txt = txtHostNameFilter.Text.Trim();

            var filterd = txt.IsNullOrWhiteSpace()
                ? _hosts
                : _hosts.Where(d => d.HostName.Contains(txt)).ToList();
            SetHostBinding(filterd);

            lstHostName.SelectedIndex = filterd.Count > 0 ? 0 : -1;
        }

        /// <summary>
        /// 删除主机名点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteHostName_Click(object sender, EventArgs e)
        {
            var host = lstHostName.SelectedItem as Host;
            if (host != null)
            {
                if (MessageBox.Show(
                    Resources.DeleteConfirmMessage,
                    Resources.DeleteConfirmMessageTitle,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _db.Hosts.Remove(host);
                    _db.SaveChanges();
                    LoadHostData();
                }
            }
            EnableControl(sender);
        }

        #endregion

        #region Ip列表操作
        /// <summary>
        /// 添加Ip点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddIp_Click(object sender, EventArgs e)
        {
            var address = txtIpFilter.Text.Trim();
            if (!address.IsNullOrWhiteSpace())
            {
                if (address.IsIpAddress())
                {
                    var ip = new Ip() { IpAddress = address };
                    var host = lstHostName.SelectedItem as Host;
                    if (host == null)
                    {
                        _db.Ips.Add(ip);
                        _db.SaveChanges();
                    }
                    else
                    {
                        host.Ips.Clear();
                        host.Ips.Add(ip);
                        _db.SaveChanges();
                    }
                    LoadAllData();
                    btnApplyToHosts_Click(null, null);
                }
                else
                {
                    Message("请输入正确的Ip地址");
                }
            }

            txtIpFilter.Focus();
            txtIpFilter.SelectAll();
            EnableControl(sender);
        }


        /// <summary>
        /// Ip清除按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearIp_Click(object sender, EventArgs e)
        {
            txtIpFilter.Clear();
            txtIpFilter.Focus();
            EnableControl(sender);
        }

        /// <summary>
        /// 指向按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDirect_Click(object sender, EventArgs e)
        {
            var curr = txtCurrent.Text.Trim();
            if (curr.IsNullOrWhiteSpace())
            {
                //添加指向
                var ip = lstIp.SelectedItem as Ip;
                var host = lstHostName.SelectedItem as Host;
                if (host == null)
                {
                    Message("请选择主机名");
                }
                else if (ip == null)
                {
                    Message("请选择Ip");
                }
                else
                {
                    host.Ips.Clear();
                    host.Ips.Add(ip);
                    _db.SaveChanges();
                    LoadAllData();
                    if (chkAutoApply.Checked)
                        btnApplyToHosts_Click(null, null);
                }
            }
            else
            {
                // 取消指向
                var host = lstHostName.SelectedItem as Host;
                if (host != null)
                {
                    host.Ips.Clear();
                    _db.SaveChanges();
                    LoadAllData();
                    if (chkAutoApply.Checked)
                        btnApplyToHosts_Click(null, null);
                }
                else
                {
                    Message("取消的对象不存在");
                }
            }
            EnableControl(sender);
        }

        /// <summary>
        /// 删除Ip点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteIp_Click(object sender, EventArgs e)
        {
            var ip = lstIp.SelectedItem as Ip;
            if (ip != null)
            {
                if (MessageBox.Show(Resources.DeleteConfirmMessage,
                    Resources.DeleteConfirmMessageTitle,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        _db.Ips.Remove(ip);
                        _db.SaveChanges();
                        LoadAllData();
                    }
                    catch
                    {
                        Message("要删除的对象不存在");
                    }
                }
            }
            EnableControl(sender);
        }

        /// <summary>
        /// Ip列表快速过滤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtIpFilter_TextChanged(object sender, EventArgs e)
        {
            var txt = txtIpFilter.Text.Trim();

            var filterd = txt.IsNullOrWhiteSpace()
                ? _ips
                : _ips.Where(d => d.IpAddress.Contains(txt)).ToList();
            SetIpBinding(filterd);

            lstIp.SelectedIndex = filterd.Count > 0 ? 0 : -1;
        }

        /// <summary>
        /// Ip快速过滤输入限制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtIpFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// ip列表快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstIp_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control && !e.Alt && !e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        btnDeleteIp_Click(null, null);
                        e.Handled = true;
                        break;

                }
            }
        }

        /// <summary>
        /// Ip快速过滤快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtIpFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control && !e.Alt && !e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        btnAddIp_Click(null, null);
                        e.Handled = true;
                        break;

                }
            }
        }

        /// <summary>
        /// 当前指向文本改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCurrent_TextChanged(object sender, EventArgs e)
        {
            var curr = txtCurrent.Text.Trim();
            btnDirect.Text = curr.IsNullOrWhiteSpace() ? "指向选中Ip" : "取消指向Ip";
            EnableControl(sender);
        }

        #endregion


        #region 应用hosts文件操作

        /// <summary>
        /// 应用hosts文件点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApplyToHosts_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                {

                    if (File.Exists(@"C:\windows\system32\drivers\etc\hosts"))
                    {
                        File.Delete(@"C:\windows\system32\drivers\etc\hosts");
                    }

                    var lines = _hosts.Where(d => d.Ips.Any()).Select(d => $"{d.Ips.First().IpAddress}\t{d.HostName}");

                    LblApplyMsgMessage("创建新的Hosts文件...");
                    File.WriteAllLines(@"C:\windows\system32\drivers\etc\hosts", lines);

                    LblApplyMsgMessage("完成...");
                }

                EnableControl(sender);
            })
            { IsBackground = true }
            .Start();
        }

        /// <summary>
        /// 应用hosts消息
        /// </summary>
        /// <param name="msg"></param>
        private void LblApplyMsgMessage(string msg)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new MethodInvoker(() =>
                {
                    txtLog.AppendText(msg + "\r\n");
                }));
            }
        }


        #endregion

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _db.Dispose();
            Environment.Exit(0);

        }
    }
}
