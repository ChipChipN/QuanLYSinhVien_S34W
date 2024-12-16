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
    public partial class frmMonHoc : Form
    {
        public frmMonHoc()
        {
            InitializeComponent();
        }

        private void loadMonHoc()
        {
            // Tạo đối tượng DataContext kết nối với cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Truy vấn dữ liệu từ bảng LOPHOC và sắp xếp theo MALOP
            var query = from monHoc in db.MONHOCs
                        orderby monHoc.MAMON
                        select monHoc;

            // Gán dữ liệu vào DataGridView
            dgvMonHoc.DataSource = query.ToList();  // Chuyển đổi kết quả từ LINQ thành danh sách
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtTenMon.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }

            // Tạo đối tượng DataContext kết nối với cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Tạo lớp học mới
            MONHOC MonHoc = new MONHOC
            {
                TENMONHOC = txtTenMon.Text,
            };

            // Thêm lớp học vào cơ sở dữ liệu
            db.MONHOCs.InsertOnSubmit(MonHoc);
            db.SubmitChanges();

            // Tải lại danh sách lớp học để cập nhật DataGridView
            loadMonHoc();
            MessageBox.Show("Thêm môn học thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có lớp học nào được chọn không
            if (string.IsNullOrEmpty(txtMaMon.Text))
            {
                MessageBox.Show("Vui lòng chọn môn học cần sửa.");
                return;
            }

            // Tạo đối tượng DataContext kết nối với cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Lấy lớp học theo mã lớp
            int maMon = int.Parse(txtMaMon.Text);
            MONHOC MonHoc = db.MONHOCs.SingleOrDefault(p => p.MAMON == maMon);

            if (MonHoc != null)
            {
                MonHoc.TENMONHOC = txtTenMon.Text;

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();

                // Tải lại danh sách lớp học để cập nhật DataGridView
                loadMonHoc();
                MessageBox.Show("Cập nhật môn học thành công!");
            }
            else
            {
                MessageBox.Show("Môn học không tồn tại.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có lớp học nào được chọn không
            if (string.IsNullOrEmpty(txtMaMon.Text))
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa.");
                return;
            }

            // Tạo đối tượng DataContext kết nối với cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Lấy lớp học theo mã lớp
            int maMon = int.Parse(txtMaMon.Text);
            MONHOC MonHoc = db.MONHOCs.SingleOrDefault(p => p.MAMON == maMon);

            if (MonHoc != null)
            {
                // Xóa lớp học khỏi cơ sở dữ liệu
                db.MONHOCs.DeleteOnSubmit(MonHoc);
                db.SubmitChanges();

                // Tải lại danh sách lớp học để cập nhật DataGridView
                loadMonHoc();
                MessageBox.Show("Xóa môn học thành công!");
            }
            else
            {
                MessageBox.Show("Lớp môn không tồn tại.");
            }
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            loadMonHoc();
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaMon.Text = dgvMonHoc.CurrentRow.Cells[0].Value.ToString();
            txtTenMon.Text = dgvMonHoc.CurrentRow.Cells[1].Value.ToString();
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
            var ketQuaTimKiem = from monHoc in db.MONHOCs
                                where monHoc.MAMON.ToString().Contains(tuKhoa) || monHoc.TENMONHOC.Contains(tuKhoa)
                                orderby monHoc.MAMON
                                select monHoc;

            // Kiểm tra nếu có kết quả
            if (ketQuaTimKiem.Any())
            {
                // Hiển thị kết quả tìm kiếm trong DataGridView
                dgvMonHoc.DataSource = ketQuaTimKiem.ToList();
            }
            else
            {
                MessageBox.Show("Không tìm thấy môn học khớp với từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Nếu không có kết quả, có thể tải lại danh sách lớp học đầy đủ
                loadMonHoc();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadMonHoc();
            txtMaMon.Text = "";
            txtTenMon.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
