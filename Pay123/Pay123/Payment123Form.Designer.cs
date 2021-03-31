
namespace Pay123
{
    partial class Payment123
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
            this.paymentDataGridView = new System.Windows.Forms.DataGridView();
            this.btnShowDetails = new System.Windows.Forms.Button();
            this.btnRefreshPay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreviousPayment = new System.Windows.Forms.Button();
            this.lblPagePayment = new System.Windows.Forms.Label();
            this.btnNextPayment = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblUsernameValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // paymentDataGridView
            // 
            this.paymentDataGridView.BackgroundColor = System.Drawing.Color.Gold;
            this.paymentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paymentDataGridView.Location = new System.Drawing.Point(12, 76);
            this.paymentDataGridView.Name = "paymentDataGridView";
            this.paymentDataGridView.RowHeadersWidth = 51;
            this.paymentDataGridView.RowTemplate.Height = 24;
            this.paymentDataGridView.Size = new System.Drawing.Size(875, 362);
            this.paymentDataGridView.TabIndex = 0;
            this.paymentDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.paymentDataGridView_CellClick);
            // 
            // btnShowDetails
            // 
            this.btnShowDetails.BackColor = System.Drawing.Color.Aqua;
            this.btnShowDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowDetails.Location = new System.Drawing.Point(717, 503);
            this.btnShowDetails.Name = "btnShowDetails";
            this.btnShowDetails.Size = new System.Drawing.Size(169, 36);
            this.btnShowDetails.TabIndex = 1;
            this.btnShowDetails.Text = "Show Details";
            this.btnShowDetails.UseVisualStyleBackColor = false;
            this.btnShowDetails.Click += new System.EventHandler(this.btnShowDetails_Click);
            // 
            // btnRefreshPay
            // 
            this.btnRefreshPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshPay.Location = new System.Drawing.Point(558, 503);
            this.btnRefreshPay.Name = "btnRefreshPay";
            this.btnRefreshPay.Size = new System.Drawing.Size(143, 36);
            this.btnRefreshPay.TabIndex = 2;
            this.btnRefreshPay.Text = "Refresh";
            this.btnRefreshPay.UseVisualStyleBackColor = true;
            this.btnRefreshPay.Click += new System.EventHandler(this.btnRefreshPay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select a record here to process payments...";
            // 
            // btnPreviousPayment
            // 
            this.btnPreviousPayment.Location = new System.Drawing.Point(318, 444);
            this.btnPreviousPayment.Name = "btnPreviousPayment";
            this.btnPreviousPayment.Size = new System.Drawing.Size(75, 31);
            this.btnPreviousPayment.TabIndex = 4;
            this.btnPreviousPayment.Text = "<<<";
            this.btnPreviousPayment.UseVisualStyleBackColor = true;
            this.btnPreviousPayment.Click += new System.EventHandler(this.btnPreviousPayment_Click);
            // 
            // lblPagePayment
            // 
            this.lblPagePayment.AutoSize = true;
            this.lblPagePayment.Location = new System.Drawing.Point(408, 451);
            this.lblPagePayment.Name = "lblPagePayment";
            this.lblPagePayment.Size = new System.Drawing.Size(0, 17);
            this.lblPagePayment.TabIndex = 5;
            this.lblPagePayment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNextPayment
            // 
            this.btnNextPayment.Location = new System.Drawing.Point(497, 444);
            this.btnNextPayment.Name = "btnNextPayment";
            this.btnNextPayment.Size = new System.Drawing.Size(75, 31);
            this.btnNextPayment.TabIndex = 6;
            this.btnNextPayment.Text = ">>>";
            this.btnNextPayment.UseVisualStyleBackColor = true;
            this.btnNextPayment.Click += new System.EventHandler(this.btnNextPayment_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(643, 23);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(75, 29);
            this.lblUsername.TabIndex = 7;
            this.lblUsername.Text = "User:";
            // 
            // lblUsernameValue
            // 
            this.lblUsernameValue.AutoSize = true;
            this.lblUsernameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameValue.Location = new System.Drawing.Point(724, 23);
            this.lblUsernameValue.Name = "lblUsernameValue";
            this.lblUsernameValue.Size = new System.Drawing.Size(0, 29);
            this.lblUsernameValue.TabIndex = 8;
            // 
            // Payment123
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tomato;
            this.ClientSize = new System.Drawing.Size(902, 551);
            this.Controls.Add(this.lblUsernameValue);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnNextPayment);
            this.Controls.Add(this.lblPagePayment);
            this.Controls.Add(this.btnPreviousPayment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefreshPay);
            this.Controls.Add(this.btnShowDetails);
            this.Controls.Add(this.paymentDataGridView);
            this.Name = "Payment123";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "123 Payment";
            this.Load += new System.EventHandler(this.Payment123_Load);
            ((System.ComponentModel.ISupportInitialize)(this.paymentDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView paymentDataGridView;
        private System.Windows.Forms.Button btnShowDetails;
        private System.Windows.Forms.Button btnRefreshPay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPreviousPayment;
        private System.Windows.Forms.Label lblPagePayment;
        private System.Windows.Forms.Button btnNextPayment;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblUsernameValue;
    }
}

