#include <iostream>
#include<Windows.h>
#include <string>

using namespace std;

string tolowerstring(string stroke) {
	string returned = "";
	for (int i = 0; i < stroke.length(); i++) {
		returned += tolower(stroke[i]);
	}
	return returned;
}



class Entry {
	string title;
	string description;
public:
	void settitle(string title) {
		this->title = title;
	}
	void setdescription(string description) {
		this->description = description;
	}
	string gettitle() {
		return title;
	}
	string getinfo() {
		return description;
	}
};

class Time {
	unsigned short hours = 0;
	unsigned short minutes = 0;
	string outputtime;
	Entry entry;
public:
	Time(unsigned short minutes = 0, unsigned short hours = 0, string title = "", string description = "") {
		if (hours >= 0 && hours <= 24) {
			this->hours = hours;
		}
		if (minutes >= 0 && minutes <= 60) {
			this->minutes = minutes;
		}
		outputtime = (hours < 10 ? "0" : "") + to_string(hours) + ':' + (minutes < 10 ? "0" : "") + to_string(minutes);

		this->entry.settitle(title);
		this->entry.setdescription(description);
	}
	string getoutputtime() {
		return outputtime;
	}
	unsigned short gethours() {
		return hours;
	}
	Entry getentry() {
		return entry;
	}

};

class Day {
	Time time[24];
	unsigned short n = 0;
public:
	Day() {

	}
	Day(Time time) {
		this->time[n] = time;
		n++;
	}
	void addtime(Time time) {
		this->time[n] = time;
		n++;
	}
	void showtimes() {
		for (int i = 0; i < 24; i++) {
			Entry entry = time[i].getentry();
			if (time[i].getoutputtime() != "00:00") {
				cout << "Time: " << time[i].getoutputtime() << endl << "Title: " << entry.gettitle() << endl << "Description: " << entry.getinfo() << "\n\n";
			}
			
		}
	}
	bool isfull() {
		bool isfull = false;
		for (int i = 0; i < 24; i++) {
			if (time[i].getoutputtime() != "00:00") {
				isfull = true;
			}
		}
		return isfull;
	}
};

class Month {
	unsigned short n = 0;
	Day* days;
	string name;
public:
	Month() {
	}
	Month(string name) {
		if (tolowerstring(name) == "january") {
			n = 31;
		}
		else if (tolowerstring(name) == "february") {
			n = 28;
		}
		else if (tolowerstring(name) == "march") {
			n = 31;
		}
		else if (tolowerstring(name) == "april") {
			n = 30;
		}
		else if (tolowerstring(name) == "may") {
			n = 31;
		}
		else if (tolowerstring(name) == "june") {
			n = 30;
		}
		else if (tolowerstring(name) == "july") {
			n = 31;
		}
		else if (tolowerstring(name) == "september") {
			n = 30;
		}
		else if (tolowerstring(name) == "october") {
			n = 31;
		}
		else if (tolowerstring(name) == "november") {
			n = 30;
		}
		else if (tolowerstring(name) == "december") {
			n = 31;
		}
		else {
			cout << "\nNo such month exist: " << tolowerstring(name);
			n = 1;

		}
		days = new Day[n];
		this->name = name;

	}
	void addday(Day day, unsigned short date) {
		days[date] = day;
	}
	string getname() {
		return this->name;
	}
	void getinfobyday(unsigned short daynumber) {
		days[daynumber - 1].showtimes();
	}
	void showdays() {
		cout << endl << this->name << ':' << endl;
		for (int i = 0; i < n; i++) {
			cout << "Day " << i+1 << endl;
			if (days[i].isfull()) {
				days[i].showtimes();
			}
			else cout << "No tasks scheduled at this day.\n";
			
		}
	}
	Day& getDay(unsigned short dayNum) {
		return days[dayNum - 1];
	}
};


class Year {
	Month M[12];
	unsigned short c = 0;
public:
	Year() {

	}
	void addmonth(Month month) {
		M[c] = month;
		c++;
	}
	Month getmonthbyname(string name) {
		for (int i = 0; i < 12; i++) {
			if (M[i].getname() == tolowerstring(name)) {
				return M[i];
			}
		}
	}
};

class Book {
	Year year2023;
public:
	Book(Year year) {
		this->year2023 = year;
	}
	void searchbymonth(string name) {
		Month object = this->year2023.getmonthbyname(name);
		object.showdays();
	}
	void searchbyday(string monthname, unsigned short daynumber) {
		Month object = this->year2023.getmonthbyname(monthname);
		object.getinfobyday(daynumber);
	}
	void addnote(string title, string info, string month, unsigned short day, unsigned short hour, unsigned short minute) {
		Time time{ minute, hour, title, info };

		Month m = this->year2023.getmonthbyname(month);
		Day& d = m.getDay(day);
		d.addtime(time);
	}
};




int main()
{
	Time two{ 12,5,"meow","mur mur mur" };
	Day three{ two };
	Month jan{ "january" };
	jan.addday(three,1);
	Year year2023;
	year2023.addmonth(jan);
	Book book{ year2023 };
	
	//book.searchbyday("january",1);
	book.addnote("Second Meow", "meow meow meow", "january", 2, 10, 25);
	book.addnote("First Meow", "meow", "january", 1, 10, 25);
	book.searchbyday("january", 2);
	book.searchbymonth("january");
}

