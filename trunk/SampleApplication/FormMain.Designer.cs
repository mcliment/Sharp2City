namespace SampleApplication
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxAccess = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxHostName = new System.Windows.Forms.TextBox();
            this.buttonShowServerInfo = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonShowAllBuilds = new System.Windows.Forms.Button();
            this.groupBoxAccess.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAccess
            // 
            this.groupBoxAccess.Controls.Add(this.label3);
            this.groupBoxAccess.Controls.Add(this.label2);
            this.groupBoxAccess.Controls.Add(this.label1);
            this.groupBoxAccess.Controls.Add(this.textBoxPassword);
            this.groupBoxAccess.Controls.Add(this.textBoxUsername);
            this.groupBoxAccess.Controls.Add(this.textBoxHostName);
            this.groupBoxAccess.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAccess.Name = "groupBoxAccess";
            this.groupBoxAccess.Size = new System.Drawing.Size(284, 100);
            this.groupBoxAccess.TabIndex = 0;
            this.groupBoxAccess.TabStop = false;
            this.groupBoxAccess.Text = "Access Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hostname:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SampleApplication.Properties.Settings.Default, "Password", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxPassword.Location = new System.Drawing.Point(70, 71);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(208, 20);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.Text = global::SampleApplication.Properties.Settings.Default.Password;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SampleApplication.Properties.Settings.Default, "UserName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxUsername.Location = new System.Drawing.Point(70, 45);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(208, 20);
            this.textBoxUsername.TabIndex = 1;
            this.textBoxUsername.Text = global::SampleApplication.Properties.Settings.Default.UserName;
            // 
            // textBoxHostName
            // 
            this.textBoxHostName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SampleApplication.Properties.Settings.Default, "Hostname", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxHostName.Location = new System.Drawing.Point(70, 19);
            this.textBoxHostName.Name = "textBoxHostName";
            this.textBoxHostName.Size = new System.Drawing.Size(208, 20);
            this.textBoxHostName.TabIndex = 0;
            this.textBoxHostName.Text = global::SampleApplication.Properties.Settings.Default.Hostname;
            // 
            // buttonShowServerInfo
            // 
            this.buttonShowServerInfo.Location = new System.Drawing.Point(302, 24);
            this.buttonShowServerInfo.Name = "buttonShowServerInfo";
            this.buttonShowServerInfo.Size = new System.Drawing.Size(124, 23);
            this.buttonShowServerInfo.TabIndex = 1;
            this.buttonShowServerInfo.Text = "Show Server Info";
            this.buttonShowServerInfo.UseVisualStyleBackColor = true;
            this.buttonShowServerInfo.Click += new System.EventHandler(this.OnButtonShowServerInfoClick);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxOutput.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOutput.Location = new System.Drawing.Point(12, 118);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutput.Size = new System.Drawing.Size(617, 163);
            this.textBoxOutput.TabIndex = 2;
            this.textBoxOutput.WordWrap = false;
            // 
            // buttonShowAllBuilds
            // 
            this.buttonShowAllBuilds.Location = new System.Drawing.Point(302, 55);
            this.buttonShowAllBuilds.Name = "buttonShowAllBuilds";
            this.buttonShowAllBuilds.Size = new System.Drawing.Size(124, 23);
            this.buttonShowAllBuilds.TabIndex = 3;
            this.buttonShowAllBuilds.Text = "Show All Builds";
            this.buttonShowAllBuilds.UseVisualStyleBackColor = true;
            this.buttonShowAllBuilds.Click += new System.EventHandler(this.OnButtonShowAllBuildsClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 293);
            this.Controls.Add(this.buttonShowAllBuilds);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonShowServerInfo);
            this.Controls.Add(this.groupBoxAccess);
            this.Name = "FormMain";
            this.Text = "Sharp2City Sample Application";
            this.groupBoxAccess.ResumeLayout(false);
            this.groupBoxAccess.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAccess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxHostName;
        private System.Windows.Forms.Button buttonShowServerInfo;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonShowAllBuilds;
    }
}

