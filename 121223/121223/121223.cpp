#include <iostream>
#include <cmath>
#include <algorithm>
#include <vector>
#include <map>

using namespace std;

class Student {
	string name;
	vector<int> grades;

public:
	Student(string studentName) : name(studentName) {}

	

	double calculateAverage() {
		int sum = 0;
		for (int grade : grades) {
			sum += grade;
		}
		return sum / grades.size();
	}

	const string& getName() const {
		return name;
	}
};

int main() {
	srand(static_cast<unsigned>(time(NULL)));

	vector<Student> students{
		Student("John"),
		Student("Mary"),
		Student("Bob")
	};
	map<string, Student> students;
	auto addGrade = [&students](const string& name, int grade) {students[name].grades.push_back(grade);};

	sort(students.begin(), students.end(), [](const Student& a, const Student& b) { return(a.calculateAverage() > b.calculateAverage()); });

	for (const auto& student : students) {
		cout << "Student: " << student.getName() << ", Average: " << student.calculateAverage() << endl;
	}
}
































/*
class Town {
	int floor;
	int apartments;
	int firstfloor;
public:
	Town(int f, int a) : floor(f), apartments(a) {
		this->firstfloor = rand() % apartments;
	}
	int getfloor() const {
		return floor;
	}
	int getapartments() const {
		return apartments;
	}
	int getfirstfloor() const {
		return firstfloor;
	}
};
 
vector <Town> towns = {
		Town(9,4),
		Town(9,6),
		Town(11,4),
		Town(16,12)
	};

	for (const auto& i : towns) {
		cout << i.getapartments() * i.getfloor() + i.getfirstfloor() << endl;
	}
	cout << "\n\n";

	//auto sortByFloor = [](const Town& a, const Town& b) {return (a.getfloor() * a.getapartments() + a.getfirstfloor()) < (b.getfloor() * b.getapartments()) + b.getfirstfloor(); };

	sort(towns.begin(), towns.end(), [](const Town& a, const Town& b) {return (a.getfloor() * a.getapartments() + a.getfirstfloor()) < (b.getfloor() * b.getapartments()) + b.getfirstfloor(); });

	for (const auto& i : towns) {
		cout << i.getapartments() * i.getfloor() + i.getfirstfloor() << endl;
	}
*/

/*
[](int a)->int {
		return a;
		};

void abss(float* x, unsigned n) {
	sort(x, x + n, [](float a, float b) {return (abs(a) > abs(b));
		}
	);
}

int m = 3;
	auto mul = [&m](int a) {return a * m; };

	cout << mul(687);


vector<int> numbers = { 1,2,3,4,5 };

//auto multyply = [](int x) {return x * 2; };

	transform(numbers.begin(), numbers.end(), numbers.begin(), [](int x) {return x * 2; });

	for (int i = 0; i < numbers.size(); i++) {
		cout << numbers[i] << endl;
	}


class Person {
	string name;
	int age;

public:
	/Person(string n, int a) {
		this->name = n;
		this->age = a;
	}/
Person(string n, int a) : name(move(n)), age(a) {}

string getname() const {
	return this->name;
}
int getage() const {
	return this->age;
}
};


vector <Person> group = {
		Person("am",13),
		Person("va",28),
		Person("mx",14),
	};

	auto sortByAge = [](const Person& a, const Person& b) {return a.getage() < b.getage(); };

	sort(group.begin(), group.end(), sortByAge);

	for (const auto& i : group) {
		cout << i.getname() << " - " << i.getage() << endl;
	}
*/