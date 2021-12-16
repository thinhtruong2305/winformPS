using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShopWinform.Model;
using System.Windows.Forms;

namespace PetShopWinform.DAO
{
    class Statistical_DAO
    {
        private PetshopWinformEntities DBPetShop;

        public Statistical_DAO() { DBPetShop = new PetshopWinformEntities(); }

        #region Sử dụng trên Form Statistical
        /// <summary>
        /// Lấy ra danh sách khách hàng từ Database
        /// dynamic là kiểu dữ liệu không thể xác định và chỉ được xác định khi chương trình được thực thi
        /// u là đối tượng không có kiểu dữ liệu cụ thể dùng để lấy các thông tin từ PetshopWinformEntities
        /// </summary>
        /// <returns>danh sách cần để hiển thị cho Form statistical</returns>
        public dynamic layDanhSachHoaDon()
        {
            var danhSach = (from u in DBPetShop.Oders
                            select new
                            {
                                Id = u.Id,
                                Date = u.DateCreate,
                                Status = u.Status,
                                Total = u.OrderInfoes.Select(c => c.Total).Sum(),
                                Costumer = u.Customer.ToString()
                            }).ToList();
            return danhSach;
        }

        /// <summary>
        /// Dùng để lọc danh sách theo ngày đã chỉ định từ ngày bắt đầu đến ngày kết thúc
        /// dynamic là kiểu dữ liệu không thể xác định và chỉ được xác định khi chương trình được thực thi
        /// u là đối tượng không có kiểu dữ liệu cụ thể dùng để lấy các thông tin từ PetshopWinformEntities
        /// </summary>
        /// <param name="ngayBatDau">Mốc bắt đầu để lọc, kiểu DateTime</param>
        /// <param name="ngayKetThuc">Mốc kết thúc để lọc, kiểu DateTime</param>
        /// <returns>Danh sách đã lọc</returns>
        public dynamic locDanhSachHoaDonTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            var danhSach = (from u in DBPetShop.Oders
                            where u.DateCreate >= ngayBatDau && u.DateCreate <= ngayKetThuc
                            select new
                            {
                                Id = u.Id,
                                Date = u.DateCreate,
                                Status = u.Status,
                                Total = u.OrderInfoes.Select(c => c.Total).Sum(),
                                Costumer = u.Customer.ToString()
                            }).ToList();
            return danhSach;
        }

        /// <summary>
        /// Dùng để tìm ra các hóa đơn theo tên khách hàng
        /// u là đối tượng không có kiểu dữ liệu cụ thể dùng để lấy các thông tin từ PetshopWinformEntities
        /// dynamic là kiểu dữ liệu không thể xác định và chỉ được xác định khi chương trình được thực thi
        /// </summary>
        /// <param name="tuKhoa">Dùng để tìm kiếm theo kiểu String đối chiếu với tên khách hàng</param>
        /// <returns>Danh sách đã tìm được</returns>
        public dynamic timKiemDanhSachHoaDonTheoTenKhachHang(String tuKhoa)
        {
            var danhSach = (from u in DBPetShop.Oders
                            where u.Customer1.Name == tuKhoa
                            select new
                            {
                                Id = u.Id,
                                Date = u.DateCreate,
                                Status = u.Status,
                                Total = u.OrderInfoes.Select(c => c.Total).Sum(),
                                Costumer = u.Customer.ToString()
                            }).ToList();
            return danhSach;
        }

        /// <summary>
        /// Dùng để tìm ra các hóa đơn theo mã hóa đơn
        /// u là đối tượng không có kiểu dữ liệu cụ thể dùng để lấy các thông tin từ PetshopWinformEntities
        /// dynamic là kiểu dữ liệu không thể xác định và chỉ được xác định khi chương trình được thực thi
        /// </summary>
        /// <param name="tuKhoa">Dùng để tìm kiếm theo kiểu int đối chiếu với mã hóa đơn</param>
        /// <returns>Danh sách đã tìm được</returns>
        public dynamic timKiemDanhSachHoaDonTheoMaHoaDon(int tuKhoa)
        {
            var danhSach = (from u in DBPetShop.Oders
                            where u.Id == tuKhoa
                            select new
                            {
                                Id = u.Id,
                                Date = u.DateCreate,
                                Status = u.Status,
                                Total = u.OrderInfoes.Select(c => c.Total).Sum(),
                                Costumer = u.Customer.ToString()
                            }).ToList();
            return danhSach;
        }
        #endregion

        #region Sử dụng trên Form Statistical_Info
        /// <summary>
        /// Dùng để tìm một khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="maKhachHang">Dùng để tìm kiếm theo kiểu int đối chiếu với mã khách hàng</param>
        /// <returns>Một khách hàng</returns>
        public Customer timKiemThongTinKhachHangTheoMa(int maKhachHang)
        {
            var khachHang = DBPetShop.Customers.Where(khach => khach.Id.Equals(maKhachHang)).First();
            return khachHang;
        }

        /// <summary>
        /// 
        /// dynamic là kiểu dữ liệu không thể xác định và chỉ được xác định khi chương trình được thực thi
        /// </summary>
        /// <param name="maHoaDon">Dùng để tìm kiếm theo kiểu int đối chiếu với mã hóa đơn</param>
        /// <returns>Danh sách tìm được</returns>
        public dynamic timDanhSachSanPhamThemMaHoaDon(int maHoaDon)
        {
            var danhSach = DBPetShop.OrderInfoes.Where(h => h.IdOrder.Equals(maHoaDon)).Select(s => new { s.IdOrder, s.Product.Name, s.Quantity, s.Total }).ToList();
            return danhSach;
        }
        #endregion

        #region Sử dụng trên Form ChartDoanhThu
        public dynamic layDanhSachDoanhThuTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            var danhSachNgay = (from u in DBPetShop.Oders
                           where u.DateCreate >= ngayBatDau && u.DateCreate <= ngayKetThuc
                           select new
                           {
                               Date = u.DateCreate.Value.Day,
                               DoanhThu = u.OrderInfoes.Select(c => c.Total).Sum()
                           }).ToList();
            return danhSachNgay;
        }

        public dynamic layDanhSachDoanhThuTheoThang(DateTime thangBatDau, DateTime thangKetThuc)
        {
            var danhSachThang = (from u in DBPetShop.Oders
                           where u.DateCreate >= thangBatDau && u.DateCreate <= thangKetThuc
                           select new
                           {
                               Month = u.DateCreate.Value.Month,
                               DoanhThu = u.OrderInfoes.Select(c => c.Total).Sum()
                           }).ToList();
            return danhSachThang;
        }

        public dynamic layDanhSachDoanhThuTheoNam(DateTime namBatDau, DateTime namKetThuc)
        {
            var danhSachNam = (from u in DBPetShop.Oders
                           where u.DateCreate >= namBatDau && u.DateCreate <= namKetThuc
                           select new
                           {
                               Year = u.DateCreate.Value.Year,
                               DoanhThu = u.OrderInfoes.Select(c => c.Total).Sum()
                           }).ToList();
            return danhSachNam;
        }
        #endregion
    }
}
