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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            User.LoadUser();
            Biblioman.LoadBiblioman();
            Admin.LoadAdmin();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            
            labelAdminNumber.Text = Admin.adminList.Count.ToString();
            labelUserNumber.Text = User.userList.Count.ToString();
            labelBibliomanNumber.Text = Biblioman.bibliomanList.Count.ToString();
        }

        private void pictureBoxPass_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminUpdatePassword pass = new AdminUpdatePassword();
            pass.Show();
        }

        private void pictureBoxUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            CrudUserSecurity user = new CrudUserSecurity();
            user.Show();
        }

        private void pictureBoxBilio_Click(object sender, EventArgs e)
        {
            this.Hide();
            CrudBiblioman biblio = new CrudBiblioman();
            biblio.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminUpdatePassword pass = new AdminUpdatePassword();
            pass.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            CrudUserSecurity user = new CrudUserSecurity();
            user.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            CrudBiblioman biblio = new CrudBiblioman();
            biblio.Show();
        }

        private void pictureBoxCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            loginPanel login = new loginPanel();
            login.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            loginPanel login = new loginPanel();
            login.Show();
        }
    }
}
