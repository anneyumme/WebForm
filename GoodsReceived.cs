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
            string sql = "select * from Products";
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
            string con = "Server=tcp:anne.database.windows.net,1433;Initial Catalog=Final_project;Persist Security Info=False;User ID=ninhdong;Password=8FtLt4P#$HL9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            cn = new SqlConnection(con);
            cn.Open();
            formload();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            enable(grb1, true);
            idTXT.Text = "";
            modelTXT.Text = "";
            nameTXT.Text = "";
            priceTXT.Text = "";
            desTXT.Text = "";
            brandTXT.Text = "";
            imageTXT.Text = "";
            yearTXT.Text = "";
            price100TXT.Text = "";
            price50TXT.Text = "";

            idTXT.Enabled= false;
            imageTXT.Enabled= false;
            nameTXT.Focus();
            saveBtn.Enabled = true;
       
            dk = 1;
        }

        private void grd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grd_Click(object sender, EventArgs e)
        {
            idTXT.Text = grd.CurrentRow.Cells[0].Value.ToString();
            modelTXT.Text = grd.CurrentRow.Cells[1].Value.ToString();
            desTXT.Text = grd.CurrentRow.Cells[2].Value.ToString();
            price50TXT.Text = grd.CurrentRow.Cells[3].Value.ToString();
            nameTXT.Text = grd.CurrentRow.Cells[4].Value.ToString();
            brandTXT.Text = grd.CurrentRow.Cells[5].Value.ToString();
            imageTXT.Text = grd.CurrentRow.Cells[6].Value.ToString();
            yearTXT.Text = grd.CurrentRow.Cells[7].Value.ToString();
            price100TXT.Text = grd.CurrentRow.Cells[8].Value.ToString();
            price50TXT.Text = grd.CurrentRow.Cells[9].Value.ToString();

            deleteBtn.Enabled = true;
            editBtn.Enabled = true;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            enable(grb1, true);
            idTXT.Enabled = false;
            brandTXT.Enabled = false;
            imageTXT.Enabled= false;
            nameTXT.Focus();
            saveBtn.Enabled = true;

            dk = 2;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "delete from Products where id = '" + idTXT.Text + "'";
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
                sql = "select * from Products where id = '" + idTXT.Text + "'";
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
                if (brandTXT.Text == "Samsung")
                {

                    sql = "insert into Products (model,description,price,name,brandId,year,price100,price50) values ('" + modelTXT.Text + "','" + desTXT.Text + "', '" + priceTXT.Text + "', '" + nameTXT.Text + "', '10','" + yearTXT.Text + "','" + price100TXT.Text + "','" + price50TXT.Text + "')";
                    cm = new SqlCommand(sql, cn);
                    cm.ExecuteNonQuery();
                }
                else if (brandTXT.Text == "Xiaomi")
                {
                    sql = "insert into Products (model,description,price,name,brandId,year,price100,price50) values ('" + modelTXT.Text + "','" + desTXT.Text + "', '" + priceTXT.Text + "', '" + nameTXT.Text + "', '11','" + yearTXT.Text + "','" + price100TXT.Text + "','" + price50TXT.Text + "')";
                    cm = new SqlCommand(sql, cn);
                    cm.ExecuteNonQuery();
                }
                else
                {
                    sql = "insert into Products (model,description,price,name,brandId,year,price100,price50) values ('" + modelTXT.Text + "','" + desTXT.Text + "', '" + priceTXT.Text + "', '" + nameTXT.Text + "', '12','" + yearTXT.Text + "','" + price100TXT.Text + "','" + price50TXT.Text + "')";
                    cm = new SqlCommand(sql, cn);
                    cm.ExecuteNonQuery();
                }
                
            }
            else //dk =2
            {
                //Update
                if (brandTXT.Text == "Samsung")
                {
                    sql = "update Products set model = '" + modelTXT.Text + "', description = '" + desTXT.Text + "', price = '" + priceTXT.Text + "', name = '" + nameTXT.Text + "', brandId = '10',imageUrl = '" + imageTXT.Text + "', year ='" + yearTXT.Text + "', price100 = '" + price100TXT.Text + "', price50 ='" + price50TXT.Text + "' where id = '" + idTXT.Text + "'";
                    cm = new SqlCommand(sql, cn);
                    cm.ExecuteNonQuery();
                }
                else if (brandTXT.Text == "Xiaomi")
                {
                    sql = "update Products set model = '" + modelTXT.Text + "', description = '" + desTXT.Text + "', price = '" + priceTXT.Text + "', name = '" + nameTXT.Text + "', brandId = '11',imageUrl = '" + imageTXT.Text + "', year ='" + yearTXT.Text + "', price100 = '" + price100TXT.Text + "', price50 ='" + price50TXT.Text + "' where id = '" + idTXT.Text + "'";
                    cm = new SqlCommand(sql, cn);
                    cm.ExecuteNonQuery();
                }
                else
                {
                    sql = "update Products set model = '" + modelTXT.Text + "', description = '" + desTXT.Text + "', price = '" + priceTXT.Text + "', name = '" + nameTXT.Text + "', brandId = '12',imageUrl = '" + imageTXT.Text + "', year ='" + yearTXT.Text + "', price100 = '" + price100TXT.Text + "', price50 ='" + price50TXT.Text + "' where id = '" + idTXT.Text + "'";
                    cm = new SqlCommand(sql, cn);
                    cm.ExecuteNonQuery();
                }
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
