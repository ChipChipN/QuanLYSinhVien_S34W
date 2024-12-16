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
    public partial class frmDiem : Form
    {
        public frmDiem()
        {
            InitializeComponent();
        }

        // Load dữ liệu điểm khi form được mở
        private void loadComboBoxLopHoc()
        {
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            // Lấy danh sách sinh viên từ cơ sở dữ liệu
            var danhSachLopHoc = db.LOPHOCs.Select(lh => new
            {
                lh.MALOP,
                lh.TENLOP
            }).ToList();

            // Gán danh sách sinh viên vào ComboBox
            cbxLopHoc.DataSource = danhSachLopHoc;
            cbxLopHoc.DisplayMember = "TENLOP";
            cbxLopHoc.ValueMember = "MALOP";
        }

        private void loadDiem(int maLop)
        {
            // Tạo kết nối đến cơ sở dữ liệu
            lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

            var danhSachDiem = from lsv in db.LOPHOC_SINHVIENs
                               join sv in db.SINHVIENs on lsv.MASV equals sv.MASV
                               join diem in db.DIEMs on sv.MASV equals diem.MASV into diemGroup
                               from diem in diemGroup.DefaultIfEmpty() // LEFT JOIN
                               where lsv.MALOP == maLop
                               select new
                               {
                                   sv.MASV,
                                   TenSinhVien = sv.HO + " " + sv.TENDEM + " " + sv.TEN,
                                   Diem = diem != null ? diem.DIEMSO : (float?)null // Nếu không có điểm, trả về null
                               };

            // Gán dữ liệu vào DataGridView
            dgvDiem.DataSource = danhSachDiem.ToList();

            // Đặt tiêu đề cho các cột trong DataGridView
            dgvDiem.Columns[0].HeaderText = "Mã Sinh Viên";
            dgvDiem.Columns[1].HeaderText = "Tên Sinh Viên";
            dgvDiem.Columns[2].HeaderText = "Điểm";
        }


        // Thêm điểm cho sinh viên
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã sinh viên và điểm từ TextBox
                string maSV = txtMaSV.Text;
                float diem = float.Parse(txtDiemSo.Text);

                // Kết nối cơ sở dữ liệu
                lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

                // Kiểm tra nếu sinh viên đã có điểm hay chưa
                var diemExist = db.DIEMs.FirstOrDefault(d => d.MASV == int.Parse(maSV));
                if (diemExist != null)
                {
                    MessageBox.Show("Sinh viên này đã có điểm.");
                }
                else
                {
                    // Thêm điểm mới
                    DIEM diemMoi = new DIEM
                    {
                        MASV = int.Parse(maSV),
                        DIEMSO = diem
                    };
                    db.DIEMs.InsertOnSubmit(diemMoi);
                    db.SubmitChanges();

                    // Hiển thị thông báo và làm mới DataGridView
                    MessageBox.Show("Điểm đã được thêm thành công.");
                    int maLop = Convert.ToInt32(cbxLopHoc.SelectedValue);
                    loadDiem(maLop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Sửa điểm của sinh viên
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã sinh viên và điểm từ TextBox
                string maSV = txtMaSV.Text;
                float diem = float.Parse(txtDiemSo.Text);

                // Kết nối cơ sở dữ liệu
                lophoc_sinhvienDataContext db = new lophoc_sinhvienDataContext();

                // Tìm kiếm sinh viên theo mã
                var diemExist = db.DIEMs.FirstOrDefault(d => d.MASV == int.Parse(maSV));
                if (diemExist != null)
                {
                    diemExist.DIEMSO = diem;
                    db.SubmitChanges();

                    // Hiển thị thông báo và làm mới DataGridView
                    MessageBox.Show("Điểm đã được sửa thành công.");
                    int maLop = Convert.ToInt32(cbxLopHoc.SelectedValue);
                    loadDiem(maLop);
                }
                else
                {
                    MessageBox.Show("Sinh viên không tồn tại trong cơ sở dữ liệu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void frmDiem_Load(object sender, EventArgs e)
        {
            loadComboBoxLopHoc();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLopHoc.SelectedItem != null)
            {
                // Lấy đối tượng vô danh chứa MALOP và TENLOP
                var selectedLopHoc = cbxLopHoc.SelectedItem as dynamic;

                if (selectedLopHoc != null)
                {
                    int maLop = selectedLopHoc.MALOP; // Lấy MALOP từ đối tượng vô danh
                    loadDiem(maLop);
                }
            }
        }

        private void dgvDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.Text = dgvDiem.CurrentRow.Cells[0].Value.ToString();
            txtTenSV.Text = dgvDiem.CurrentRow.Cells[1].Value.ToString();
            // Kiểm tra xem điểm có null không
            var diemCellValue = dgvDiem.CurrentRow.Cells[2].Value;

            if (diemCellValue == null || diemCellValue == DBNull.Value)
            {
                // Nếu không có điểm, hiển thị "0"
                txtDiemSo.Text = "0";
            }
            else
            {
                // Nếu có điểm, hiển thị giá trị điểm
                txtDiemSo.Text = diemCellValue.ToString();
            }
        }
    }
}
