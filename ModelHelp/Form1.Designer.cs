namespace ModelHelp
{
    partial class Form1
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
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbServerType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbConfig = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chbCreateRepository = new System.Windows.Forms.CheckBox();
            this.chbCreateService = new System.Windows.Forms.CheckBox();
            this.chkSqlHelp = new System.Windows.Forms.CheckBox();
            this.labSlhelp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(191, 106);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(146, 21);
            this.txtHost.TabIndex = 10;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(191, 147);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(146, 21);
            this.txtUserName.TabIndex = 20;
            // 
            // txtpwd
            // 
            this.txtpwd.Location = new System.Drawing.Point(191, 188);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.Size = new System.Drawing.Size(146, 21);
            this.txtpwd.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "服务器地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "用户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "密码";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(262, 468);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "生成模型";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(191, 309);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(146, 21);
            this.txtNameSpace.TabIndex = 60;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "自定义命名空间头";
            // 
            // cmbServerType
            // 
            this.cmbServerType.FormattingEnabled = true;
            this.cmbServerType.Items.AddRange(new object[] {
            "Sql Server",
            "MySql"});
            this.cmbServerType.Location = new System.Drawing.Point(191, 226);
            this.cmbServerType.Name = "cmbServerType";
            this.cmbServerType.Size = new System.Drawing.Size(146, 20);
            this.cmbServerType.TabIndex = 40;
            this.cmbServerType.SelectedValueChanged += new System.EventHandler(this.cmbServerType_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "数据库类型";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(134, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "端口号";
            // 
            // txtProt
            // 
            this.txtProt.Location = new System.Drawing.Point(191, 264);
            this.txtProt.Name = "txtProt";
            this.txtProt.Size = new System.Drawing.Size(146, 21);
            this.txtProt.TabIndex = 50;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(100, 468);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "保存配置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmbConfig
            // 
            this.cmbConfig.FormattingEnabled = true;
            this.cmbConfig.Location = new System.Drawing.Point(191, 73);
            this.cmbConfig.Name = "cmbConfig";
            this.cmbConfig.Size = new System.Drawing.Size(146, 20);
            this.cmbConfig.TabIndex = 0;
            this.cmbConfig.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "配置";
            // 
            // chbCreateRepository
            // 
            this.chbCreateRepository.AutoSize = true;
            this.chbCreateRepository.Location = new System.Drawing.Point(191, 380);
            this.chbCreateRepository.Name = "chbCreateRepository";
            this.chbCreateRepository.Size = new System.Drawing.Size(84, 16);
            this.chbCreateRepository.TabIndex = 61;
            this.chbCreateRepository.Text = "生成仓储类";
            this.chbCreateRepository.UseVisualStyleBackColor = true;
            // 
            // chbCreateService
            // 
            this.chbCreateService.AutoSize = true;
            this.chbCreateService.Location = new System.Drawing.Point(191, 416);
            this.chbCreateService.Name = "chbCreateService";
            this.chbCreateService.Size = new System.Drawing.Size(84, 16);
            this.chbCreateService.TabIndex = 62;
            this.chbCreateService.Text = "生成服务类";
            this.chbCreateService.UseVisualStyleBackColor = true;
            // 
            // chkSqlHelp
            // 
            this.chkSqlHelp.AutoSize = true;
            this.chkSqlHelp.Location = new System.Drawing.Point(191, 346);
            this.chkSqlHelp.Name = "chkSqlHelp";
            this.chkSqlHelp.Size = new System.Drawing.Size(90, 16);
            this.chkSqlHelp.TabIndex = 63;
            this.chkSqlHelp.Text = "继承Sql帮助";
            this.chkSqlHelp.UseVisualStyleBackColor = true;
            this.chkSqlHelp.MouseHover += new System.EventHandler(this.chkSqlHelp_MouseHover);
            // 
            // labSlhelp
            // 
            this.labSlhelp.AutoSize = true;
            this.labSlhelp.ForeColor = System.Drawing.Color.Red;
            this.labSlhelp.Location = new System.Drawing.Point(61, 333);
            this.labSlhelp.Name = "labSlhelp";
            this.labSlhelp.Size = new System.Drawing.Size(389, 12);
            this.labSlhelp.TabIndex = 64;
            this.labSlhelp.Text = "不同数据库将继承不同数据库基类，基类中包含生成增删改查的语句函数";
            this.labSlhelp.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 586);
            this.Controls.Add(this.labSlhelp);
            this.Controls.Add(this.chkSqlHelp);
            this.Controls.Add(this.chbCreateService);
            this.Controls.Add(this.chbCreateRepository);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbConfig);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtProt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbServerType);
            this.Controls.Add(this.txtNameSpace);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtHost);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbServerType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbConfig;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chbCreateRepository;
        private System.Windows.Forms.CheckBox chbCreateService;
        private System.Windows.Forms.CheckBox chkSqlHelp;
        private System.Windows.Forms.Label labSlhelp;
    }
}

