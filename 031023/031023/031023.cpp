// 031023.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <math.h>

using namespace std;

class Figure {

public:
	string name;
	int square;
	int lineThickness;
	string linecolor;
	string fillcolor;

};

class Square : public Figure {

public:
	int sidelength;

	Square(string name, int sidelength, int lineThickness, string linecolor, string fillcolor) {
		this->name = "square";
		this->sidelength = sidelength;
		this->lineThickness = lineThickness;
		this->linecolor = linecolor;
		this->fillcolor = fillcolor;
	}
	int getsquare() {
		return((sidelength * sidelength));
	}
	int getperimeter() {
		return(sidelength * 4);
	}
	void getall() {
		cout << "Name: " << this->name << endl;
		cout << "Square: " << this->getsquare() << endl;
		cout << "Perimeter: " << this->getperimeter() << endl;
		cout << "Line color: " << this->linecolor << endl;
		cout << "Fill color: " << this->fillcolor << endl;
		cout << "Line thickness: " << this->lineThickness << endl << endl;
	}

};

class Rectangle : public Figure {

public:
	int side1, side2;

	Rectangle(string name, int side1, int side2, int lineThickness, string linecolor, string fillcolor) {
		this->name = "rectangle";
		this->side1 = side1;
		this->side2 = side2;
		this->lineThickness = lineThickness;
		this->linecolor = linecolor;
		this->fillcolor = fillcolor;
	}
	int getsquare() {
		return(side1 * side2);
	}
	int getperimeter() {
		return(side1 * 2 + side2 * 2);
	}
	void getall() {
		cout << "Name: " << this->name << endl;
		cout << "Square: " << this->getsquare() << endl;
		cout << "Perimeter: " << this->getperimeter() << endl;
		cout << "Line color: " << this->linecolor << endl;
		cout << "Fill color: " << this->fillcolor << endl;
		cout << "Line thickness: " << this->lineThickness << endl << endl;
	}
};

class Rhombus : public Figure {

public:
	int side;
	int height;
	Rhombus(string name, int side, int height, int lineThickness, string linecolor, string fillcolor) {
		this->name = "rhombus";
		this->side = side;
		this->height = height;
		this->lineThickness = lineThickness;
		this->linecolor = linecolor;
		this->fillcolor = fillcolor;
	}
	int getsquare() {
		return(side * height);
	}
	int getperimeter() {
		return(side * 4);
	}
	void getall() {
		cout << "Name: " << this->name << endl;
		cout << "Square: " << this->getsquare() << endl;
		cout << "Perimeter: " << this->getperimeter() << endl;
		cout << "Line color: " << this->linecolor << endl;
		cout << "Fill color: " << this->fillcolor << endl;
		cout << "Line thickness: " << this->lineThickness << endl << endl;
	}
};

class Triangle : public Figure {
public:
	int sides[3];
	Triangle(string name, int sides[3], int lineThickness, string linecolor, string fillcolor) {
		this->name = "triangle";
		for (int i = 0; i < 3; i++) {
			this->sides[i] = sides[i];
		}
		this->lineThickness = lineThickness;
		this->linecolor = linecolor;
		this->fillcolor = fillcolor;
	}
	int getsquare() {
		int s = getperimeter() / 2;
		return sqrt(s * (s - sides[0]) * (s - sides[1]) * (s - sides[2]));
	}
	int getperimeter() {
		int S = 0;
		for (int i = 0; i < 3; i++) {
			S += sides[i];
		}
		return S;
	}
	void getall() {
		cout << "Name: " << this->name << endl;
		cout << "Square: " << this->getsquare() << endl;
		cout << "Perimeter: " << this->getperimeter() << endl;
		cout << "Line color: " << this->linecolor << endl;
		cout << "Fill color: " << this->fillcolor << endl;
		cout << "Line thickness: " << this->lineThickness << endl;
		cout << "Sides: " << endl;
		for (int i = 0; i < 3; i++) {
			cout << "side " << i << " : " << sides[i] << endl;
		}
		cout << endl;
	}
};

class Circle : public Figure {

public:
	int radius;
	Circle(string name, int radius, int lineThickness, string linecolor, string fillcolor) {
		this->name = "circle";
		this->radius = radius;
		this->lineThickness = lineThickness;
		this->linecolor = linecolor;
		this->fillcolor = fillcolor;
	}
	int getsquare() {
		return(2 * 3.14 * (radius * radius));
	}
	int getcirclelength() {
		return(2 * 3.14 * radius);
	}
	int getdiameter() {
		return(radius * 2);
	}
	void getall() {
		cout << "Name: " << this->name << endl;
		cout << "Square: " << this->getsquare() << endl;
		cout << "Circle length: " << this->getcirclelength() << endl;
		cout << "Radius: " << this->radius << endl;
		cout << "Diameter: " << this->getdiameter() << endl;
		cout << "Line color: " << this->linecolor << endl;
		cout << "Fill color: " << this->fillcolor << endl;
		cout << "Line thickness: " << this->lineThickness << endl << endl;
	}

};

int main()
{
	int sides[3] = { 5,2,1 };
	Circle Max{ "Max", 5,2,"Yellow","Red" };
	Triangle Anton{ "Anton", sides, 3, "Black", "White" };
	Rhombus Danya{ "Danil", 2, 3, 2, "Black", "White" };
	Rectangle Denis{ "Denis", 2, 4, 2, "Brown", "Red" };
	Square Bogdan{ "Bogdan", 16, 3, "Black", "Cyan" };

	Max.getall();
	Anton.getall();
	Danya.getall();
	Denis.getall();
	Bogdan.getall();
}

