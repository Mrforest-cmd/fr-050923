// 090124.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <vector>
#include <algorithm>
#include <string>

using namespace std;

double stdd(string s) {
    double number = 0;

    int i = 0;

    for (int i = 0; i < s.length(); i++) {
        if (!isdigit(s[i])) {
            break;
        }

        number = number * 10 + (s[i] - '0');
    }

    return number;
}

class Expense {
    double amount;
    string description;
    string date;
public:
    Expense(double amount, string description, string date) {
        this->amount = amount;
        this->description = description;
        this->date = date;
    }
    double getamount() { return amount; }
    string getdescription() { return description; }
    string getdate() { return date; }
    void coutinfo() {
        cout << "Amount: " << amount << endl
            << "Description: " << description << endl
            << "Date: " << date << endl << endl;
    }
};

class ExpenseTracker {
    vector<Expense> expenses;
public:
    void addexpense(Expense expense) {
        expenses.push_back(expense);
    }
    void addexpense(double amount=0, string description="None", string date = "00.00.0000") {
        Expense expense{ amount, description, date };
        expenses.push_back(expense);
    }
    void dellastexpense() {
        expenses.pop_back();
    }
    void showsumofexpenses() {
        double sum = 0;
        for (Expense i : expenses) {
            sum += i.getamount();
        }
        cout << sum << endl;
    }
    void showallexpenses() {
        for (Expense i : expenses) {
            i.coutinfo();
        }
    }

    void sortbydate(bool side=1) {
        if (side) {
            sort(expenses.begin(), expenses.end(),

                [](Expense& a, Expense& b) {

                    int a_day = stdd(a.getdate().substr(0, 2));
                    int a_month = stdd(a.getdate().substr(3, 2));
                    int a_year = stdd(a.getdate().substr(6, 4));

                    int b_day = stdd(b.getdate().substr(0, 2));
                    int b_month = stdd(b.getdate().substr(3, 2));
                    int b_year = stdd(b.getdate().substr(6, 4));

                    if (a_year > b_year) return true;
                    if (a_year < b_year) return false;

                    if (a_month > b_month) return true;
                    if (a_month < b_month) return false;

                    if (a_day > b_day) return true;
                    return false;
                });
        }
        else {
            sort(expenses.begin(), expenses.end(),

                [](Expense& a, Expense& b) {

                    int a_day = stdd(a.getdate().substr(0, 2));
                    int a_month = stdd(a.getdate().substr(3, 2));
                    int a_year = stdd(a.getdate().substr(6, 4));

                    int b_day = stdd(b.getdate().substr(0, 2));
                    int b_month = stdd(b.getdate().substr(3, 2));
                    int b_year = stdd(b.getdate().substr(6, 4));

                    if (a_year < b_year) return true;
                    if (a_year > b_year) return false;

                    if (a_month < b_month) return true;
                    if (a_month > b_month) return false;

                    if (a_day < b_day) return true;
                    return false;
                });
        }
    }
    void sortbyamount(bool side=1) {
        if (side) {
            sort(expenses.begin(), expenses.end(), [](Expense& a, Expense& b) {return a.getamount() > b.getamount(); });
        }
        else {
            sort(expenses.begin(), expenses.end(), [](Expense& a, Expense& b) {return a.getamount() < b.getamount(); });
        }
    }

    void showbydate(string date) {
        for (Expense i : expenses) {
            if (i.getdate() == date) {
                i.coutinfo();
            }
        }
    }
    void showbymonth(unsigned short month) {
        for (Expense i : expenses) {
            if (stdd(i.getdate().substr(3, 2)) == month) {
                i.coutinfo();
            }
        }
    }
    void showbylastweek(string today) {
        if (stdd(today.substr(0, 2)) < 8) {

        }
        else {
            int day = stdd(today.substr(0, 2));
            for (int i = day; i != day-7; i--) {
                string date = i < 10 ? to_string(i) : '0' + to_string(i) + today.substr(2);
                if (expenses[i].getdate() == date) {
                    expenses[i].coutinfo();
                }
            }
        }
    }
};

int main()
{
    ExpenseTracker trac;

    trac.addexpense(100, "Korm dlya kotov", "09.01.2024");
    trac.addexpense(500, "krovat dlya kotov", "07.01.2024");
    trac.addexpense(1100, "babah", "10.01.2024");
    trac.addexpense(15000, "car", "10.02.2024");

    trac.showallexpenses();

    trac.sortbyamount();

    cout << "---------------------------------------------\n";

    trac.showbymonth(1);
}

/*
Створіть клас ExpenseTracker, який дозволить користувачам вести облік своїх витрат. 
Клас повинен мати можливість додавання витрати (сума, опис, дата) та видалення останньої витрати. 
Додайте метод для виведення загальної суми витрат.

Завдання:
Створіть клас Expense для представлення окремої витрати з полями для суми, опису та дати.
У класі ExpenseTracker створіть вектор (або список) об'єктів Expense для зберігання витрат.

Додайте методи для:
Додавання нової витрати до списку.
Видалення останньої витрати зі списку.
Виведення загальної суми витрат.

Використовуйте лямбда-функції для:
Сортування списку витрат за датою.
Виведення витрат за певний період часу (наприклад, за останній місяць або тиждень).

Напишіть функцію, яка використовує лямбда-вирази для фільтрації витрат за певним критерієм (наприклад, вивести всі витрати, сума яких більше 100).
*/