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
    public partial class CrudBiblioman : Form
    {

        public CrudBiblioman()
        {
            InitializeComponent();
            Biblioman.LoadBiblioman();
        }

        private void CrudBiblioman_Load(object sender, EventArgs e)
        {
            
            textBoxIdBiblioman.Enabled = true;
            textBoxUsernameBiblioman.Enabled = true;
            textBoxPasswordBiblioman.Enabled = true;
            buttonEdit.Enabled = false; //ahidy ilay button edit sao misy mikitika
            buttonDelete.Enabled = false;
            Biblioman.saveBiblioman();
            loadListView();
            labelSelectedElement.Text = "00";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Biblioman biblioman = new Biblioman();
            try
            {
                int id = int.Parse(textBoxIdBiblioman.Text);
                int num = Biblioman.GetBibliomanById(id);
                //tadiavina aloha ilay id sao dia efa mi-exist ao anaty file
                if (num == 2)
                {
                    string passEncrpt = Admin.passwordEncryption(textBoxPasswordBiblioman.Text);
                    biblioman.Id = id;
                    biblioman.FullName = textBoxFullnameBiblioman.Text;
                    biblioman.Phone = textBoxPhoneBiblioman.Text;
                    biblioman.Address = textBoxAddressBiblioman.Text;
                    biblioman.Email = textBoxEmailBiblioman.Text;
                    biblioman.UserName = textBoxUsernameBiblioman.Text;
                    biblioman.Password = passEncrpt;
                    biblioman.CreatedDate = DateTime.Now;
                    biblioman.UpdatedDate = DateTime.Now;

                    Biblioman.bibliomanList.Add(biblioman);
                    Biblioman.saveBiblioman();
                    loadListView();
                    labelSelectedElement.Text = "00";
                    MessageBox.Show("Biblioman registered !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                //raha ao anaty file izy dia tsy mety intsony
                else
                    MessageBox.Show("Biblioman realy exist in list !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add tools is empty !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(labelSelectedElement.Text);
            int i = Biblioman.GetBibliomanById(index);
            if (i != 2)
            {
                Biblioman.bibliomanList[i].FullName = textBoxFullnameBiblioman.Text;
                Biblioman.bibliomanList[i].Phone = textBoxPhoneBiblioman.Text;
                Biblioman.bibliomanList[i].Address = textBoxAddressBiblioman.Text;
                Biblioman.bibliomanList[i].Email = textBoxEmailBiblioman.Text;

                Biblioman.saveBiblioman();
                loadListView();
                MessageBox.Show("Biblioman updated !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labelSelectedElement.Text = "00";
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(labelSelectedElement.Text);
            int i = Biblioman.GetBibliomanById(index);

            if (i != 2)
            {
                Biblioman.bibliomanList.RemoveAt(i);
                loadListView();
                Biblioman.saveBiblioman();
                MessageBox.Show("Biblioman deleted !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                labelSelectedElement.Text = "00";
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard admin = new AdminDashboard();
            admin.Show();
        }

        //search data in list view by name
        void loadListViewByName(string name)
        {
            listViewBiblioman.Items.Clear();

            foreach (Biblioman biblioman in Biblioman.bibliomanList)
            {
                if (biblioman.FullName.ToLower().Contains(name.ToLower()))
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        biblioman.Id.ToString(),
                        biblioman.FullName,
                        biblioman.Phone,
                        biblioman.Address,
                        biblioman.Email,
                        biblioman.UserName,
                        biblioman.CreatedDate.ToShortDateString(),
                        biblioman.UpdatedDate.ToShortDateString()
                    });

                    listViewBiblioman.Items.Add(listViewItem);
                }
                initialisation();
                toolStripStatusLabel1.Text = listViewBiblioman.Items.Count + "  biblioman(s) have this name saved";
            }
        }

        private void searchByName_TextChanged(object sender, EventArgs e)
        {
            loadListViewByName(searchByName.Text);
        }
        //search data in list view by username
        void loadListViewByUsername(string username)
        {
            listViewBiblioman.Items.Clear();

            foreach (Biblioman biblioman in Biblioman.bibliomanList)
            {
                if (biblioman.UserName.ToLower().Contains(username.ToLower()))
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        biblioman.Id.ToString(),
                        biblioman.FullName,
                        biblioman.Phone,
                        biblioman.Address,
                        biblioman.Email,
                        biblioman.UserName,
                        biblioman.CreatedDate.ToShortDateString(),
                        biblioman.UpdatedDate.ToShortDateString()
                    });

                    listViewBiblioman.Items.Add(listViewItem);
                }
                initialisation();
                toolStripStatusLabel1.Text = listViewBiblioman.Items.Count + "  biblioman(s) have this name saved";
            }
        }

        private void searchByUsername_TextChanged(object sender, EventArgs e)
        {
            loadListViewByUsername(searchByUsername.Text);
        }
        //search data in list view by address
        void loadListViewByAddress(string address)
        {
            listViewBiblioman.Items.Clear();

            foreach (Biblioman biblioman in Biblioman.bibliomanList)
            {
                if (biblioman.Address.ToLower().Contains(address.ToLower()))
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        biblioman.Id.ToString(),
                        biblioman.FullName,
                        biblioman.Phone,
                        biblioman.Address,
                        biblioman.Email,
                        biblioman.UserName,
                        biblioman.CreatedDate.ToShortDateString(),
                        biblioman.UpdatedDate.ToShortDateString()
                    });

                    listViewBiblioman.Items.Add(listViewItem);
                }
                initialisation();
                toolStripStatusLabel1.Text = listViewBiblioman.Items.Count + "  biblioman(s) have this name saved";
            }
        }

        private void searchByAddress_TextChanged(object sender, EventArgs e)
        {
            loadListViewByAddress(searchByAddress.Text);
        }

        private void listViewBiblioman_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listes = listViewBiblioman.SelectedItems;

            foreach (ListViewItem item in listes)
            {
                labelSelectedElement.Text = item.Text;
                int index = Convert.ToInt32(labelSelectedElement.Text);
                int i = Biblioman.GetBibliomanById(index);
                if (i != 2)
                {
                    textBoxIdBiblioman.Text = Convert.ToString(Biblioman.bibliomanList[i].Id);
                    textBoxFullnameBiblioman.Text = Biblioman.bibliomanList[i].FullName;
                    textBoxPhoneBiblioman.Text = Biblioman.bibliomanList[i].Phone;
                    textBoxAddressBiblioman.Text = Biblioman.bibliomanList[i].Address;
                    textBoxEmailBiblioman.Text = Biblioman.bibliomanList[i].Email;
                    textBoxUsernameBiblioman.Text = Biblioman.bibliomanList[i].UserName;
                    textBoxPasswordBiblioman.Text = "";
                }
            }
            buttonSave.Enabled = false; //blocker-na ilay button save sao misy mikitika
            buttonEdit.Enabled = true;//button edit ihany no azo kitiana ao amin'ny panel voalohany
            //blocker-na izay tsy azo ovaina
            textBoxIdBiblioman.Enabled = false;
            textBoxUsernameBiblioman.Enabled = false;
            textBoxPasswordBiblioman.Enabled = false;
            buttonDelete.Enabled = true;
        }

        //atao vide izay forme eo
        void initialisation()
        {
            textBoxIdBiblioman.Text = "";
            textBoxFullnameBiblioman.Text = "";
            textBoxPhoneBiblioman.Text = "";
            textBoxAddressBiblioman.Text = "";
            textBoxEmailBiblioman.Text = "";
            textBoxUsernameBiblioman.Text = "";
            textBoxPasswordBiblioman.Text = "";
            labelSelectedElement.Text = "00";
        }

        //rafraichir listView
        void loadListView()
        {
            listViewBiblioman.Items.Clear();

            foreach (Biblioman biblioman in Biblioman.bibliomanList)
            {
                ListViewItem listViewItem = new ListViewItem(new string[]
                {
                    biblioman.Id.ToString(),
                    biblioman.FullName,
                    biblioman.Phone,
                    biblioman.Address,
                    biblioman.Email,
                    biblioman.UserName,
                    biblioman.CreatedDate.ToShortDateString(),
                    biblioman.UpdatedDate.ToShortDateString()
                });

                listViewBiblioman.Items.Add(listViewItem);
                initialisation();
            }

            toolStripStatusLabel1.Text = listViewBiblioman.Items.Count + "  biblioman(s) saved";
        }

    }
}
