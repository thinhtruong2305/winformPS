using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShopWinform.DAO;
using System.Windows.Forms;

namespace PetShopWinform.BUS
{
    class Statistical_BUS
    {
        private Statistical_DAO danhSachThongKe;

        public Statistical_BUS() { danhSachThongKe = new Statistical_DAO(); }

        /// <summary>
        /// truyền danh sách vào data grid view
        /// </summary>
        /// <param name="view">bảng hiển thị danh sách</param>
        public void layDanhSachThongKe(DataGridView view)
        {
            view.DataSource = null;
            view.DataSource = danhSachThongKe.layDanhSachThongKe();
        }

        /// <summary>
        /// Truyền danh sách đã lọc theo ngày vào data grid view
        /// </summary>
        /// <param name="view">bảng hiển thị danh sách</param>
        /// <param name="ngayBatDau"></param>
        /// <param name="ngayKetThuc"></param>
        public void layDanhSachThongKeTheoNgay(DataGridView view, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            view.DataSource = danhSachThongKe.locDanhSachTheoNgay(ngayBatDau, ngayKetThuc);
        }

        /// <summary>
        /// Truyền danh sách đã tìm database đến DataGridView
        /// </summary>
        /// <param name="view">Bảng hiển thị thông tin</param>
        /// <param name="tuKhoa">Dùng để tìm kiếm theo kiểu String đối chiếu với tên khách hàng</param>
        /// <returns>boolean để xác nhận tìm thấy hoặc không tìm thấy</returns>
        public bool timHoaDonTheoTen(DataGridView view, String tuKhoa)
        {
            var danhSach = danhSachThongKe.timKiemDanhSachTheoTenKhachHang(tuKhoa);
            if(danhSach != null)
            {
                view.DataSource = danhSachThongKe.timKiemDanhSachTheoTenKhachHang(tuKhoa);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Truyền danh sách đã tìm vào dataGridView
        /// </summary>
        /// <param name="view">Bảng hiển thị thông tin</param>
        /// <param name="tuKhoa">Dùng để tìm kiếm theo kiểu int đối chiếu với mã hóa đơn</param>
        /// <returns>boolean để xác nhận tìm thấy hoặc không tìm thấy</returns>
        public bool timHoaDonTheoMaHoaDon(DataGridView view, int tuKhoa)
        {
            var danhSach = danhSachThongKe.timKiemDanhSachTheoMaHoaDon(tuKhoa);
            if (danhSach != null)
            {
                view.DataSource = danhSachThongKe.timKiemDanhSachTheoMaHoaDon(tuKhoa);
                return true;
            }
            return false;
        }
    }
}
