using Pay123.Data;
using Pay123.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pay123
{
    public partial class RegisterUser : Form
    {
        
        private User objUser;
        public RegisterUser()
        {
            InitializeComponent();
            
            objUser = new User();
            LoadData();
            ClearControls();
        }

        #region CHECK VALID PASSWORD
        private int CheckNumeric(string strPassword)
        {
            int numberOfDigits = 0;

            foreach (char ch in strPassword)
            {
                if (char.IsDigit(ch))
                    numberOfDigits++;
            }

            return numberOfDigits;
        }

        private int CheckLowerCase(string strPassword)
        {
            int numOfLowercase = 0;

            foreach (char cd in strPassword)
            {
                if (char.IsLower(cd))
                    numOfLowercase++;
            }
            return numOfLowercase;
        }

        private int checkUpperCase(string strPassword)
        {
            int numOfUppercase = 0;
            foreach (var ch in strPassword)
            {
                if (char.IsUpper(ch))
                    numOfUppercase++;
            }

            return numOfUppercase;
        }
        #endregion

        private bool isRegisterControlValid()
        {
            if (txtRegisterUsername.Text.Length == 0)
            {
                MessageBox.Show("Please enter username.", "Data Enter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegisterUsername.Focus();
                return false;
            }

            //Password must be a minimum of 8 characters long
            //Password must contain at least one uppercase letter
            //Password must contain at least one lowercase letter
            //Password must contain at least one numeric digit

            if (txtPasswordRegister.Text.Length == 0)
            {
                MessageBox.Show("Please enter password.", "Data Enter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPasswordRegister.Focus();
                return false;
            }
            else
            {
                if (txtPasswordRegister.Text.Length < 8 || CheckNumeric(txtPasswordRegister.Text) < 1 ||
                    CheckLowerCase(txtPasswordRegister.Text) < 1 || checkUpperCase(txtPasswordRegister.Text) < 1)
                {
                    MessageBox.Show("Please enter a valid password. \n\nHint: \n\tPassword must be a minimum of 8 characters long. \n\t" +
                        "Password must contain at least one uppercase letter. \n\t" + "Password must contain at least one lowercase letter. \n\t" +
                        "Password must contain at least one numeric digit.",
                        "Data Enter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPasswordRegister.Focus();
                    return false;
                }
            }

            if (txtConfirmPasswordRegister.Text.Length == 0)
            {
                MessageBox.Show("Please enter confirm password.", "Data Enter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPasswordRegister.Focus();
                return false;
            }
            else
            {
                if (txtConfirmPasswordRegister.Text != txtPasswordRegister.Text)
                {
                    MessageBox.Show("Both password do not match, please try again!.", "Data Enter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtConfirmPasswordRegister.Focus();
                    return false;
                }
            }        
            return true;
        }


        private void ClearControls()
        {
            txtRegisterUsername.Text = "";
            txtPasswordRegister.Text = "";
            txtConfirmPasswordRegister.Text = "";
        }

        private void LoadData()
        {
            using (var pay123Db = new Pay123Db())
            {
                var users = pay123Db.Users.ToList();

                registeredUserDataGridView.DataSource = users;
                registeredUserDataGridView.Columns["UserId"].Visible = false;
                registeredUserDataGridView.Columns["Password"].Visible = false;

            }
                
        }

        private void UserData()
        {
            objUser.UserId = Convert.ToInt32(numUserId.Value);
            objUser.UserName = txtRegisterUsername.Text;
            objUser.Password = txtPasswordRegister.Text;
        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            objUser = new User();
            this.UserData();

            if(isRegisterControlValid())
            {
                using (var pay123Db = new Pay123Db())
                {
                    pay123Db.Users.Add(objUser);
                    pay123Db.SaveChanges();
                }
                    
            }

            this.LoadData();
            this.ClearControls();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (isRegisterControlValid())
            {
                int id = Convert.ToInt32(numUserId.Value);
                using (var pay123Db = new Pay123Db())
                {
                    var userDb = pay123Db.Users.Where(u => u.UserId == id).FirstOrDefault();
                    userDb.UserName = txtRegisterUsername.Text;
                    userDb.Password = txtPasswordRegister.Text;
                    pay123Db.SaveChanges();
                }

            }
            this.LoadData();
            this.ClearControls();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            DialogResult objDialog = MessageBox.Show("Are you sure you want to remove this record?", "Confirm record Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (objDialog == DialogResult.Yes)
            {
                int id = Convert.ToInt32(numUserId.Value);
                using (var pay123Db = new Pay123Db())
                {
                    var userDb = pay123Db.Users.Where(u => u.UserId == id).FirstOrDefault();
                    pay123Db.Users.Remove(userDb);
                    pay123Db.SaveChanges();
                }

                this.LoadData();
                this.ClearControls();
            }
        }

        private void registeredUserDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellCollection cells = registeredUserDataGridView.CurrentRow.Cells;
            numUserId.Value = Convert.ToDecimal(cells[0].Value.ToString());
            txtRegisterUsername.Text = cells[1].Value.ToString();
            txtPasswordRegister.Text = cells[2].Value.ToString();
        }
    }
}
