using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    internal class User
    {
        public string Category { get; set; }
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public static List<User> userList = new List<User>();

        public const string userFileName = "user.txt";

        //izay anaty fichier ataovy anaty list

        public static List<User> GetAllUserOnList()
        {
            string[] lines = File.ReadAllLines(userFileName);

            List<User> listUser = new List<User>();

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');

                User user = new User();
                user.Category = fields[0];
                user.Id = int.Parse(fields[1]);
                user.Fullname = fields[2];
                user.Department = fields[3];
                user.Phone = fields[4];
                user.Address = fields[5];
                user.Username = fields[6];
                user.Password = fields[7];
                user.CreatedDate = DateTime.Parse(fields[8]);
                user.UpdatedDate = DateTime.Parse(fields[9]);

                listUser.Add(user);
            }

            return listUser;
        }
        //search data with id return id
        public static int GetUserById(int id)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Id == id)
                    return i;
            }
            return 2;
        }

        //search data by id and return object
        public static User findUserByIdReturnUser(int id)
        {
            int j = GetUserById(id);
            if (j == 2)
            {
                MessageBox.Show("This User not exist");
            }
            else
            {
                return userList[j];
            }
            return null;
        }

        //izay anaty fichier ataovy anaty list
        public static void LoadUser()
        {
            if (userList.Count > 0)
            {
                userList.Clear(); //raha efa misy ny ao anaty list dia fafao dia izay anaty fichier no ampidirina ao anaty liste
                try
                {
                    string[] lines = File.ReadAllLines(userFileName);

                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(';');

                        User user = new User
                        {
                            Category = fields[0],
                            Id = int.Parse(fields[1]),
                            Fullname = fields[2],
                            Department = fields[3],
                            Phone = fields[4],
                            Address = fields[5],
                            Username = fields[6],
                            Password = fields[7],
                            CreatedDate = DateTime.Parse(fields[8]),
                            UpdatedDate = DateTime.Parse(fields[9])
                        };
                        userList.Add(user);
                    }
                }
                catch (Exception ex) { }

            }
        }

        //mi-enregistrer ilay fichier
        public static void saveUser()
        {
            if (File.Exists(userFileName))
            {
                File.Delete(userFileName);
                try
                {
                    using (StreamWriter writer = new StreamWriter(userFileName, true))
                    {
                        foreach (User user in userList)
                        {
                            writer.Write(user.Category + ";");
                            writer.Write(user.Id + ";");
                            writer.Write(user.Fullname + ";");
                            writer.Write(user.Department + ";");
                            writer.Write(user.Phone + ";");
                            writer.Write(user.Address + ";");
                            writer.Write(user.Username + ";");
                            writer.Write(user.Password + ";");
                            writer.Write(user.CreatedDate + ";");
                            writer.Write(user.UpdatedDate + "\n");
                        }
                        writer.Close();
                    }
                }catch (Exception ex)
                {

                }
            }
            else
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(userFileName, true))
                    {
                        foreach (User user in userList)
                        {
                            writer.Write(user.Category + ";");
                            writer.Write(user.Id + ";");
                            writer.Write(user.Fullname + ";");
                            writer.Write(user.Department + ";");
                            writer.Write(user.Phone + ";");
                            writer.Write(user.Address + ";");
                            writer.Write(user.Username + ";");
                            writer.Write(user.Password + ";");
                            writer.Write(user.CreatedDate + ";");
                            writer.Write(user.UpdatedDate + "\n");
                        }
                        writer.Close();
                    }
                }catch(Exception ex)
                {

                }
            }
        }

        public static string findUsername(string username)
        {
            int lineNumber = 0;
            try
            {
                using (StreamReader reader = new StreamReader(userFileName))
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
            }catch(Exception ex)
            {

            }
            return null;
        }
        public static string findPassword(string password)
        {
            int lineNumber = 0;
            try
            {
                using (StreamReader reader = new StreamReader(userFileName))
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
            }catch (Exception ex)
            {

            }
            return null;
        }

    }
}
