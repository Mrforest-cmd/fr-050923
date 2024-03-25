using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace ConsoleApp15
{
    class User
    {
        public string email;
        private string password;
        public string fullName;
        public DateTime birthDate;
        public string phoneNumber;

        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public bool Register(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlElement root = doc.DocumentElement;

            foreach (XmlNode node in root.SelectNodes("user"))
            {
                if (node.SelectSingleNode("email").InnerText == email)
                {
                    Console.WriteLine("Email already registered.");
                    return false;
                }
            }

            XmlElement userElement = doc.CreateElement("user");
            XmlElement emailElement = doc.CreateElement("email");
            emailElement.InnerText = email;
            XmlElement passwordElement = doc.CreateElement("password");
            passwordElement.InnerText = password;

            userElement.AppendChild(emailElement);
            userElement.AppendChild(passwordElement);
            root.AppendChild(userElement);

            doc.Save(fileName);
            Console.WriteLine("Registration successful.");
            return true;
        }

        public void AddPersonalInfo(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlElement root = doc.DocumentElement;

            XmlNode userNode = root.SelectSingleNode($"user[email='{email}']");
            if (userNode != null)
            {
                XmlElement fullNameElement = doc.CreateElement("fullName");
                fullNameElement.InnerText = fullName;
                XmlElement birthDateElement = doc.CreateElement("birthDate");
                birthDateElement.InnerText = birthDate.ToString("yyyy-MM-dd");
                XmlElement phoneNumberElement = doc.CreateElement("phoneNumber");
                phoneNumberElement.InnerText = phoneNumber;

                userNode.AppendChild(fullNameElement);
                userNode.AppendChild(birthDateElement);
                userNode.AppendChild(phoneNumberElement);

                doc.Save(fileName);
                Console.WriteLine("Personal information added successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
    }

    class Admin
    {
        private string adminName;
        private string adminPassword;

        public Admin(string adminName, string adminPassword)
        {
            this.adminName = adminName;
            this.adminPassword = adminPassword;
        }

        public bool Login()
        {
            Console.Write("Enter admin name: ");
            string inputName = Console.ReadLine();
            Console.Write("Enter admin password: ");
            string inputPassword = Console.ReadLine();

            if (inputName == adminName && inputPassword == adminPassword)
            {
                Console.WriteLine("Login successful.");
                return true;
            }
            else
            {
                Console.WriteLine("Incorrect admin name or password.");
                return false;
            }
        }

        public void ShowAllUsers(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlElement root = doc.DocumentElement;

            Console.WriteLine("All registered users:");
            foreach (XmlNode userNode in root.SelectNodes("user"))
            {
                string email = userNode.SelectSingleNode("email").InnerText;
                string password = userNode.SelectSingleNode("password").InnerText;
                string fullName = userNode.SelectSingleNode("fullName")?.InnerText ?? "N/A";
                string birthDate = userNode.SelectSingleNode("birthDate")?.InnerText ?? "N/A";
                string phoneNumber = userNode.SelectSingleNode("phoneNumber")?.InnerText ?? "N/A";

                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Password: {password}");
                Console.WriteLine($"Full Name: {fullName}");
                Console.WriteLine($"Birth Date: {birthDate}");
                Console.WriteLine($"Phone Number: {phoneNumber}");
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void CreateDB(string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Clients");
            xmlDoc.AppendChild(root);
            xmlDoc.Save(fileName);
        }

        static void Main(string[] args)
        {
            const string fileName = "users.xml";
            const string adminName = "admin";
            const string adminPassword = "admin";

            CreateDB(fileName);

            Admin admin = new Admin(adminName, adminPassword);

            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Register as a user");
                Console.WriteLine("2. Add personal information (for registered users)");
                Console.WriteLine("3. Show all users (admin)");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();

                        User user = new User(email, password);
                        user.Register(fileName);
                        break;

                    case "2":
                        Console.Write("Enter email: ");
                        email = Console.ReadLine();
                        Console.Write("Enter full name: ");
                        string fullName = Console.ReadLine();
                        Console.Write("Enter birth date (yyyy-MM-dd): ");
                        DateTime birthDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter phone number: ");
                        string phoneNumber = Console.ReadLine();

                        user = new User(email, "");
                        user.fullName = fullName;
                        user.birthDate = birthDate;
                        user.phoneNumber = phoneNumber;
                        user.AddPersonalInfo(fileName);
                        break;

                    case "3":
                        if (admin.Login())
                        {
                            admin.ShowAllUsers(fileName);
                        }
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
/*
Створіть програму.
З базою даних має працювати 2 сутності:
-Адміністратор
-Користувач
 
Користувач має можливість зареєструватись використовуючи пошту та пароль.
Якщо такий така пошта вже зареєстрована, то реєстрація не проходить.
Після реєстрація, користувач має можливість ввести свої дані (ПІБ, Дата народження, Номер телефону).

Адміністратор має змогу отримати повний список усіх користувачів.

 */
