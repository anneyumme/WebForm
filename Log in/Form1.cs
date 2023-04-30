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
using System.Diagnostics;

namespace Log_in
{
    public partial class Form1 : Form
    {
        SqlConnection cn;
        SqlDataAdapter data;
        SqlCommand cm;
        DataTable tb;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string con = "initial catalog = Login; data source = LAPTOP-RAHH94CV; integrated security = true";
            cn = new SqlConnection(con);
            cn.Open();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            string username, user_password;
            username = txtUser.Text;
            user_password = txtPass.Text;

            try
            {
                string sql = "select * from login_new WHERE username ='"+txtUser.Text+"' AND password = '"+txtPass.Text+"' ";
                data = new SqlDataAdapter(sql,cn);
                tb = new DataTable();
                data.Fill(tb);

                if(tb.Rows.Count > 0 )
                {
                    username = txtUser.Text;
                    user_password = txtPass.Text;

                    //page that needed to be loaded next
                    Menu form2 = new Menu();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!!!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUser.Clear();
                    txtPass.Clear();

                    //focus username
                    txtUser.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
            finally { cn.Close(); }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPass.Clear();

            txtUser.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to exit?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }
    }
}
