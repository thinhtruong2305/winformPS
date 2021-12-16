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
    public partial class FormChartDoanhThu : Form
    {
        private Statistical_BUS busThongKe;
        private DateTime ngayBatDau = DateTime.MinValue;
        private DateTime ngayKetThuc = DateTime.MaxValue;

        public FormChartDoanhThu()
        {
            InitializeComponent();
            busThongKe = new Statistical_BUS();
        }

        #region Sự kiện
        private void FormChartDoanhThu_Load(object sender, EventArgs e)
        {
            radioButtonYear_CheckedChanged(sender, e);
        }

        private void radioButtonDate_CheckedChanged(object sender, EventArgs e)
        {
            busThongKe.truyenThongTinDoanhThuTheoNgay(chartDoanhThu, ngayBatDau, ngayKetThuc);
        }

        private void radioButtonMonth_CheckedChanged(object sender, EventArgs e)
        {
            busThongKe.truyenThongtinDoanhThuTheoThang(chartDoanhThu, ngayBatDau, ngayKetThuc);
        }

        private void radioButtonYear_CheckedChanged(object sender, EventArgs e)
        {
            busThongKe.truyenThongTinDoanhThuTheoNam(chartDoanhThu, ngayBatDau, ngayKetThuc);
        }
        #endregion
    }
}
