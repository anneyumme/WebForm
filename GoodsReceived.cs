using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Log_in
{
    public partial class GoodsReceived : Form
    {
        SqlConnection cn;
        SqlDataAdapter data;
        SqlCommand cm;
        DataTable tb;
        int dk = 0;
        public GoodsReceived()
        {
            InitializeComponent();
        }

        public void enable(GroupBox grp, bool b)
        {
            grp.Enabled = b;
        }

        public void showGRD()
        {
            string sql = "select * from goods";
            data = new SqlDataAdapter(sql, cn);
            tb = new DataTable();
            data.Fill(tb);
            grd.DataSource = tb;
        }

 

        public void formload()
        {
            showGRD();
            enable(grb1, false);
            editBtn.Enabled = false;
            deleteBtn.Enabled = false;
            saveBtn.Enabled = false;
            dk = 0;
        }

        private void GoodsReceived_Load(object sender, EventArgs e)
        {
            string con = "initial catalog = goodsReceived; data source = LAPTOP-RAHH94CV; integrated security = true";
            cn = new SqlConnection(con);
            cn.Open();
            formload();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            enable(grb1, true);
            idTXT.Text = "";
            slTXT.Text = "";
            nameTXT.Text = "";
            priceTXT.Text = "";
            spTXT.Text = "";
       

            nameTXT.Focus();
            saveBtn.Enabled = true;
            idTXT.Enabled = false;
            idTXT.Text = auto();
            dk = 1;
        }
        public string auto()
        {
            int count = 0;
            count = grd.Rows.Count;
            string s = "";
            int s1 = 0;
            s = Convert.ToString(grd.Rows[count - 2].Cells[0].Value);
            s1 = Convert.ToInt32((s.Remove(0, 1)));
            if (s1 + 1 < 10)
            {
                idTXT.Text = "G0" + (s1 + 1).ToString();

            }
            else if (s1 + 1 < 100) {
                idTXT.Text = "G" + (s1 + 1).ToString();
            }
            return idTXT.Text;
        }

        private void grd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grd_Click(object sender, EventArgs e)
        {
            idTXT.Text = grd.CurrentRow.Cells[0].Value.ToString();
            nameTXT.Text = grd.CurrentRow.Cells[1].Value.ToString();
            dtp.Text = grd.CurrentRow.Cells[2].Value.ToString();
            spTXT.Text = grd.CurrentRow.Cells[3].Value.ToString();
            priceTXT.Text = grd.CurrentRow.Cells[6].Value.ToString();
            slTXT.Text = grd.CurrentRow.Cells[4].Value.ToString();
            TXTBrand.Text = grd.CurrentRow.Cells[5].Value.ToString();
            deleteBtn.Enabled = true;
            editBtn.Enabled = true;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            enable(grb1, true);
            idTXT.Enabled = false;
            dtp.Enabled = false;
            slTXT.Focus();
            saveBtn.Enabled = true;

            dk = 2;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "delete from goods where ID = '" + idTXT.Text + "'";
                cm = new SqlCommand(sql, cn);
                cm.ExecuteNonQuery();
                formload();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (dk == 1)//Add
            {
                //check primary key
                sql = "select * from goods where ID = '" + idTXT.Text + "'";
                data = new SqlDataAdapter(sql, cn);
                tb = new DataTable();
                data.Fill(tb);
                if (tb.Rows.Count > 0)
                {
                    MessageBox.Show("Goods exists");
                    idTXT.Focus();
                    return;
                }
                //Insert into
                sql = "insert into goods values ('" + idTXT.Text + "','" + nameTXT.Text + "','" + dtp.Value.ToShortDateString() + "', '" + spTXT.Text + "', " + slTXT.Text + ", '" + TXTBrand.Text + "','"+priceTXT.Text+"')";
                cm = new SqlCommand(sql, cn);
                cm.ExecuteNonQuery();
            }
            else //dk =2
            {
                //Update
                sql = "update goods set nameG = '" + nameTXT.Text + "', dateRe = '" + dtp.Value.ToShortDateString() + "', supplier = '" + spTXT.Text + "', quantity = " + slTXT.Text + ", brand = '" + TXTBrand.Text + "',price = '"+priceTXT.Text+"' where ID = '" + idTXT.Text + "'";
                cm = new SqlCommand(sql, cn);
                cm.ExecuteNonQuery();
            }
            formload();
            addBtn.Focus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Hide();    
        }

        private void TXTBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }

        private void TXTBrand_Click(object sender, EventArgs e)
        {
            
        }

        private void TXTBrand_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
