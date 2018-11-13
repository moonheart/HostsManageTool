using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
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

        //private List<Host> _hosts;
        //private List<Ip> _ips;

        /// <summary>
        /// 加载初始数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadAllData();
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
        /// <param name="select">要选中的项Id</param>
        private void LoadHostData(string select = null)
        {
            if (select == null) select = lstHostName.SelectedValue as string;
            SetHostBinding(_db.Hosts.ToList());
            if (select != null)
                lstHostName.SelectedValue = select;
        }

        /// <summary>
        /// 加载Ip列表
        /// <param name="select">要选中的项Id</param>
        /// </summary>
        private void LoadHostIpData(string select = null)
        {
            if (select == null) select = lstIp.SelectedValue as string;
            SetIpBinding(_db.Ips.ToList());
            if (select != null)
                lstIp.SelectedValue = select;
        }

        #endregion

        #region 列表绑定

        /// 设置主机名列表绑定
        private void SetHostBinding(IList<Host> list)
        {
            lstHostName.DataSource = null;
            lstHostName.ResetBindings();
            lstHostName.DataSource = list.OrderBy(d => d.HostName).ToList();
            lstHostName.DisplayMember = nameof(Host.HostName);
            lstHostName.ValueMember = nameof(Host.HostName);
        }

        /// Ip列表
        private void SetIpBinding(IList<Ip> list)
        {
            lstIp.DataSource = null;
            lstIp.ResetBindings();
            lstIp.DataSource = list.OrderBy(d => d.IpAddress).ToList();
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
                        btnDeleteHostName_Click();
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
                        btnAddHostName_Click();
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
        private void btnAddHostName_Click(object sender = null, EventArgs e = null)
        {
            var name = txtHostNameFilter.Text.Trim();
            if (!name.IsNullOrWhiteSpace())
            {
                var host = _db.Hosts.Create<Host>();
                host.HostName = name;
                _db.Hosts.Add(host);
                _db.SaveChanges();
                LoadHostData(name);
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

            var ip = host.TargetIp;
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
                ? _db.Hosts
                : _db.Hosts.Where(d => d.HostName.Contains(txt));
            SetHostBinding(filterd.ToList());

            lstHostName.SelectedIndex = filterd.Any() ? 0 : -1;
        }

        /// <summary>
        /// 删除主机名点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteHostName_Click(object sender = null, EventArgs e = null)
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
        private void btnAddIp_Click(object sender = null, EventArgs e = null)
        {
            var address = txtIpFilter.Text.Trim();
            if (!address.IsNullOrWhiteSpace())
            {
                if (address.IsIpAddress())
                {
                    var ip = _db.Ips.Create<Ip>();
                    ip.IpAddress = address;
                    var host = lstHostName.SelectedItem as Host;
                    if (host == null)
                    {
                        _db.Ips.Add(ip);
                        _db.SaveChanges();
                    }
                    else
                    {
                        host.TargetIp = ip;
                        _db.SaveChanges();
                    }
                    LoadAllData();
                    btnApplyToHosts_Click();
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
                    host.TargetIp = ip;
                    _db.SaveChanges();
                    LoadAllData();
                    if (chkAutoApply.Checked)
                        btnApplyToHosts_Click();
                }
            }
            else
            {
                // 取消指向
                var host = lstHostName.SelectedItem as Host;
                if (host != null)
                {
                    host.TargetIp = null;
                    _db.SaveChanges();
                    LoadAllData();
                    if (chkAutoApply.Checked)
                        btnApplyToHosts_Click();
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
        private void btnDeleteIp_Click(object sender = null, EventArgs e = null)
        {
            var ip = lstIp.SelectedItem as Ip;
            if (ip != null)
            {
                if (MessageBox.Show(Resources.DeleteConfirmMessage,
                    Resources.DeleteConfirmMessageTitle,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _db.Ips.Remove(ip);
                    _db.SaveChanges();
                    btnApplyToHosts_Click();
                    LoadAllData();
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
                ? _db.Ips
                : _db.Ips.Where(d => d.IpAddress.Contains(txt));
            SetIpBinding(filterd.ToList());

            lstIp.SelectedIndex = filterd.Any() ? 0 : -1;
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
                        btnDeleteIp_Click();
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
                        btnAddIp_Click();
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
        private void btnApplyToHosts_Click(object sender = null, EventArgs e = null)
        {
            var windows = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            var hostsFile = Path.Combine(windows, @"system32\drivers\etc\hosts2");

            var hosts = _db.Hosts.ToList();
            var lines = hosts.Where(d => d.TargetIp != null)
                .Select(d => $"{d.TargetIp.IpAddress}\t{d.HostName}");

            LblApplyMsgMessage("写入Hosts文件...");
            File.WriteAllLines(hostsFile, lines);

            LblApplyMsgMessage("刷新dns缓存...");
            var startInfo = new ProcessStartInfo("ipconfig", " /flushdns");
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            Process.Start(startInfo);

            LblApplyMsgMessage("完成...");

            EnableControl(sender);

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
            //Environment.Exit(0);
        }

        /// <summary>
        /// 导入hosts文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_importHostsFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                    @"system32\drivers\etc\")
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var lines = File.ReadAllLines(dialog.FileName)
                    .Select(d => d.Trim())
                    .Where(d => !d.StartsWith("#"))
                    .Select(d => d.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                    .Where(d => d.Length == 2);
                var hosts = _db.Hosts.ToList();
                var ips = _db.Ips.ToList();
                foreach (var line in lines)
                {
                    var ipStr = line[0];
                    var hostStr = line[1];
                    if (!ipStr.IsIpAddress()) continue;
                    var host = hosts.FirstOrDefault(d => d.HostName == hostStr);
                    var ip = ips.FirstOrDefault(d => d.IpAddress == ipStr);
                    if (ip == null)
                    {
                        ip = _db.Ips.Create();
                        ip.IpAddress = ipStr;
                        ips.Add(ip);
                    }

                    if (host != null)
                    {
                        host.TargetIp = ip;
                    }
                    else
                    {
                        host = _db.Hosts.Create();
                        host.HostName = hostStr;
                        host.TargetIp = ip;
                        _db.Hosts.Add(host);
                        hosts.Add(host);
                    }
                }
                _db.SaveChanges();
                LoadAllData();
            }

            EnableControl(sender);
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            LoadAllData();
            EnableControl(sender);
        }
    }
}
