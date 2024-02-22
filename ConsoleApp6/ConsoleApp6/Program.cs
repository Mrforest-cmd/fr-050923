using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smh;

namespace ConsoleApp6
{
    public abstract class Contact
    {
        string Name;
        string PhoneNumber;
    }
    class PersonalContact : Contact
    {
        PersonalContact(string N, string PN) { ; }
    }
    class BuisnessContact : Contact
    {

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
/*
Розробіть програму для зоопарку, яка моделює роботу з тваринами. 

Створіть інтерфейс "Тварина" (Animal), який містить методи "Голосити" та "Їсти". 
Створіть абстрактний клас "Ссавець" (Mammal), який наслідується від інтерфейсу "Тварина" та містить властивість "Тип Харчування". 
Створіть класи "Собака" (Dog), "Кіт" (Cat) і "Слон" (Elephant), які наслідуються від "Ссавця". 

У кожного з цих класів має бути своя реалізація методів "Голосити" та "Їсти". Додайте можливість зберігати та виводити інформацію про тварин у зоопарку
. 
Використайте колекції для зберігання об'єктів тварин. 
Реалізуйте взаємодію з користувачем, дозволяючи додавати нових тварин, визначати, які тварини знаходяться в зоопарку, та викликати методи "Голосити" та "Їсти" для кожної тварини.
 */