using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using HostsManageTool.Winform.Bll;
using HostsManageTool.Winform.Model;
using HostsManageTool.Winform.Properties;

namespace HostsManageTool.Winform
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 主机名列表
        /// </summary>
        private readonly List<HostName> _hostNames = new List<HostName>();
        private readonly List<HostName> _hostNamesSerch = new List<HostName>();

        /// <summary>
        /// Ip列表
        /// </summary>
        private readonly List<HostIp> _hostIps = new List<HostIp>();
        private readonly List<HostIp> _hostIpsSearch = new List<HostIp>();

        /// <summary>
        /// hosts源列表
        /// </summary>
        private readonly List<HostsSource> _hostsSources = new List<HostsSource>();


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
            try
            {
                LoadHostNameData();
                LoadHostIpData();
                LoadHostSource();
            }
            catch (Exception ex)
            {
                Message(ex.Message);
                Message(ex.StackTrace);
                Application.Exit();
            }
        }

        #region 列表加载

        /// <summary>
        /// 加载hosts源列表
        /// </summary>
        /// <param name="selectedvalue">要选中的项Id</param>
        private void LoadHostSource(int selectedvalue = 0)
        {
            var list = HostsSourceManager.Instance.GetAllHostsSource();
            if (list != null)
            {

                _hostsSources.Clear();
                _hostsSources.AddRange(list.OrderBy(d => d.Id));
                SetSourceBinding(_hostsSources);
                lstSource.SelectedValue = selectedvalue;
            }
            else
            {
                Message("加载数据出错");
            }
        }

        /// <summary>
        /// 加载主机名列表
        /// </summary>
        /// <param name="selectedvalue">要选中的项Id</param>
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

        /// <summary>
        /// 加载Ip列表
        /// <param name="selectedvalue">要选中的项Id</param>
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

        #endregion

        #region 列表绑定

        /// <summary>
        /// 设置hosts源列表绑定
        /// </summary>
        /// <param name="list"></param>
        private void SetSourceBinding(List<HostsSource> list)
        {
            lstSource.DataSource = null;
            lstSource.ResetBindings();
            lstSource.DataSource = list;
            lstSource.DisplayMember = "Display";
            lstSource.ValueMember = "Id";
        }

        /// 设置主机名列表绑定
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

        /// 设置Ip列表绑定
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

        #endregion

        #region 公用操作
        /// <summary>
        /// 启用控件
        /// </summary>
        /// <param name="s"></param>
        private void EnableControl(object s)
        {
            ExtentionClass.EnableControl(s);
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
                var h = new HostName {Name = name};

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
            txtCurrent.Text = hostip != null ? hostip.IpAddress : "";
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
            _hostNamesSerch.Clear();
            _hostNamesSerch.AddRange(txt.IsNullOrWhiteSpace()
                ? _hostNames.OrderBy(d => d.Name)
                : _hostNames.Where(d => d.Name.Contains(txt)));
            SetHostNameBinding(_hostNamesSerch);
            lstHostName.SelectedIndex = _hostNamesSerch.Count > 0 ? 0 : -1;

        }

        /// <summary>
        /// 删除主机名点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteHostName_Click(object sender, EventArgs e)
        {
            var hostname = lstHostName.SelectedItem as HostName;
            if (hostname != null)
            {
                if (MessageBox.Show(Resources.DeleteConfirmMessage, Resources.DeleteConfirmMessageTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                    DialogResult.OK)
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
            }
            EnableControl(sender);
        }

        #endregion

        #region Ip列表操作
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
                }
            }
            else
            {
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
                    var n = UserHostManager.Instance.RemoveHostDirect(hostname);
                    if (n > 0)
                    {
                        LoadHostNameData(hostname.Id);
                    }
                    else
                    {
                        Message("取消失败");
                    }
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
            var ip = lstIp.SelectedItem as HostIp;
            if (ip != null)
            {
                if (MessageBox.Show(Resources.DeleteConfirmMessage, Resources.DeleteConfirmMessageTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                    DialogResult.OK)
                {
                    try
                    {
                        var n = UserHostManager.Instance.RemoveHostIp(ip.Id);
                        if (n <= 0)
                        {
                            Message("删除失败");
                        }
                        else
                        {
                            LoadHostNameData();
                            LoadHostIpData();
                        }
                    }
                    catch (ItemNotFoundException)
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
            _hostIpsSearch.Clear();
            _hostIpsSearch.AddRange(txt.IsNullOrWhiteSpace()
                ? _hostIps.OrderBy(d => d.IpAddress)
                : _hostIps.Where(d => d.IpAddress.Contains(txt)));
            SetHostIpBinding(_hostIpsSearch);
            lstIp.SelectedIndex = _hostIpsSearch.Count > 0 ? 0 : -1;
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

        #region hosts源操作

        /// <summary>
        /// hosts源列表双击编辑 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSource_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lstSource.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                btnEditSource_Click(null, null);
            }
        }


        /// <summary>
        /// 添加hosts源点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSource_Click(object sender, EventArgs e)
        {
            var form = new SourceEditForm();
            form.Text = @"添加Hosts源";
            var re = form.ShowDialog();
            switch (re)
            {
                case DialogResult.OK:
                    try
                    {
                        var source = form.Source;
                        var n = HostsSourceManager.Instance.AddHostSource(source);
                        if (n != null)
                        {
                            LoadHostSource(n.Id);
                        }
                        else
                        {
                            Message("添加失败");
                        }
                    }
                    catch (ItemAlreadyExitedException)
                    {
                        Message("相同Url的已存在");
                    }
                    catch (ItemOperationFaildException)
                    {
                        Message("添加失败");
                    }
                    break;
                case DialogResult.Cancel:

                    break;
            }
            lstSource.Focus();
            EnableControl(sender);
        }

        /// <summary>
        /// 删除hosts源点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteSource_Click(object sender, EventArgs e)
        {
            var source = lstSource.SelectedItem as HostsSource;
            if (source != null)
            {
                if (MessageBox.Show(Resources.DeleteConfirmMessage, Resources.DeleteConfirmMessageTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                    DialogResult.OK)
                {
                    try
                    {
                        var n = HostsSourceManager.Instance.DeleteHostsSource(source.Id);
                        if (n > 0)
                        {
                            LoadHostSource();
                        }
                    }
                    catch (ItemNotFoundException)
                    {
                        Message("要删除的项目不存在");
                    }
                }
                lstSource.Focus();
            }
            EnableControl(sender);
        }

        /// <summary>
        /// 编辑hosts源点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditSource_Click(object sender, EventArgs e)
        {
            var source = lstSource.SelectedItem as HostsSource;
            if (source != null)
            {
                var form = new SourceEditForm
                {
                    Source = source,
                    Text = @"添加Hosts源"
                };
                var re = form.ShowDialog();
                switch (re)
                {
                    case DialogResult.OK:
                        try
                        {
                            //source = form.Source;
                            var n = HostsSourceManager.Instance.UpdateHostsSource(source);
                            if (n > 0)
                            {
                                LoadHostSource(source.Id);
                            }
                            else
                            {
                                Message("修改失败");
                            }
                        }
                        catch (ItemNotFoundException)
                        {
                            Message("找不到要修改的对象");
                        }
                        break;
                    case DialogResult.Cancel:

                        break;
                }
            }
            lstSource.Focus();
            EnableControl(sender);
        }

        /// <summary>
        /// 禁用hosts源点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisableEnable_Click(object sender, EventArgs e)
        {
            var s = lstSource.SelectedItem as HostsSource;
            if (s != null)
            {
                try
                {
                    var n = HostsSourceManager.Instance.DisbaleEnable(s.Id);
                    if (n > 0)
                    {
                        LoadHostSource(s.Id);
                    }
                }
                catch (ItemNotFoundException)
                {
                    Message("找不到要操作的项");
                }
            }
            EnableControl(sender);
        }

        /// <summary>
        /// hosts源列表选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = lstSource.SelectedItem as HostsSource;
            if (s != null)
            {
                btnDisableEnable.Text = s.IsEnabled == 1 ? "禁用" : "启用";
            }
        }

        /// <summary>
        /// hosts源列表上移下移
        /// </summary>
        /// <param name="pos"></param>
        private void ChangeSequence(int pos)
        {
            var sourceNow = lstSource.SelectedItem as HostsSource;
            if (sourceNow != null)
            {
                var nowindex = _hostsSources.IndexOf(sourceNow);
                HostsSource alter = null;
                if (nowindex + pos >= 0 && nowindex + pos < _hostsSources.Count)
                {
                    alter = _hostsSources[nowindex + pos];
                }
                try
                {
                    if (alter != null)
                    {
                        var n = HostsSourceManager.Instance.ChangeSequence(sourceNow.Id, alter.Id);
                        if (n > 0)
                        {
                            LoadHostSource(alter.Id);
                        }
                        else
                        {
                            Message("操作失败");
                        }
                    }
                }
                catch (ItemNotFoundException)
                {
                    Message("要操作的对象不存在");
                }
            }
        }

        /// <summary>
        /// hosts源列表上移点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpSource_Click(object sender, EventArgs e)
        {
            ChangeSequence(-1);
            EnableControl(sender);
        }

        /// <summary>
        /// hosts源列表下移点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownSource_Click(object sender, EventArgs e)
        {
            ChangeSequence(1);
            EnableControl(sender);
        }

        /// <summary>
        /// hosts源列表快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSource_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control && !e.Alt && !e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        btnEditSource_Click(null, null);
                        e.Handled = true;
                        break;
                    case Keys.Delete:
                        btnDeleteSource_Click(null, null);
                        e.Handled = true;
                        break;

                }
            }
            if (e.KeyData == (Keys.Alt | Keys.Up))
            {
                btnUpSource_Click(null, null);
                e.Handled = true;
            }
            else if (e.KeyData == (Keys.Alt | Keys.Down))
            {
                btnDownSource_Click(null, null);
                e.Handled = true;
            }
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
                try
                {
                    LblApplyMsgMessage("获取用户hosts配置...");
                    var dicUser = UserHostManager.Instance.GetUserDictionary();

                    LblApplyMsgMessage("下载远程hosts配置...");
                    var dicRemote = HostsSourceManager.Instance.GetRemoteDictionary();

                    LblApplyMsgMessage("缓存远程hosts配置...");

                    HostsSourceManager.Instance.WriteRemoteDicBak(dicRemote);
                    //File.WriteAllLines(
                    //    ExtentionClass.ApplicationPath + "remoteback.txt",
                    //    dicRemote.Select(pair => $"{pair.Value}\t{pair.Key}"));

                    LblApplyMsgMessage("混合hosts配置...");
                    foreach (KeyValuePair<string, string> pair in dicRemote)
                    {
                        if (!dicUser.ContainsKey(pair.Key))
                            dicUser.Add(pair.Key, pair.Value);
                    }
                    dicUser.Remove("localhost");
                    dicUser.Remove("broadcasthost");
                    var listDefault = new List<string>()
                    {
                        "127.0.0.1\tlocalhost",
                        "255.255.255.255\tbroadcasthost",
                        "::1\tlocalhost",
                        "fe80::1%lo0\tlocalhost"
                    };
                    listDefault.AddRange(dicUser.Select(pair => $"{pair.Value}\t{pair.Key}"));

                    LblApplyMsgMessage("备份Hosts文件...");

                    File.Copy(@"C:\windows\system32\drivers\etc\hosts", ExtentionClass.ApplicationPath + "hosts_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".bak");
                    File.Delete(@"C:\windows\system32\drivers\etc\hosts");
                    LblApplyMsgMessage("创建新的Hosts文件...");
                    File.AppendAllLines(@"C:\windows\system32\drivers\etc\hosts", listDefault);

                    LblApplyMsgMessage("完成...");
                }
                catch (HostSourceFalseException ex)
                {
                    Message("下载Hosts时失败：" + ex.RequestUrl + "  " + ex.Message);
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

        /// <summary>
        /// 应用hosts文件（仅用户）点击
        /// </summary>
        private void btnApplyOnlyUser_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                try
                {
                    LblApplyMsgMessage("获取用户hosts配置...");
                    var dicUser = UserHostManager.Instance.GetUserDictionary();

                    LblApplyMsgMessage("读取远程hosts配置缓存...");
                    var dicRemote = HostsSourceManager.Instance.ReadRemoteDicBak();

                    LblApplyMsgMessage("混合hosts配置...");
                    foreach (KeyValuePair<string, string> pair in dicRemote ?? new Dictionary<string, string>())
                    {
                        if (!dicUser.ContainsKey(pair.Key))
                            dicUser.Add(pair.Key, pair.Value);
                    }
                    dicUser.Remove("localhost");
                    dicUser.Remove("broadcasthost");
                    var listDefault = new List<string>()
                    {
                        "127.0.0.1\tlocalhost",
                        "255.255.255.255\tbroadcasthost",
                        "::1\tlocalhost",
                        "fe80::1%lo0\tlocalhost"
                    };
                    listDefault.AddRange(dicUser.Select(pair => $"{pair.Value}\t{pair.Key}"));

                    LblApplyMsgMessage("备份Hosts文件...");

                    File.Copy(@"C:\windows\system32\drivers\etc\hosts", ExtentionClass.ApplicationPath + "hosts_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".bak");
                    File.Delete(@"C:\windows\system32\drivers\etc\hosts");
                    LblApplyMsgMessage("创建新的Hosts文件...");
                    File.AppendAllLines(@"C:\windows\system32\drivers\etc\hosts", listDefault);

                    LblApplyMsgMessage("完成...");
                }
                catch (HostSourceFalseException ex)
                {
                    Message("下载Hosts时失败：" + ex.RequestUrl + "  " + ex.Message);
                }

                EnableControl(sender);
            })
            { IsBackground = true }
            .Start();
        }

        #endregion

    }
}
