#include <iostream>
using namespace std;

class Student {
public:
    string name;
    int age;
};
/*
Student olderStudent(Student list[]) {
    Student biggest{ "", 0 };
    for (int i = 0; i < 3; i++) { 
        if (list[i].age > biggest.age) { 
            biggest.age = list[i].age;
            biggest.name = list[i].name;
        }
    }

    return biggest;
}
*/
void sortuvannya(Student list[], int n) {
    for (int i = 0; i < n - 1; i++) {
        for (int j = 0; j < n - i - 1; j++) {
            if (list[j].age > list[j + 1].age) {
                Student temp = list[j];
                list[j] = list[j + 1];
                list[j + 1] = temp;
            }
        }
    }
}
int main()
{
    const int n = 3;
    Student list[n]{ {"Bogdan", 34}, {"Mike",10},{"Jan", 27} };
    sortuvannya(list, n);
    for (int i = 0; i < n; i++) {
        cout << list[i].name << ", Age: " << list[i].age << endl;
    }
    //cout << olderStudent(list).name << endl << olderStudent(list).age;

}
