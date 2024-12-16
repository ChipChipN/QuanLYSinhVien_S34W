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
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtTenTK.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }
            // Kiểm tra xem các trường thông tin có hợp lệ không
            if (string.IsNullOrEmpty(txtMK.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học.");
                return;
            }

            // Tạo đối tượng DataContext kết nối với cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Tạo lớp học mới
            TAIKHOAN TaiKhoan = new TAIKHOAN
            {
                TENTK = txtTenTK.Text,
                MATKHAU = txtMK.Text,
                ROLE = cbxROLE.Text,
            };

            // Thêm lớp học vào cơ sở dữ liệu
            db.TAIKHOANs.InsertOnSubmit(TaiKhoan);
            db.SubmitChanges();

            MessageBox.Show("Đăng ký tài khoản thành công thành công!");
        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            // Xóa các mục hiện có (nếu có)
            cbxROLE.Items.Clear();

            // Thêm các giá trị vào ComboBox
            cbxROLE.Items.Add("Quản trị viên");
            cbxROLE.Items.Add("Giáo viên");
            cbxROLE.Items.Add("Sinh viên");

            // Chọn giá trị mặc định
            cbxROLE.SelectedIndex = 0;  // Chọn mục đầu tiên
        }

        private void showMK_CheckedChanged(object sender, EventArgs e)
        {
            if (showMK.Checked)  // Nếu CheckBox được chọn (Hiện mật khẩu)
            {
                txtMK.PasswordChar = '\0';  // Bỏ ẩn mật khẩu
            }
            else  // Nếu bỏ chọn CheckBox
            {
                txtMK.PasswordChar = '*';  // Gán lại ký tự ẩn mật khẩu
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap login = new frmDangNhap();
            login.ShowDialog();
            this.Close();
        }
    }
}
