using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Admin
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public static List<Admin> adminList = new List<Admin>();

        public const string adminFileName = "admin.txt";

        ///public static string adminFileName = "admin.txt";
        ///
        //izay anaty fichier ataovy anaty list

        public static List<Admin> GetAllAdminOnList()
        {
            string[] lines = File.ReadAllLines(adminFileName);

            List<Admin> adminlist = new List<Admin>();

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');

                Admin admin = new Admin();
                admin.Username = fields[0];
                admin.Password = fields[1];

                adminlist.Add(admin);
            }

            return adminlist;
        }


        //izay anaty fichier ataovy anaty list
        public static void LoadAdmin()
        {
            if (adminList.Count == 0)
            {
                adminList.Clear();//raha efa misy ny ao anaty list dia fafao dia izay anaty fichier no ampidirina ao anaty liste

                try
                {
                    string[] lines = File.ReadAllLines(adminFileName);

                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(';');

                        Admin admin = new Admin
                        {
                            Username = fields[0],
                            Password = fields[1]
                        };
                        adminList.Add(admin);
                    }
                }
                catch (Exception ex) { }
            }
        }

        //mi-enregistrer ilay fichier
        public static void saveAdmin()
        {
            using (StreamWriter writer = new StreamWriter(adminFileName, true))
            {
                foreach (Admin admin in adminList)
                {
                    writer.Write(admin.Username + ";");
                    writer.Write(admin.Password + "\n");
                }
            }
        }

        public static string findUsername(string username)
        {
            int lineNumber = 0;
            try
            {
                using (StreamReader reader = new StreamReader(adminFileName))
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
            }catch (Exception ex) { }
            return null;
        }
        public static string findPassword(string password)
        {
            int lineNumber = 0;

            using (StreamReader reader = new StreamReader(adminFileName))
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
            return null;
        }

        //function mi-crypter mot de pass
        public static string passwordEncryption(string password)
        {
            //avadika byte en base de 16(hexamal) ilay password ary stocker-na anaty tableau byte
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            SHA256 sha256 = SHA256.Create(); //mi-calcul zay donnee entrer ho amin'ny sha256 hachage

            byte[] hashBytes = sha256.ComputeHash(passwordBytes); //mi-calcul ny valeur hachage amin'ilay tableau byte
            string hashString = BitConverter.ToString(hashBytes).Replace("-", "");
            //raisina anty string amin'izay ilay izy ary afficher-na sous forme hexadecimal

            return hashString;
        }
    }
}
