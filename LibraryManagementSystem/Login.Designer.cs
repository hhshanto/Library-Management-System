namespace LibraryManagementSystem
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.UserLabel = new System.Windows.Forms.Label();
            this.PassLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.panelDown = new System.Windows.Forms.Panel();
            this.NameLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.passLabel2 = new System.Windows.Forms.Label();
            this.userLabel2 = new System.Windows.Forms.Label();
            this.createAccountButton = new System.Windows.Forms.Button();
            this.addressBox2 = new System.Windows.Forms.TextBox();
            this.mobileBox2 = new System.Windows.Forms.TextBox();
            this.nameBox2 = new System.Windows.Forms.TextBox();
            this.passwordBox2 = new System.Windows.Forms.TextBox();
            this.userBox2 = new System.Windows.Forms.TextBox();
            this.signUpButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            resources.ApplyResources(this.exitButton, "exitButton");
            this.exitButton.Name = "exitButton";
            this.exitButton.TabStop = false;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // userNameBox
            // 
            this.userNameBox.BackColor = System.Drawing.Color.DimGray;
            this.userNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.userNameBox, "userNameBox");
            this.userNameBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(216)))), ((int)(((byte)(53)))));
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userNameBox_KeyDown);
            // 
            // passwordBox
            // 
            this.passwordBox.BackColor = System.Drawing.Color.DimGray;
            this.passwordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.passwordBox, "passwordBox");
            this.passwordBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(216)))), ((int)(((byte)(53)))));
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordBox_KeyDown);
            // 
            // welcomeLabel
            // 
            resources.ApplyResources(this.welcomeLabel, "welcomeLabel");
            this.welcomeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(127)))), ((int)(((byte)(23)))));
            this.welcomeLabel.Name = "welcomeLabel";
            // 
            // UserLabel
            // 
            resources.ApplyResources(this.UserLabel, "UserLabel");
            this.UserLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(192)))), ((int)(((byte)(45)))));
            this.UserLabel.Name = "UserLabel";
            // 
            // PassLabel
            // 
            resources.ApplyResources(this.PassLabel, "PassLabel");
            this.PassLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(216)))), ((int)(((byte)(53)))));
            this.PassLabel.Name = "PassLabel";
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.LoginButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(127)))), ((int)(((byte)(23)))));
            this.LoginButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.LoginButton, "LoginButton");
            this.LoginButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // panelDown
            // 
            this.panelDown.Controls.Add(this.NameLabel);
            this.panelDown.Controls.Add(this.phoneLabel);
            this.panelDown.Controls.Add(this.addressLabel);
            this.panelDown.Controls.Add(this.passLabel2);
            this.panelDown.Controls.Add(this.userLabel2);
            this.panelDown.Controls.Add(this.createAccountButton);
            this.panelDown.Controls.Add(this.addressBox2);
            this.panelDown.Controls.Add(this.mobileBox2);
            this.panelDown.Controls.Add(this.nameBox2);
            this.panelDown.Controls.Add(this.passwordBox2);
            this.panelDown.Controls.Add(this.userBox2);
            this.panelDown.Controls.Add(this.signUpButton);
            this.panelDown.Controls.Add(this.pictureBox2);
            resources.ApplyResources(this.panelDown, "panelDown");
            this.panelDown.Name = "panelDown";
            // 
            // NameLabel
            // 
            resources.ApplyResources(this.NameLabel, "NameLabel");
            this.NameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.NameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.NameLabel.Name = "NameLabel";
            // 
            // phoneLabel
            // 
            resources.ApplyResources(this.phoneLabel, "phoneLabel");
            this.phoneLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.phoneLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.phoneLabel.Name = "phoneLabel";
            // 
            // addressLabel
            // 
            resources.ApplyResources(this.addressLabel, "addressLabel");
            this.addressLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.addressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.addressLabel.Name = "addressLabel";
            // 
            // passLabel2
            // 
            resources.ApplyResources(this.passLabel2, "passLabel2");
            this.passLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.passLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.passLabel2.Name = "passLabel2";
            // 
            // userLabel2
            // 
            resources.ApplyResources(this.userLabel2, "userLabel2");
            this.userLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.userLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.userLabel2.Name = "userLabel2";
            // 
            // createAccountButton
            // 
            this.createAccountButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.createAccountButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.createAccountButton, "createAccountButton");
            this.createAccountButton.Name = "createAccountButton";
            this.createAccountButton.UseVisualStyleBackColor = false;
            this.createAccountButton.Click += new System.EventHandler(this.createAccountButton_Click_1);
            // 
            // addressBox2
            // 
            this.addressBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.addressBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.addressBox2, "addressBox2");
            this.addressBox2.Name = "addressBox2";
            // 
            // mobileBox2
            // 
            this.mobileBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.mobileBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.mobileBox2, "mobileBox2");
            this.mobileBox2.Name = "mobileBox2";
            // 
            // nameBox2
            // 
            this.nameBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.nameBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.nameBox2, "nameBox2");
            this.nameBox2.Name = "nameBox2";
            // 
            // passwordBox2
            // 
            this.passwordBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.passwordBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.passwordBox2, "passwordBox2");
            this.passwordBox2.Name = "passwordBox2";
            // 
            // userBox2
            // 
            this.userBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.userBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.userBox2, "userBox2");
            this.userBox2.Name = "userBox2";
            // 
            // signUpButton
            // 
            resources.ApplyResources(this.signUpButton, "signUpButton");
            this.signUpButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.signUpButton.FlatAppearance.BorderSize = 0;
            this.signUpButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.UseVisualStyleBackColor = false;
            this.signUpButton.Click += new System.EventHandler(this.signUpButton_Click);
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.panelDown);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PassLabel);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.userNameBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelDown.ResumeLayout(false);
            this.panelDown.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Label PassLabel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Panel panelDown;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button signUpButton;
        private System.Windows.Forms.Button createAccountButton;
        private System.Windows.Forms.TextBox addressBox2;
        private System.Windows.Forms.TextBox mobileBox2;
        private System.Windows.Forms.TextBox nameBox2;
        private System.Windows.Forms.TextBox passwordBox2;
        private System.Windows.Forms.TextBox userBox2;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label passLabel2;
        private System.Windows.Forms.Label userLabel2;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Timer timer1;
    }
}

