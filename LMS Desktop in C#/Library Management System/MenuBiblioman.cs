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
    public partial class MenuBiblioman : Form
    {
        public MenuBiblioman()
        {
            InitializeComponent();
            User.LoadUser();
            Book.LoadBook();
            Borrow.LoadBorrow();
        }

        /**********************
         * 
         * ****FORM MANAGE*****
         * 
         * ********************/

        private void buttonExitX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //raha hainidy forme
        private void MenuAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Do you realy exit this app ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlg == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        //load menu dia miverina mankany amin'ny dashboard
        private void MenuBiblioman_Load(object sender, EventArgs e)
        {
            panelHome.Visible = true;
            panelUserManage.Visible = false;
            panelBookManage.Visible = false;
            panelBorrow.Visible = false;
            comboBoxFunction.SelectedIndex = 1;
            comboBoxDepartment.SelectedIndex = 0;
            filterCmbByCategory.SelectedIndex = 2;
            filterCmbByDepartment.SelectedIndex = 7;
            textBoxIdUser.Enabled = true;
            textBoxUsername.Enabled = true;
            textBoxPassword.Enabled = true;
            buttonEdit.Enabled = false; //ahidy ilay button edit sao misy mikitika
            buttonDelete.Enabled = false; 
            loadListView();
            loadListViewBook();
            loadListViewBorrow();
            labelUserNumber.Text = Convert.ToString(User.userList.Count);
            labelBookNumber.Text = Convert.ToString(Book.bookList.Count);
            labelBorrowNumber.Text = Convert.ToString(Borrow.borrowList.Count);
        }

        //raha hi-deconnect
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginPanel menu = new loginPanel();
            menu.Show();
        }

        //raha hijery dashboard
        private void buttonHome_Click(object sender, EventArgs e)
        {
            labelUserNumber.Text = Convert.ToString(User.userList.Count);
            panelHome.Visible = true;
            panelUserManage.Visible = false;
            panelBookManage.Visible = false;
            panelBorrow.Visible = false;
        }


        /**********************
         * 
         * ****USER MANAGE*****
         * 
         * ********************/
        //raha hijery user manage
        private void buttonUserManage_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            panelUserManage.Visible = true;
            panelBookManage.Visible = false;
            panelBorrow.Visible = false;
        }

        //add user in file
        private void buttonSaveUser_Click_1(object sender, EventArgs e)
        {
            User user = new User();
            try
            {
                int id = int.Parse(textBoxIdUser.Text);
                int num = User.GetUserById(id);
                //tadiavina aloha ilay id sao dia efa mi-exist ao anaty file
                if (num == 2)
                {
                    /*if (textBoxFullname.Text == null && comboBoxDepartment.Text == null && textBoxUsername.Text == null && textBoxPassword.Text == null)
                    {
                        MessageBox.Show("Have an error !", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {*/
                    string passEncrpt = Admin.passwordEncryption(textBoxPassword.Text);
                    user.Category = comboBoxFunction.Text;
                    user.Id = int.Parse(textBoxIdUser.Text);
                    user.Fullname = textBoxFullname.Text;
                    user.Department = comboBoxDepartment.Text;
                    user.Phone = textBoxPhone.Text;
                    user.Address = textBoxAddress.Text;
                    user.Username = textBoxUsername.Text;
                    user.Password = passEncrpt;
                    user.CreatedDate = DateTime.Now;
                    user.UpdatedDate = DateTime.Now;

                    User.userList.Add(user);
                    User.saveUser();
                    loadListView();
                    MessageBox.Show("User registered !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                }
                //raha ao anaty file izy dia tsy mety intsony
                else
                    MessageBox.Show("User realy exist in list !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add tools is empty !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //atao vide izay forme eo
        void initialisation()
        {
            comboBoxFunction.SelectedIndex = 1;
            comboBoxDepartment.SelectedIndex = 0;
            textBoxIdUser.Text = "";
            textBoxFullname.Text = "";
            textBoxPhone.Text = "";
            textBoxAddress.Text = "";
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
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
                    user.Phone,
                    user.Department,
                    user.Username,
                    user.Address,
                    user.CreatedDate.ToShortDateString(),
                    user.UpdatedDate.ToShortDateString(),
                    user.Category
                });

                listViewUser.Items.Add(listViewItem);
                initialisation();
            }

            toolStripStatusLabel1.Text = listViewUser.Items.Count + "  user(s) saved";
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
                        user.Phone,
                        user.Department,
                        user.Username,
                        user.Address,
                        user.CreatedDate.ToShortDateString(),
                        user.UpdatedDate.ToShortDateString(),
                        user.Category
                    });

                    listViewUser.Items.Add(listViewItem);
                }
                initialisation();
                toolStripStatusLabel1.Text = listViewUser.Items.Count + "  user(s) have this name saved";
            }
        }

        //search data in list view by address
        void loadListViewByAddress(string address)
        {
            listViewUser.Items.Clear();

            foreach (User user in User.userList)
            {
                if (user.Address.ToLower().Contains(address.ToLower()))
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        user.Id.ToString(),
                        user.Fullname,
                        user.Phone,
                        user.Department,
                        user.Username,
                        user.Address,
                        user.CreatedDate.ToShortDateString(),
                        user.UpdatedDate.ToShortDateString(),
                        user.Category
                    });

                    listViewUser.Items.Add(listViewItem);
                }
                initialisation();
                toolStripStatusLabel1.Text = listViewUser.Items.Count + "  user(s) have this address saved";
            }
        }

        //filter data n list view by category
        void filterByCategory(string category)
        {
            listViewUser.Items.Clear();

            foreach (User user in User.userList)
            {

                if (user.Category.ToLower() == category.ToLower())
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        user.Id.ToString(),
                        user.Fullname,
                        user.Phone,
                        user.Department,
                        user.Username,
                        user.Address,
                        user.CreatedDate.ToShortDateString(),
                        user.UpdatedDate.ToShortDateString(),
                        user.Category
                    });

                    listViewUser.Items.Add(listViewItem);
                    toolStripStatusLabel1.Text = listViewUser.Items.Count + "  user(s) in this category saved";
                }

                if (filterCmbByCategory.SelectedItem.ToString().Equals("ALL"))
                {
                    loadListView();
                }


                initialisation();
            }
        }

        //filter data n list view by department
        void filterByDepartment(string department)
        {
            listViewUser.Items.Clear();

            foreach (User user in User.userList)
            {

                if (user.Department.ToLower() == department.ToLower())
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        user.Id.ToString(),
                        user.Fullname,
                        user.Phone,
                        user.Department,
                        user.Username,
                        user.Address,
                        user.CreatedDate.ToShortDateString(),
                        user.UpdatedDate.ToShortDateString(),
                        user.Category
                    });

                    listViewUser.Items.Add(listViewItem);
                    toolStripStatusLabel1.Text = listViewUser.Items.Count + "  user(s) in this department saved";
                }

                if (filterCmbByDepartment.SelectedItem.ToString().Equals("All"))
                {
                    loadListView();
                }
                initialisation();
            }
        }

        //raha mikitika sary user eo amin'ny dashboard
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            panelUserManage.Visible = true;
        }
        //mitady anarana amin'ny alalan'ny soratra atao eo
        private void searchNameTxt_TextChanged(object sender, EventArgs e)
        {
            loadListViewByName(searchNameTxt.Text);
        }
        //mitady address amin'ny alalan'ny soratra atao eo
        private void searchAddressText_TextChanged(object sender, EventArgs e)
        {
            loadListViewByAddress(searchAddressText.Text);
        }
        //filter department amin'ny alalan'ny izay safidy atao eo
        private void filterCmbByDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterByDepartment(filterCmbByDepartment.SelectedItem.ToString());
        }
        //filter category amin'ny alalan'ny izay safidy atao eo
        private void filterCmbByCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterByCategory(filterCmbByCategory.SelectedItem.ToString());
        }
        //izay tsindrina eo amin'ny listView dia aseho eny ambony ny momba azy
        private void listViewUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listes = listViewUser.SelectedItems;

            foreach (ListViewItem item in listes)
            {
                labelIdSelected.Text = item.Text;
                int index = Convert.ToInt32(labelIdSelected.Text);
                int i = User.GetUserById(index);
                if (i != 2)
                {
                    comboBoxFunction.Text = User.userList[i].Category;
                    comboBoxDepartment.Text = User.userList[i].Department;
                    textBoxIdUser.Text = Convert.ToString(User.userList[i].Id);
                    textBoxFullname.Text = User.userList[i].Fullname;
                    textBoxPhone.Text = User.userList[i].Phone;
                    textBoxAddress.Text = User.userList[i].Address;
                    textBoxUsername.Text = User.userList[i].Username;
                    textBoxPassword.Text = "";
                }
            }
            buttonSaveUser.Enabled = false; //blocker-na ilay button save sao misy mikitika
            buttonEdit.Enabled = true;//button edit ihany no azo kitiana ao amin'ny panel voalohany
            //blocker-na izay tsy azo ovaina
            textBoxIdUser.Enabled = false;
            textBoxUsername.Enabled = false;
            textBoxPassword.Enabled = false;
            buttonDelete.Enabled = true;
        }
        //mamafa ary tadiavina ao anaty list aloha
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(labelIdSelected.Text);
                int i = User.GetUserById(index);

                if (i != 2)
                {
                    User.userList.RemoveAt(i);
                    loadListView();
                    User.saveUser();
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Select any user !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //manova izay user tadiavina ny index-n'ilay id dia soloana izay manana an'iny index iny ao amin'ny list
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(labelIdSelected.Text);
            int i = User.GetUserById(index);
            if (i != 2)
            {
                User.userList[i].Category = comboBoxFunction.Text;
                User.userList[i].Department = comboBoxDepartment.Text;
                User.userList[i].Fullname = textBoxFullname.Text;
                User.userList[i].Phone = textBoxPhone.Text;
                User.userList[i].Address = textBoxAddress.Text;

                User.saveUser();
                loadListView();
            }
        }


        /**********************
         * 
         * ****BOOK MANAGE*****
         * 
         * ********************/
        private void buttonBookManage_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            panelUserManage.Visible = false;
            panelBookManage.Visible = true;
            panelBorrow.Visible = false;
        }

        private void buttonSaveBook_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            try
            {
                string isbn = textBoxIsbn.Text;
                int num = Book.GetBookByIsbn(isbn);
                //tadiavina aloha ilay id sao dia efa mi-exist ao anaty file
                if (num == 2)
                {
                    book.Isbn = textBoxIsbn.Text;
                    book.Title = textBoxTitle.Text;
                    book.Author = textBoxAuthor.Text;
                    book.Category = comboBoxCategoryBook.Text;
                    book.Athem = textBoxAthem.Text;
                    book.CreatedDate = DateTime.Now;
                    book.UpdatedDate = DateTime.Now;

                    Book.bookList.Add(book);
                    Book.saveBook();
                    loadListView();
                    MessageBox.Show("User registered !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                }
                //raha ao anaty file izy dia tsy mety intsony
                else
                    MessageBox.Show("User realy exist in list !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add tools is empty !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //atao vide izay forme eo
        void initialisationBook()
        {
            textBoxIsbn.Text = "";
            textBoxTitle.Text = "";
            textBoxAuthor.Text = "";
            comboBoxCategoryBook.SelectedIndex = 0;
            textBoxAuthor.Text = "";
        }

        //rafraichir listView
        void loadListViewBook()
        {
            listViewBook.Items.Clear();

            foreach (Book book in Book.bookList)
            {
                ListViewItem listViewItem = new ListViewItem(new string[]
                {
                    book.Isbn,
                    book.Title,
                    book.Author,
                    book.Category,
                    book.Athem,
                    book.CreatedDate.ToShortDateString(),
                    book.UpdatedDate.ToShortDateString()
                });

                listViewBook.Items.Add(listViewItem);
                initialisationBook();
            }

            toolStripStatusLabelBook.Text = listViewBook.Items.Count + "  book(s) saved";
        }

        //search data in list view by isbn
        void loadListViewByIsbn(string search)
        {
            listViewBook.Items.Clear();

            foreach (Book book in Book.bookList)
            {
                if (book.Isbn.ToLower().Contains(search.ToLower()))
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        book.Isbn,
                        book.Title,
                        book.Author,
                        book.Category,
                        book.Athem,
                        book.CreatedDate.ToShortDateString(),
                        book.UpdatedDate.ToShortDateString()
                    });

                    listViewBook.Items.Add(listViewItem);
                    initialisationBook();
                }

                toolStripStatusLabelBook.Text = listViewBook.Items.Count + "  book(s) have this isbn saved";
            }
        }

        //search data in list view by title
        void loadListViewByTitle(string search)
        {
            listViewBook.Items.Clear();

            foreach (Book book in Book.bookList)
            {
                if (book.Title.ToLower().Contains(search.ToLower()))
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        book.Isbn,
                        book.Title,
                        book.Author,
                        book.Category,
                        book.Athem,
                        book.CreatedDate.ToShortDateString(),
                        book.UpdatedDate.ToShortDateString()
                    });

                    listViewBook.Items.Add(listViewItem);
                    initialisationBook();
                }

                toolStripStatusLabelBook.Text = listViewBook.Items.Count + "  book(s) have this title saved";
            }
        }

        //search data in list view by author
        void loadListViewByAuthor(string search)
        {
            listViewBook.Items.Clear();

            foreach (Book book in Book.bookList)
            {
                if (book.Author.ToLower().Contains(search.ToLower()))
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        book.Isbn,
                        book.Title,
                        book.Author,
                        book.Category,
                        book.Athem,
                        book.CreatedDate.ToShortDateString(),
                        book.UpdatedDate.ToShortDateString()
                    });

                    listViewBook.Items.Add(listViewItem);
                    initialisationBook();
                }

                toolStripStatusLabelBook.Text = listViewBook.Items.Count + "  book(s) have this author saved";
            }
        }

        //search data in list view by athem
        void loadListViewByAthem(string search)
        {
            listViewBook.Items.Clear();

            foreach (Book book in Book.bookList)
            {
                if (book.Athem.ToLower().Contains(search.ToLower()))
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        book.Isbn,
                        book.Title,
                        book.Author,
                        book.Category,
                        book.Athem,
                        book.CreatedDate.ToShortDateString(),
                        book.UpdatedDate.ToShortDateString()
                    });

                    listViewBook.Items.Add(listViewItem);
                    initialisationBook();
                }

                toolStripStatusLabelBook.Text = listViewBook.Items.Count + "  book(s) have this author saved";
            }
        }

        //filter data n list view by category
        void filterByCategoryBook(string category)
        {
            listViewBook.Items.Clear();

            foreach (Book book in Book.bookList)
            {

                if (book.Category.ToLower() == category.ToLower())
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        book.Isbn,
                        book.Title,
                        book.Author,
                        book.Category,
                        book.Athem,
                        book.CreatedDate.ToShortDateString(),
                        book.UpdatedDate.ToShortDateString()
                    });

                    listViewUser.Items.Add(listViewItem);
                    toolStripStatusLabelBook.Text = listViewBook.Items.Count + "  book(s) in this category saved";
                }

                if (filterComboCategory.SelectedItem.ToString().Equals("ALL"))
                {
                    loadListViewBook();
                }


                initialisationBook();
            }
        }

        private void textBoxSearchIsbn_TextChanged(object sender, EventArgs e)
        {
            loadListViewByIsbn(textBoxSearchTitle.Text);
        }

        private void filterComboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterByCategoryBook(filterComboCategory.SelectedItem.ToString());
        }

        private void textBoxSearchTitle_TextChanged(object sender, EventArgs e)
        {
            loadListViewByTitle(textBoxSearchTitle.Text);
        }

        private void textBoxSearchAuthor_TextChanged(object sender, EventArgs e)
        {
            loadListViewByAuthor(textBoxSearchAuthor.Text);
        }

        private void textBoxSearchAthem_TextChanged(object sender, EventArgs e)
        {
            loadListViewByAthem(textBoxSearchAthem.Text);
        }

        private void listViewBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listes = listViewBook.SelectedItems;

            foreach (ListViewItem item in listes)
            {
                labelSelectedElementBook.Text = item.Text;
                string isbn = labelSelectedElementBook.Text;
                int i = Book.GetBookByIsbn(isbn);
                if (i != 2)
                {
                    textBoxIsbn.Text = Book.bookList[i].Isbn;
                    textBoxTitle.Text = Book.bookList[i].Title;
                    textBoxAuthor.Text = Book.bookList[i].Author;
                    comboBoxCategoryBook.Text = Book.bookList[i].Category;
                    textBoxAthem.Text = Book.bookList[i].Athem;
                }
            }
            buttonSaveBook.Enabled = false; //blocker-na ilay button save sao misy mikitika
            buttonEditBook.Enabled = true;//button edit ihany no azo kitiana ao amin'ny panel voalohany
            //blocker/na izay tsy azo ovaina
            textBoxIsbn.Enabled = false;
            buttonDelete.Enabled = true;
        }

        private void buttonEditBook_Click(object sender, EventArgs e)
        {
            string isbn = labelSelectedElementBook.Text;
            int i = Book.GetBookByIsbn(isbn);
            if (i != 2)
            {
                Book.bookList[i].Title = textBoxTitle.Text;
                Book.bookList[i].Author = textBoxAuthor.Text;
                Book.bookList[i].Category = comboBoxCategoryBook.Text;
                Book.bookList[i].Athem = textBoxAthem.Text;

                Book.saveBook();
                loadListViewBook();
                labelSelectedElementBook.Text = "00";
            }
        }

        private void buttonDeleteBook_Click(object sender, EventArgs e)
        {
            try
            {
                string isbn = labelSelectedElementBook.Text;
                int i = Book.GetBookByIsbn(isbn);
                if (i != 2)
                {
                    Book.bookList.RemoveAt(i);
                    loadListViewBook();
                    Book.saveBook();
                    labelSelectedElementBook.Text = "00";
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Select any book !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /**********************
         * 
         * ****BORROW*****
         * 
         * ********************/

        private void buttonBorrow_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            panelUserManage.Visible = false;
            panelBookManage.Visible = false;
            panelBorrow.Visible = true;
            loadListViewBorrow();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            panelUserManage.Visible = false;
            panelBookManage.Visible = false;
            panelBorrow.Visible = true;
            loadListViewBorrow();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            panelUserManage.Visible = false;
            panelBookManage.Visible = true;
            panelBorrow.Visible = false;
            loadListViewBorrow();
        }
        //rafraichir listView
        void loadListViewBorrow()
        {
            listViewBorrow.Items.Clear();

            foreach (Borrow borrow in Borrow.borrowList)
            {
                Book book = Book.findBookByIsbnReturnBookBorrowed(borrow.Isbn);
                ListViewItem listViewItem = new ListViewItem(new string[]
                {
                    borrow.Isbn,
                    book.Title,
                    book.Author,
                    borrow.IdUser.ToString(),
                    borrow.BorrowDate.ToShortDateString(),
                    borrow.ReturnDate.ToShortDateString(),
                    borrow.Status,
                    borrow.Pay
                });

                listViewBorrow.Items.Add(listViewItem);
                initialisationBook();
            }

            toolStripStatusLabel1.Text = listViewBorrow.Items.Count + "  book(s) borrowed saved";
        }
        //search data in list view by isbn
        void loadlistViewBorrowByIsbn(string search)
        {
            listViewBorrow.Items.Clear();

            foreach (Borrow borrow in Borrow.borrowList)
            {
                Book book = Book.findBookByIsbnReturnBookBorrowed(borrow.Isbn);
                if (book.Isbn.ToLower().Contains(search.ToLower()))
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        borrow.Isbn,
                        book.Title,
                        book.Author,
                        borrow.IdUser.ToString(),
                        book.CreatedDate.ToShortDateString(),
                        book.UpdatedDate.ToShortDateString()
                });

                    listViewBorrow.Items.Add(listViewItem);
                    initialisationBook();
                }

                toolStripStatusLabel2.Text = listViewBorrow.Items.Count + "  book(s) have this isbn saved";
            }
        }

        //search data in list view by title
        void loadListViewBorrowByTitle(string search)
        {
            listViewBorrow.Items.Clear();

            foreach (Borrow borrow in Borrow.borrowList)
            {
                Book book = Book.findBookByIsbnReturnBookBorrowed(borrow.Isbn);
                if (book.Title.ToLower().Contains(search.ToLower()))
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        borrow.Isbn,
                        book.Title,
                        book.Author,
                        borrow.IdUser.ToString(),
                        book.CreatedDate.ToShortDateString(),
                        book.UpdatedDate.ToShortDateString()
                    });
                    listViewBorrow.Items.Add(listViewItem);
                    initialisationBook();
                }

                toolStripStatusLabel2.Text = listViewBorrow.Items.Count + "  book(s) have this title saved";
            }
        }

        //search data in list view by author
        void loadListViewBorrowByAuthor(string search)
        {
            listViewBook.Items.Clear();

            foreach (Borrow borrow in Borrow.borrowList)
            {
                Book book = Book.findBookByIsbnReturnBookBorrowed(borrow.Isbn);
                if (book.Author.ToLower().Contains(search.ToLower()))
                {
                    ListViewItem listViewItem = new ListViewItem(new string[]
                    {
                        borrow.Isbn,
                        book.Title,
                        book.Author,
                        borrow.IdUser.ToString(),
                        book.CreatedDate.ToShortDateString(),
                        book.UpdatedDate.ToShortDateString()
                    });

                    listViewBorrow.Items.Add(listViewItem);
                    initialisationBook();
                }

                toolStripStatusLabel2.Text = listViewBorrow.Items.Count + "  book(s) have this author saved";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            loadlistViewBorrowByIsbn(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            loadListViewBorrowByTitle(textBox4.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            loadListViewBorrowByAuthor(textBox2.Text);
        }
        /********************************
* 
* labelBorrowNumber
* labelBookNumber
* 
* ******************************/
    }
}
