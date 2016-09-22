namespace HostsManageTool.Winform
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lstHostName = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstIp = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lstSource = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLog = new HostsManageTool.Winform.UserControl.TextBoxEx();
            this.btnApplyOnlyUser = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnApplyToHosts = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnUpSource = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnDownSource = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnDisableEnable = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnEditSource = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnDeleteSource = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnAddSource = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnDirect = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.txtCurrent = new HostsManageTool.Winform.UserControl.TextBoxEx();
            this.btnDeleteIp = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnAddIp = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnDeleteHostName = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnClearIp = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnClearHostName = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnAddHostName = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.txtIpFilter = new HostsManageTool.Winform.UserControl.TextBoxEx();
            this.txtHostNameFilter = new HostsManageTool.Winform.UserControl.TextBoxEx();
            this.chkAutoApply = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lstHostName
            // 
            this.lstHostName.FormattingEnabled = true;
            this.lstHostName.ItemHeight = 12;
            this.lstHostName.Location = new System.Drawing.Point(12, 84);
            this.lstHostName.Name = "lstHostName";
            this.lstHostName.Size = new System.Drawing.Size(211, 364);
            this.lstHostName.TabIndex = 0;
            this.lstHostName.SelectedIndexChanged += new System.EventHandler(this.lstHostName_SelectedIndexChanged);
            this.lstHostName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstHostName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "主机名列表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "输入主机名快速过滤，回车键添加：";
            // 
            // lstIp
            // 
            this.lstIp.FormattingEnabled = true;
            this.lstIp.ItemHeight = 12;
            this.lstIp.Location = new System.Drawing.Point(272, 132);
            this.lstIp.Name = "lstIp";
            this.lstIp.Size = new System.Drawing.Size(152, 316);
            this.lstIp.TabIndex = 0;
            this.lstIp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstIp_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(270, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "指向Ip列表";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "输入Ip快速过滤，回车键添加：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "当前主机指向：";
            // 
            // lstSource
            // 
            this.lstSource.FormattingEnabled = true;
            this.lstSource.ItemHeight = 12;
            this.lstSource.Location = new System.Drawing.Point(495, 72);
            this.lstSource.Name = "lstSource";
            this.lstSource.Size = new System.Drawing.Size(270, 136);
            this.lstSource.TabIndex = 8;
            this.lstSource.SelectedIndexChanged += new System.EventHandler(this.lstSource_SelectedIndexChanged);
            this.lstSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSource_KeyDown);
            this.lstSource.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstSource_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(491, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Hosts远程源列表";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(493, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(275, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "*不同的源有相同域名指向时，排在前面的优先级高";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 459);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "在列表中：Delete键删除";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(493, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(233, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "* 回车键编辑，Alt+↑ 上移，Alt+↓ 下移";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(495, 321);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(270, 127);
            this.txtLog.TabIndex = 16;
            // 
            // btnApplyOnlyUser
            // 
            this.btnApplyOnlyUser.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApplyOnlyUser.Location = new System.Drawing.Point(495, 268);
            this.btnApplyOnlyUser.Name = "btnApplyOnlyUser";
            this.btnApplyOnlyUser.Size = new System.Drawing.Size(270, 47);
            this.btnApplyOnlyUser.TabIndex = 15;
            this.btnApplyOnlyUser.Text = "应用到Hosts文件(使用上次远程缓存)";
            this.btnApplyOnlyUser.UseVisualStyleBackColor = true;
            this.btnApplyOnlyUser.Click += new System.EventHandler(this.btnApplyOnlyUser_Click);
            // 
            // btnApplyToHosts
            // 
            this.btnApplyToHosts.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApplyToHosts.Location = new System.Drawing.Point(495, 215);
            this.btnApplyToHosts.Name = "btnApplyToHosts";
            this.btnApplyToHosts.Size = new System.Drawing.Size(270, 47);
            this.btnApplyToHosts.TabIndex = 15;
            this.btnApplyToHosts.Text = "应用到Hosts文件(重新下载远程配置)";
            this.btnApplyToHosts.UseVisualStyleBackColor = true;
            this.btnApplyToHosts.Click += new System.EventHandler(this.btnApplyToHosts_Click);
            // 
            // btnUpSource
            // 
            this.btnUpSource.Location = new System.Drawing.Point(771, 147);
            this.btnUpSource.Name = "btnUpSource";
            this.btnUpSource.Size = new System.Drawing.Size(38, 23);
            this.btnUpSource.TabIndex = 12;
            this.btnUpSource.Text = "上移";
            this.btnUpSource.UseVisualStyleBackColor = true;
            this.btnUpSource.Click += new System.EventHandler(this.btnUpSource_Click);
            // 
            // btnDownSource
            // 
            this.btnDownSource.Location = new System.Drawing.Point(771, 172);
            this.btnDownSource.Name = "btnDownSource";
            this.btnDownSource.Size = new System.Drawing.Size(38, 23);
            this.btnDownSource.TabIndex = 13;
            this.btnDownSource.Text = "下移";
            this.btnDownSource.UseVisualStyleBackColor = true;
            this.btnDownSource.Click += new System.EventHandler(this.btnDownSource_Click);
            // 
            // btnDisableEnable
            // 
            this.btnDisableEnable.Location = new System.Drawing.Point(771, 197);
            this.btnDisableEnable.Name = "btnDisableEnable";
            this.btnDisableEnable.Size = new System.Drawing.Size(38, 23);
            this.btnDisableEnable.TabIndex = 14;
            this.btnDisableEnable.Text = "禁用";
            this.btnDisableEnable.UseVisualStyleBackColor = true;
            this.btnDisableEnable.Click += new System.EventHandler(this.btnDisableEnable_Click);
            // 
            // btnEditSource
            // 
            this.btnEditSource.Location = new System.Drawing.Point(771, 122);
            this.btnEditSource.Name = "btnEditSource";
            this.btnEditSource.Size = new System.Drawing.Size(38, 23);
            this.btnEditSource.TabIndex = 11;
            this.btnEditSource.Text = "编辑";
            this.btnEditSource.UseVisualStyleBackColor = true;
            this.btnEditSource.Click += new System.EventHandler(this.btnEditSource_Click);
            // 
            // btnDeleteSource
            // 
            this.btnDeleteSource.Location = new System.Drawing.Point(771, 97);
            this.btnDeleteSource.Name = "btnDeleteSource";
            this.btnDeleteSource.Size = new System.Drawing.Size(38, 23);
            this.btnDeleteSource.TabIndex = 10;
            this.btnDeleteSource.Text = "删除";
            this.btnDeleteSource.UseVisualStyleBackColor = true;
            this.btnDeleteSource.Click += new System.EventHandler(this.btnDeleteSource_Click);
            // 
            // btnAddSource
            // 
            this.btnAddSource.Location = new System.Drawing.Point(771, 72);
            this.btnAddSource.Name = "btnAddSource";
            this.btnAddSource.Size = new System.Drawing.Size(38, 23);
            this.btnAddSource.TabIndex = 9;
            this.btnAddSource.Text = "添加";
            this.btnAddSource.UseVisualStyleBackColor = true;
            this.btnAddSource.Click += new System.EventHandler(this.btnAddSource_Click);
            // 
            // btnDirect
            // 
            this.btnDirect.Location = new System.Drawing.Point(385, 60);
            this.btnDirect.Name = "btnDirect";
            this.btnDirect.Size = new System.Drawing.Size(75, 23);
            this.btnDirect.TabIndex = 7;
            this.btnDirect.Text = "指向选中Ip";
            this.btnDirect.UseVisualStyleBackColor = true;
            this.btnDirect.Click += new System.EventHandler(this.btnDirect_Click);
            // 
            // txtCurrent
            // 
            this.txtCurrent.Location = new System.Drawing.Point(274, 62);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.ReadOnly = true;
            this.txtCurrent.Size = new System.Drawing.Size(107, 21);
            this.txtCurrent.TabIndex = 6;
            this.txtCurrent.TextChanged += new System.EventHandler(this.txtCurrent_TextChanged);
            // 
            // btnDeleteIp
            // 
            this.btnDeleteIp.Location = new System.Drawing.Point(430, 155);
            this.btnDeleteIp.Name = "btnDeleteIp";
            this.btnDeleteIp.Size = new System.Drawing.Size(39, 23);
            this.btnDeleteIp.TabIndex = 4;
            this.btnDeleteIp.Text = "删除";
            this.btnDeleteIp.UseVisualStyleBackColor = true;
            this.btnDeleteIp.Click += new System.EventHandler(this.btnDeleteIp_Click);
            // 
            // btnAddIp
            // 
            this.btnAddIp.Location = new System.Drawing.Point(430, 126);
            this.btnAddIp.Name = "btnAddIp";
            this.btnAddIp.Size = new System.Drawing.Size(39, 23);
            this.btnAddIp.TabIndex = 4;
            this.btnAddIp.Text = "添加";
            this.btnAddIp.UseVisualStyleBackColor = true;
            this.btnAddIp.Click += new System.EventHandler(this.btnAddIp_Click);
            // 
            // btnDeleteHostName
            // 
            this.btnDeleteHostName.Location = new System.Drawing.Point(229, 111);
            this.btnDeleteHostName.Name = "btnDeleteHostName";
            this.btnDeleteHostName.Size = new System.Drawing.Size(39, 23);
            this.btnDeleteHostName.TabIndex = 4;
            this.btnDeleteHostName.Text = "删除";
            this.btnDeleteHostName.UseVisualStyleBackColor = true;
            this.btnDeleteHostName.Click += new System.EventHandler(this.btnDeleteHostName_Click);
            // 
            // btnClearIp
            // 
            this.btnClearIp.Location = new System.Drawing.Point(385, 104);
            this.btnClearIp.Name = "btnClearIp";
            this.btnClearIp.Size = new System.Drawing.Size(39, 23);
            this.btnClearIp.TabIndex = 4;
            this.btnClearIp.Text = "清空";
            this.btnClearIp.UseVisualStyleBackColor = true;
            this.btnClearIp.Click += new System.EventHandler(this.btnClearIp_Click);
            // 
            // btnClearHostName
            // 
            this.btnClearHostName.Location = new System.Drawing.Point(184, 55);
            this.btnClearHostName.Name = "btnClearHostName";
            this.btnClearHostName.Size = new System.Drawing.Size(39, 23);
            this.btnClearHostName.TabIndex = 4;
            this.btnClearHostName.Text = "清空";
            this.btnClearHostName.UseVisualStyleBackColor = true;
            this.btnClearHostName.Click += new System.EventHandler(this.btnClearHostName_Click);
            // 
            // btnAddHostName
            // 
            this.btnAddHostName.Location = new System.Drawing.Point(229, 82);
            this.btnAddHostName.Name = "btnAddHostName";
            this.btnAddHostName.Size = new System.Drawing.Size(39, 23);
            this.btnAddHostName.TabIndex = 4;
            this.btnAddHostName.Text = "添加";
            this.btnAddHostName.UseVisualStyleBackColor = true;
            this.btnAddHostName.Click += new System.EventHandler(this.btnAddHostName_Click);
            // 
            // txtIpFilter
            // 
            this.txtIpFilter.Location = new System.Drawing.Point(272, 106);
            this.txtIpFilter.Name = "txtIpFilter";
            this.txtIpFilter.Size = new System.Drawing.Size(107, 21);
            this.txtIpFilter.TabIndex = 2;
            this.txtIpFilter.TextChanged += new System.EventHandler(this.txtIpFilter_TextChanged);
            this.txtIpFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIpFilter_KeyDown);
            this.txtIpFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIpFilter_KeyPress);
            // 
            // txtHostNameFilter
            // 
            this.txtHostNameFilter.Location = new System.Drawing.Point(12, 57);
            this.txtHostNameFilter.Name = "txtHostNameFilter";
            this.txtHostNameFilter.Size = new System.Drawing.Size(166, 21);
            this.txtHostNameFilter.TabIndex = 2;
            this.txtHostNameFilter.TextChanged += new System.EventHandler(this.txtHostNameFilter_TextChanged);
            this.txtHostNameFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHostNameFilter_KeyDown);
            // 
            // chkAutoApply
            // 
            this.chkAutoApply.AutoSize = true;
            this.chkAutoApply.Checked = true;
            this.chkAutoApply.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoApply.Location = new System.Drawing.Point(274, 33);
            this.chkAutoApply.Name = "chkAutoApply";
            this.chkAutoApply.Size = new System.Drawing.Size(198, 16);
            this.chkAutoApply.TabIndex = 17;
            this.chkAutoApply.Text = "更改指向时自动应用到Hosts文件";
            this.chkAutoApply.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 480);
            this.Controls.Add(this.chkAutoApply);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnApplyOnlyUser);
            this.Controls.Add(this.btnApplyToHosts);
            this.Controls.Add(this.btnUpSource);
            this.Controls.Add(this.btnDownSource);
            this.Controls.Add(this.btnDisableEnable);
            this.Controls.Add(this.btnEditSource);
            this.Controls.Add(this.btnDeleteSource);
            this.Controls.Add(this.btnAddSource);
            this.Controls.Add(this.lstSource);
            this.Controls.Add(this.btnDirect);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDeleteIp);
            this.Controls.Add(this.btnAddIp);
            this.Controls.Add(this.btnDeleteHostName);
            this.Controls.Add(this.btnClearIp);
            this.Controls.Add(this.btnClearHostName);
            this.Controls.Add(this.btnAddHostName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIpFilter);
            this.Controls.Add(this.txtHostNameFilter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstIp);
            this.Controls.Add(this.lstHostName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hosts管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstHostName;
        private System.Windows.Forms.Label label1;
        private HostsManageTool.Winform.UserControl.TextBoxEx txtHostNameFilter;
        private System.Windows.Forms.Label label2;
        private HostsManageTool.Winform.UserControl.ButtonEx btnAddHostName;
        private HostsManageTool.Winform.UserControl.ButtonEx btnDeleteHostName;
        private System.Windows.Forms.ListBox lstIp;
        private System.Windows.Forms.Label label3;
        private HostsManageTool.Winform.UserControl.ButtonEx btnAddIp;
        private HostsManageTool.Winform.UserControl.ButtonEx btnDeleteIp;
        private HostsManageTool.Winform.UserControl.TextBoxEx txtIpFilter;
        private System.Windows.Forms.Label label4;
        private HostsManageTool.Winform.UserControl.ButtonEx btnClearHostName;
        private HostsManageTool.Winform.UserControl.ButtonEx btnClearIp;
        private System.Windows.Forms.Label label5;
        private HostsManageTool.Winform.UserControl.TextBoxEx txtCurrent;
        private HostsManageTool.Winform.UserControl.ButtonEx btnDirect;
        private System.Windows.Forms.ListBox lstSource;
        private System.Windows.Forms.Label label6;
        private HostsManageTool.Winform.UserControl.ButtonEx btnAddSource;
        private HostsManageTool.Winform.UserControl.ButtonEx btnDeleteSource;
        private HostsManageTool.Winform.UserControl.ButtonEx btnDisableEnable;
        private HostsManageTool.Winform.UserControl.ButtonEx btnEditSource;
        private HostsManageTool.Winform.UserControl.ButtonEx btnDownSource;
        private HostsManageTool.Winform.UserControl.ButtonEx btnUpSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private UserControl.ButtonEx btnApplyToHosts;
        private UserControl.ButtonEx btnApplyOnlyUser;
        private HostsManageTool.Winform.UserControl.TextBoxEx txtLog;
        private System.Windows.Forms.CheckBox chkAutoApply;
    }
}

