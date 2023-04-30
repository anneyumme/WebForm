using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_in
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GoodsReceived gr = new GoodsReceived();
            gr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GoodsDelivery gd = new GoodsDelivery();
            gd.Show();
            this.Hide();
        }
    }
}
