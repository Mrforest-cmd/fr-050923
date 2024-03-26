using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace ConsoleApp16
{
    static class UserOperations
    {
        public static void CreateUser(string filepath, string name, string password, string email, int age, double balance, string status, DateTime birthDate, string country)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);

            XmlElement root = xmlDoc.DocumentElement;

            XmlElement user = xmlDoc.CreateElement("User");

            XmlElement nameElement = xmlDoc.CreateElement("Name");
            nameElement.InnerText = name;
            user.AppendChild(nameElement);

            XmlElement passwordElement = xmlDoc.CreateElement("Password");
            passwordElement.InnerText = password;
            user.AppendChild(passwordElement);

            XmlElement emailElement = xmlDoc.CreateElement("Email");
            emailElement.InnerText = email;
            user.AppendChild(emailElement);

            XmlElement ageElement = xmlDoc.CreateElement("Age");
            ageElement.InnerText = age.ToString();
            user.AppendChild(ageElement);

            XmlElement balanceElement = xmlDoc.CreateElement("Balance");
            balanceElement.InnerText = balance.ToString();
            user.AppendChild(balanceElement);

            XmlElement statusElement = xmlDoc.CreateElement("Status");
            statusElement.InnerText = status;
            user.AppendChild(statusElement);

            XmlElement birthDateElement = xmlDoc.CreateElement("BirthDate");
            birthDateElement.InnerText = birthDate.ToString();
            user.AppendChild(birthDateElement);

            XmlElement countryElement = xmlDoc.CreateElement("Country");
            countryElement.InnerText = country;
            user.AppendChild(countryElement);

            root.AppendChild(user);

            xmlDoc.Save(filepath);
            Console.WriteLine("New user record created successfully.");
        }

        public static void EditUser(string filepath, string name, string newPassword, string newEmail, int newAge, double newBalance, string newStatus, DateTime newBirthDate, string newCountry)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);

            XmlNodeList nodes = xmlDoc.SelectNodes($"//User[Name='{name}']");

            foreach (XmlNode node in nodes)
            {
                XmlNode passwordNode = node.SelectSingleNode("Password");
                XmlNode emailNode = node.SelectSingleNode("Email");
                XmlNode ageNode = node.SelectSingleNode("Age");
                XmlNode balanceNode = node.SelectSingleNode("Balance");
                XmlNode statusNode = node.SelectSingleNode("Status");
                XmlNode birthDateNode = node.SelectSingleNode("BirthDate");
                XmlNode countryNode = node.SelectSingleNode("Country");

                passwordNode.InnerText = newPassword;
                emailNode.InnerText = newEmail;
                ageNode.InnerText = newAge.ToString();
                balanceNode.InnerText = newBalance.ToString();
                statusNode.InnerText = newStatus;
                birthDateNode.InnerText = newBirthDate.ToString();
                countryNode.InnerText = newCountry;
            }

            xmlDoc.Save(filepath);
            Console.WriteLine("User record edited successfully.");
        }

        public static void DeleteUser(string filepath, string name)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);

            XmlNodeList nodes = xmlDoc.SelectNodes($"//User[Name='{name}']");

            foreach (XmlNode node in nodes)
            {
                node.ParentNode.RemoveChild(node);
            }
            xmlDoc.Save(filepath);
            Console.WriteLine("User record deleted successfully.");
        }

        public static void ReadUsers(string filepath, string filter = null)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);

            XmlNodeList nodes;
            if (string.IsNullOrEmpty(filter))
            {
                nodes = xmlDoc.SelectNodes("//User");
            }
            else
            {
                nodes = xmlDoc.SelectNodes($"//User[contains(Name, '{filter}') or contains(Email, '{filter}') or contains(Status, '{filter}') or contains(Country, '{filter}')]");
            }

            Console.WriteLine("User data from the XML file:");
            foreach (XmlNode node in nodes)
            {
                string name = node.SelectSingleNode("Name").InnerText;
                string password = node.SelectSingleNode("Password").InnerText;
                string email = node.SelectSingleNode("Email").InnerText;
                int age = int.Parse(node.SelectSingleNode("Age").InnerText);
                double balance = double.Parse(node.SelectSingleNode("Balance").InnerText);
                string status = node.SelectSingleNode("Status").InnerText;
                DateTime birthDate = DateTime.Parse(node.SelectSingleNode("BirthDate").InnerText);
                string country = node.SelectSingleNode("Country").InnerText;

                Console.WriteLine($"Name: {name}\nPassword: {password}\nEmail: {email}\nAge: {age}\nBalance: {balance}\nStatus: {status}\nBirth Date: {birthDate.ToShortDateString()}\nCountry: {country}\n");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string xmlFilePath = "users.xml";

            if (!File.Exists(xmlFilePath))
            {
                Console.WriteLine("File not found. Creating a new XML file.");
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement root = xmlDoc.CreateElement("Users");
                xmlDoc.AppendChild(root);
                xmlDoc.Save(xmlFilePath);
            }

            bool continueLoop = true;

            while (continueLoop)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Create a new user");
                Console.WriteLine("2. Edit an existing user");
                Console.WriteLine("3. Read user data");
                Console.WriteLine("4. Delete a user");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();
                        Console.Write("Enter email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter age: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Enter balance: ");
                        double balance = double.Parse(Console.ReadLine());
                        Console.Write("Enter status: ");
                        string status = Console.ReadLine();
                        Console.Write("Enter birth date (yyyy-MM-dd): ");
                        DateTime birthDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter country: ");
                        string country = Console.ReadLine();

                        UserOperations.CreateUser(xmlFilePath, name, password, email, age, balance, status, birthDate, country);
                        break;

                    case "2":
                        Console.Write("Enter the name of the user to edit: ");
                        string nameToEdit = Console.ReadLine();
                        Console.Write("Enter new password: ");
                        string newPassword = Console.ReadLine();
                        Console.Write("Enter new email: ");
                        string newEmail = Console.ReadLine();
                        Console.Write("Enter new age: ");
                        int newAge = int.Parse(Console.ReadLine());
                        Console.Write("Enter new balance: ");
                        double newBalance = double.Parse(Console.ReadLine());
                        Console.Write("Enter new status: ");
                        string newStatus = Console.ReadLine();
                        Console.Write("Enter new birth date (yyyy-MM-dd): ");
                        DateTime newBirthDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter new country: ");
                        string newCountry = Console.ReadLine();

                        UserOperations.EditUser(xmlFilePath, nameToEdit, newPassword, newEmail, newAge, newBalance, newStatus, newBirthDate, newCountry);
                        break;

                    case "3":
                        Console.Write("Enter a filter (leave blank for all users): ");
                        string filter = Console.ReadLine();
                        UserOperations.ReadUsers(xmlFilePath, filter);
                        break;

                    case "4":
                        Console.Write("Enter the name of the user to delete: ");
                        string nameToDelete = Console.ReadLine();
                        UserOperations.DeleteUser(xmlFilePath, nameToDelete);
                        break;

                    case "5":
                        continueLoop = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}