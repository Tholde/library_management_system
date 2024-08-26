using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    internal class Biblioman
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public static List<Biblioman> bibliomanList = new List<Biblioman>();

        public const string bibliomanFileName = "biblioman.txt";

        //izay anaty fichier ataovy anaty list

        public static List<Biblioman> GetAllBibliomanOnList()
        {
            string[] lines = File.ReadAllLines(bibliomanFileName);

            List<Biblioman> listBiblioman = new List<Biblioman>();

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');

                Biblioman biblioman = new Biblioman();
                biblioman.Id = int.Parse(fields[0]);
                biblioman.FullName = fields[1];
                biblioman.Phone = fields[2];
                biblioman.Email = fields[3];
                biblioman.Address = fields[4];
                biblioman.UserName = fields[5];
                biblioman.Password = fields[6];
                biblioman.CreatedDate = DateTime.Parse(fields[7]);
                biblioman.UpdatedDate = DateTime.Parse(fields[8]);

                listBiblioman.Add(biblioman);
            }

            return listBiblioman;
        }
        //search data with id return id
        public static int GetBibliomanById(int id)
        {
            for (int i = 0; i < bibliomanList.Count; i++)
            {
                if (bibliomanList[i].Id == id)
                    return i;
            }
            return 2;
        }

        //search data by id and return object
        public static Biblioman findBibliomanByIdReturnBiblioman(int id)
        {
            int j = GetBibliomanById(id);
            if (j == 2)
            {
                MessageBox.Show("This Biblioman not exist");
            }
            else
            {
                return bibliomanList[j];
            }
            return null;
        }

        //izay anaty fichier ataovy anaty list
        public static void LoadBiblioman()
        {
            if (bibliomanList.Count == 0)
            {

                bibliomanList.Clear();//raha efa misy ny ao anaty list dia fafao dia izay anaty fichier no ampidirina ao anaty liste
                try
                {
                    string[] lines = File.ReadAllLines(bibliomanFileName);

                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(';');

                        Biblioman biblioman = new Biblioman
                        {
                            Id = int.Parse(fields[0]),
                            FullName = fields[1],
                            Phone = fields[2],
                            Email = fields[3],
                            UserName = fields[4],
                            Password = fields[5],
                            CreatedDate = DateTime.Parse(fields[6]),
                            UpdatedDate = DateTime.Parse(fields[7])
                        };
                        bibliomanList.Add(biblioman);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        //mi-enregistrer ilay fichier
        public static void saveBiblioman()
        {
            if (File.Exists(bibliomanFileName))
            {
                File.Delete(bibliomanFileName);
                try
                {
                    using (StreamWriter writer = new StreamWriter(bibliomanFileName, true))
                    {
                        foreach (Biblioman biblioman in bibliomanList)
                        {
                            writer.Write(biblioman.Id + ";");
                            writer.Write(biblioman.FullName + ";");
                            writer.Write(biblioman.Phone + ";");
                            writer.Write(biblioman.Email + ";");
                            writer.Write(biblioman.Phone + ";");
                            writer.Write(biblioman.UserName + ";");
                            writer.Write(biblioman.Password + ";");
                            writer.Write(biblioman.CreatedDate + ";");
                            writer.Write(biblioman.UpdatedDate + "\n");
                        }
                        writer.Close();
                    }
                }catch(Exception ex) { }
            }
            else
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(bibliomanFileName, true))
                    {
                        foreach (Biblioman biblioman in bibliomanList)
                        {
                            writer.Write(biblioman.Id + ";");
                            writer.Write(biblioman.FullName + ";");
                            writer.Write(biblioman.Phone + ";");
                            writer.Write(biblioman.Email + ";");
                            writer.Write(biblioman.Phone + ";");
                            writer.Write(biblioman.UserName + ";");
                            writer.Write(biblioman.Password + ";");
                            writer.Write(biblioman.CreatedDate + ";");
                            writer.Write(biblioman.UpdatedDate + "\n");
                        }
                        writer.Close();
                    }
                }catch (Exception ex) { }
            }
        }

        public static string findUsername(string username)
        {
            int lineNumber = 0;
            try
            {
                using (StreamReader reader = new StreamReader(bibliomanFileName))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        lineNumber++;
                        if (line.Contains(username))
                        {
                            return username;
                        }
                    }
                }
            }catch (Exception ex)
            {

            }
            return null;
        }
        public static string findPassword(string password)
        {
            int lineNumber = 0;
            try
            {
                using (StreamReader reader = new StreamReader(bibliomanFileName))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        lineNumber++;
                        if (line.Contains(password))
                        {
                            return password;
                        }
                    }
                }
            }catch(Exception ex)
            {

            }
            return null;
        }

    }
}
