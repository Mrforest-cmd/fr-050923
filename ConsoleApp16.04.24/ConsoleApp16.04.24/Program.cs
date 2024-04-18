using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp16._04._24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("table16042024.xml");

            XmlNodeList companyNodes = xmlDoc.SelectNodes("//Company");

            foreach (XmlNode companyNode in companyNodes)
            {
                Console.WriteLine("Company ID: " + companyNode.SelectSingleNode("ID").InnerText);
                Console.WriteLine("Company Name: " + companyNode.SelectSingleNode("Name").InnerText);

                XmlNodeList employeeNodes = companyNode.SelectNodes(".//Employee");

                foreach (XmlNode employeeNode in employeeNodes)
                {
                    Console.WriteLine("\tEmployee ID: " + employeeNode.SelectSingleNode("ID").InnerText);
                    Console.WriteLine("\tEmployee Name: " + employeeNode.SelectSingleNode("Name").InnerText);
                    Console.WriteLine("\tEmployee Department: " + employeeNode.SelectSingleNode("Department").InnerText);
                    Console.WriteLine("\tEmployee Salary: " + employeeNode.SelectSingleNode("Salary").InnerText);

                    XmlNodeList projectNodes = employeeNode.SelectNodes(".//Projects/ProjectID");

                    Console.Write("\tEmployee Projects: ");
                    foreach (XmlNode projectNode in projectNodes)
                    {
                        Console.Write(projectNode.InnerText + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
