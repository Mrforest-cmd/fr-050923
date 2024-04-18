using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace LibraryManagementSystem
{
    class Program
    {
        private static List<Book> books = new List<Book>();
        private static string filePath = "books.json";

        static void Main(string[] args)
        {
            LoadBooksFromFile();
            bool exit = false;

            while (!exit)
            {
                DisplayMenu();
                int choice = GetUserChoice();
                HandleUserChoice(choice);
                exit = choice == 6;
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Library Management System");
            Console.WriteLine("1. Add a new book");
            Console.WriteLine("2. Edit a book");
            Console.WriteLine("3. Delete a book");
            Console.WriteLine("4. Search for books");
            Console.WriteLine("5. View all books");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
        }

        static int GetUserChoice()
        {
            return int.Parse(Console.ReadLine());
        }

        static void HandleUserChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddBook();
                    break;
                case 2:
                    EditBook();
                    break;
                case 3:
                    DeleteBook();
                    break;
                case 4:
                    SearchBooks();
                    break;
                case 5:
                    ViewAllBooks();
                    break;
                case 6:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        static void AddBook()
        {
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();
            Console.Write("Enter author: ");
            string author = Console.ReadLine();
            Console.Write("Enter genre: ");
            string genre = Console.ReadLine();
            Console.Write("Enter publication year: ");
            int publicationYear = int.Parse(Console.ReadLine());

            Book newBook = new Book
            {
                Title = title,
                Author = author,
                Genre = genre,
                PublicationYear = publicationYear
            };

            books.Add(newBook);
            SaveBooksToFile();
            Console.WriteLine("Book added successfully.");
        }

        static void EditBook()
        {
            Console.Write("Enter the title of the book you want to edit: ");
            string title = Console.ReadLine();

            Book bookToEdit = books.Find(b => b.Title == title);

            if (bookToEdit != null)
            {
                Console.Write("Enter new title (or leave blank to keep the current title): ");
                string newTitle = Console.ReadLine();
                if (!string.IsNullOrEmpty(newTitle))
                    bookToEdit.Title = newTitle;

                Console.Write("Enter new author (or leave blank to keep the current author): ");
                string newAuthor = Console.ReadLine();
                if (!string.IsNullOrEmpty(newAuthor))
                    bookToEdit.Author = newAuthor;

                Console.Write("Enter new genre (or leave blank to keep the current genre): ");
                string newGenre = Console.ReadLine();
                if (!string.IsNullOrEmpty(newGenre))
                    bookToEdit.Genre = newGenre;

                Console.Write("Enter new publication year (or leave blank to keep the current year): ");
                string newPublicationYear = Console.ReadLine();
                if (!string.IsNullOrEmpty(newPublicationYear))
                    bookToEdit.PublicationYear = int.Parse(newPublicationYear);

                SaveBooksToFile();
                Console.WriteLine("Book edited successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        static void DeleteBook()
        {
            Console.Write("Enter the title of the book you want to delete: ");
            string title = Console.ReadLine();

            Book bookToDelete = books.Find(b => b.Title == title);

            if (bookToDelete != null)
            {
                books.Remove(bookToDelete);
                SaveBooksToFile();
                Console.WriteLine("Book deleted successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        static void SearchBooks()
        {
            Console.Write("Enter search criteria (title, author, genre, or publication year): ");
            string searchCriteria = Console.ReadLine();

            List<Book> searchResults = books.FindAll(b =>
                b.Title.Contains(searchCriteria) ||
                b.Author.Contains(searchCriteria) ||
                b.Genre.Contains(searchCriteria) ||
                b.PublicationYear.ToString().Contains(searchCriteria)
            );

            if (searchResults.Count > 0)
            {
                Console.WriteLine("Search results:");
                foreach (Book book in searchResults)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Publication Year: {book.PublicationYear}");
                }
            }
            else
            {
                Console.WriteLine("No books found matching the search criteria.");
            }
        }

        static void ViewAllBooks()
        {
            if (books.Count > 0)
            {
                Console.WriteLine("All books in the library:");
                foreach (Book book in books)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Publication Year: {book.PublicationYear}");
                }
            }
            else
            {
                Console.WriteLine("No books found in the library.");
            }
        }

        static void LoadBooksFromFile()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }
        }

        static void SaveBooksToFile()
        {
            string json = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
    }
}