using Pay123.Data;
using Pay123.Models;
using Pay123.Services;
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
    public partial class LogInForm : Form
    {
        private User objUser;
        public LogInForm()
        {
            InitializeComponent();
            objUser = new User();
        }

        private void UserData()
        {
            objUser.UserName =  txtUsername.Text;
            objUser.Password = txtPassword.Text;
            
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            UserData();
            bool isTrue;

            using (var db = new Pay123Db())
            {
                isTrue = db.Users.Any(u => u.UserName == objUser.UserName && u.Password == objUser.Password);
               
                if (isTrue)
                {
                    var user = db.Users.Where(u => u.UserName == objUser.UserName && u.Password == objUser.Password).SingleOrDefault();
                    GlobalUser.Username = user.UserName;
                }
                
            }

            if(isTrue)
            {
                Payment123MDI payment123MDI = new Payment123MDI();
                this.Hide();
                payment123MDI.Show();
            }
            else
            {
                MessageBox.Show("Unauthorized credential provided!!!", "Unathorized User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
