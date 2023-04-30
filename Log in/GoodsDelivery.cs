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
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Org.BouncyCastle.Bcpg;

namespace Log_in
{
    public partial class GoodsDelivery : Form
    {
        SqlConnection cn;
        SqlDataAdapter data;
        SqlCommand cm;
        DataTable tb;
        int dk = 0;
        public GoodsDelivery()
        {
            InitializeComponent();
        }

        public void enable(GroupBox grp, bool b)
        {
            grp.Enabled = b;
        }

        public void showGRD()
        {
            string sql = "select * from delivery";
            data = new SqlDataAdapter(sql, cn);
            tb = new DataTable();
            data.Fill(tb);
            grd.DataSource = tb;
        }

        public void formload()
        {
            showGRD();
            enable(grb1, false);
            dk = 0;
        }

        private void GoodsDelivery_Load(object sender, EventArgs e)
        {
            string con = "initial catalog = goodsReceived; data source = LAPTOP-RAHH94CV; integrated security = true";
            cn = new SqlConnection(con);
            cn.Open();
            formload();
        }

        private void grd_Click(object sender, EventArgs e)
        {
            txtDeli.Text = grd.CurrentRow.Cells[0].Value.ToString();
            dtp.Text = grd.CurrentRow.Cells[1].Value.ToString();
            txtAgent.Text = grd.CurrentRow.Cells[2].Value.ToString();
            txtProduct.Text = grd.CurrentRow.Cells[3].Value.ToString();
            txtgoods.Text = grd.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text = grd.CurrentRow.Cells[5].Value.ToString();
            txtPayment.Text = grd.CurrentRow.Cells[6].Value.ToString();
            txtQuality.Text = grd.CurrentRow.Cells[7].Value.ToString();
            txtPrice.Text = grd.CurrentRow.Cells[8].Value.ToString();

            btnUpdate.Enabled = true;
            btnPrint.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            enable(grb1, true);
            txtDeli.Text = "";
            txtAgent.Text = "";
            txtProduct.Text = "";
            txtgoods.Text = "Not transfer";
            txtPayment.Text = "Not complete";
            txtPrice.Text = "";
            txtQuality.Text = "";

            dtp.Focus();
            txtDeli.Text = auto();
            txtAgent.Text = auto1();
            txtProduct.Text = auto2();
            txtDeli.Enabled = false;
            txtAgent.Enabled = false;
            txtProduct.Enabled = false;
            txtgoods.Enabled = false;
            txtPayment.Enabled = false;
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
                txtDeli.Text = "D0" + (s1 + 1).ToString();

            }
            else if (s1 + 1 < 100)
            {
                txtDeli.Text = "G" + (s1 + 1).ToString();
            }
            return txtDeli.Text;
        }

        public string auto1()
        {
            int count = 0;
            count = grd.Rows.Count;
            string s = "";
            int s1 = 0;
            s = Convert.ToString(grd.Rows[count - 2].Cells[0].Value);
            s1 = Convert.ToInt32((s.Remove(0, 1)));
            if (s1 + 1 < 10)
            {
                txtAgent.Text = "E0" + (s1 + 1).ToString();

            }
            else if (s1 + 1 < 100)
            {
                txtAgent.Text = "E" + (s1 + 1).ToString();
            }
            return txtAgent.Text;
        }

        public string auto2()
        {
            int count = 0;
            count = grd.Rows.Count;
            string s = "";
            int s1 = 0;
            s = Convert.ToString(grd.Rows[count - 2].Cells[0].Value);
            s1 = Convert.ToInt32((s.Remove(0, 1)));
            if (s1 + 1 < 10)
            {
                txtProduct.Text = "G0" + (s1 + 1).ToString();

            }
            else if (s1 + 1 < 100)
            {
                txtProduct.Text = "G" + (s1 + 1).ToString();
            }
            return txtProduct.Text;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (dk == 1)//Add
            {
                //check primary key
                sql = "select * from delivery where deliveryID = '" + txtDeli.Text + "'";
                data = new SqlDataAdapter(sql, cn);
                tb = new DataTable();
                data.Fill(tb);
                if (tb.Rows.Count > 0)
                {
                    MessageBox.Show("Exists");
                    txtDeli.Focus();
                    return;
                }
                //Insert into
                sql = "insert into delivery values ('" + txtDeli.Text + "','" + dtp.Value.ToShortDateString() + "','" + txtAgent.Text + "','" + txtProduct.Text + "','" + txtgoods.Text + "','" + comboBox1.Text + "','" + txtPayment.Text + "'," + txtQuality.Text + "," + txtPrice.Text + ")";
                cm = new SqlCommand(sql, cn);
                cm.ExecuteNonQuery();
            }
            formload();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (txtPayment.Text == "Complete")
            {
                MessageBox.Show("The agent has already paid");
                return;
            }
            else if(comboBox1.Text == "By Cash")
            {
                MessageBox.Show("The agent will pay by cashing");
                return;
            }
            else
            {
                if (MessageBox.Show("Are you sure that the agent has paid the invoice?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sql = "update delivery set deliveryDate = '" + dtp.Value.ToShortDateString() + "', agentID = '" + txtAgent.Text + "', productID = '" + txtProduct.Text + "', status = '" + txtgoods.Text + "', paymentMethods = '" + comboBox1.Text + "', paymentStatus = 'Complete', quantity = " + txtQuality.Text + ", price = " + txtPrice.Text + " where deliveryID = '" + txtDeli.Text + "'";
                    cm = new SqlCommand(sql, cn);
                    cm.ExecuteNonQuery();
                }
            }
            formload();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from delivery where deliveryID = '" + txtDeli.Text + "'";
            cm = new SqlCommand(sql, cn);
            cm.ExecuteNonQuery();
            formload();
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (txtPayment.Text == "Complete")
            {
                sql = "update delivery set deliveryDate = '" + dtp.Value.ToShortDateString() + "', agentID = '" + txtAgent.Text + "', productID = '" + txtProduct.Text + "', status = 'Being transfered', paymentMethods = '" + comboBox1.Text + "', paymentStatus = 'Complete', quantity = " + txtQuality.Text + ", price = " + txtPrice.Text + " where deliveryID = '" + txtDeli.Text + "'";
                cm = new SqlCommand(sql, cn);
                cm.ExecuteNonQuery();
            }
            else if(comboBox1.Text == "By Cash")
            {
                sql = "update delivery set deliveryDate = '" + dtp.Value.ToShortDateString() + "', agentID = '" + txtAgent.Text + "', productID = '" + txtProduct.Text + "', status = 'Being transfered', paymentMethods = '" + comboBox1.Text + "', paymentStatus = 'Not Complete', quantity = " + txtQuality.Text + ", price = " + txtPrice.Text + " where deliveryID = '" + txtDeli.Text + "'";
                cm = new SqlCommand(sql, cn);
                cm.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("The agent has not paid");
                return;
            }
            formload();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (grd.Rows.Count - 1 > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(grd.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            //add column
                            foreach (DataGridViewColumn column in grd.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            //add value
                            for (int i = 0; i < grd.Rows.Count - 1; ++i)
                            {
                                for (int j = 0; j < grd.Columns.Count; ++j)
                                {
                                    // string s = grd.Rows[i].Cells[j].Value.ToString();
                                    pdfTable.AddCell(grd.Rows[i].Cells[j].Value.ToString());

                                }
                            }

                            /*
                            foreach (DataGridViewRow row in grd.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }
                            */
                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Hide();
        }
    }
 }
