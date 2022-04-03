
namespace typing_and_clicking
{
    partial class Login
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.forgot_password_link = new System.Windows.Forms.LinkLabel();
            this.label_login_wait = new System.Windows.Forms.Label();
            this.label_failed_login = new System.Windows.Forms.Label();
            this.login_btn = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.forgot_password_link);
            this.groupBox1.Controls.Add(this.label_login_wait);
            this.groupBox1.Controls.Add(this.label_failed_login);
            this.groupBox1.Controls.Add(this.login_btn);
            this.groupBox1.Controls.Add(this.username);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 257);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Welcome To APP-Z";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // forgot_password_link
            // 
            this.forgot_password_link.AutoSize = true;
            this.forgot_password_link.ForeColor = System.Drawing.Color.DarkCyan;
            this.forgot_password_link.Location = new System.Drawing.Point(16, 233);
            this.forgot_password_link.Name = "forgot_password_link";
            this.forgot_password_link.Size = new System.Drawing.Size(86, 13);
            this.forgot_password_link.TabIndex = 10;
            this.forgot_password_link.TabStop = true;
            this.forgot_password_link.Text = "Forgot Password";
            this.forgot_password_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.forgot_password_link_LinkClicked);
            // 
            // label_login_wait
            // 
            this.label_login_wait.AutoSize = true;
            this.label_login_wait.Location = new System.Drawing.Point(100, 213);
            this.label_login_wait.Name = "label_login_wait";
            this.label_login_wait.Size = new System.Drawing.Size(73, 13);
            this.label_login_wait.TabIndex = 9;
            this.label_login_wait.Text = "Please wait....";
            // 
            // label_failed_login
            // 
            this.label_failed_login.AutoSize = true;
            this.label_failed_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_failed_login.ForeColor = System.Drawing.Color.Red;
            this.label_failed_login.Location = new System.Drawing.Point(16, 212);
            this.label_failed_login.Name = "label_failed_login";
            this.label_failed_login.Size = new System.Drawing.Size(35, 13);
            this.label_failed_login.TabIndex = 8;
            this.label_failed_login.Text = "Error..";
            this.label_failed_login.Click += new System.EventHandler(this.label_failed_login_Click);
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(19, 159);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(246, 43);
            this.login_btn.TabIndex = 7;
            this.login_btn.Text = "Login";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(19, 68);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(246, 20);
            this.username.TabIndex = 5;
            this.username.TextChanged += new System.EventHandler(this.username_TextChanged);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(19, 121);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(246, 20);
            this.password.TabIndex = 6;
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username:";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "Login";
            this.Text = "Login";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Label label_failed_login;
        private System.Windows.Forms.Label label_login_wait;
        private System.Windows.Forms.LinkLabel forgot_password_link;
    }
}