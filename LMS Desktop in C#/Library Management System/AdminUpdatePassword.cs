using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class AdminUpdatePassword : Form
    {
        public AdminUpdatePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            string username = textBoxUsername.Text;
            string passEncrpt = Admin.passwordEncryption(textBoxPassword.Text);
            string usernameTrue = Admin.findUsername(username);
            if (usernameTrue != null)
            {
                admin.Username = username;
                admin.Password = passEncrpt;
                Admin.adminList.Add(admin);
                Admin.saveAdmin();
                MessageBox.Show("Admin security updated !");
            }
            else
                MessageBox.Show("Username or Password not found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard admin = new AdminDashboard();
            admin.Show();
        }

        private void AdminUpdatePassword_Load(object sender, EventArgs e)
        {
            Admin.LoadAdmin();
        }
    }
}
