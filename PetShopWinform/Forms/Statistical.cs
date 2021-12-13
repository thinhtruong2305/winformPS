using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetShopWinform.BUS;

namespace PetShopWinform.Forms
{
    public partial class Statistical : Form
    {
        Statistical_BUS busThongKe;

        public Statistical()
        {
            InitializeComponent();
            busThongKe = new Statistical_BUS();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label1.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
        }

        private void load_data()
        {
            busThongKe.layDanhSachThongKe(dataGridView1);
        }

        private void Statistical_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}
