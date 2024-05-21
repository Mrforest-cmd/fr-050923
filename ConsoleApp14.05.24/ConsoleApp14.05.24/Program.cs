using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14._05._24
{
        class Contact
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
        }

        class ContactManager
        {
            private List<Contact> contacts = new List<Contact>();

            public void AddContact(Contact contact)
            {
                contacts.Add(contact);
            }

            public void RemoveContact(Contact contact)
            {
                contacts.Remove(contact);
            }

            public List<Contact> GetAllContacts()
            {
                return contacts;
            }
        }

        class Controller
        {
            private ContactManager contactManager = new ContactManager();

            public void Run()
            {
                while (true)
                {
                    Console.WriteLine("Виберіть опцію:");
                    Console.WriteLine("1. Додати контакт");
                    Console.WriteLine("2. Видалити контакт");
                    Console.WriteLine("3. Переглянути всі контакти");
                    Console.WriteLine("4. Вийти");

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            AddContact();
                            break;
                        case "2":
                            RemoveContact();
                            break;
                        case "3":
                            ViewAllContacts();
                            break;
                        case "4":
                            return;
                        default:
                            Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                            break;
                    }
                }
            }

            private void AddContact()
            {
                Console.Write("Введіть ім'я: ");
                string firstName = Console.ReadLine();

                Console.Write("Введіть прізвище: ");
                string lastName = Console.ReadLine();

                Console.Write("Введіть номер телефону: ");
                string phoneNumber = Console.ReadLine();

                Contact contact = new Contact
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber
                };

                contactManager.AddContact(contact);
                Console.WriteLine("Контакт додано.");
            }

            private void RemoveContact()
            {
                List<Contact> contacts = contactManager.GetAllContacts();

                if (contacts.Count == 0)
                {
                    Console.WriteLine("Список контактів порожній.");
                    return;
                }

                Console.WriteLine("Виберіть контакт для видалення:");

                for (int i = 0; i < contacts.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {contacts[i].FirstName} {contacts[i].LastName}");
                }

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= contacts.Count)
                {
                    Contact contactToRemove = contacts[choice - 1];
                    contactManager.RemoveContact(contactToRemove);
                    Console.WriteLine("Контакт видалено.");
                }
                else
                {
                    Console.WriteLine("Невірний вибір.");
                }
            }

            private void ViewAllContacts()
            {
                List<Contact> contacts = contactManager.GetAllContacts();

                if (contacts.Count == 0)
                {
                    Console.WriteLine("Список контактів порожній.");
                    return;
                }

                Console.WriteLine("Список контактів:");

                foreach (Contact contact in contacts)
                {
                    Console.WriteLine($"{contact.FirstName} {contact.LastName} - {contact.PhoneNumber}");
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Controller controller = new Controller();
                controller.Run();
            }
        }
    }
