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
            this.lstHostName = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHostNameFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstIp = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIpFilter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.lstSource = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUpSource = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnDownSource = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnDisableEnable = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnEditSource = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnDeleteSource = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnAddSource = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnDirect = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnDeleteIp = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnAddIp = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnDeleteHostName = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnClearIp = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnClearHostName = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.btnAddHostName = new HostsManageTool.Winform.UserControl.ButtonEx();
            this.SuspendLayout();
            // 
            // lstHostName
            // 
            this.lstHostName.FormattingEnabled = true;
            this.lstHostName.ItemHeight = 12;
            this.lstHostName.Location = new System.Drawing.Point(12, 84);
            this.lstHostName.Name = "lstHostName";
            this.lstHostName.Size = new System.Drawing.Size(211, 376);
            this.lstHostName.TabIndex = 0;
            this.lstHostName.SelectedIndexChanged += new System.EventHandler(this.lstHostName_SelectedIndexChanged);
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
            // txtHostNameFilter
            // 
            this.txtHostNameFilter.Location = new System.Drawing.Point(12, 57);
            this.txtHostNameFilter.Name = "txtHostNameFilter";
            this.txtHostNameFilter.Size = new System.Drawing.Size(166, 21);
            this.txtHostNameFilter.TabIndex = 2;
            this.txtHostNameFilter.TextChanged += new System.EventHandler(this.txtHostNameFilter_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "输入主机名快速过滤或添加：";
            // 
            // lstIp
            // 
            this.lstIp.FormattingEnabled = true;
            this.lstIp.ItemHeight = 12;
            this.lstIp.Location = new System.Drawing.Point(272, 126);
            this.lstIp.Name = "lstIp";
            this.lstIp.Size = new System.Drawing.Size(152, 328);
            this.lstIp.TabIndex = 0;
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
            // txtIpFilter
            // 
            this.txtIpFilter.Location = new System.Drawing.Point(272, 99);
            this.txtIpFilter.Name = "txtIpFilter";
            this.txtIpFilter.Size = new System.Drawing.Size(107, 21);
            this.txtIpFilter.TabIndex = 2;
            this.txtIpFilter.TextChanged += new System.EventHandler(this.txtIpFilter_TextChanged);
            this.txtIpFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIpFilter_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "输入Ip快速过滤或添加：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "当前主机指向：";
            // 
            // txtCurrent
            // 
            this.txtCurrent.Location = new System.Drawing.Point(274, 55);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.ReadOnly = true;
            this.txtCurrent.Size = new System.Drawing.Size(107, 21);
            this.txtCurrent.TabIndex = 6;
            this.txtCurrent.TextChanged += new System.EventHandler(this.txtCurrent_TextChanged);
            // 
            // lstSource
            // 
            this.lstSource.FormattingEnabled = true;
            this.lstSource.ItemHeight = 12;
            this.lstSource.Location = new System.Drawing.Point(495, 53);
            this.lstSource.Name = "lstSource";
            this.lstSource.Size = new System.Drawing.Size(270, 400);
            this.lstSource.TabIndex = 8;
            this.lstSource.SelectedIndexChanged += new System.EventHandler(this.lstSource_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(491, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Hosts源列表";
            // 
            // btnUpSource
            // 
            this.btnUpSource.Location = new System.Drawing.Point(771, 157);
            this.btnUpSource.Name = "btnUpSource";
            this.btnUpSource.Size = new System.Drawing.Size(38, 23);
            this.btnUpSource.TabIndex = 12;
            this.btnUpSource.Text = "上移";
            this.btnUpSource.UseVisualStyleBackColor = true;
            // 
            // btnDownSource
            // 
            this.btnDownSource.Location = new System.Drawing.Point(771, 186);
            this.btnDownSource.Name = "btnDownSource";
            this.btnDownSource.Size = new System.Drawing.Size(38, 23);
            this.btnDownSource.TabIndex = 13;
            this.btnDownSource.Text = "下移";
            this.btnDownSource.UseVisualStyleBackColor = true;
            // 
            // btnDisableEnable
            // 
            this.btnDisableEnable.Location = new System.Drawing.Point(771, 215);
            this.btnDisableEnable.Name = "btnDisableEnable";
            this.btnDisableEnable.Size = new System.Drawing.Size(38, 23);
            this.btnDisableEnable.TabIndex = 14;
            this.btnDisableEnable.Text = "禁用";
            this.btnDisableEnable.UseVisualStyleBackColor = true;
            this.btnDisableEnable.Click += new System.EventHandler(this.btnDisableEnable_Click);
            // 
            // btnEditSource
            // 
            this.btnEditSource.Location = new System.Drawing.Point(771, 111);
            this.btnEditSource.Name = "btnEditSource";
            this.btnEditSource.Size = new System.Drawing.Size(38, 23);
            this.btnEditSource.TabIndex = 11;
            this.btnEditSource.Text = "编辑";
            this.btnEditSource.UseVisualStyleBackColor = true;
            this.btnEditSource.Click += new System.EventHandler(this.btnEditSource_Click);
            // 
            // btnDeleteSource
            // 
            this.btnDeleteSource.Location = new System.Drawing.Point(771, 82);
            this.btnDeleteSource.Name = "btnDeleteSource";
            this.btnDeleteSource.Size = new System.Drawing.Size(38, 23);
            this.btnDeleteSource.TabIndex = 10;
            this.btnDeleteSource.Text = "删除";
            this.btnDeleteSource.UseVisualStyleBackColor = true;
            this.btnDeleteSource.Click += new System.EventHandler(this.btnDeleteSource_Click);
            // 
            // btnAddSource
            // 
            this.btnAddSource.Location = new System.Drawing.Point(771, 53);
            this.btnAddSource.Name = "btnAddSource";
            this.btnAddSource.Size = new System.Drawing.Size(38, 23);
            this.btnAddSource.TabIndex = 9;
            this.btnAddSource.Text = "添加";
            this.btnAddSource.UseVisualStyleBackColor = true;
            this.btnAddSource.Click += new System.EventHandler(this.btnAddSource_Click);
            // 
            // btnDirect
            // 
            this.btnDirect.Location = new System.Drawing.Point(385, 53);
            this.btnDirect.Name = "btnDirect";
            this.btnDirect.Size = new System.Drawing.Size(75, 23);
            this.btnDirect.TabIndex = 7;
            this.btnDirect.Text = "指向选中Ip";
            this.btnDirect.UseVisualStyleBackColor = true;
            this.btnDirect.Click += new System.EventHandler(this.btnDirect_Click);
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
            this.btnClearIp.Location = new System.Drawing.Point(385, 97);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 480);
            this.Controls.Add(this.btnUpSource);
            this.Controls.Add(this.btnDownSource);
            this.Controls.Add(this.btnDisableEnable);
            this.Controls.Add(this.btnEditSource);
            this.Controls.Add(this.btnDeleteSource);
            this.Controls.Add(this.btnAddSource);
            this.Controls.Add(this.lstSource);
            this.Controls.Add(this.btnDirect);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDeleteIp);
            this.Controls.Add(this.btnAddIp);
            this.Controls.Add(this.btnDeleteHostName);
            this.Controls.Add(this.btnClearIp);
            this.Controls.Add(this.btnClearHostName);
            this.Controls.Add(this.btnAddHostName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIpFilter);
            this.Controls.Add(this.txtHostNameFilter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstIp);
            this.Controls.Add(this.lstHostName);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hosts管理";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstHostName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHostNameFilter;
        private System.Windows.Forms.Label label2;
        private HostsManageTool.Winform.UserControl.ButtonEx btnAddHostName;
        private HostsManageTool.Winform.UserControl.ButtonEx btnDeleteHostName;
        private System.Windows.Forms.ListBox lstIp;
        private System.Windows.Forms.Label label3;
        private HostsManageTool.Winform.UserControl.ButtonEx btnAddIp;
        private HostsManageTool.Winform.UserControl.ButtonEx btnDeleteIp;
        private System.Windows.Forms.TextBox txtIpFilter;
        private System.Windows.Forms.Label label4;
        private HostsManageTool.Winform.UserControl.ButtonEx btnClearHostName;
        private HostsManageTool.Winform.UserControl.ButtonEx btnClearIp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCurrent;
        private HostsManageTool.Winform.UserControl.ButtonEx btnDirect;
        private System.Windows.Forms.ListBox lstSource;
        private System.Windows.Forms.Label label6;
        private HostsManageTool.Winform.UserControl.ButtonEx btnAddSource;
        private HostsManageTool.Winform.UserControl.ButtonEx btnDeleteSource;
        private HostsManageTool.Winform.UserControl.ButtonEx btnDisableEnable;
        private HostsManageTool.Winform.UserControl.ButtonEx btnEditSource;
        private HostsManageTool.Winform.UserControl.ButtonEx btnDownSource;
        private HostsManageTool.Winform.UserControl.ButtonEx btnUpSource;
    }
}

