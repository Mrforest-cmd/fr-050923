using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{
    public class CollectionManager<T> where T : IComparable<T>
    {
        private List<T> collection;

        public CollectionManager()
        {
            collection = new List<T>();
        }

        public void AddItem(T item)
        {
            collection.Add(item);
            Console.WriteLine($"Елемент {item} додано до колекції.");
        }

        public void RemoveItem(T item)
        {
            if (collection.Remove(item))
            {
                Console.WriteLine($"Елемент {item} видалено з колекції.");
            }
            else
            {
                Console.WriteLine($"Елемент {item} не знайдено в колекції.");
            }
        }

        public void DisplayItems()
        {
            Console.WriteLine("Елементи колекції:");
            foreach (T item in collection)
            {
                Console.WriteLine(item);
            }
        }
        public void SortCollection(bool ascending = true)
        {
            if (ascending)
            {
                collection.Sort();
                Console.WriteLine("Колекцію відсортовано за зростанням.");
            }
            else
            {
                collection.Sort();
                collection.Reverse();
                Console.WriteLine("Колекцію відсортовано за спаданням.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Виберіть тип колекції:");
                Console.WriteLine("1. Цілі числа");
                Console.WriteLine("2. Рядки");
                Console.WriteLine("3. Об'єкти");
                Console.WriteLine("4. Вийти з програми");

                int choice1 = int.Parse(Console.ReadLine());

                switch (choice1)
                {
                    case 1:
                        CollectionManager<int> integerCollection = new CollectionManager<int>();
                        ManageIntegerCollection(integerCollection);
                        break;
                    case 2:
                        CollectionManager<string> stringCollection = new CollectionManager<string>();
                        ManageStringCollection(stringCollection);
                        break;
                    case 3:
                        ManageObjectCollection();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }

        public static void ManageIntegerCollection(CollectionManager<int> collection)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Виберіть дію для колекції цілих чисел:");
                Console.WriteLine("1. Додати число");
                Console.WriteLine("2. Видалити число");
                Console.WriteLine("3. Вивести коллекцію");
                Console.WriteLine("4. Повернутися до головного меню");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Введіть число: ");
                        int number = int.Parse(Console.ReadLine());
                        collection.AddItem(number);
                        break;
                    case 2:
                        Console.Write("Введіть число для видалення: ");
                        number = int.Parse(Console.ReadLine());
                        collection.RemoveItem(number);
                        break;
                    case 3:
                        collection.DisplayItems();
                        Console.ReadLine();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }

        public static void ManageStringCollection(CollectionManager<string> collection)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Виберіть дію для колекції рядків:");
                Console.WriteLine("1. Додати рядок");
                Console.WriteLine("2. Видалити рядок");
                Console.WriteLine("3. Вивести коллекцію");
                Console.WriteLine("4. Повернутися до головного меню");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Введіть рядок: ");
                        string input = Console.ReadLine();
                        collection.AddItem(input);
                        break;
                    case 2:
                        Console.Write("Введіть рядок для видалення: ");
                        input = Console.ReadLine();
                        collection.RemoveItem(input);
                        break;
                    case 3:
                        collection.DisplayItems();
                        Console.ReadLine();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }

        public static void ManageObjectCollection()
        {
            CollectionManager<Person> personCollection = new CollectionManager<Person>();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Виберіть дію для колекції об'єктів:");
                Console.WriteLine("1. Додати об'єкт");
                Console.WriteLine("2. Видалити об'єкт");
                Console.WriteLine("3. Вивести коллекцію");
                Console.WriteLine("4. Повернутися до головного меню");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Введіть ім'я: ");
                        string name = Console.ReadLine();
                        Console.Write("Введіть вік: ");
                        int age = int.Parse(Console.ReadLine());
                        Person person = new Person { Name = name, Age = age };
                        personCollection.AddItem(person);
                        break;
                    case 2:
                        Console.Write("Введіть ім'я особи для видалення: ");
                        name = Console.ReadLine();
                        Console.Write("Введіть вік особи для видалення: ");
                        age = int.Parse(Console.ReadLine());
                        person = new Person { Name = name, Age = age };
                        personCollection.RemoveItem(person);
                        break;
                    case 3:
                        personCollection.DisplayItems();
                        Console.ReadLine();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
/*
Мета проекту:
Створити програму для управління різнорідними колекціями за допомогою узагальненних класів в мові програмування C#.
Програма повинна забезпечувати можливість додавання, видалення та виведення елементів для різних типів даних.

Основні вимоги:

Створіть обобщений клас CollectionManager<T>, який може працювати з колекціями будь-якого типу T.

Реалізуйте методи для додавання (AddItem), видалення (RemoveItem) та виведення (DisplayItems) елементів колекції.

Забезпечте можливість створення екземплярів CollectionManager для різних типів даних (наприклад, для цілих чисел, рядків, об'єктів тощо).

Напишіть тестовий код, який демонструє використання вашого CollectionManager для різних типів даних.

Зробіть програму інтерактивною, де користувач може обирати тип колекції та взаємодіяти з нею.

Критерії оцінювання:
Правильна реалізація обобщеного класу CollectionManager.
Правильна робота методів додавання, видалення та виведення елементів.
Можливість створення екземплярів для різних типів даних.
Ефективне використання обобщень для роботи з різними типами даних.
Відсутність помилок та відповідність стандартам коду C#.
 */