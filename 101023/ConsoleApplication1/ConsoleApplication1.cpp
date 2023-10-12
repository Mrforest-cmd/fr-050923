// ConsoleApplication1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>

using namespace std;

class Book {
private:
	string title;
	string author;
	unsigned year;
	string isbn;
	bool isavailable;
public:
	Book() {
		this->title = "title";
		this->author = "author";
		this->year = 1970;
		this->isbn = "isbn";
		this->isavailable = false;
	}
	Book(string title, string author, unsigned year, string isbn, bool isavailable) {
		this->title = title;
		this->author = author;
		this->year = year;
		this->isbn = isbn;
		this->isavailable = isavailable;
	}
	string getisbn() {
		return isbn;
	}
	string getauthor() {
		return author;
	}
	string gettitle() {
		return title;
	}
	bool getisavailable() {
		return isavailable;
	}
	unsigned getyear() {
		return year;
	}
};

class Library {
private:
	unsigned int amount_of_books;
	Book Books[10];
	//Book* Books = new Book[amount_of_books];
public:
	Library(Book Books[]) {
		//this->amount_of_books = 5;
		for (int i = 0; i < 5; i++) {
			this->Books[i] = Books[i];
		}
	}

	void addbook(Book book) {
		Books[amount_of_books] = book;
		++amount_of_books;
	}

	void removebook(string isbn) {
		for (int i = 0; i < amount_of_books; i++) {
			if (Books[i].getisbn() == isbn) {
				Books[i] = {};
			}
		}
	}

	void searchbyauthor(string author) {
		for (int i = 0; i < amount_of_books; i++) {
			if (Books[i].getauthor() == author) {
				cout << "\nTitle: " << Books[i].gettitle();
				cout << "\nAuthor: " << Books[i].getauthor();
				cout << "\nYear: " << Books[i].getyear();
				cout << "\nisbn: " << Books[i].getisbn();
				cout << "\navailable: " << this->Books[i].getisavailable();
				cout << "\n-----------------------";
				break;
			}

		}
	}

};

int main()
{
	Book Books[] {
	{ "To Kill a Mockingbird", "Harper Lee", 1960, "978-0-06-112008-4", true },
	{ "1984", "George Orwell", 1949, "978-0-452-28423-4", true },
	{ "The Great Gatsby", "F. Scott Fitzgerald", 1925, "978-0-7432-7356-5", true },
	{ "Pride and Prejudice", "Jane Austen", 1813, "978-1-59308-190-9", true },
	{ "The Catcher in the Rye", "J.D. Salinger", 1951, "978-0-316-76948-0", true },
	{ "To the Lighthouse", "Virginia Woolf", 1927, "978-0-15-690739-2", true },
	{ "Moby-Dick", "Herman Melville", 1851, "978-0-553-21033-5", true },
	{ "Brave New World", "Aldous Huxley", 1932, "978-0-06-085052-4", true },
	{ "The Hobbit", "J.R.R. Tolkien", 1937, "978-0-618-00221-0", true },
	{ "The Lord of the Rings", "J.R.R. Tolkien", 1954, "978-0-618-34625-3", true }
	};
	Library leha_library { Books };
	leha_library.searchbyauthor("J.R.R. Tolkien");
}


