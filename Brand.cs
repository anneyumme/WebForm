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
using static System.Net.WebRequestMethods;

namespace Log_in
{
    public partial class Brand : Form
    {
        SqlConnection cn;
        SqlDataAdapter data;
        SqlCommand cm;
        DataTable tb;
        int dk = 0;
        public Brand()
        {
            InitializeComponent();
        }

        public void enable(GroupBox grp, bool b)
        {
            grp.Enabled = b;
        }

        public void showGRD()
        {
            string sql = "select * from brand";
            data = new SqlDataAdapter(sql, cn);
            tb = new DataTable();
            data.Fill(tb);
            grd.DataSource = tb;
        }

        public void formload()
        {
            showGRD();
            enable(grb1, false);
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            dk = 0;
        }
        private void Brand_Load(object sender, EventArgs e)
        {
            string con = "initial catalog = goodsReceived; data source = LAPTOP-RAHH94CV; integrated security = true";
            cn = new SqlConnection(con);
            cn.Open();
            formload();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            enable(grb1, true);
            idTXT.Text = "";
            nameTXT.Text = "";
            TXTDes.Text = "";
            


            nameTXT.Focus();
            btnSave.Enabled = true;
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
            else if (s1 + 1 < 100)
            {
                idTXT.Text = "G" + (s1 + 1).ToString();
            }
            return idTXT.Text;
        }

        private void grd_Click(object sender, EventArgs e)
        {
            idTXT.Text = grd.CurrentRow.Cells[0].Value.ToString();
            nameTXT.Text = grd.CurrentRow.Cells[1].Value.ToString();
            TXTDes.Text = grd.CurrentRow.Cells[2].Value.ToString();
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoodsReceived gr = new GoodsReceived();
            gr.Show();
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            enable(grb1, true);
            idTXT.Enabled = false;
            TXTDes.Focus();
            btnSave.Enabled = true;
            nameTXT.Enabled = false;

            dk = 2;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "delete from brand where ID = '" + idTXT.Text + "'";
                cm = new SqlCommand(sql, cn);
                cm.ExecuteNonQuery();
                formload();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (dk == 1)//Add
            {
                //check primary key
                sql = "select * from brand where ID = '" + idTXT.Text + "'";
                data = new SqlDataAdapter(sql, cn);
                tb = new DataTable();
                data.Fill(tb);
                if (tb.Rows.Count > 0)
                {
                    MessageBox.Show("Brand exists");
                    idTXT.Focus();
                    return;
                }
                //Insert into
                sql = "insert into brand values ('" + idTXT.Text + "','" + nameTXT.Text + "','" + TXTDes.Text + "')";
                cm = new SqlCommand(sql, cn);
                cm.ExecuteNonQuery();
            }
            else //dk =2
            {
                //Update
                sql = "update brand set name = '" + nameTXT.Text + "', description =  '"+TXTDes.Text+"'  where ID = '" + idTXT.Text + "'";
                cm = new SqlCommand(sql, cn);
                cm.ExecuteNonQuery();
            }
            formload();
        }
    }
}
