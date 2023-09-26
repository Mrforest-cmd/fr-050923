#include <cstdlib>
#include <ctime>
#include <iostream>
#include <string>
#include <Windows.h>



using namespace std;



string nameList[] = { "Oliver", "Jake", "Noah", "James", "Jack", "Connor", "Liam", "John" , "Harry" , "Callum" , "Mason" , "Robert" , "Jacob",
                     "Jacob	", "Michael", "Charlie", "Kyle", "Jack", "William", "Thomas", "Joe" , "Ethan" , "David" , "George" , "Reece" , "Daniel", };



class BankAccount {
private:
    string name;
    string id;
    int balance;
    unsigned long generateID() {
        static unsigned long generate = 0;
        return ++generate;
    }
public:
    BankAccount() {
        name = nameList[rand() % 6];
        balance = rand() % 1000;
        id = "N" + to_string(generateID());
    }
    string getId() { return id; }
    string getName() { return name; }
    int GetBalance() { return balance; }
    void Deposit(int addBalance) { balance += addBalance; }
    void Withdraw(int withdrawBalanve) {
        balance -= withdrawBalanve;
        if (balance <= 0) { balance = 0; }
    }
    void DisplayInfo() {
        cout << "name: " << name << endl;
        cout << "id: " << id << endl;
        cout << "balance: " << balance << endl;



    }
};



class Bank {
private:
    BankAccount Account[100];
public:
    string Transaction(string senderID, string recipientID, int amountOfMoney) {
        for (int x = 0; x < 5; x++) {
            if (senderID == Account[x].getId()) {
                if (Account[x].GetBalance() >= amountOfMoney) {
                    Account[x].Withdraw(amountOfMoney);
                }
                else {
                    return "Error.Not enough money\n";
                }
            }
        }
        for (int x = 0; x < 5; x++) {
            if (recipientID == Account[x].getId()) {
                Account[x].Deposit(amountOfMoney);
            }
        }
        return "Ok. The transaction was successful ---" + to_string(amountOfMoney) + "---\n";
    }
    void checkInfo(string ID) {
        for (int x = 0; x < 5; x++) {
            if (ID == Account[x].getId()) {
                Account[x].DisplayInfo();
                cout << endl;
            }
        }
    }
    void searchByName(string inputName) {
        for (int x = 0; x < 100; x++) {
            if (inputName == Account[x].getName()) {
                cout << "Name: " << Account[x].getName() << ". Id: " << Account[x].getId() << endl;
            }
        }
    }
    void showAllAccount() {
        for (int x = 0; x < 100; x++) {
            cout << "Name: " << Account[x].getName() << ". Id: " << Account[x].getId() << endl;
        }
    }
};



int main()
{
    srand(time(NULL));
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    Bank MonoBank;
    MonoBank.searchByName("Oliver");
}