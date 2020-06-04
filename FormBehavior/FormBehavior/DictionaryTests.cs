using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormBehavior
{
    public partial class DictionaryTests : Form
    {
        List<List<string>> matriz = new List<List<string>>();
        int currentIndex = -1;

        public DictionaryTests()
        {
            InitializeComponent();            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> data = new List<string>();

            String name = txtName.Text;
            String email = txtEmail.Text;
            String password = txtPassword.Text;

            data.Add(name);
            data.Add(email);
            data.Add(password);

            matriz.Add(data);

            //MessageBox.Show(matriz[0][0] + " e " + matriz[0][1]);
            //dgvDictionary.Rows.Add(data[0], data[1], data[2]);
        }

        private void dgvDictionary_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //int index = dgvDictionary.Rows[e.RowIndex].Index;
            //int index = dgvDictionary.CurrentRow.Index;
            //int index = dgvDictionary.CurrentCell.RowIndex;
            int index = e.RowIndex;
            currentIndex = index;

            if (currentIndex >= 0)
            {
                txtName.Text = matriz[index][0];
                txtEmail.Text = matriz[index][1];
                txtPassword.Text = matriz[index][2];
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dgvDictionary.Rows.Clear();

            for (int i = 0; i < matriz.Count; i++)
            {
                dgvDictionary.Rows.Add(matriz[i][0], matriz[i][1], matriz[i][2]);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (currentIndex >= 0)
            {
                matriz[currentIndex][0] = txtName.Text;
                matriz[currentIndex][1] = txtEmail.Text;
                matriz[currentIndex][2] = txtPassword.Text;

                dgvDictionary.Rows[currentIndex].Cells[0].Value = txtName.Text;
                dgvDictionary.Rows[currentIndex].Cells[1].Value = txtEmail.Text;
                dgvDictionary.Rows[currentIndex].Cells[2].Value = txtPassword.Text;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentIndex >= 0)
            {
                matriz.RemoveAt(currentIndex);
                dgvDictionary.Rows.RemoveAt(currentIndex);
            }
        }
    }
}
