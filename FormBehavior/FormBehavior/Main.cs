using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormBehavior
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void mnuPessoaFisica_Click(object sender, EventArgs e)
        {
            Customer form = new Customer();
            form.Show();
        }

        private void mnuSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Close application", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Environment.Exit(4);
            }
            else if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
