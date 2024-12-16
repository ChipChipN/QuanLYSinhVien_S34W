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
    public partial class frmLopHoc : Form
    {
        public frmLopHoc()
        {
            InitializeComponent();
        }

        private void frmLopHoc_Load(object sender, EventArgs e)
        {
            // Gọi phương thức để tải danh sách lớp học khi form được load
            loadDSLopHoc();
            LoadDSMonHoc();
            loadComboBoxSinhVien();
            LoadDSGiaoVien();
            txtMaLop.Enabled = false;
        }

        // Phương thức để tải danh sách lớp học vào DataGridView
        private void loadDSLopHoc()
        {
            // Tạo đối tượng DataContext kết nối với cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Truy vấn dữ liệu từ bảng LOPHOC và sắp xếp theo MALOP
            var query = from lopHoc in db.LOPHOCs
                        orderby lopHoc.MALOP
                        select lopHoc;

            // Gán dữ liệu vào DataGridView
            dgvLopHoc.DataSource = query.ToList();  // Chuyển đổi kết quả từ LINQ thành danh sách
        }

        //Load DANH SÁCH MÔN HỌC
        private void LoadDSMonHoc()
        {
            // Tạo kết nối tới cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Lấy danh sách sinh viên từ cơ sở dữ liệu
            var danhSachMonHoc = db.MONHOCs.Select(mh => new
            {
                mh.MAMON,
                mh.TENMONHOC,
            }).ToList();

            // Gán danh sách sinh viên vào ComboBox
            cbxMonHoc.DataSource = danhSachMonHoc;
            cbxMonHoc.DisplayMember = "TENMONHOC";
            cbxMonHoc.ValueMember = "MAMON";
        }

        //Load DANH SÁCH MÔN HỌC
        private void LoadDSGiaoVien()
        {
            // Tạo kết nối tới cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Lấy danh sách sinh viên từ cơ sở dữ liệu
            var danhSachGiaoVien = db.GIAOVIENs.Select(mh => new
            {
                mh.MAGV,
                mh.HOTEN,
            }).ToList();

            // Gán danh sách sinh viên vào ComboBox
            cbxGV.DataSource = danhSachGiaoVien;
            cbxGV.DisplayMember = "HOTEN";
            cbxGV.ValueMember = "MAGV";
        }

        private void loadDSSinhVien(int maLop)
        {
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Truy vấn danh sách sinh viên của lớp học
            var danhSachSinhVienLop = db.LOPHOC_SINHVIENs
                                         .Where(lsv => lsv.MALOP == maLop)
                                         .Join(db.SINHVIENs,
                                               lsv => lsv.MASV,
                                               sv => sv.MASV,
                                               (lsv, sv) => new
                                               {
                                                   sv.MASV,
                                                   TenSinhVien = sv.HO + " " + sv.TENDEM + " " + sv.TEN
                                               })
                                         .ToList();

            // Cập nhật DataGridView với danh sách sinh viên
            dgvSV.DataSource = danhSachSinhVienLop;
        }

        // Phương thức để hiển thị dữ liệu của dòng được chọn
        private void showLopHoc(int idrow)
        {
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Lấy mã lớp học từ DataGridView
            string MaLopHoc = dgvLopHoc.Rows[idrow].Cells[0].Value.ToString();

            // Truy vấn lớp học theo MALOP
            LOPHOC LopHoc = db.LOPHOCs.SingleOrDefault(p => p.MALOP == int.Parse(MaLopHoc));

            if (LopHoc != null)
            {
                // Hiển thị thông tin lớp học vào các TextBox
                txtMaLop.Text = LopHoc.MALOP.ToString();
                lbl.Text = LopHoc.TENLOP;
                txtSoLuong.Text = LopHoc.SOLUONG_SV.ToString();
                cbxMonHoc.Text = LopHoc.MAMON.ToString();
            }
        }

        // Sự kiện khi người dùng chọn dòng trong DataGridView
        private void dgvLopHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLopHoc.SelectedRows.Count > 0)
            {
                int idrow = dgvLopHoc.SelectedRows[0].Index;  // Lấy chỉ số dòng được chọn
                showLopHoc(idrow);  // Hiển thị dữ liệu cho dòng đã chọn
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Phương thức để thêm lớp học
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtTenLop.Text) || string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }

            // Tạo đối tượng DataContext kết nối với cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            int maMonHoc = int.Parse(cbxMonHoc.SelectedValue.ToString());
            int maGiaoVien = int.Parse(cbxGV.SelectedValue.ToString());

            // Tạo lớp học mới
            LOPHOC LopHoc = new LOPHOC
            {
                TENLOP = txtTenLop.Text,
                SOLUONG_SV = int.Parse(txtSoLuong.Text),
                MAMON = maMonHoc,
                MAGV = maGiaoVien,
            };

            // Thêm lớp học vào cơ sở dữ liệu
            db.LOPHOCs.InsertOnSubmit(LopHoc);
            db.SubmitChanges();

            // Tải lại danh sách lớp học để cập nhật DataGridView
            loadDSLopHoc();
            MessageBox.Show("Thêm lớp học thành công!");

            txtMaLop.Text = "";
            txtTenLop.Text = "";
            txtSoLuong.Text = "";
        }

        // Phương thức để sửa lớp học
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có lớp học nào được chọn không
            if (string.IsNullOrEmpty(txtMaLop.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp học cần sửa.");
                return;
            }

            // Tạo đối tượng DataContext kết nối với cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Lấy lớp học theo mã lớp
            int maLop = int.Parse(txtMaLop.Text);
            LOPHOC LopHoc = db.LOPHOCs.SingleOrDefault(p => p.MALOP == maLop);

            if (LopHoc != null)
            {
                // Cập nhật thông tin lớp học
                LopHoc.TENLOP = txtTenLop.Text;
                LopHoc.SOLUONG_SV = int.Parse(txtSoLuong.Text);

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();

                // Tải lại danh sách lớp học để cập nhật DataGridView
                loadDSLopHoc();
                MessageBox.Show("Cập nhật lớp học thành công!");
            }
            else
            {
                MessageBox.Show("Lớp học không tồn tại.");
            }
        }

        // Phương thức để xóa lớp học
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có lớp học nào được chọn không
            if (string.IsNullOrEmpty(txtMaLop.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp học cần xóa.");
                return;
            }

            // Tạo đối tượng DataContext kết nối với cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Lấy lớp học theo mã lớp
            int maLop = int.Parse(txtMaLop.Text);
            LOPHOC LopHoc = db.LOPHOCs.SingleOrDefault(p => p.MALOP == maLop);

            if (LopHoc != null)
            {
                // Xóa lớp học khỏi cơ sở dữ liệu
                db.LOPHOCs.DeleteOnSubmit(LopHoc);
                db.SubmitChanges();

                // Tải lại danh sách lớp học để cập nhật DataGridView
                loadDSLopHoc();
                MessageBox.Show("Xóa lớp học thành công!");
            }
            else
            {
                MessageBox.Show("Lớp học không tồn tại.");
            }
        }

        private void dgvLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy ExamId của đề thi được chọn
            int maLop = Convert.ToInt32(dgvLopHoc.CurrentRow.Cells[0].Value);

            txtMaLop.Text = maLop.ToString();
            txtTenLop.Text = dgvLopHoc.CurrentRow.Cells[1].Value.ToString();
            txtSoLuong.Text = dgvLopHoc.CurrentRow.Cells[2].Value.ToString();
            cbxMonHoc.Text = dgvLopHoc.CurrentRow.Cells[3].Value.ToString();
            cbxGV.Text = dgvLopHoc.CurrentRow.Cells[4].Value.ToString();

            // Gọi phương thức để tải danh sách sinh viên của lớp học
            loadDSSinhVien(maLop);
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
            var ketQuaTimKiem = from lopHoc in db.LOPHOCs
                                where lopHoc.MALOP.ToString().Contains(tuKhoa) || lopHoc.TENLOP.Contains(tuKhoa)
                                orderby lopHoc.MALOP
                                select lopHoc;

            // Kiểm tra nếu có kết quả
            if (ketQuaTimKiem.Any())
            {
                // Hiển thị kết quả tìm kiếm trong DataGridView
                dgvLopHoc.DataSource = ketQuaTimKiem.ToList();
            }
            else
            {
                MessageBox.Show("Không tìm thấy lớp học khớp với từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Nếu không có kết quả, có thể tải lại danh sách lớp học đầy đủ
                loadDSLopHoc();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadDSLopHoc();
            txtMaLop.Text = "";
            txtTenLop.Text = "";
            txtSoLuong.Text = "";
        }

        private void loadComboBoxSinhVien()
        {
            // Tạo kết nối tới cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Lấy danh sách sinh viên từ cơ sở dữ liệu
            var danhSachSinhVien = db.SINHVIENs.Select(sv => new
            {
                sv.MASV,  // Mã sinh viên
                TenSinhVien = sv.HO + " " + sv.TENDEM + " " + sv.TEN  // Tên sinh viên
            }).ToList();

            // Gán danh sách sinh viên vào ComboBox
            cbxSinhVien.DataSource = danhSachSinhVien;
            cbxSinhVien.DisplayMember = "TenSinhVien";  // Hiển thị tên sinh viên trong ComboBox
            cbxSinhVien.ValueMember = "MASV";  // Lưu mã sinh viên trong Value của ComboBox
        }

        private void btnAddToLop_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn lớp học và sinh viên chưa
            if (txtMaLop.Text == "")
            {
                MessageBox.Show("Vui lòng chọn lớp học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbxSinhVien.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên để thêm vào lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã lớp học từ TextBox
            int maLopHoc = int.Parse(txtMaLop.Text);

            // Lấy mã sinh viên từ ComboBox
            int maSinhVien = int.Parse(cbxSinhVien.SelectedValue.ToString());  // Lấy giá trị từ ComboBox (MASV)

            // Kết nối tới DataContext (Database)
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Kiểm tra nếu mối quan hệ giữa lớp học và sinh viên đã tồn tại trong bảng LopHoc_SinhVien chưa
            var kiemTraLopSinhVien = db.LOPHOC_SINHVIENs
                                        .Where(lsv => lsv.MALOP == maLopHoc && lsv.MASV == maSinhVien)
                                        .SingleOrDefault();

            if (kiemTraLopSinhVien != null)
            {
                MessageBox.Show("Sinh viên đã có trong lớp học này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Thêm sinh viên vào lớp học
            LOPHOC_SINHVIEN lopHocSinhVien = new LOPHOC_SINHVIEN()
            {
                MALOP = maLopHoc,
                MASV = maSinhVien
            };

            db.LOPHOC_SINHVIENs.InsertOnSubmit(lopHocSinhVien);

            // Cập nhật số lượng sinh viên của lớp học
            var lopHoc = db.LOPHOCs.SingleOrDefault(lh => lh.MALOP == maLopHoc);
            if (lopHoc != null)
            {
                lopHoc.SOLUONG_SV += 1; // Tăng số lượng sinh viên lên 1
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            db.SubmitChanges();

            // Cập nhật lại DataGridView sinh viên của lớp
            loadDSSinhVien(maLopHoc);

            // Cập nhật lại danh sách lớp học
            loadDSLopHoc();

            MessageBox.Show("Sinh viên đã được thêm vào lớp và số lượng sinh viên đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFrmDiem_Click(object sender, EventArgs e)
        {
            frmDiem diem = new frmDiem();
            diem.ShowDialog();
            this.Hide();
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            frmMonHoc mh = new frmMonHoc();
            mh.ShowDialog();
            this.Hide();
        }
    }
}
