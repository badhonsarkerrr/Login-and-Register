using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login_and_Register
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(
            @"Data Source=Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;

        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" &&
                txtPassword.Text == "" &&
                txtConPassword.Text == "")
            {
                MessageBox.Show(
                    "Username and Password fields are empty",
                    "Register Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            else if (txtPassword.Text == txtConPassword.Text)
            {
                try
                {
                    con.Open();

                    string register =
                        "INSERT INTO tbl_users (username, password) " +
                        "VALUES (@username, @password)";

                    cmd = new SqlCommand(register, con);

                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                    cmd.ExecuteNonQuery();

                    con.Close();

                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtConPassword.Text = "";
                    txtUsername.Focus();

                    MessageBox.Show(
                        "Your Account has been Successfully Created",
                        "Registration Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(
                    "Password does not match, Please Re-enter",
                    "Register Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                txtPassword.Text = "";
                txtConPassword.Text = "";
                txtPassword.Focus();
            }
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtConPassword.PasswordChar = '•';
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConPassword.Text = "";
            txtUsername.Focus();
        }

        private void clickLogin_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Goodbye");
            Application.Exit();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }
    }
}