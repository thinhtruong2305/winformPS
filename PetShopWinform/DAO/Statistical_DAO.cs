using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShopWinform.Model;
using System.Collections.Generic;

namespace PetShopWinform.DAO
{
    class Statistical_DAO
    {
        private PetshopWinformEntities DBPetShop;

        public Statistical_DAO() { DBPetShop = new PetshopWinformEntities(); }

        /// <summary>
        /// Lấy ra danh sách khách hàng từ data base
        /// dynamic là kiểu dữ liệu không thể xác định và chỉ được xác định khi chương trình được thực thi
        /// có sử dụng if else rút gọn để lọc sử dụng dữ liệu
        /// </summary>
        /// <returns>danh sách cần để hiển thị thống kê</returns>
        public dynamic layDanhSachThongKe()
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

            //Có thể dùng 1 trong 2 cái này chưa dùng nhiều có thể sẽ sai
            /*var danhSach = DBPetShop.Oders.Select(hd => new
            {
                hd.Id,
                hd.Customer1.Name,
                hd.Status,
                hd.DateCreate,
                hd.OrderInfoes.Where(h => h.IdOrder == hd.Id).First().Total
            }).ToList();
            return danhSach;*/
        }

        /// <summary>
        /// Dùng để lọc danh sách theo ngày đã chỉ định từ ngày bắt đầu đến ngày kết thúc
        /// dynamic là kiểu dữ liệu không thể xác định và chỉ được xác định khi chương trình được thực thi
        /// </summary>
        /// <param name="ngayBatDau">Kiểu DateTime</param>
        /// <param name="ngayKetThuc">Kiểu DateTime</param>
        /// <returns>Danh sách đã lọc</returns>
        public dynamic locDanhSachTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
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
        /// Dùng để tìm ra hóa đơn cần thiết theo tên khách hàng
        /// </summary>
        /// <param name="tuKhoa">Để tìm kiếm tên khách hàng theo kiểu String</param>
        /// <returns>Danh sách đã tìm được</returns>
        public dynamic timKiemDanhSachTheoTenKhachHang(String tuKhoa)
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
        /// Dùng để tìm ra hóa đơn cần thiết theo mã hóa đơn
        /// </summary>
        /// <param name="tuKhoa">Để tìm kiếm mã hóa đơn theo kiểu int</param>
        /// <returns>Danh sách đã tìm được</returns>
        public dynamic timKiemDanhSachTheoMaHoaDon(int tuKhoa)
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
    }
}
