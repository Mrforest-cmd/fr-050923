#include <iostream>
#include<Windows.h>
#include <string>

using namespace std;

string tolowerstring(string stroke) {
	string returned = "";
	for (int i = 0; i < stroke.length(); i++) {
		returned[i] = tolower(stroke[i]);
	}
	return returned;
}

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

class Month {
	unsigned short n = 0;
	Day* days = new Day[n];
	string name;
	unsigned short c = 0;
public:
	Month(string name="stub") {
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
			cout << "\nNo such month exist.\n";
			n = 1;
		}
		this->name = name;
	}
	void addday(Day day) {
		days[c] = day;
		c++;
	}
	string getname() {
		return this->name;
	}
	void showdays() {
		for (int i = 0; i < n; i++) {
			days[i].showtimes();
		}
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
			cout << "Time: " << time[i].getoutputtime() << endl << "Title: " << entry.gettitle() << endl << "Description: " << entry.getinfo() << endl;
		}
	}
};


class Time {
	unsigned short hours;
	unsigned short minutes;
	string outputtime;
	Entry entry;
public:
	Time(int minutes=0, int hours=0, string title="", string description="") {
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
	string gettitle(){
		return title;
	}
	string getinfo() {
		return description;
	}
};



int main()
{
	Time two{ 12,5,"meow","mur mur mur" };
	Day three{ two };
	Month jan{ "january" };
	jan.addday(three);
	Year year2023;
	year2023.addmonth(jan);
	Book book{ year2023 };



}

