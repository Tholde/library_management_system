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
    public partial class CrudUserSecurity : Form
    {
        public CrudUserSecurity()
        {
            InitializeComponent();
            User.LoadUser();
        }

        private void CrudUserSecurity_Load(object sender, EventArgs e)
        {
            loadListView();
            textBoxIdUser.Enabled = true;
            labelSelectedElement.Text = "00";
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(labelSelectedElement.Text);
            int i = User.GetUserById(index);
            if (i != 2)
            {
                string pass = Admin.passwordEncryption(textBoxPassword.Text);
                User.userList[i].Username = textBoxUsername.Text;
                User.userList[i].Password = pass;

                User.saveUser();
                loadListView();
                labelSelectedElement.Text = "00";
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            loginPanel login = new loginPanel();
            login.Show();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminDashboard dashb = new AdminDashboard();
            dashb.Show();
        }
        //search data in list view by name
        void loadListViewByName(string name)
        {
            listViewUser.Items.Clear();

            foreach (User user in User.userList)
            {
                if (user.Fullname.ToLower().Contains(name.ToLower()))
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        user.Id.ToString(),
                        user.Fullname,
                        user.Department,
                        user.Username,
                        user.CreatedDate.ToShortDateString(),
                        user.UpdatedDate.ToShortDateString()
                    });

                    listViewUser.Items.Add(listViewItem);
                }
                initialisation();
                toolStripStatusLabel1.Text = listViewUser.Items.Count + "  user(s) have this name saved";
            }
        }
        //search data in list view by name
        void loadListViewByUsername(string name)
        {
            listViewUser.Items.Clear();

            foreach (User user in User.userList)
            {
                if (user.Username.ToLower().Contains(name.ToLower()))
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        user.Id.ToString(),
                        user.Fullname,
                        user.Department,
                        user.Username,
                        user.CreatedDate.ToShortDateString(),
                        user.UpdatedDate.ToShortDateString()
                    });

                    listViewUser.Items.Add(listViewItem);
                }
                initialisation();
                toolStripStatusLabel1.Text = listViewUser.Items.Count + "  user(s) have this name saved";
            }
        }
        private void textBoxSearchUserName_TextChanged(object sender, EventArgs e)
        {
            loadListViewByUsername(textBoxSearchUserName.Text);
        }

        private void textBoxSearchName_TextChanged(object sender, EventArgs e)
        {
            loadListViewByName(textBoxSearchName.Text);
        }


        //atao vide izay forme eo
        void initialisation()
        {
            textBoxIdUser.Text = "";
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            labelSelectedElement.Text = "00";
        }

        //rafraichir listView
        void loadListView()
        {
            listViewUser.Items.Clear();

            foreach (User user in User.userList)
            {
                ListViewItem listViewItem = new ListViewItem(new string[]
                {
                    user.Id.ToString(),
                    user.Fullname,
                    user.Department,
                    user.Username,
                    user.CreatedDate.ToShortDateString(),
                    user.UpdatedDate.ToShortDateString()
                });

                listViewUser.Items.Add(listViewItem);
                initialisation();
            }

            toolStripStatusLabel1.Text = listViewUser.Items.Count + "  user(s) saved";
        }

        private void listViewUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listes = listViewUser.SelectedItems;

            foreach (ListViewItem item in listes)
            {
                labelSelectedElement.Text = item.Text;
                int index = Convert.ToInt32(labelSelectedElement.Text);
                int i = User.GetUserById(index);
                if (i != 2)
                {
                    textBoxIdUser.Text = Convert.ToString(User.userList[i].Id);
                    textBoxUsername.Text = User.userList[i].Username;
                    textBoxPassword.Text = "";
                }
            }
            textBoxIdUser.Enabled = false;
        }
    }
}
