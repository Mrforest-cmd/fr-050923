using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace ConsoleApp15
{
    
    public class DataBase
    {
        private string fileName;
        private int elementcount;
        public DataBase(string fileName)
        {
            this.fileName = fileName;
            this.elementcount = 0;
            CreateDB();
            
        }
        private void CreateDB()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Clients");
            xmlDoc.AppendChild(root);
            xmlDoc.Save(fileName);
        }
        public void AddClient(string pip, int age, string phone)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            XmlElement root = xmlDoc.DocumentElement;

            XmlElement client = xmlDoc.CreateElement("Client");

            XmlElement Pip = xmlDoc.CreateElement("Pip");
            Pip.InnerText = pip;
            client.AppendChild(Pip);

            XmlElement Age = xmlDoc.CreateElement("Age");
            Age.InnerText = age.ToString();
            client.AppendChild(Age);

            XmlElement Phone = xmlDoc.CreateElement("Phone");
            Phone.InnerText = phone;
            client.AppendChild(Phone);

            XmlElement id = xmlDoc.CreateElement("ID");
            id.InnerText = (++elementcount).ToString();
            client.AppendChild(id);

            root.AppendChild(client);

            xmlDoc.Save(fileName);
        }

        public void ShowClients()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            XmlElement root = xmlDoc.DocumentElement;

            Console.WriteLine("XML DATA:");
            foreach (XmlNode node in root.ChildNodes)
            {
                string name = node.SelectSingleNode("Pip").InnerText;
                string age = node.SelectSingleNode("Age").InnerText;
                string Phone = node.SelectSingleNode("Phone").InnerText;
                string id = node.SelectSingleNode("ID").InnerText;

                Console.WriteLine($"Name: {name}\n" +
                    $"Age: {age}\n" +
                    $"Phone: {Phone}\n" +
                    $"Id: {id}\n");
            }
        }
    }
    internal class task1
    {
        static void Main1(string[] args)
        {
            DataBase db = new DataBase("MeowDB.xml");

            db.AddClient("Barsik Blohovozka Mihailovich", 5, "+380182388");
            db.AddClient("Lucya Blohovozka Barsikovna", 6, "+380123672");

            db.ShowClients();
        }
    }
}
