using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gabriel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void labasData()
        {
            Class1 db = new Class1();
            dGridView.DataSource = db.selectCmd("Select * from Gabriel");
        }
        public void linis()
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Class1 db = new Class1();
            lblConnection.ForeColor = Color.Green;
            labasData();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string sql = "Insert into Gabriel Values ('"+textBox2.Text+"','"+textBox1.Text+"')";
            Class1 db = new Class1();
            if(db.CudCMD(sql) > 0) {
                linis();
                labasData();
                MessageBox.Show("Record has been updated");
            } else
            {
                MessageBox.Show("Record has not been updated");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string sql = "Delete from Gabriel Where Id ='" + textBox2.Text + "'";
            Class1 db = new Class1();
            if (db.CudCMD(sql) > 0)
            {
                linis();
                labasData();
                MessageBox.Show("Record has been updated");
            }
            else
            {
                MessageBox.Show("Record has not been updated");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                int index = e.RowIndex;
                DataGridViewRow selectedRows = dGridView.Rows[index];
                textBox2.Text = selectedRows.Cells[0].Value.ToString();
                textBox1.Text = selectedRows.Cells[1].Value.ToString();
            } catch
            {

            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            string sql = "Update  Gabriel set Name='" + textBox1.Text 
                 + "'Where Id ='"+textBox2.Text+ "'";
            Class1 db = new Class1();
            if (db.CudCMD(sql) > 0)
            {
                linis();
                labasData();
                MessageBox.Show("Record has been updated");
            }
            else
            {
                MessageBox.Show("Record has not been updated");
            }
        }
    }
}
