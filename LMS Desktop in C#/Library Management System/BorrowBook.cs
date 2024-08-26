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
    public partial class BorrowBook : Form
    {
        public BorrowBook()
        {
            InitializeComponent();
            User.LoadUser();
            Book.LoadBook();
            Borrow.LoadBorrow();
            Borrow.LoadBorrowStory();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            loginPanel login = new loginPanel();
            login.Show();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDashboard user = new UserDashboard();
            user.Show();
        }


        private void listViewBorrowList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listes = listViewBorrowList.SelectedItems;

            foreach (ListViewItem item in listes)
            {
                labelSelectedElement.Text = item.Text;
                string isbn = labelSelectedElement.Text;
                int i = Borrow.GetBorrowByIsbn(isbn);
                if (i != 2)
                {
                    textBoxIdUser.Text = Convert.ToString(Borrow.borrowList[i].IdUser);
                    textBoxIsbnBook.Text = Borrow.borrowList[i].Isbn;
                }
            }
            buttonBorrow.Enabled = false; //blocker-na ilay button save sao misy mikitika
            buttonReturn.Enabled = true;//button edit ihany no azo kitiana ao amin'ny panel voalohany
            //blocker/na izay tsy azo ovaina
            textBoxIsbnBook.Enabled = false;
            textBoxIdUser.Enabled = false;
            dateTimePicker2.Enabled = true;
        }

        //atao vide izay forme eo
        void initialisationBook()
        {
            textBoxIdUser.Text = "";
            textBoxIsbnBook.Text = "";
            dateTimeEndOfSemester.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }



        //rafraichir listView
        void loadListViewBook(int id)
        {
            listViewBorrowList.Items.Clear();
            List<Borrow> borrowList = Borrow.listSpecific(id);

            foreach (Borrow borrow in borrowList)
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
                }) ;

                listViewBorrowList.Items.Add(listViewItem);
                initialisationBook();
            }

            toolStripStatusLabel1.Text = listViewBorrowList.Items.Count + "  book(s) borrowed saved";
        }

        //rafraichir listView
        void loadListViewBorrowStory(int id)
        {
            listViewBorrowList.Items.Clear();
            List<Borrow> borrowList = Borrow.listSpecificBorrowStory(id);

            foreach (Borrow borrow in borrowList)
            {
                //Book book = Book.findBookByIsbnReturnBookBorrowed(borrow.Isbn);

                ListViewItem listViewItem = new ListViewItem(new string[]
                {
                    borrow.Isbn,
                    borrow.IdUser.ToString(),
                    borrow.BorrowDate.ToShortDateString(),
                    borrow.ReturnDate.ToShortDateString(),
                    borrow.Status,
                    borrow.Pay
                });

                listViewBorrowList.Items.Add(listViewItem);
                initialisationBook();
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            listViewBorrowList.Enabled = true;
            listViewStory.Enabled = true;
            loadListViewBook(int.Parse(textBoxIdUserStory.Text));
            loadListViewBorrowStory(int.Parse(textBoxIdUserStory.Text));
        }


        private void buttonBorrow_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(textBoxIdUser.Text);
            int i = User.GetUserById(index);

            if (i != 2)
            {
                if (User.userList[i].Category.Equals("STUDENT"))
                {
                    Book book = Book.findBookByIsbnReturnBook(textBoxIsbnBook.Text);
                    Borrow borrow = new Borrow();
                    if (book != null)
                    {
                        /*int j = Book.GetBookByIsbn(book.Isbn);
                        if (j != 2)
                        {*/
                        borrow.Isbn = book.Isbn;
                        borrow.BorrowDate = DateTime.Now;
                        borrow.ReturnDate = DateTime.Today.AddDays(3);
                        borrow.IdUser = index;
                        borrow.Status = "borrowed";
                        borrow.Pay = "00 Ar";
                        Book.bookBorrowedList.Add(book);
                        Book.saveBookBorrowed();
                        Borrow.borrowList.Add(borrow);
                        Borrow.saveBorrow();
                        //Book.bookList.RemoveAt(j);
                        Book.bookList.Remove(book);
                        Book.saveBook();
                        //}
                    }
                }
                else if (User.userList[i].Category.Equals("PROFESSOR"))
                {
                    Book book = Book.findBookByIsbnReturnBook(textBoxIsbnBook.Text);
                    Borrow borrow = new Borrow();
                    if (book != null)
                    {
                        /*int j = Book.GetBookByIsbn(book.Isbn);
                        if (j != 2)
                        {*/
                        borrow.Isbn = book.Isbn;
                        borrow.BorrowDate = DateTime.Now;
                        borrow.ReturnDate = dateTimeEndOfSemester.Value;
                        borrow.IdUser = index;
                        borrow.Status = "borrowed";
                        Book.bookBorrowedList.Add(book);
                        Book.saveBookBorrowed();
                        Borrow.borrowList.Add(borrow);
                        Borrow.saveBorrow();
                        //Book.bookList.RemoveAt(j);
                        Book.bookList.Remove(book);
                        Book.saveBook();
                        loadListViewBook(index);
                        //}
                    }
                }
                else
                {
                    MessageBox.Show("User realy exist in list !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(textBoxIdUser.Text);
            int i = User.GetUserById(index);

            if (i != 2)
            {
                if (User.userList[i].Category.Equals("STUDENT"))
                {
                    Book book = Book.findBookByIsbnReturnBookBorrowed(textBoxIsbnBook.Text);
                    if (book != null)
                    {
                        /*int j = Book.GetBookByIsbn(book.Isbn);
                        if (j != 2)
                        {*/
                        Borrow borrow = Borrow.findBorrowByIdReturnBorrow(book.Isbn);
                        TimeSpan borrowingPeriod = borrow.ReturnDate - dateTimePicker2.Value;
                        if(borrowingPeriod.Days > 0)
                        {
                            borrow.Status = "Late "+borrowingPeriod.Days+" day";
                            int result = borrowingPeriod.Days * 500;
                            borrow.Pay = result +" Ar";
                            Book.bookList.Add(book);
                            Book.saveBookBorrowed();
                            Borrow.storyList.Add(borrow);
                            Borrow.saveBorrowStory();
                            Borrow.borrowList.Remove(borrow);
                            Borrow.saveBorrow();
                            loadListViewBook(index);
                            loadListViewBorrowStory(index);
                        }
                        else
                        {
                            borrow.Status = "Normal";
                            borrow.Pay = "00 Ar";
                            Book.bookList.Add(book);
                            Book.saveBookBorrowed();
                            Borrow.storyList.Add(borrow);
                            Borrow.saveBorrowStory();
                            Borrow.borrowList.Remove(borrow);
                            Borrow.saveBorrow();
                            loadListViewBook(index);
                            loadListViewBorrowStory(index);
                        }
                        
                        
                        //}
                    }
                }else if(User.userList[i].Category.Equals("PROFESSOR")){
                    Book book = Book.findBookByIsbnReturnBookBorrowed(textBoxIsbnBook.Text);
                    if (book != null)
                    {
                        /*int j = Book.GetBookByIsbn(book.Isbn);
                        if (j != 2)
                        {*/
                        Borrow borrow = Borrow.findBorrowByIdReturnBorrow(book.Isbn);
                        TimeSpan borrowingPeriod = borrow.ReturnDate - dateTimeEndOfSemester.Value;
                        if (borrowingPeriod.Days > 0)
                        {
                            borrow.Status = "Late " + borrowingPeriod.Days + " day";
                            int result = borrowingPeriod.Days * 500;
                            borrow.Pay = result + " Ar";
                            Book.bookList.Add(book);
                            Book.saveBookBorrowed();
                            Borrow.storyList.Add(borrow);
                            Borrow.saveBorrowStory();
                            Borrow.borrowList.Remove(borrow);
                            Borrow.saveBorrow();
                            loadListViewBook(index);
                            loadListViewBorrowStory(index);
                        }
                        else
                        {
                            borrow.Status = "Normal";
                            borrow.Pay = "00 Ar";
                            Book.bookList.Add(book);
                            Book.saveBookBorrowed();
                            Borrow.storyList.Add(borrow);
                            Borrow.saveBorrowStory();
                            Borrow.borrowList.Remove(borrow);
                            Borrow.saveBorrow();
                            loadListViewBook(index);
                            loadListViewBorrowStory(index);
                        }
                        //}
                    }
                }
            }
        }

        private void BorrowBook_Load(object sender, EventArgs e)
        {
            
            listViewBorrowList.Enabled = false;
            listViewStory.Enabled = false;
            dateTimePicker2.Enabled = false;
            buttonReturn.Enabled = false;
        }

        private void listViewStory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
