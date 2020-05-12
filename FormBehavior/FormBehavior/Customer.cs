using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormBehavior
{
    public partial class Customer : Form
    {
        // XML
        // JSON
        // CSV
        // XLS - !!!
        static String path = AppDomain.CurrentDomain.BaseDirectory + "data";
        static String file = path + "/Customer.txt";

        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Console.WriteLine("Pressed keys enter");
                SendKeys.Send("{TAB}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtName.Text.Trim())) {
            //if (String.IsNullOrEmpty(txtName.Text)) {

            //if (String.IsNullOrWhiteSpace(txtName.Text)) {

            //if (txtName.Text.Length == 0) {
            //if (txtName.Text.Trim().Length == 0) {

            //if (txtName.Text == "") {
            //if (txtName.Text.Trim() == "") {

            
            if ( String.IsNullOrWhiteSpace( txtName.Text ) )
            {
                // MessageBox.Show("Name is required");
                erpCustomer.SetError(txtName, "Name is required");

                txtName.BackColor = Color.FromArgb(250, 128, 114);
            }
            else
            {
                erpCustomer.SetError(txtName, "");

                txtName.BackColor = Color.FromName("Window");
            }

            if (String.IsNullOrWhiteSpace(txtEmail.Text))
            {
                erpCustomer.SetError(txtEmail, "E-mail is required");

                txtEmail.BackColor = Color.FromArgb(250, 128, 114);
            }
            else
            {
                erpCustomer.SetError(txtEmail, "");

                txtEmail.BackColor = Color.FromName("Window");
            }

            mktPostalCode.Mask = "";

            if (mktPostalCode.Text == "     -")
            //if (mktPostalCode.Mask == mktPostalCode.Text)
            {
                erpCustomer.SetError(mktPostalCode, "CEP is required");

                mktPostalCode.BackColor = Color.FromArgb(250, 128, 114);
            }
            else
            {
                erpCustomer.SetError(mktPostalCode, "");

                mktPostalCode.BackColor = Color.FromName("Window");
            }

            // = Atribuição 
            // == Comparar valores
            // != Diferente
            if ( txtPass.Text != txtConPass.Text)
            {
                erpCustomer.SetError(txtConPass, "Passwords does not match");

                txtConPass.BackColor = Color.FromArgb(250, 128, 114);
            }
            else
            {
                erpCustomer.SetError(txtConPass, "");

                txtConPass.BackColor = Color.FromName("Window");
            }


            bool checkDirExist = Directory.Exists(path);
            //if (checkDirExist == false)
            //if (!checkDirExist == true)
            if (!checkDirExist)
                Directory.CreateDirectory(path);
            

            String line = txtName.Text + "|" + txtEmail.Text + "|" + txtPass.Text + "|" + mktPostalCode.Text + "|" + mktCnpj.Text;

            bool checkFileExist = File.Exists(file);

            if (!checkFileExist)
            {
                using (StreamWriter sw = File.CreateText(file))
                {
                    sw.WriteLine(line);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(file))
                {
                    sw.WriteLine(line);
                }
            }


        }
    }
}
