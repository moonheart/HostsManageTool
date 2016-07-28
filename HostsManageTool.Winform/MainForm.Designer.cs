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
            this.btnAddHostName = new System.Windows.Forms.Button();
            this.btnDeleteHostName = new System.Windows.Forms.Button();
            this.lstIp = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddIp = new System.Windows.Forms.Button();
            this.btnDeleteIp = new System.Windows.Forms.Button();
            this.btnDisableAllIp = new System.Windows.Forms.Button();
            this.txtIpFilter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClearHostName = new System.Windows.Forms.Button();
            this.btnClearIp = new System.Windows.Forms.Button();
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
            // btnDeleteHostName
            // 
            this.btnDeleteHostName.Location = new System.Drawing.Point(229, 111);
            this.btnDeleteHostName.Name = "btnDeleteHostName";
            this.btnDeleteHostName.Size = new System.Drawing.Size(39, 23);
            this.btnDeleteHostName.TabIndex = 4;
            this.btnDeleteHostName.Text = "删除";
            this.btnDeleteHostName.UseVisualStyleBackColor = true;
            // 
            // lstIp
            // 
            this.lstIp.FormattingEnabled = true;
            this.lstIp.ItemHeight = 12;
            this.lstIp.Location = new System.Drawing.Point(274, 82);
            this.lstIp.Name = "lstIp";
            this.lstIp.Size = new System.Drawing.Size(152, 376);
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
            // btnAddIp
            // 
            this.btnAddIp.Location = new System.Drawing.Point(432, 82);
            this.btnAddIp.Name = "btnAddIp";
            this.btnAddIp.Size = new System.Drawing.Size(39, 23);
            this.btnAddIp.TabIndex = 4;
            this.btnAddIp.Text = "添加";
            this.btnAddIp.UseVisualStyleBackColor = true;
            // 
            // btnDeleteIp
            // 
            this.btnDeleteIp.Location = new System.Drawing.Point(432, 111);
            this.btnDeleteIp.Name = "btnDeleteIp";
            this.btnDeleteIp.Size = new System.Drawing.Size(39, 23);
            this.btnDeleteIp.TabIndex = 4;
            this.btnDeleteIp.Text = "删除";
            this.btnDeleteIp.UseVisualStyleBackColor = true;
            // 
            // btnDisableAllIp
            // 
            this.btnDisableAllIp.Location = new System.Drawing.Point(432, 140);
            this.btnDisableAllIp.Name = "btnDisableAllIp";
            this.btnDisableAllIp.Size = new System.Drawing.Size(39, 23);
            this.btnDisableAllIp.TabIndex = 4;
            this.btnDisableAllIp.Text = "禁用";
            this.btnDisableAllIp.UseVisualStyleBackColor = true;
            // 
            // txtIpFilter
            // 
            this.txtIpFilter.Location = new System.Drawing.Point(274, 55);
            this.txtIpFilter.Name = "txtIpFilter";
            this.txtIpFilter.Size = new System.Drawing.Size(107, 21);
            this.txtIpFilter.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "输入Ip快速过滤或添加：";
            // 
            // btnClearHostName
            // 
            this.btnClearHostName.Location = new System.Drawing.Point(184, 55);
            this.btnClearHostName.Name = "btnClearHostName";
            this.btnClearHostName.Size = new System.Drawing.Size(39, 23);
            this.btnClearHostName.TabIndex = 4;
            this.btnClearHostName.Text = "清空";
            this.btnClearHostName.UseVisualStyleBackColor = true;
            // 
            // btnClearIp
            // 
            this.btnClearIp.Location = new System.Drawing.Point(387, 53);
            this.btnClearIp.Name = "btnClearIp";
            this.btnClearIp.Size = new System.Drawing.Size(39, 23);
            this.btnClearIp.TabIndex = 4;
            this.btnClearIp.Text = "清空";
            this.btnClearIp.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 480);
            this.Controls.Add(this.btnDisableAllIp);
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
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstIp);
            this.Controls.Add(this.lstHostName);
            this.Name = "MainForm";
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
        private System.Windows.Forms.Button btnAddHostName;
        private System.Windows.Forms.Button btnDeleteHostName;
        private System.Windows.Forms.ListBox lstIp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddIp;
        private System.Windows.Forms.Button btnDeleteIp;
        private System.Windows.Forms.Button btnDisableAllIp;
        private System.Windows.Forms.TextBox txtIpFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClearHostName;
        private System.Windows.Forms.Button btnClearIp;
    }
}

