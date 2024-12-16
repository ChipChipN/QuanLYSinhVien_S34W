using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QLLOPHOC_QLDIEM
{
    public partial class frmGiaoVien : Form
    {
        public frmGiaoVien()
        {
            InitializeComponent();
        }


        private void loadGiaoVien()
        {
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Truy vấn dữ liệu từ bảng LOPHOC và sắp xếp theo MALOP
            var query = from giaoVien in db.GIAOVIENs
                        orderby giaoVien.MAGV
                        select giaoVien;

            // Gán dữ liệu vào DataGridView
            dgvGiaoVien.DataSource = query.ToList();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtTenGV.Text))
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
            GIAOVIEN GiaoVien = new GIAOVIEN
            {
                HOTEN = txtTenGV.Text,
                GIOITINH = txtGioiTinh.Text,
                NGAYSINH = DateTime.Parse(dtpNgaySinh.Text),
                DIACHI = txtDiaChi.Text,
                SODT = txtSDT.Text,
                EMAIL = txtEmail.Text,
            };

            // Thêm lớp học vào cơ sở dữ liệu
            db.GIAOVIENs.InsertOnSubmit(GiaoVien);
            db.SubmitChanges();

            // Tải lại danh sách lớp học để cập nhật DataGridView
            loadGiaoVien();
            MessageBox.Show("Thêm giáo viên thành công!");

            txtTenGV.Text = "";
            txtGioiTinh.Text = "";
            dtpNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtTenGV.Text))
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
            int maGV = int.Parse(txtMaGV.Text);
            GIAOVIEN GiaoVien = db.GIAOVIENs.SingleOrDefault(p => p.MAGV == maGV);

            if (GiaoVien != null)
            {
                GiaoVien.HOTEN = txtTenGV.Text;
                GiaoVien.GIOITINH = txtGioiTinh.Text;
                GiaoVien.SODT = txtSDT.Text;
                GiaoVien.NGAYSINH = DateTime.Parse(dtpNgaySinh.Text);
                GiaoVien.EMAIL = txtEmail.Text;
                GiaoVien.DIACHI = txtDiaChi.Text;

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();

                // Tải lại danh sách lớp học để cập nhật DataGridView
                loadGiaoVien();
                MessageBox.Show("Cập nhật giáo viên thành công!");
            }
            else
            {
                MessageBox.Show("Giáo Viên không tồn tại.");
            }

            txtMaGV.Text = "";
            txtTenGV.Text = "";
            txtGioiTinh.Text = "";
            dtpNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có lớp học nào được chọn không
            if (string.IsNullOrEmpty(txtMaGV.Text))
            {
                MessageBox.Show("Vui lòng chọn giáo viên cần xóa.");
                return;
            }

            // Tạo đối tượng DataContext kết nối với cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            int maGV = int.Parse(txtMaGV.Text);
            GIAOVIEN GiaoVien = db.GIAOVIENs.SingleOrDefault(p => p.MAGV == maGV);

            if (GiaoVien != null)
            {
                db.GIAOVIENs.DeleteOnSubmit(GiaoVien);

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();

                // Tải lại danh sách lớp học để cập nhật DataGridView
                loadGiaoVien();
                MessageBox.Show("Xóa giáo viên thành công!");
            }
            else
            {
                MessageBox.Show("Giáo Viên không tồn tại.");
            }

            txtMaGV.Text = "";
            txtTenGV.Text = "";
            txtGioiTinh.Text = "";
            dtpNgaySinh.Text = "";
            txtDiaChi.Text = "";
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

            // Truy vấn dữ liệu tìm kiếm (tìm theo MALOP hoặc TENLOP)
            var ketQuaTimKiem = from giaoVien in db.GIAOVIENs
                                where giaoVien.HOTEN.ToString().Contains(tuKhoa)
                                orderby giaoVien.MAGV
                                select giaoVien;

            // Kiểm tra nếu có kết quả
            if (ketQuaTimKiem.Any())
            {
                // Hiển thị kết quả tìm kiếm trong DataGridView
                dgvGiaoVien.DataSource = ketQuaTimKiem.ToList();
            }
            else
            {
                MessageBox.Show("Không tìm thấy giáo viên khớp với từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Nếu không có kết quả, có thể tải lại danh sách lớp học đầy đủ
                loadGiaoVien();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadGiaoVien();
            txtMaGV.Text = "";
            txtTenGV.Text = "";
            txtGioiTinh.Text = "";
            dtpNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
        }

        private void frmGiaoVien_Load(object sender, EventArgs e)
        {
            loadGiaoVien();
            txtMaGV.Enabled = false;
        }

        private void dgvGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaGV.Text = dgvGiaoVien.CurrentRow.Cells[0].Value.ToString();
            txtTenGV.Text = dgvGiaoVien.CurrentRow.Cells[1].Value.ToString();
            txtGioiTinh.Text = dgvGiaoVien.CurrentRow.Cells[2].Value.ToString();
            dtpNgaySinh.Text = dgvGiaoVien.CurrentRow.Cells[3].Value.ToString();
            txtDiaChi.Text = dgvGiaoVien.CurrentRow.Cells[4].Value.ToString();
            txtSDT.Text = dgvGiaoVien.CurrentRow.Cells[5].Value.ToString();
            txtEmail.Text = dgvGiaoVien.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
