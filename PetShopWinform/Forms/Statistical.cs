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
                    btn.ForeColor = Color.Black;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label1.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = ThemeColor.PrimaryColor;
        }

        private void load_data()
        {
            busThongKe.layDanhSachThongKe(dataGridViewBangHienThi);
        }

        private void Statistical_Load(object sender, EventArgs e)
        {
            LoadTheme();
            load_data();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            busThongKe.layDanhSachThongKeTheoNgay(dataGridViewBangHienThi, dateTimePickerFrom.Value, dateTimePickerTo.Value);
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            busThongKe.layDanhSachThongKeTheoNgay(dataGridViewBangHienThi, dateTimePickerFrom.Value, dateTimePickerTo.Value);
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            Statistical_Load(sender, e);
        }

        private void txtFind_Click(object sender, EventArgs e)
        {
            txtFind.Text = null;
            txtFind.ForeColor = Color.Black;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtFind.Text != "")
            {
                char c = Convert.ToChar(txtFind.Text.ElementAt(0));
                if (c >= 48 && c <= 57)
                {
                    if (busThongKe.timHoaDonTheoMaHoaDon(dataGridViewBangHienThi, Convert.ToInt32(txtFind.Text)))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Xin lỗi! Chúng tôi không tìm thấy dữ liệu phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (busThongKe.timHoaDonTheoTen(dataGridViewBangHienThi, txtFind.Text))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Xin lỗi! Chúng tôi không tìm thấy dữ liệu phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
                MessageBox.Show("Xin lỗi! Yêu cầu bạn nhập thông tin trước khi tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Statistical_Click(object sender, EventArgs e)
        {
            txtFind.Text = "Nhập mã hóa đơn, tên khách hàng";
            txtFind.ForeColor = Color.DarkGray;
            dateTimePickerFrom.Value = DateTime.Now;
            dateTimePickerTo.Value = DateTime.Now;
        }


        private void dataGridViewBangHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                pictureBox1_Click(sender, e);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }
    }
}
