using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    internal class Borrow
    {
        public string Isbn { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime BorrowDate { get; set; }
        public int IdUser { get; set; }
        public string Status { get; set; }
        public string Pay { get; set; }
        public const string borrowFileName = "borrow.txt";
        public static List<Borrow> borrowList = new List<Borrow>();
        public const string storyFileName = "story.txt";
        public static List<Borrow> storyList = new List<Borrow>();


        //izay anaty fichier ataovy anaty list

        public static List<Borrow> GetAllBorrowOnList()
        {
            string[] lines = File.ReadAllLines(borrowFileName);

            List<Borrow> listBorrow = new List<Borrow>();

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');

                Borrow borrow = new Borrow();
                borrow.Isbn = fields[0];
                borrow.ReturnDate = DateTime.Parse(fields[1]);
                borrow.BorrowDate = DateTime.Parse(fields[2]);
                borrow.IdUser = int.Parse(fields[3]);
                borrow.Status = fields[4];
                borrow.Pay = fields[5];

                listBorrow.Add(borrow);
            }

            return listBorrow;
        }

        public static List<Borrow> listSpecific(int id)
        {
            List<Borrow> specificList = new List<Borrow>();
            foreach (Borrow brw in borrowList)
            {
                if (brw.IdUser == id)
                {
                    specificList.Add(brw);
                }
            }
            return specificList;
        }
        //search data with id return id
        public static int GetBorrowByIsbn(string isbn)
        {
            for (int i = 0; i < borrowList.Count; i++)
            {
                if (borrowList[i].Isbn.ToLower().Equals(isbn.ToLower()))
                    return i;
            }
            return 2;
        }
        //search data with id return id
        public static int GetBorrowByIsbnStory(string isbn)
        {
            for (int i = 0; i < storyList.Count; i++)
            {
                if (storyList[i].Isbn.ToLower().Equals(isbn.ToLower()))
                    return i;
            }
            return 2;
        }

        //search data with id return id
        public static int GetBorrowByIdUser(int iduser)
        {
            for (int i = 0; i < borrowList.Count; i++)
            {
                if (borrowList[i].IdUser.Equals(iduser))
                    return i;
            }
            return 2;
        }
        //search data by id and return object
        public static Borrow findBorrowByIdReturnBorrowID(int searchkey)
        {
            try
            {
                int j = GetBorrowByIdUser(searchkey);
                if (j == 2)
                {
                    MessageBox.Show("This Book do not borrow");
                }
                else
                {
                    return borrowList[j];
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        //search data by id and return object
        public static Borrow findBorrowByIdReturnBorrow(string searchkey)
        {
            try
            {
                int j = GetBorrowByIsbn(searchkey);
                if (j == 2)
                {
                    MessageBox.Show("This Book do not borrow");
                }
                else
                {
                    return borrowList[j];
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        //search data by id and return object
        public static Borrow findBorrowByIdReturnBorrowStory(string searchkey)
        {
            try
            {
                int j = GetBorrowByIsbnStory(searchkey);
                if (j == 2)
                {
                    MessageBox.Show("This Book do not borrow");
                }
                else
                {
                    return storyList[j];
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        //izay anaty fichier ataovy anaty list
        public static void LoadBorrow()
        {
            if (borrowList.Count == 0)
            {
                borrowList.Clear();//raha efa misy ny ao anaty list dia fafao dia izay anaty fichier no ampidirina ao anaty liste
                try
                {
                    string[] lines = File.ReadAllLines(borrowFileName);

                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(';');

                        Borrow borrow = new Borrow
                        {
                            Isbn = fields[0],
                            ReturnDate = DateTime.Parse(fields[1]),
                            BorrowDate = DateTime.Parse(fields[2]),
                            IdUser = int.Parse(fields[3]),
                            Status = fields[4],
                            Pay = fields[5]
                        };
                        borrowList.Add(borrow);
                    }
                }
                catch (Exception ex) { }
            }
        }

        //mi-enregistrer ilay fichier
        public static void saveBorrow()
        {
            if (File.Exists(borrowFileName))
            {
                File.Delete(borrowFileName);
                using (StreamWriter writer = new StreamWriter(borrowFileName, true))
                {
                    foreach (Borrow borrow in borrowList)
                    {
                        writer.Write(borrow.Isbn + ";");
                        writer.Write(borrow.ReturnDate + ";");
                        writer.Write(borrow.BorrowDate + ";");
                        writer.Write(borrow.IdUser + ";");
                        writer.Write(borrow.Status + ";");
                        writer.Write(borrow.Pay + "\n");
                    }
                    writer.Close();
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(borrowFileName, true))
                {
                    foreach (Borrow borrow in borrowList)
                    {
                        writer.Write(borrow.Isbn + ";");
                        writer.Write(borrow.ReturnDate + ";");
                        writer.Write(borrow.BorrowDate + ";");
                        writer.Write(borrow.IdUser + ";");
                        writer.Write(borrow.Status + ";");
                        writer.Write(borrow.Pay + "\n");
                    }
                    writer.Close();
                }
            }
        }
        //izay anaty fichier ataovy anaty list
        public static void LoadBorrowStory()
        {
            if (storyList.Count == 0)
            {
                storyList.Clear();
                try
                {
                    string[] lines = File.ReadAllLines(storyFileName);

                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(';');

                        Borrow borrow = new Borrow
                        {
                            Isbn = fields[0],
                            ReturnDate = DateTime.Parse(fields[1]),
                            BorrowDate = DateTime.Parse(fields[2]),
                            IdUser = int.Parse(fields[3]),
                            Status = fields[4],
                            Pay = fields[5]
                        };
                        storyList.Add(borrow);
                    }
                }
                catch (Exception ex) { }
            }
        }

        //mi-enregistrer ilay fichier
        public static void saveBorrowStory()
        {
            if (File.Exists(borrowFileName))
            {
                File.Delete(borrowFileName);
                using (StreamWriter writer = new StreamWriter(storyFileName, true))
                {
                    foreach (Borrow borrow in storyList)
                    {
                        writer.Write(borrow.Isbn + ";");
                        writer.Write(borrow.ReturnDate + ";");
                        writer.Write(borrow.BorrowDate + ";");
                        writer.Write(borrow.IdUser + ";");
                        writer.Write(borrow.Status + ";");
                        writer.Write(borrow.Pay + "\n");
                    }
                    writer.Close();
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(storyFileName, true))
                {
                    foreach (Borrow borrow in storyList)
                    {
                        writer.Write(borrow.Isbn + ";");
                        writer.Write(borrow.ReturnDate + ";");
                        writer.Write(borrow.BorrowDate + ";");
                        writer.Write(borrow.IdUser + ";");
                        writer.Write(borrow.Status + ";");
                        writer.Write(borrow.Pay + "\n");
                    }
                    writer.Close();
                }
            }
        }
        public static List<Borrow> listSpecificBorrowStory(int id)
        {
            List<Borrow> specificList = new List<Borrow>();
            foreach (Borrow brw in storyList)
            {
                if (brw.IdUser == id)
                {
                    specificList.Add(brw);
                }
            }
            return specificList;
        }
    }
}
