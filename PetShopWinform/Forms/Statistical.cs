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
using App = Microsoft.Office.Interop.Excel.Application;
using Microsoft.Office.Interop.Excel;


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

        //Truyền và xử lí dữ liệu
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(System.Windows.Forms.Button))
                {
                    System.Windows.Forms.Button btn = (System.Windows.Forms.Button)btns;
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

        public void exportToExcel(DataGridView view, String fileInfo)
        {
            App app = new App();
            Workbook workbook = app.Workbooks.Add(Type.Missing);
            Worksheet worksheet = null;
            //Định vị sheet
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            //Định dạng sheet
            dinhDangWorksheet(worksheet);
            //cái i = 1 là vị trí cell 1 bên excel
            //columns.count + 1 là count đếm thiếu một số nên phải cộng 1
            for (int i = 1; i < view.Columns.Count + 1; i++)
            {
                app.Cells[1, i] = view.Columns[i - 1].HeaderText;
            }
            //hai vòng lặp
            //Vòng lặp một là số dòng
            //Vòng lặp hai là cell ô của excel lấy giá trị từ cell datagridview
            for (int i = 0; i < view.Rows.Count; i++)
            {
                for (int j = 0; j < view.Columns.Count; j++)
                {
                    if (view.Rows[i].Cells[j].Value != null)
                    {
                        //dòng và ô phải cộng 1 vì khởi tạo vòng lặp i và j đều bằng 0 có thể thay đổi nếu muốn
                        app.Cells[i + 2, j + 1] = view.Rows[i].Cells[j].Value.ToString();
                        if (j + 1 == 4)
                        {
                            //định dạng thêm tiền cho các cell excel D và E tương ứng là cell 4 và 5
                            app.Cells[i + 2, j + 1] = view.Rows[i].Cells[j].Value.ToString() + "000 VND";
                        }
                    }
                }
            }
            app.ActiveWorkbook.SaveCopyAs(fileInfo);
            app.ActiveWorkbook.Saved = true;
            MessageBox.Show("Bạn đã truyền dữ liệu sáng excel thành công", "Thông báo");
        }

        //Định dạng
        private void dinhDangHeadertext()
        {
            dataGridViewBangHienThi.Columns[0].HeaderText = "Mã hóa đơn";
            dataGridViewBangHienThi.Columns[1].HeaderText = "Ngày tạo";
            dataGridViewBangHienThi.Columns[2].HeaderText = "Trạng thái";
            dataGridViewBangHienThi.Columns[3].HeaderText = "Tổng tiền";
            dataGridViewBangHienThi.Columns[4].HeaderText = "Mã Khách hàng";
        }

        private void dinhDangWorksheet(Worksheet worksheet)
        {
            int soDong = dataGridViewBangHienThi.Rows.Count + 1;
            //định dạng trang
            worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
            worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
            worksheet.PageSetup.TopMargin = 0;
            worksheet.PageSetup.LeftMargin = 0;
            worksheet.PageSetup.RightMargin = 0;
            worksheet.PageSetup.BottomMargin = 0;
            //định dạng cột
            worksheet.Range["A1"].ColumnWidth = 15;
            worksheet.Range["B1"].ColumnWidth = 20;
            worksheet.Range["C1"].ColumnWidth = 25;
            worksheet.Range["D1"].ColumnWidth = 20;
            worksheet.Range["E1"].ColumnWidth = 20;
            //định dạng font chữ
            worksheet.Range["A1", "E" + soDong].Font.Name = "Times New Roman";
            worksheet.Range["A1", "E" + soDong].Font.Size = 14;
            worksheet.Range["A1", "E1"].Font.Bold = true;
            //Kẻ bảng
            worksheet.Range["A1", "E" + soDong].Borders.LineStyle = 1;
            //Căn lề
            worksheet.Range["A1", "E" + soDong].HorizontalAlignment = 3;
        }

        private void dataGridViewBangHienThi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex.Equals(2))
            {
                String trangThai = e.Value.ToString();
                if (trangThai.Equals("CHƯA DUYỆT"))
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.White;
                }
            }else if (e.ColumnIndex.Equals(1))
            {
                e.CellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void dinhDangForm()
        {
            dinhDangHeadertext();
        }
        
        //Bắt sự kiện
        private void Statistical_Load(object sender, EventArgs e)
        {
            LoadTheme();
            load_data();
            dinhDangForm();
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
                    if (busThongKe.timHoaDonTheoMaHoaDon(dataGridViewBangHienThi, Convert.ToInt32(txtFind.Text))){ }
                    else
                    {
                        MessageBox.Show("Xin lỗi! Chúng tôi không tìm thấy dữ liệu phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (busThongKe.timHoaDonTheoTen(dataGridViewBangHienThi, txtFind.Text)){ }
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

            txtFind.Enabled = false;
            txtFind.Enabled = true;

            dateTimePickerFrom.Value = DateTime.Now;
            dateTimePickerTo.Value = DateTime.Now;
        }


        private void dataGridViewBangHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int maKhachHang = Convert.ToInt32(dataGridViewBangHienThi.CurrentRow.Cells[4].Value);
            int maHoaDon = Convert.ToInt32(dataGridViewBangHienThi.CurrentRow.Cells[0].Value.ToString());
            DateTime ngayTao = Convert.ToDateTime(dataGridViewBangHienThi.CurrentRow.Cells[1].Value.ToString());
            if (maKhachHang.Equals(0))
            {
                Statistcal_Info info = new Statistcal_Info(maHoaDon, ngayTao);
                info.Show();
            }
            else
            {
                Statistcal_Info info = new Statistcal_Info(maKhachHang, maHoaDon, ngayTao);
                info.Show();
            }
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
            using(SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter="Excel Workbook|*.xlsx" })
            {
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    exportToExcel(dataGridViewBangHienThi, saveFileDialog.FileName);
                }
            }
        }
    }
}
