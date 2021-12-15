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

namespace PetShopWinform.Forms
{
    public partial class Statistcal_Info : Form
    {
        private PetshopWinformEntities DBPetShop;
        private int maHoaDon;
        private DateTime ngayTao;
        private int maKhachHang = 0;

        public Statistcal_Info()
        {
            InitializeComponent();
            DBPetShop = new PetshopWinformEntities();
        }

        public Statistcal_Info(int maHoaDon, DateTime ngayTao)
        {
            InitializeComponent();
            DBPetShop = new PetshopWinformEntities();
            this.maHoaDon = maHoaDon;
            this.ngayTao = ngayTao;
        }

        public Statistcal_Info(int maKhachHang, int maHoaDon, DateTime ngayTao)
        {
            InitializeComponent();
            DBPetShop = new PetshopWinformEntities();
            this.maHoaDon = maHoaDon;
            this.maKhachHang = maKhachHang;
            this.ngayTao = ngayTao;
        }

        //truyền và xử lý dữ liệu
        private void load_data()
        {
            if (!maKhachHang.Equals(0))
            {
                textBoxTenKhachHang.Text = DBPetShop.Customers.Find(maKhachHang).Name.ToString();
                textBoxDiaChi.Text = DBPetShop.Customers.Find(maKhachHang).Address.ToString();
                textBoxDienThoai.Text = DBPetShop.Customers.Find(maKhachHang).Phone.ToString();
                checkBoxGiamGia.Checked = DBPetShop.Customers.Find(maKhachHang).Vip.Value;
                textBoxMaKhachHang.Text = maKhachHang.ToString();
            }
            dataGridViewDanhMucSanPham.DataSource = DBPetShop.OrderInfoes.Where(h => h.IdOrder.Equals(maHoaDon)).Select(s => new { s.IdOrder, s.Product.Name, s.Quantity, s.Total }).ToList();
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
