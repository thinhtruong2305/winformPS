using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetShopWinform.Model;
using PetShopWinform.BUS;

namespace PetShopWinform.Forms
{
    public partial class Statistcal_Info : Form
    {
        private PetshopWinformEntities DBPetShop;
        private Statistical_BUS busThongKe;
        private int maHoaDon;
        private DateTime ngayTao;
        private int maKhachHang = 0;

        public Statistcal_Info()
        {
            InitializeComponent();
            DBPetShop = new PetshopWinformEntities();
            busThongKe = new Statistical_BUS();
        }

        public Statistcal_Info(int maHoaDon, DateTime ngayTao)
        {
            InitializeComponent();
            DBPetShop = new PetshopWinformEntities();
            busThongKe = new Statistical_BUS();
            this.maHoaDon = maHoaDon;
            this.ngayTao = ngayTao;
        }

        public Statistcal_Info(int maKhachHang, int maHoaDon, DateTime ngayTao)
        {
            InitializeComponent();
            DBPetShop = new PetshopWinformEntities();
            busThongKe = new Statistical_BUS();
            this.maHoaDon = maHoaDon;
            this.maKhachHang = maKhachHang;
            this.ngayTao = ngayTao;
        }

        //truyền và xử lý dữ liệu
        private void load_data()
        {
            busThongKe.truyenThongTinKhachHangTheoMaKhachHang(textBoxMaKhachHang, textBoxTenKhachHang, textBoxDiaChi, textBoxDienThoai, checkBoxGiamGia, maKhachHang);
            busThongKe.truyenThongTinSanPhamTheoMaHoaDon(dataGridViewDanhMucSanPham, maHoaDon);
            textBoxMaHoaDon.Text = maHoaDon.ToString();
            dateTimePickerNgayTao.Value = ngayTao;
        }

        //định dạng

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Statistcal_Info_Load(object sender, EventArgs e)
        {
            load_data();
        }
    }
}
