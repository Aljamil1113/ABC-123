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
    public partial class Payment123MDI : Form
    {
        Payment123 objPayment123 = null;
        PaymentAbout objPaymentAbout = null;
        RegisterUser objRegisterUser = null;
        SuccessPaymentsForm objSuccessPaymentsForm = null;
        public Payment123MDI()
        {
            InitializeComponent();
        }

        private void processPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(objPayment123 == null)
            {
                objPayment123 = new Payment123();
                objPayment123.MdiParent = this;
                objPayment123.FormClosed += objPayment123_FormClosed;
                objPayment123.Show();
            }
            else
            {
                objPayment123.Activate();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(objPaymentAbout == null)
            {
                objPaymentAbout = new PaymentAbout();
                objPaymentAbout.MdiParent = this;
                objPaymentAbout.FormClosed += objPaymentAbout_FormClosed;
                objPaymentAbout.Show();
            }
            else
            {
                objPaymentAbout.Activate();
            }
        }

        private void registeruserToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(objRegisterUser == null)
            {
                objRegisterUser = new RegisterUser();
                objRegisterUser.MdiParent = this;
                objRegisterUser.FormClosed += objRegisterUser_FormClosed;
                objRegisterUser.Show();
            }
            else
            {
                objRegisterUser.Activate();
            }
        }

        private void successfulPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(objSuccessPaymentsForm == null)
            {
                objSuccessPaymentsForm = new SuccessPaymentsForm();
                objSuccessPaymentsForm.MdiParent = this;
                objSuccessPaymentsForm.FormClosed += objSuccessPaymentsForm_FormClosed;
                objSuccessPaymentsForm.Show();
            }
            else
            {
                objSuccessPaymentsForm.Activate();
            }
        }

        private void objSuccessPaymentsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            objSuccessPaymentsForm = null;
        }

        private void objRegisterUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            objRegisterUser = null;
        }

        private void objPaymentAbout_FormClosed(object sender, FormClosedEventArgs e)
        {
            objPaymentAbout = null;
        }

        private void objPayment123_FormClosed(object sender, FormClosedEventArgs e)
        {
            objPayment123 = null;
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void arrangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }
    }
}
