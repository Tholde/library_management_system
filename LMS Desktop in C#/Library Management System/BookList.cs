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
    public partial class BookList : Form
    {
        public BookList()
        {
            InitializeComponent();
            Book.LoadBook();
        }

        private void BookList_Load(object sender, EventArgs e)
        {
            loadListView();
        }
        //search data in list view by isbn
        void loadListViewByIsbn(string search)
        {
            listViewBookList.Items.Clear();

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

                    listViewBookList.Items.Add(listViewItem);
                }

                toolStripStatusLabel1.Text = listViewBookList.Items.Count + "  book(s) have this isbn saved";
            }
        }

        //search data in list view by title
        void loadListViewByTitle(string search)
        {
            listViewBookList.Items.Clear();

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

                    listViewBookList.Items.Add(listViewItem);
                }

                toolStripStatusLabel1.Text = listViewBookList.Items.Count + "  book(s) have this title saved";
            }
        }

        //search data in list view by author
        void loadListViewByAuthor(string search)
        {
            listViewBookList.Items.Clear();

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

                    listViewBookList.Items.Add(listViewItem);
                }

                toolStripStatusLabel1.Text = listViewBookList.Items.Count + "  book(s) have this author saved";
            }
        }

        //search data in list view by athem
        void loadListViewByAthem(string search)
        {
            listViewBookList.Items.Clear();

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

                    listViewBookList.Items.Add(listViewItem);
                }

                toolStripStatusLabel1.Text = listViewBookList.Items.Count + "  book(s) have this author saved";
            }
        }

        //filter data n list view by category
        void filterByCategoryBook(string category)
        {
            listViewBookList.Items.Clear();

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

                    listViewBookList.Items.Add(listViewItem);
                    toolStripStatusLabel1.Text = listViewBookList.Items.Count + "  book(s) in this category saved";
                }

                if (comboBoxCategory.SelectedItem.ToString().Equals("ALL"))
                {
                    loadListView();
                }


            }
        }
        private void textBoxIsbn_TextChanged(object sender, EventArgs e)
        {
            loadListViewByIsbn(textBoxIsbn.Text);
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterByCategoryBook(comboBoxCategory.Text);
        }

        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {
            loadListViewByTitle(textBoxTitle.Text);
        }

        private void textBoxAthem_TextChanged(object sender, EventArgs e)
        {
            loadListViewByAthem(textBoxAthem.Text);
        }

        private void textBoxAuthor_TextChanged(object sender, EventArgs e)
        {
            loadListViewByAuthor(textBoxAuthor.Text);
        }

        private void listViewBookList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void loadListView()
        {
            listViewBookList.Items.Clear();

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
                listViewBookList.Items.Add(listViewItem);
            }

            toolStripStatusLabel1.Text = listViewBookList.Items.Count + "  book(s) saved";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDashboard user = new UserDashboard();
            user.Show();
        }
    }
}
