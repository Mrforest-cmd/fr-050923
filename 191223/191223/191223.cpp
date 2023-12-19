#include <iostream>
#include <vector>
#include <string>
#include <cmath>
#include <algorithm>
#include <Windows.h>

using namespace std;

class Product {
    string name;
    unsigned int price;
    unsigned int id;
    unsigned int amount;
    static unsigned int startId;
public:
    Product(string name="air", unsigned int price=0, unsigned int amount=0) {
        this->name = name;
        this->price = price;
        this->amount = amount;
        id = startId++;
    }
    string getname() {
        return name;
    }
    unsigned int getprice() {
        return this->price;
    }
    unsigned int getamount() {
        return this->amount;
    }
    void setprice(unsigned int price) {
        if (price >= 0) {
            this->price = price;
        }
        else {
            cout << "Price can't be negative.";
        }
    }
    void addamount(unsigned int amount) {
        this->amount += amount;
    }

    unsigned int getid() {
        return id;
    }
};
unsigned int Product::startId = 0;

class Warehouse {
    vector<Product> products;

public:
    void addProduct(string name, unsigned int price, unsigned int amount=0) {
        Product smth{ name,price,amount };
        products.push_back(smth);
    }
    void addProductAmount(string name, unsigned int amount=0) {
        for (auto& product : products) {
            if (product.getname() == name) {
                product.addamount(amount);
                return;
            }
        }
    }
    void delbyid(unsigned int id) {
        for (int i = 0; i < products.size(); i++) {
            if (products[i].getid() == id) {
                products.erase(products.begin() + i);
                break;
            }
        }
    }
    unsigned int getProductsAmount() {
        return products.size();
    }

    void sortByPrice() {
        auto sorting = [](Product& a, Product& b) {return a.getprice() < b.getprice(); };
        sort(products.begin(), products.end(), sorting);
    }

    void sortByAmount() {
        auto sorting = [](Product& a, Product& b) {return a.getamount() < b.getamount(); };
        sort(products.begin(), products.end(), sorting);
    }

    void sortById() {
        auto sorting = [](Product& a, Product& b) {return a.getid() < b.getid(); };
        sort(products.begin(), products.end(), sorting);
    }

    void DisplayProducts() {
        for (auto& i : products) {
            cout << endl << i.getname() << endl
                << "Price: " << i.getprice() << endl
                << "Amount: " << i.getamount() << endl
                << "Id: " << i.getid() << endl;
        }
    }
    bool doesexist(string name) {
        for (auto& i : products) {
            if (i.getname() == name) {
                return true;
            }
        }
        return false;
    }
};

int main()
{
    Warehouse one;
    //one.addProduct("Milk", 100, 1000);
    //one.addProduct("Banana", 50, 10000);
    //one.addProduct("Cocoa", 250, 300);
    //one.addProduct("Jam", 1025, 700);
    while (1) {
        cout << "What do you want to do? (1-4)\n"
            << "1. Add a product to Ware house.\n"
            << "2. Remove a product from the Ware house.\n"
            << "3. Display all the products.\n"
            << "4. Sort products.\n";
        unsigned short choice;
        cin >> choice;
        system("CLS");
        if (choice == 1) {
            cout << "What do you want to add? (1-2)\n\n"
                << "1. Add amount of an existing product.\n"
                << "2. Add a new product to ware house.\n";
            unsigned short move1;
            cin >> move1;
            system("CLS");
            if (move1 == 1) {
                string line;
                cout << "Input name of the product: ";
                cin.ignore();
                getline(cin, line);
                if (one.doesexist(line)) {
                    cout << "Input the amount of the product: ";
                    unsigned int amount;
                    cin >> amount;
                    one.addProductAmount(line, amount);
                }
                else {
                    cout << "No such product found. (Press any button)\n";
                    system("pause");;
                    continue;
                }
            }
            else if (move1 == 2) {
                string name;
                unsigned int price, amount;
                cout << "Input the name of the product: ";
                cin.ignore();
                getline(cin, name);
                cout << "Input the price of the product: ";
                cin >> price;
                cout << "Input amount of the product: ";
                cin >> amount;
                one.addProduct(name, price, amount);
            }
            cout << "Success! (Press any button)\n";
            system("pause");;
            system("CLS");
            continue;
        }

        else if (choice == 2) {
            unsigned int id;
            cout << "Input id of the product: ";
            cin >> id;
            one.delbyid(id);

            cout << "Success! (Press any button)\n";
            system("pause");;
            system("CLS");
            continue;
        }

        else if (choice == 3) {
            one.DisplayProducts();

            cout << endl << "Press any button\n";
            system("pause");
            system("CLS");
            continue;
        }

        else if(choice == 4){
            unsigned short userchoice;
            cout << "How do you want to sort?\n\n"
                << "1. Sort by price.\n"
                << "2. Sort by amount.\n"
                << "3. Sort by id\n";
            cin >> userchoice;
            if (userchoice == 1) {
                one.sortByPrice();
            }
            else if (userchoice == 2) {
                one.sortByAmount();
            }
            else if (userchoice == 3) {
                one.sortById();
            }

            cout << "Success! (Press any button)\n";
            system("pause");;
            system("CLS");
            continue;
        }   
    }
    
}

/*
Необхідно розробити систему управління складом товарів для магазину. 
Система повинна дозволяти додавати товари на склад, видаляти їх, відстежувати кількість товарів і робити фільтрацію за певними критеріями.

Вимоги:
Клас товару (Product):
Клас повинен містити поля для назви, унікального ідентифікатора, ціни та кількості одиниць товару на складі.
Методи для отримання та зміни ціни, кількості товарів.
Перевантаження операторів для порівняння товарів за різними критеріями (назва, ціна і т.д.).

Склад (Warehouse):
Клас, який представляє склад товарів, містить контейнер (наприклад, vector) для зберігання об'єктів товару.
Методи для додавання товару на склад, видалення товару за ідентифікатором, отримання кількості товарів на складі, фільтрація товарів за різними критеріями (наприклад, за ціною, за кількістю тощо).
Функція для виведення усіх товарів на складі.

Використання лямбда-функцій:
Використовуйте лямбда-функції для сортування товарів за різними критеріями, такими як ціна, кількість тощо.
Можливість фільтрації за певними умовами за допомогою лямбда-функцій.

Взаємодія із користувачем:
Реалізуйте консольний інтерфейс для взаємодії з системою: додавання, видалення товарів, виведення інформації про товари та їх фільтрація.
*/
