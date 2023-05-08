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
            string sql = "select * from Orders";
            data = new SqlDataAdapter(sql, cn);
            tb = new DataTable();
            data.Fill(tb);
            grd.DataSource = tb;
        }

        public void formload()
        {
            showGRD();
            enable(grp1, false);
            btnSave.Enabled = false;
            btnPrint.Enabled = false;
            dk = 0;
        }

        private void GoodsDelivery_Load(object sender, EventArgs e)
        {
            string con = "Server=tcp:anne.database.windows.net,1433;Initial Catalog=Final_project;Persist Security Info=False;User ID=ninhdong;Password=8FtLt4P#$HL9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            cn = new SqlConnection(con);
            cn.Open();
            formload();
        }

        private void grd_Click(object sender, EventArgs e)
        {
            idTXT.Text = grd.CurrentRow.Cells[0].Value.ToString();
            userTXT.Text = grd.CurrentRow.Cells[1].Value.ToString();
            orderCreateTXT.Text = grd.CurrentRow.Cells[2].Value.ToString();
            shippingTXT.Text = grd.CurrentRow.Cells[3].Value.ToString();
            orderTotalTXT.Text = grd.CurrentRow.Cells[4].Value.ToString();
            orderStatusTXT.Text = grd.CurrentRow.Cells[5].Value.ToString();
            paymentStatusTXT.Text = grd.CurrentRow.Cells[6].Value.ToString();
            paymentDateTXT.Text = grd.CurrentRow.Cells[7].Value.ToString();
            paymentDueDateTXT.Text = grd.CurrentRow.Cells[8].Value.ToString();
            paymentltentIdTXT.Text = grd.CurrentRow.Cells[9].Value.ToString();
            phoneTXT.Text = grd.CurrentRow.Cells[10].Value.ToString();
            streetTXT.Text = grd.CurrentRow.Cells[11].Value.ToString();
            cityTXT.Text = grd.CurrentRow.Cells[12].Value.ToString();
            provinceTXT.Text = grd.CurrentRow.Cells[13].Value.ToString();
            nameTXT.Text = grd.CurrentRow.Cells[14].Value.ToString();
            sessionIDTXT.Text = grd.CurrentRow.Cells[15].Value.ToString();
            paymentTypeTXT.Text = grd.CurrentRow.Cells[16].Value.ToString();

            btnUpdate.Enabled = true;
            btnPrint.Enabled = true;
            btnSave.Enabled = true;
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "";
            sql = "update Orders set ApplicationUserId = '" + userTXT.Text + "', OrderCreate = '" + orderCreateTXT.Text + "', ShippingDate = '" + shippingTXT.Text + "', OrderTotal = '" + orderTotalTXT.Text + "', orderStatus = '"+orderStatusTXT.Text+ "',PaymentStatus = '" + paymentStatusTXT.Text + "', PaymentDate ='" + paymentDateTXT.Text + "', PaymentDueDate = '" + paymentDueDateTXT.Text + "', PaymentItentId ='" + paymentltentIdTXT.Text + "', PhoneNumber='"+phoneTXT.Text+ "',StreetAdress= '"+streetTXT.Text+ "', City='"+cityTXT.Text+ "', Province= '"+provinceTXT.Text+ "', Name='"+nameTXT.Text+ "', SessionId='"+sessionIDTXT.Text+ "', paymentType='"+paymentTypeTXT.Text+"' where id = '" + idTXT.Text + "'";
            cm = new SqlCommand(sql, cn);
            cm.ExecuteNonQuery();
            formload();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            enable(grp1, true);
            idTXT.Enabled = false;
            userTXT.Enabled = false;
            orderCreateTXT.Enabled = false;
            orderStatusTXT.Enabled = false;
            orderTotalTXT.Enabled = false;
            paymentTypeTXT.Enabled = false;
            paymentStatusTXT.Enabled = false;
            paymentltentIdTXT.Enabled = false;
            paymentDateTXT.Enabled = false;
            paymentDueDateTXT.Enabled = false;
            paymentltentIdTXT.Enabled=false;
            sessionIDTXT.Enabled = false;
            btnSave.Enabled = true;
            
        }

        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Enabled = true;
            //Create a new SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            //Set the file name filter
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";

            //Show the SaveFileDialog
            DialogResult result = saveFileDialog.ShowDialog();

            //If the user clicks the Save button, export the DataGridView to PDF
            if (result == DialogResult.OK)
            {
                //Create a new PDF document
                Document document = new Document();

                //Create a new PDF writer
                PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));

                //Open the document
                document.Open();

                //Create a new table with the number of columns required
                PdfPTable table = new PdfPTable(8);

                //Add the column headers to the table
                table.AddCell("ID");
                table.AddCell("NAME");
                table.AddCell("PROVINCE");
                table.AddCell("CITY");
                table.AddCell("STREET ADDRESS");
                table.AddCell("PHONE NUMBER");
                table.AddCell("PAYMENT TYPE");
                table.AddCell("ORDER TOTAL");

                //Loop through the rows of the DataGridView

                //Create a new table row
                for(int i = 0; i < grd.Rows.Count - 1; i++)
                {
                    table.AddCell(grd.Rows[i].Cells[0].Value.ToString());
                    table.AddCell(grd.Rows[i].Cells[14].Value.ToString());
                    table.AddCell(grd.Rows[i].Cells[13].Value.ToString());
                    table.AddCell(grd.Rows[i].Cells[12].Value.ToString());
                    table.AddCell(grd.Rows[i].Cells[11].Value.ToString());
                    table.AddCell(grd.Rows[i].Cells[10].Value.ToString());
                    table.AddCell(grd.Rows[i].Cells[16].Value.ToString());
                    table.AddCell(grd.Rows[i].Cells[4].Value.ToString());
                }
                    
                
                

                //Add the table to the PDF document
                document.Add(table);

                //Close the document
                document.Close();

                MessageBox.Show("PDF file saved successfully!");
            }
        }
            

        private void btnBack_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Hide();
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
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
    }
}
