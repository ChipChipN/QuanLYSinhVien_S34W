using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLLOPHOC_QLDIEM
{
    public partial class frmSinhVien : Form
    {
        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void loadSinhVien()
        {
            // Tạo đối tượng DataContext kết nối với cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Truy vấn dữ liệu từ bảng LOPHOC và sắp xếp theo MALOP
            var query = from sinhVien in db.SINHVIENs
                        orderby sinhVien.MASV
                        select sinhVien;

            // Gán dữ liệu vào DataGridView
            dgvSinhVien.DataSource = query.ToList();  // Chuyển đổi kết quả từ LINQ thành danh sách
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtHo.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtTenDem.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtGioiTinh.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtQueQuan.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(dtpNgaySinh.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }

            // Tạo đối tượng DataContext kết nối với cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Tạo lớp học mới
            SINHVIEN SinhVien = new SINHVIEN
            {
                HO = txtHo.Text,
                TENDEM = txtTenDem.Text,
                TEN = txtTen.Text,
                GIOITINH = txtGioiTinh.Text,
                NGAYSINH = DateTime.Parse(dtpNgaySinh.Text),
                DIACHI = txtDiaChi.Text,
                QUEQUAN = txtQueQuan.Text,
                DIENTHOAI = txtSDT.Text,
                EMAIL = txtEmail.Text,
            };

            // Thêm lớp học vào cơ sở dữ liệu
            db.SINHVIENs.InsertOnSubmit(SinhVien);
            db.SubmitChanges();

            // Tải lại danh sách lớp học để cập nhật DataGridView
            loadSinhVien();
            MessageBox.Show("Thêm sinh viên thành công!");

            txtHo.Text = "";
            txtTenDem.Text = "";
            txtTen.Text = "";
            txtGioiTinh.Text = "";
            dtpNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtQueQuan.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtHo.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtTenDem.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtGioiTinh.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtQueQuan.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(dtpNgaySinh.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }

            // Tạo đối tượng DataContext kết nối với cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Lấy lớp học theo mã lớp
            int maSV = int.Parse(txtMaSV.Text);
            SINHVIEN SinhVien = db.SINHVIENs.SingleOrDefault(p => p.MASV == maSV);

            if (SinhVien != null)
            {
                SinhVien.HO = txtHo.Text;
                SinhVien.TENDEM = txtTenDem.Text;
                SinhVien.TEN = txtTen.Text;
                SinhVien.GIOITINH = txtGioiTinh.Text;
                SinhVien.DIENTHOAI = txtSDT.Text;
                SinhVien.NGAYSINH = DateTime.Parse(dtpNgaySinh.Text);
                SinhVien.EMAIL = txtEmail.Text;
                SinhVien.DIACHI = txtDiaChi.Text;
                SinhVien.QUEQUAN = txtQueQuan.Text;

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();

                // Tải lại danh sách lớp học để cập nhật DataGridView
                loadSinhVien();
                MessageBox.Show("Cập nhật sinh viên thành công!");
            }
            else
            {
                MessageBox.Show("Sinh Viên không tồn tại.");
            }

            txtMaSV.Text = "";
            txtHo.Text = "";
            txtTenDem.Text = "";
            txtTen.Text = "";
            txtGioiTinh.Text = "";
            dtpNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtQueQuan.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có lớp học nào được chọn không
            if (string.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa.");
                return;
            }


            // Tạo đối tượng DataContext kết nối với cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            int maSV = int.Parse(txtMaSV.Text);
            SINHVIEN SinhVien = db.SINHVIENs.SingleOrDefault(p => p.MASV == maSV);

            if (SinhVien != null)
            {
                db.SINHVIENs.DeleteOnSubmit(SinhVien);

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();

                // Tải lại danh sách lớp học để cập nhật DataGridView
                loadSinhVien();
                MessageBox.Show("Xóa sinh viên thành công!");
            }
            else
            {
                MessageBox.Show("Sinh Viên không tồn tại.");
            }

            txtMaSV.Text = "";
            txtHo.Text = "";
            txtTenDem.Text = "";
            txtTen.Text = "";
            txtGioiTinh.Text = "";
            dtpNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtQueQuan.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Lấy giá trị tìm kiếm từ ô nhập
            string tuKhoa = txtTimKiem.Text.Trim();  // Loại bỏ khoảng trắng đầu và cuối

            // Kiểm tra nếu ô tìm kiếm rỗng
            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng DataContext kết nối với cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            var ketQuaTimKiem = from sinhVien in db.SINHVIENs
                                where sinhVien.HO.ToString().Contains(tuKhoa)   // Tìm theo Họ
                                || sinhVien.TENDEM.ToString().Contains(tuKhoa)  // Tìm theo Tên đệm
                                || sinhVien.TEN.ToString().Contains(tuKhoa)     // Tìm theo Tên
                                || (sinhVien.HO.ToString() + " " + sinhVien.TENDEM.ToString() + " " + sinhVien.TEN.ToString()).Contains(tuKhoa) // Tìm theo toàn bộ tên
                                orderby sinhVien.MASV
                                select sinhVien;


            // Kiểm tra nếu có kết quả
            if (ketQuaTimKiem.Any())
            {
                // Hiển thị kết quả tìm kiếm trong DataGridView
                dgvSinhVien.DataSource = ketQuaTimKiem.ToList();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên khớp với từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Nếu không có kết quả, có thể tải lại danh sách lớp học đầy đủ
                loadSinhVien();
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.Text = dgvSinhVien.CurrentRow.Cells[0].Value.ToString();
            txtHo.Text = dgvSinhVien.CurrentRow.Cells[1].Value.ToString();
            txtTenDem.Text = dgvSinhVien.CurrentRow.Cells[2].Value.ToString();
            txtTen.Text = dgvSinhVien.CurrentRow.Cells[3].Value.ToString();
            dtpNgaySinh.Text = dgvSinhVien.CurrentRow.Cells[4].Value.ToString();
            txtGioiTinh.Text = dgvSinhVien.CurrentRow.Cells[5].Value.ToString();
            txtQueQuan.Text = dgvSinhVien.CurrentRow.Cells[6].Value.ToString();
            txtDiaChi.Text = dgvSinhVien.CurrentRow.Cells[7].Value.ToString();
            txtSDT.Text = dgvSinhVien.CurrentRow.Cells[8].Value.ToString();
            txtEmail.Text = dgvSinhVien.CurrentRow.Cells[9].Value.ToString();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            txtMaSV.Enabled = false;
            loadSinhVien();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
