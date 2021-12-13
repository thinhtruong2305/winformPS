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
        /// truyền danh sách đã tìm vào data grid view
        /// </summary>
        /// <param name="view">bảng hiển thị danh sách</param>
        /// <param name="tuKhoa"></param>
        public void timHoaDon(DataGridView view, String tuKhoa)
        {
            view.DataSource = danhSachThongKe.timKiemDanhSach(tuKhoa);
        }
    }
}
