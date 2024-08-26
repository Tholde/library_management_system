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
    public partial class UserDashboard : Form
    {
        public UserDashboard()
        {
            InitializeComponent();
            Book.LoadBook();
        }

        private void pictureBoxBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookList book = new BookList();
            book.Show();
        }

        private void pictureBoxBorrow_Click(object sender, EventArgs e)
        {
            this.Hide();
            BorrowBook borrow = new BorrowBook();
            borrow.Show();
        }

        private void labelBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookList book = new BookList();
            book.Show();
        }

        private void labelBorrow_Click(object sender, EventArgs e)
        {
            this.Hide();
            BorrowBook borrow = new BorrowBook();
            borrow.Show();
        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {
            labelBookNumber.Text = Convert.ToString(Book.bookList.Count);
        }
    }
}
