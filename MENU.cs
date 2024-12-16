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
    public partial class MENU : Form
    {
        private string userRole;  // Biến lưu ROLE của người dùng

        // Constructor nhận tham số ROLE
        public MENU(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void MENU_Load(object sender, EventArgs e)
        {
            CustomizeButtonsByRole();
            txtROLE.Text = userRole;
        }

        private void CustomizeButtonsByRole()
        {
            // Mặc định ẩn tất cả các Button
            btnQuanLyMonHoc.Visible = false;
            btnQuanLyLopHoc.Visible = false;
            btnQuanLySinhVien.Visible = false;
            btnQuanLyGiaoVien.Visible = false;
            btnQuanLyDiemHoc.Visible = false;

            // Hiển thị Button theo từng ROLE
            if (userRole == "Quản trị viên")
            {
                // Hiển thị tất cả các Button
                btnQuanLyMonHoc.Visible = true;
                btnQuanLyLopHoc.Visible = true;
                btnQuanLySinhVien.Visible = true;
                btnQuanLyGiaoVien.Visible = true;
                btnQuanLyDiemHoc.Visible = true;
            }
            else if (userRole == "Giáo viên")
            {
                // Chỉ hiển thị Button "Quản lý Lớp Học"
                btnQuanLyLopHoc.Visible = true;
            }
            else if (userRole == "Sinh viên")
            {
                // Chỉ hiển thị Button "Quản lý Điểm Học"
                btnQuanLyDiemHoc.Visible = true;
            }
        }

        private void btnQuanLyMonHoc_Click(object sender, EventArgs e)
        {
            frmMonHoc monHoc = new frmMonHoc();
            monHoc.ShowDialog();
        }

        private void btnQuanLyLopHoc_Click(object sender, EventArgs e)
        {
            frmLopHoc lopHoc = new frmLopHoc();
            lopHoc.ShowDialog();
        }

        private void btnQuanLySinhVien_Click(object sender, EventArgs e)
        {
            frmSinhVien sinhVien = new frmSinhVien();
            sinhVien.ShowDialog();
        }

        private void btnQuanLyGiaoVien_Click(object sender, EventArgs e)
        {
            frmGiaoVien giaoVien = new frmGiaoVien();
            giaoVien.ShowDialog();
        }

        private void btnQuanLyDiemHoc_Click(object sender, EventArgs e)
        {
            frmDiem diem = new frmDiem();
            diem.ShowDialog();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            frmDangNhap login = new frmDangNhap();
            login.ShowDialog();
            this.Close();
        }
    }
}
