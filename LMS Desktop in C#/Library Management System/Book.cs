using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    internal class Book
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Athem { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public static List<Book> bookList = new List<Book>();

        public const string bookFileName = "book.txt";

        public static List<Book> bookBorrowedList = new List<Book>();

        public const string bookBorrowFileName = "bookBorrowed.txt";

        //izay anaty fichier ataovy anaty list

        public static List<Book> GetAllBookBorrowedOnList()
        {
            
            string[] lines = File.ReadAllLines(bookBorrowFileName);

            List<Book> listBook = new List<Book>();

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');

                Book book = new Book();
                book.Isbn = fields[0];
                book.Title = fields[1];
                book.Author = fields[2];
                book.Category = fields[3];
                book.Athem = fields[4];
                book.CreatedDate = DateTime.Parse(fields[5]);
                book.UpdatedDate = DateTime.Parse(fields[6]);

                listBook.Add(book);
            }

            return listBook;
        }
        //search data with id return id
        public static int GetBookBorrowedByIsbn(string isbn)
        {
            for (int i = 0; i < bookBorrowedList.Count; i++)
            {
                if (bookBorrowedList[i].Isbn.ToLower().Equals(isbn.ToLower()))
                    return i;
            }
            return 2;
        }

        //search data by id and return object
        public static Book findBookByIsbnReturnBookBorrowed(string searchkey)
        {
            int j = GetBookBorrowedByIsbn(searchkey);
            if (j == 2)
            {
                MessageBox.Show("This Book not exist");
            }
            else
            {
                return bookBorrowedList[j];
            }
            return null;
        }
        //izay anaty fichier ataovy anaty list
        public static void LoadBookBorrowed()
        {
            if (bookList.Count > 0)
            {
                bookList.Clear();
                try
                {
                    string[] lines = File.ReadAllLines(bookBorrowFileName);

                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(';');

                        Book book = new Book
                        {
                            Isbn = fields[0],
                            Title = fields[1],
                            Author = fields[2],
                            Category = fields[3],
                            Athem = fields[4],
                            CreatedDate = DateTime.Parse(fields[5]),
                            UpdatedDate = DateTime.Parse(fields[6])
                        };
                        bookBorrowedList.Add(book);
                    }
                }
                catch (Exception ex) { }
            }
        }

        //mi-enregistrer ilay fichier
        public static void saveBookBorrowed()
        {
            if (File.Exists(bookBorrowFileName))
            {
                File.Delete(bookBorrowFileName);
                using (StreamWriter writer = new StreamWriter(bookBorrowFileName, true))
                {
                    foreach (Book book in bookBorrowedList)
                    {
                        writer.Write(book.Isbn + ";");
                        writer.Write(book.Title + ";");
                        writer.Write(book.Author + ";");
                        writer.Write(book.Category + ";");
                        writer.Write(book.Athem + ";");
                        writer.Write(book.CreatedDate + ";");
                        writer.Write(book.UpdatedDate + "\n");
                    }
                    writer.Close();
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(bookBorrowFileName, true))
                {
                    foreach (Book book in bookBorrowedList)
                    {
                        writer.Write(book.Isbn + ";");
                        writer.Write(book.Title + ";");
                        writer.Write(book.Author + ";");
                        writer.Write(book.Category + ";");
                        writer.Write(book.Athem + ";");
                        writer.Write(book.CreatedDate + ";");
                        writer.Write(book.UpdatedDate + "\n");
                    }
                    writer.Close();
                }
            }
        }

        //izay anaty fichier ataovy anaty list

        public static List<Book> GetAllBookOnList()
        {
            string[] lines = File.ReadAllLines(bookFileName);

            List<Book> listBook = new List<Book>();

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');

                Book book = new Book();
                book.Isbn = fields[0];
                book.Title = fields[1];
                book.Author = fields[2];
                book.Category = fields[3];
                book.Athem = fields[4];
                book.CreatedDate = DateTime.Parse(fields[5]);
                book.UpdatedDate = DateTime.Parse(fields[6]);

                listBook.Add(book);
            }

            return listBook;
        }
        //search data with id return id
        public static int GetBookByIsbn(string isbn)
        {
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].Isbn.ToLower().Equals(isbn.ToLower()))
                    return i;
            }
            return 2;
        }

        //search data by id and return object
        public static Book findBookByIsbnReturnBook(string searchkey)
        {
            int j = GetBookByIsbn(searchkey);
                if (j == 2)
                {
                    MessageBox.Show("This Book not exist");
                }
                else
                {
                    return bookList[j];
                }
            return null;
        }

        //izay anaty fichier ataovy anaty list
        public static void LoadBook()
        {
            if (bookList.Count > 0)
            {
                bookList.Clear();//raha efa misy ny ao anaty list dia fafao dia izay anaty fichier no ampidirina ao anaty liste
                try
                {
                    string[] lines = File.ReadAllLines(bookFileName);

                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(';');

                        Book book = new Book
                        {
                            Isbn = fields[0],
                            Title = fields[1],
                            Author = fields[2],
                            Category = fields[3],
                            Athem = fields[4],
                            CreatedDate = DateTime.Parse(fields[5]),
                            UpdatedDate = DateTime.Parse(fields[6])
                        };
                        bookList.Add(book);
                    }
                }
                catch (Exception ex) { }
            }
        }

        //mi-enregistrer ilay fichier
        public static void saveBook()
        {
            if (File.Exists(bookFileName))
            {
                File.Delete(bookFileName);
                try
                {
                    using (StreamWriter writer = new StreamWriter(bookFileName, true))
                    {
                        foreach (Book book in bookList)
                        {
                            writer.Write(book.Isbn + ";");
                            writer.Write(book.Title + ";");
                            writer.Write(book.Author + ";");
                            writer.Write(book.Category + ";");
                            writer.Write(book.Athem + ";");
                            writer.Write(book.CreatedDate + ";");
                            writer.Write(book.UpdatedDate + "\n");
                        }
                        writer.Close();
                    }
                }catch(Exception ex)
                {

                }
            }
            else
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(bookFileName, true))
                    {
                        foreach (Book book in bookList)
                        {
                            writer.Write(book.Isbn + ";");
                            writer.Write(book.Title + ";");
                            writer.Write(book.Author + ";");
                            writer.Write(book.Category + ";");
                            writer.Write(book.Athem + ";");
                            writer.Write(book.CreatedDate + ";");
                            writer.Write(book.UpdatedDate + "\n");
                        }
                        writer.Close();
                    }
                }catch (Exception ex) { }
            }
        }

    }
}
