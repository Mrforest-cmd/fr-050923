#include <iostream>



using namespace std;



class Player {
private:
    string name;
    int hp;
    float speed;
    float accuracy; //damage = speed * accuracy
public:
    Player(string name) {
        this->name = name;
        this->hp = 100;
        this->speed = this->hp / 100;
        this->accuracy = rand() % 3 + 1;
    }
    float getspeed(){ return this->speed; }
    float getacc() { return this->accuracy; }
    string getname(){ return this->name;}
    void newStep() { this->accuracy = rand() % 10; }
    void setHP(int hp) { this->hp = hp; }
    int damage() { return this->speed * this->accuracy; }
    int gethp() { return this->hp; }
};



class Game {
    bool isStart = false;
    int round = 0;
    Player list[4] = { {"Max"},{"Yan"},{"Dima"},{"Oleg"} };
    bool check() {
        unsigned short c;
        for (int i = 0; i < 4; i++) {
            if (list[i].gethp() > 0) {
                c++;
            }
        }
        return (c > 1);
    }
    int getRound() {
        cout << this->round;
        return this->round;
    }
public:
    Game(){
        
    }
    void Start() {
        if (isStart == false) { isStart = true; }
        this->nextRound();
    }
    void Finish() { if (isStart == true) { isStart = false; } }
    
    void nextRound() {
        while (check()) {
            this->round++;
            for (int i = 0; i < 4; i++) {
                for (int y = 0; y < 4; y++) {
                    if (y != i) {
                        this->list[i].setHP(this->list[y].gethp() - this->list[y].damage());
                    }
                }
            }
            show();
        }
    }
    void show() {
        cout << "--------------" << endl;
        cout << "   Round " << this->round << endl;
        cout << "--------------" << endl;
        for (int i = 0; i < 4; i++) {
            if (list[i].gethp() > 0) {
                cout << list[i].getname() << " - " << list[i].gethp() << " hp." << endl;
            }
        }
        cout << "--------------" << endl;
        cout << endl;
    }
};



int main()
{
    srand((unsigned)time(NULL));
    Game first;
    first.Start();

    first.Finish();
}

/*
cout << "--------------" << endl;
        cout << "    Test " << endl;
        cout << "--------------" << endl;
        for (int i = 0; i < 4; i++) {
            if (list[i].gethp() > 0) {
                cout << list[i].getname() << " - " << list[i].gethp() << " hp, speed = " << list[i].getspeed() << " accurate = " << list[i].getacc() << endl;
            }
        }
        cout << "--------------" << endl;
        cout << endl;
*/