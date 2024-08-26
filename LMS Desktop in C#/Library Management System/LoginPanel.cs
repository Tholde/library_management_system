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
    public partial class loginPanel : Form
    {
        public loginPanel()
        {
            InitializeComponent();
            Admin.LoadAdmin();
            Biblioman.LoadBiblioman();
            User.LoadUser();
        }

        //button exit system
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //List < Admin > listAdmin = Admin.GetAllAdminOnList();
            string username = textBoxUsername.Text;
            string passEncrpt = Admin.passwordEncryption(textBoxPassword.Text);
            string usernameTrue = Admin.findUsername(username);
            string passwordTrue = Admin.findPassword(passEncrpt);

            //biblioman
            string usernameBiblioTrue = Biblioman.findUsername(username);
            string passwordBiblioTrue = Biblioman.findPassword(passEncrpt);

            //user
            string usernameUserTrue = User.findUsername(username);
            string passwordUserTrue = User.findPassword(passEncrpt);

            if (comboBoxFunction.SelectedIndex == 0)
            {
                if (usernameTrue != null && passwordTrue != null)
                {
                    this.Hide();
                    AdminDashboard adminDashboard = new AdminDashboard();
                    adminDashboard.Show();
                }
                else
                    MessageBox.Show("Username or Password not found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (comboBoxFunction.SelectedIndex == 1)
            {
                if (usernameBiblioTrue != null && passwordBiblioTrue != null)
                {
                    this.Hide();
                    MenuBiblioman menu = new MenuBiblioman();
                    menu.Show();
                }
                else
                    MessageBox.Show("Username or Password not found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (comboBoxFunction.SelectedIndex == 2 || comboBoxFunction.SelectedIndex == 3)
            {
                if (usernameUserTrue != null && passwordUserTrue != null)
                {
                    this.Hide();
                    UserDashboard menu = new UserDashboard();
                    menu.Show();
                }
                else
                    MessageBox.Show("Username or Password not found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminUpdatePassword menu = new AdminUpdatePassword();
            menu.Show();
        }

        private void loginPanel_Load(object sender, EventArgs e)
        {
            comboBoxFunction.SelectedIndex = 3;
        }
    }
}
