// 280923.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>

using namespace std;

class Bird {
public:
	string color;
	float weight;
	float height;
	string habitat;
	Bird() {
		this->color = "";
		this->weight = 0;
		this->height = 0;
		this->habitat = "";

	}
};

class Kiwi : public Bird {
public:
	string name;
	int age;

	Kiwi(string name, int age) {
		this->name = name;
		this->age = age;
	}
	void fly(string place) {
		cout << this->name << " flew to " << place << endl;
	}
	void fly() {
		cout << this->name << " flew away.\n";
	}
};

class Pinguin : public Bird {
public:
	string name;
	int age;
	int peakdivingdepth;
	Pinguin(int age, string name, int depth) {
		this->name = name;
		this->age = age;
		this->peakdivingdepth = depth;
	}

	void dive(int depth) {
		cout << this->name << " Dove to " << depth << " meters down.\n";
	}
};


int main()
{

}


