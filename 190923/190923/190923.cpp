// 190923.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>

using namespace std;

string names[10] = {"John", "mike", "Sam", "Nox", "Ful", "Josh", "Honey", "Sans", "Glock", "Man"};

class Student {
private:
	int id;
public:
	string name;
	int mathassesment;
	int physicassesment;

	void setID(int inputID) {
		id = inputID;
	}
	int getID() {
		return id;
	}
	
};
class Schoolclass {
private:
	Student allStudents[26];
public:
	Schoolclass() {
		for (int x = 0; x < 26; x++) {
			allStudents[x].name = names[(rand() % 10)];
			allStudents[x].mathassesment = rand() % 12;
			allStudents[x].physicassesment = rand() % 12;
			allStudents[x].setID(x+1);
		}
	}
	
	void beststudent(){
		Student beststudent;
		for (int i = 0; i < 26; i++) {
			if ((allStudents[i].mathassesment + allStudents[i].physicassesment) / 2 > (beststudent.mathassesment + beststudent.physicassesment) / 2) {
				beststudent = allStudents[i];
			}
		}
		cout << "Best student:" << endl << "name: " << beststudent.name;
	}

	void avaragegrade() {
		unsigned avarage_grade_math = 0;
		unsigned avarage_grade_physics = 0;
		for (int i = 0; i < 26; i++) {
			avarage_grade_math += allStudents[i].mathassesment;
			avarage_grade_physics += allStudents[i].physicassesment;
		}
		avarage_grade_math /= 26;
		avarage_grade_physics /= 26;
		cout << "Avarage math grade - " << avarage_grade_math << endl << "Avarage physics grade - " << avarage_grade_physics;
	}
	void smth() {
		for (int i = 0; i < 26 - 1; i++) {
			for (int b = 0; b < 26 - i - 1; b++) {
				if ((allStudents[b + 1].mathassesment + allStudents[b + 1].physicassesment) / 2.0 < (allStudents[b].mathassesment + allStudents[b].physicassesment) / 2.0) {
					Student term = allStudents[b];
					allStudents[b] = allStudents[b + 1];
					allStudents[b + 1] = term;
				}
			}
		}
		
	}

	void gradebyid(int id, int grade, string predmet) {
		for (int i = 0; i < 26; i++) {
			if (allStudents[i].getID() == id) {
				if (predmet == "Physics") {
					allStudents[i].physicassesment = grade;
				}
				else if (predmet == "Math") {
					allStudents[i].mathassesment = grade;
				}
				
			}
		}
		this->smth();
		for (int i = 1; i < 26; i++) {
			cout << i << ". name: " << allStudents[i].name << " / Math grade:" << allStudents[i].mathassesment << " / Physics grade:" << allStudents[i].physicassesment << " / ID: " << allStudents[i].getID() << "\n\n";
		}
		cout << "\n\n";
	}

		
};

int main()
{
	srand((unsigned)time(NULL));
	Schoolclass A;
	A.smth();
	A.gradebyid(1, 12, "Physics");
	A.gradebyid(1, 12, "Math");
}


