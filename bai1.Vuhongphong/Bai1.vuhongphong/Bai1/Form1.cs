using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ndkhoabai1
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối tới cơ sở dữ liệu LocalDB của bạn
        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=baitap51;Integrated Security=True";
        private ErrorProvider errorProvider1 = new ErrorProvider();
        public Form1()
        {
            InitializeComponent();
        }

        // 1. Sự kiện khi bấm nút Đăng Nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Kiểm tra trống Tên đăng nhập
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Tên đăng nhập không được để trống!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUsername, "");
            }

            // Kiểm tra trống Mật khẩu
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Mật khẩu không được để trống!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }

            // Kết nối CSDL để kiểm tra tài khoản
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @user AND MatKhau = @pass";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim());

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 2. Sự kiện khi bấm nút Thoát
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 3. Sự kiện khi tích chọn Hiển thị mật khẩu
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}