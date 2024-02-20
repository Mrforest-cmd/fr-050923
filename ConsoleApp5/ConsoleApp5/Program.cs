using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public interface IBook
    {
        string Name { get; set; }
        string Description { get; set; }
        string Author { get; set; }
        ushort Year { get; set; }
    }
    public class Book : IBook
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public ushort Year { get; set; }

        public Book(string Name, string desc, string auth, ushort issue) {
            this.Name = Name;
            this.Description = desc;
            this.Author = auth;
            this.Year = issue;
        }   

    }
    public interface ILibrary
    {
        void AddBook(Book book);
        void RmBook(string Name);
        void ShowAllBooks();
        
    }
    class Library : ILibrary
    {
        public List<Book> Books = new List<Book>();
        public Library() {
            
        }
        public void AddBook(Book book)
        {
            Books.Add(book);
        }
        public void RmBook(string Name)
        {
            foreach (Book book in Books) {
            if(book.Name == Name)
                {
                    Books.Remove(book);
                }
            }
        }
        public void ShowAllBooks()
        {
            foreach (Book book in Books) {
                Console.WriteLine($"Title: {book.Name}" +
                    $"Author: {book.Author}\n" +
                    $"Description: {book.Description}\n" +
                    $"Year of issue: {book.Year}\n");
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Library lib = new Library();
            lib.AddBook(new Book("a","b","c",100));
            lib.AddBook(new Book("d", "e", "f", 150));
            lib.ShowAllBooks();
            lib.RmBook("a");
            lib.ShowAllBooks();
        }
    }
}

/*
Створіть інтерфейс IBook, який визначає методи для отримання інформації про книгу (наприклад, назва, автор, рік видання).

Реалізуйте цей інтерфейс у класах, що представляють окремі книги. Кожен клас повинен надати конкретну реалізацію методів.

Створіть інтерфейс ILibrary, який визначає методи для додавання та видалення книги з бібліотеки, а також для отримання списку всіх книг у бібліотеці.

Реалізуйте цей інтерфейс у класі Library, який буде представляти справжню бібліотеку. Клас повинен мати колекцію книг та методи для взаємодії з бібліотекою.

Створіть основний код програми, в якому створюється об'єкт бібліотеки, додаються кілька книг, виводиться інформація про всі книги та видаляється одна з книг.
 */