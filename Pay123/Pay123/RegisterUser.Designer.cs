
namespace Pay123
{
    partial class RegisterUser
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
            this.grpRegisterUser = new System.Windows.Forms.GroupBox();
            this.numUserId = new System.Windows.Forms.NumericUpDown();
            this.txtConfirmPasswordRegister = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtPasswordRegister = new System.Windows.Forms.TextBox();
            this.txtRegisterUsername = new System.Windows.Forms.TextBox();
            this.lblPasswordRegister = new System.Windows.Forms.Label();
            this.lblUserRegister = new System.Windows.Forms.Label();
            this.grpRegisteredUser = new System.Windows.Forms.GroupBox();
            this.registeredUserDataGridView = new System.Windows.Forms.DataGridView();
            this.btnRegisterUser = new System.Windows.Forms.Button();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.grpRegisterUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUserId)).BeginInit();
            this.grpRegisteredUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registeredUserDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // grpRegisterUser
            // 
            this.grpRegisterUser.Controls.Add(this.numUserId);
            this.grpRegisterUser.Controls.Add(this.txtConfirmPasswordRegister);
            this.grpRegisterUser.Controls.Add(this.lblConfirmPassword);
            this.grpRegisterUser.Controls.Add(this.txtPasswordRegister);
            this.grpRegisterUser.Controls.Add(this.txtRegisterUsername);
            this.grpRegisterUser.Controls.Add(this.lblPasswordRegister);
            this.grpRegisterUser.Controls.Add(this.lblUserRegister);
            this.grpRegisterUser.Location = new System.Drawing.Point(31, 41);
            this.grpRegisterUser.Name = "grpRegisterUser";
            this.grpRegisterUser.Size = new System.Drawing.Size(329, 338);
            this.grpRegisterUser.TabIndex = 0;
            this.grpRegisterUser.TabStop = false;
            this.grpRegisterUser.Text = "Register User";
            // 
            // numUserId
            // 
            this.numUserId.Location = new System.Drawing.Point(184, 48);
            this.numUserId.Name = "numUserId";
            this.numUserId.Size = new System.Drawing.Size(120, 22);
            this.numUserId.TabIndex = 6;
            this.numUserId.Visible = false;
            // 
            // txtConfirmPasswordRegister
            // 
            this.txtConfirmPasswordRegister.Location = new System.Drawing.Point(160, 197);
            this.txtConfirmPasswordRegister.Name = "txtConfirmPasswordRegister";
            this.txtConfirmPasswordRegister.PasswordChar = '*';
            this.txtConfirmPasswordRegister.Size = new System.Drawing.Size(163, 22);
            this.txtConfirmPasswordRegister.TabIndex = 5;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(16, 202);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(125, 17);
            this.lblConfirmPassword.TabIndex = 4;
            this.lblConfirmPassword.Text = "Confirm Password:";
            // 
            // txtPasswordRegister
            // 
            this.txtPasswordRegister.Location = new System.Drawing.Point(160, 142);
            this.txtPasswordRegister.Name = "txtPasswordRegister";
            this.txtPasswordRegister.PasswordChar = '*';
            this.txtPasswordRegister.Size = new System.Drawing.Size(163, 22);
            this.txtPasswordRegister.TabIndex = 3;
            // 
            // txtRegisterUsername
            // 
            this.txtRegisterUsername.Location = new System.Drawing.Point(160, 88);
            this.txtRegisterUsername.Name = "txtRegisterUsername";
            this.txtRegisterUsername.Size = new System.Drawing.Size(163, 22);
            this.txtRegisterUsername.TabIndex = 2;
            // 
            // lblPasswordRegister
            // 
            this.lblPasswordRegister.AutoSize = true;
            this.lblPasswordRegister.Location = new System.Drawing.Point(16, 142);
            this.lblPasswordRegister.Name = "lblPasswordRegister";
            this.lblPasswordRegister.Size = new System.Drawing.Size(73, 17);
            this.lblPasswordRegister.TabIndex = 1;
            this.lblPasswordRegister.Text = "Password:";
            // 
            // lblUserRegister
            // 
            this.lblUserRegister.AutoSize = true;
            this.lblUserRegister.Location = new System.Drawing.Point(16, 88);
            this.lblUserRegister.Name = "lblUserRegister";
            this.lblUserRegister.Size = new System.Drawing.Size(77, 17);
            this.lblUserRegister.TabIndex = 0;
            this.lblUserRegister.Text = "Username:";
            // 
            // grpRegisteredUser
            // 
            this.grpRegisteredUser.Controls.Add(this.registeredUserDataGridView);
            this.grpRegisteredUser.Location = new System.Drawing.Point(374, 41);
            this.grpRegisteredUser.Name = "grpRegisteredUser";
            this.grpRegisteredUser.Size = new System.Drawing.Size(524, 338);
            this.grpRegisteredUser.TabIndex = 1;
            this.grpRegisteredUser.TabStop = false;
            this.grpRegisteredUser.Text = "Registered User";
            // 
            // registeredUserDataGridView
            // 
            this.registeredUserDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.registeredUserDataGridView.Location = new System.Drawing.Point(29, 33);
            this.registeredUserDataGridView.Name = "registeredUserDataGridView";
            this.registeredUserDataGridView.RowHeadersWidth = 51;
            this.registeredUserDataGridView.RowTemplate.Height = 24;
            this.registeredUserDataGridView.Size = new System.Drawing.Size(473, 274);
            this.registeredUserDataGridView.TabIndex = 0;
            this.registeredUserDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.registeredUserDataGridView_CellClick);
            // 
            // btnRegisterUser
            // 
            this.btnRegisterUser.BackColor = System.Drawing.Color.Gold;
            this.btnRegisterUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterUser.Location = new System.Drawing.Point(31, 444);
            this.btnRegisterUser.Name = "btnRegisterUser";
            this.btnRegisterUser.Size = new System.Drawing.Size(165, 35);
            this.btnRegisterUser.TabIndex = 2;
            this.btnRegisterUser.Text = "Register User";
            this.btnRegisterUser.UseVisualStyleBackColor = false;
            this.btnRegisterUser.Click += new System.EventHandler(this.btnRegisterUser_Click);
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.BackColor = System.Drawing.Color.Gold;
            this.btnUpdateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateUser.Location = new System.Drawing.Point(230, 444);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(206, 35);
            this.btnUpdateUser.TabIndex = 3;
            this.btnUpdateUser.Text = "Update User";
            this.btnUpdateUser.UseVisualStyleBackColor = false;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Gold;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(480, 444);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(182, 35);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.Gold;
            this.btnDeleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.Location = new System.Drawing.Point(697, 443);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(179, 35);
            this.btnDeleteUser.TabIndex = 5;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // RegisterUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(910, 528);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnUpdateUser);
            this.Controls.Add(this.btnRegisterUser);
            this.Controls.Add(this.grpRegisteredUser);
            this.Controls.Add(this.grpRegisterUser);
            this.Name = "RegisterUser";
            this.Text = "Register User";
            this.grpRegisterUser.ResumeLayout(false);
            this.grpRegisterUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUserId)).EndInit();
            this.grpRegisteredUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.registeredUserDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRegisterUser;
        private System.Windows.Forms.GroupBox grpRegisteredUser;
        private System.Windows.Forms.DataGridView registeredUserDataGridView;
        private System.Windows.Forms.TextBox txtPasswordRegister;
        private System.Windows.Forms.TextBox txtRegisterUsername;
        private System.Windows.Forms.Label lblPasswordRegister;
        private System.Windows.Forms.Label lblUserRegister;
        private System.Windows.Forms.Button btnRegisterUser;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.TextBox txtConfirmPasswordRegister;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.NumericUpDown numUserId;
    }
}