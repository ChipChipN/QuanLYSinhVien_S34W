using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLLOPHOC_QLDIEM
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenTK.Text;
            string password = txtMK.Text;

            // Chuỗi kết nối
            string connectionString = @"Data Source=DTNMSI\SQLEXPRESS2012;Initial Catalog=DOAN;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ROLE FROM TAIKHOAN WHERE TENTK = @username AND MATKHAU = @password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string role = reader["ROLE"].ToString();

                        // Thông báo đăng nhập thành công
                        MessageBox.Show($"Đăng nhập thành công với vai trò: {role}");

                        // Chuyển đến Form MENU và truyền ROLE
                        this.Hide();  // Ẩn form đăng nhập
                        MENU menuForm = new MENU(role);  // Truyền ROLE sang form MENU
                        menuForm.ShowDialog();
                        this.Show();  // Hiện lại form đăng nhập khi menu đóng
                    }
                    else
                    {
                        MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
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



        private void frmDangNhap_Load(object sender, EventArgs e)
        {
        }

        private void btnDoi_Click(object sender, EventArgs e)
        {
            frmDangKy register = new frmDangKy();
            register.ShowDialog();
            this.Hide();
        }
    }
}
