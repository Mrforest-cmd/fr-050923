
#include <iostream>
#include <cmath>

using namespace std;

class Point {

public:
    int x;
    int y;
    int thickness = 1;
    string color;
    Point(int x = 0, int y = 0) {
        this->x = x;
        this->y = y;
        this->color = "black";
    }
};

class Line : public Point {
    int x;
    int y;
public:
    Point p1;
    Point p2;
    double length;
    Line(Point p1, Point p2) {
        this->p1 = p1;
        this->p2 = p2;
        this->x = p1.x > p2.x ? (p1.x - p2.x) : p2.x - p1.x;
        this->y = p1.y > p2.y ? (p1.y - p2.y) : p2.y - p1.y;
       
        this->length = sqrt(((x*x)+(y*y)));
    }
};

class Polygone {
public:
    double S;
    Polygone(Line line1, Line line2, Line line3) {
        int p = (line1.length + line2.length + line3.length) / 2;
        this->S = sqrt(p * (p - line1.length) * (p - line2.length) * (p - line3.length));
    }
};

class Figure {
public:
    double S;
    Figure(Line line1, Line line2, Line line3) {
        Polygone polyg { line1,line2,line3};
        this->S = polyg.S;

    }
    Figure(Line line1, Line line2, Line line3, Line line4) {


    }
    Figure(Line line1, Line line2, Line line3, Line line4, Line line5) {

    }
};

int main()
{
    Point p1 { 40, 50 };
    Point p2 { 30, 70 };
    Point p3{ 20, 50 };
    Point p4{ 50, 40 };


    Line liniya1 {p1, p2};
    Line liniya2{ p2, p3 };
    Line liniya3{ p3, p4 };
    Line liniya4{ p4, p1 };

    Figure trikytnik {liniya1, liniya2, liniya3};
    Figure chetirekytnik{ liniya1, liniya2, liniya3, liniya4};
    cout << trikytnik.S << endl;

}

/*
 if (p1.x > p2.x) {
            this->x = (p1.x - p2.x);
        }
        else {
            this->x = p2.x - p1.x;
        }
        if (p1.y > p2.y) {
            this->y = (p1.y - p2.y);
        }
        else {
            this->y = (p1.y - p2.y);
        }

*/
