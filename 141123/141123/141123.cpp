#include <iostream>
#include<Windows.h>

using namespace std;

string tolower1251(string stroke) {
	string returned = "";
	for (int i = 0; i < stroke.length(); i++) {
		if (stroke[i] > 191 && stroke[i] < 225) {
			returned[i] = stroke[i] + 32;
		}
		else {
			returned[i] = stroke[i];
		}

	}
	return returned;
}

class Book {
	Year year2023;
public:

};

class Year {
	Month M[12];
public:

};

class Month {
	Day* days = new Day[n];
	unsigned short n = 0;
	string name;
	static unsigned int id;
public:
	Month(string name) {
		id++;
		
		
		switch () {

		}
	}
};
unsigned int Month::id = 0;


class Day {
	Hours hour[24];
	static unsigned int id;
	string info = "";
public:
	Day(string infot="") {
		id++;
		if (infot.length() > this->info.length()) {
			info = infot;
		}
		else {
			delete& info;
		}
	}
	string getinfo() {
		return info;
	}
};
unsigned int Day::id = 0;


class Hours {
	static unsigned int id;
	string info = "";
public:
	Hours(string infot="") {
		id++;
		if (infot.length() > this->info.length()) {
			info = infot;
		}
		else {
			delete& info;
		}
	}
	string getinfo() {
		return info;
	}
};
unsigned int Hours::id = 0;


int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

}

