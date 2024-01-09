#include <iostream>
#include <cmath>
#include <algorithm>
#include <vector>
#include <Windows.h>
#include <string>

using namespace std;


class Task {
    string title;
    string description;
    bool status;
    unsigned short deadline;
public:
    Task(string title, string description, unsigned short deadline) {
        this->title = title;
        this->description = description;
        this->deadline = deadline;
        status = 0;
    }
    unsigned short getdeadline() const {return deadline;}
    string gettitle() {return title;}
    string getdesc() {return description;}
    bool getstatus() const {return status;}

    void setstatus() {
        if (status) {
            status = false;
        }
        else if (!status) {
            status = true;
        }
    }
};

class Project {
    vector<Task> tasks;
    string title;
    string description;
    string start;
    unsigned short end;
    bool status;
    unsigned int id;
    static unsigned int startId;
public:
    Project(string title, string description, string start, unsigned short end) {
        this->title = title;
        this->description = description;
        this->start = start;
        this->end = end;
        this->status = false;
        id = startId++;
    }
    void addtask(string title, string description, unsigned short deadline) {
        Task task{ title, description, deadline };
        tasks.push_back(task);
    }
    void deltaskbytitle(string title) {
        for (int i = 0; i < tasks.size(); i++) {
            if (tasks[i].gettitle() == title) {
                tasks.erase(tasks.begin() + i);
                return;
            }
        }
    }

    void setendtime(unsigned short end) {
        this->end = end;
    }
    
    void setstatus() {
        if (status) {
            status = false;
        }
        else if (!status) {
            status = true;
        }
    }
    bool getstatus() const { return status; }
    unsigned int getid() const {return id;}
    string gettitle() {return title;}
    string getdescription() {return description;}
    string getstart() {return start;}
    unsigned short getend() const {return end;}

    void showalltasks() {
        cout << "-- Project Name: " << title << " --" << endl
            << "Amount of tasks: " << tasks.size() << endl
            << "ID: " << id << endl
            << "Status: " << status << endl
            << "\n\n";
        for (Task i : tasks) {
            cout << "Title: " << i.gettitle() << endl
                << "Description: " << i.getdesc() << endl
                << "Deadline: " << i.getdeadline() << endl
                << "Status: " << i.getstatus() << "\n\n";
        }
    }

    void sortbystatus() {
        auto sorting = [](Task& a, Task& b) {return a.getstatus() > b.getstatus(); };
        sort(tasks.begin(), tasks.end(), sorting);
    }

    void sortbyendtime() {
        auto sorting = [](Task& a, Task& b) {return a.getdeadline() < b.getdeadline(); };
        sort(tasks.begin(), tasks.end(), sorting);
    }
};
unsigned int Project::startId = 0;

class ProjectManager {
    vector<Project> projects;
public:
    ProjectManager() {

    }
    void addProject(string title, string description, string start, unsigned short end) {
        Project project { title, description, start, end };
        projects.push_back(project);
    }
    void delProjectByTitle(string title) {
        for (int i = 0; i < projects.size(); i++) {
            if (projects[i].gettitle() == title) {
                projects.erase(projects.begin() + i);
                return;
            }
        }
    }
    void delProjectById(unsigned int id) {
        for (int i = 0; i < projects.size(); i++) {
            if (projects[i].getid() == id) {
                projects.erase(projects.begin() + i);
                return;
            }
        }
    }
    void showProjectById(unsigned int id) {
        for (int i = 0; i < projects.size(); i++) {
            if (projects[i].getid() == id) {
                projects[i].showalltasks();
                break;
            }
        }
    }
    

    void sortProjectByEndTime(string title) {
        for (auto& i : projects) {
            if (i.gettitle() == title) {
                i.sortbyendtime();
                break;
            }
        }
    }
    void sortProjectByStatus(string title) {
        for (auto& i : projects) {
            if (i.gettitle() == title) {
                i.sortbystatus();
                break;
            }
        }
    }
    void sortProjectsByStatus() {
        auto sorting = [](Project& a, Project& b) {return a.getstatus() < b.getstatus(); };
        sort(projects.begin(), projects.end(), sorting);
    }
    void sortProjectsByEndTime() {
        auto sorting = [](Project& a, Project& b) {return a.getend() < b.getend(); };
        sort(projects.begin(), projects.end(), sorting);
    }
    void addTaskToProject(string projecttitle, string title, string description, unsigned short deadline) {
        for (Project& i : projects) {
            if (i.gettitle() == projecttitle) {
                i.addtask(title, description, deadline);
                cout << "Success!\n";
                return;
            }
        }
        cout << "No such project found.\n";
    }
    void showAllTasksByTitle(string title) {
        bool found = 0;
        for (Project i : projects) {
            if (i.gettitle() == title) {
                i.showalltasks();
                found = 1;
                break;
            }

        }
        if (!found) {
            cout << "No such project found.\n";
        }
    }

    void interStatus(string title) {
        for (auto& i : projects) {
            if (i.gettitle() == title) {
                i.setstatus();
                break;
            }
        }
    }
};




int main()
{
    ProjectManager one;
    one.addProject("Two", "Meow project", "11th June", 50);
    one.addProject("Meow Meow", "Murr", "12th December", 170);

    one.addTaskToProject("Two", "Meow", "to meow meow", 3);
    one.addTaskToProject("Meow Meow", "MeowMeow", "to meow meow meow", 5);

    cout << endl;

    one.showAllTasksByTitle("Two");
    one.showAllTasksByTitle("Meow Meow");

    cout << endl << endl <<"------------------------------------------------------" << endl << endl;

    one.interStatus("Meow Meow");

    one.sortProjectsByStatus();

    one.showAllTasksByTitle("Two");
    one.showAllTasksByTitle("Meow Meow");
    
}


/*
Опис проблеми:
Потрібно створити систему для керування проектами у розробці програмного забезпечення. 
Система має забезпечити можливість створення, відстеження та аналізу проектів, їх завдань та термінів виконання.
Вимоги:

Клас Проекту (Project):
Клас повинен містити поля для назви проекту, опису, дати початку, дати завершення та списку завдань (Task).
Методи для додавання та видалення завдань, встановлення термінів та отримання загального статусу проекту (наприклад, "в розробці", "завершено" і т.д.).

Клас Завдання (Task):
Клас, що представляє окреме завдання в межах проекту. Містить поля для опису завдання, статусу виконання та терміну виконання.
Методи для зміни статусу виконання та отримання інформації про завдання.

Система керування проектами (ProjectManager):
Клас, який управляє проектами та завданнями. Містить контейнер для зберігання об'єктів проектів.
Методи для створення нового проекту, додавання/видалення завдань, відстеження та аналізу стану проектів.

Використання лямбда-функцій:
Використовуйте лямбда-функції для сортування та фільтрації завдань за різними критеріями (наприклад, за статусом, за терміном тощо).
Можливість виводу на екран певних списків завдань з урахуванням критеріїв сортування та фільтрації.

Взаємодія із користувачем:
Реалізуйте консольний інтерфейс для взаємодії з системою: створення проектів, додавання/видалення завдань, відстеження та аналіз проектів та їх завдань.

*/