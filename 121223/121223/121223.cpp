#include <iostream>
#include <cmath>
#include <algorithm>
#include <vector>
#include <Windows.h>
#include <string>

using namespace std;

class do_smth_with_a_string {
	string line;
public:
	vector<string> strings;

	do_smth_with_a_string(string str) {
		this->line = str;
	}

	auto get_amount_of_words() {

	}

	auto get_longest_word() {

	}

	void cout_lengths_of_words() {

	}

	void cout_words_and_duplicates_amount() {

	}
};

int main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(static_cast<unsigned>(time(NULL)));

	string term;
	string line;

	getline(cin, line);

	vector<string> strings;

	auto amount_of_words = [&strings](string line) {
		string temp = "";
		for (char i : line) {
			if (i != ' ' && i != ',' && i != '.') {
				temp += i;
			}
			else {
				strings.push_back(temp);
				temp.clear();
			}
		}
		if (!temp.empty()) {
			strings.push_back(temp);
		}

		return strings.size();
	};

	auto the_longest_word = [&strings](string line) {
		string longest_word;
		for (string word : strings) {
			if (word.length() > longest_word.length()) {
				longest_word = word;
			}
		}
		return longest_word;
	};
	

	cout << "Amount of words - " << amount_of_words(line) << endl;
	cout << "The longest word - " << the_longest_word(line) << ", length is - " << the_longest_word(line).length() << "." << endl;

	for (string word : strings) {
		cout << word.length() << " ";
	}
	cout << endl;

	sort(strings.begin(), strings.end(), [](const string& a, const string& b) {return a < b; });

	

	string prev;
	int count=1;

	for (string word : strings) {
		if (word != prev) {
			if (prev != "") {
				cout << prev << ": " << count << endl;
			}
			prev = word;
			count = 1;
		}
		else {
			count++;
		}
	}
	cout << prev << ": " << count << endl;

}
/*for (string word : strings) {
		if (word != term) {
			cout << word << " ";
			term = word;
		}
	}*/































/*
* 
auto calculate = [](double number1, double number2, char operation) {
		switch (operation) {
		case '+':
			return number1 + number2;
		case '-':
			return number1 - number2;
		case '*':
			return number1 * number2;
		case '/':
			return number1 / number2;
		}
	};

	double num1,num2;
	char operation;

	cout << "Введіть перше число: ";
	cin >> num1;
	cout << "Введіть операцію (+, -, *, /): ";
	cin >> operation;
	cout << "Введіть друге число: ";
	cin >> num2;

	cout << calculate(num1, num2, operation) << endl;
* 
for (int i = 0; i < 5;i++) {
		string input;
		cin >> input;
		strings.push_back(input);
	}

	auto sortbylength = [](string str,string str2) { return str.length() > str2.length(); };

	cout << "\n\n";

	sort(strings.begin(), strings.end(), sortbylength);

	for (string str : strings) {
		cout << str << endl;
	}
* 
for (unsigned short num : nums) {
		if (iseven(num)) {
			cout << num << endl;
		}
	}
* 
vector<Student> students{
		Student("John"),
		Student("Mary"),
		Student("Bob")
	};
	map<string, Student> students;
	auto addGrade = [&students](const string& name, int grade) {students[name].grades.push_back(grade);};
* 
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