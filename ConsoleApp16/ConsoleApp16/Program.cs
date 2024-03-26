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

            if (File.Exists(xmlFilePath))
            {
                Console.WriteLine("File found.");

                Console.WriteLine("\nCreating new user record.");
                UserOperations.CreateUser(xmlFilePath, "John Doe", "password123", "john@example.com", 30, 1000.0, "Active", new DateTime(1990, 5, 15), "USA");

                Console.WriteLine("\nData after creating new user record:");
                UserOperations.ReadUsers(xmlFilePath);

                Console.WriteLine("\nEditing user record");
                UserOperations.EditUser(xmlFilePath, "John Doe", "newpassword", "john.doe@example.com", 31, 1200.0, "Inactive", new DateTime(1990, 5, 16), "Canada");

                Console.WriteLine("\nData after editing user record:");
                UserOperations.ReadUsers(xmlFilePath);

                Console.WriteLine("\nReading user records with filter 'john':");
                UserOperations.ReadUsers(xmlFilePath, "john");

                Console.WriteLine("\nDeleting user record");
                UserOperations.DeleteUser(xmlFilePath, "John Doe");

                Console.WriteLine("\nData after deleting user record:");
                UserOperations.ReadUsers(xmlFilePath);
            }
            else
            {
                Console.WriteLine("File not found");
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement root = xmlDoc.CreateElement("Users");
                xmlDoc.AppendChild(root);
                xmlDoc.Save(xmlFilePath);
            }
        }
    }
}