#include <iostream>

using namespace std;

class Player;

class Weapon {

protected:

    unsigned short damage;

    unsigned short weight;

    unsigned short numberOfCartridgesInTheClip;

    unsigned short numberOfClips;

    unsigned short accuracy; // 0.1 -> 0.9

    double rateOfFire; // 0.1 -> 0.9  

public:

    void setDamage(unsigned short damage) { this->damage = damage; };

    unsigned short getDamage() { return this->damage; }

    void attack(Player& target) {
        target.takeDamage(damage);
    }

};

class Empty : public Weapon {
public:
    Empty() {
        setDamage(5);
        this->weight = 0;
        this->numberOfCartridgesInTheClip = 2;
        this->numberOfClips = 1;
        this->accuracy = 90;
        this->rateOfFire = 50;
    }

};

class Glock : public Weapon {
public:
    Glock() {
        setDamage(15);
        this->weight = 15;
        this->numberOfCartridgesInTheClip = 8;
        this->numberOfClips = 5;
        this->accuracy = 60;
        this->rateOfFire = 600;
    }
};

class AK47 : public Weapon {
public:
    AK47() {
        setDamage(25);
        this->weight = 35;
        this->numberOfCartridgesInTheClip = 30;
        this->numberOfClips = 5;
        this->accuracy = 65;
        this->rateOfFire = 650;
    }
};

class M4A1 : public Weapon {
public:
    M4A1() {
        setDamage(20);
        this->weight = 25;
        this->numberOfCartridgesInTheClip = 30;
        this->numberOfClips = 5;
        this->accuracy = 75;
        this->rateOfFire = 700;
    }
};

class ShotGun : public Weapon {
public:
    ShotGun() {
        setDamage(35);
        this->weight = 35;
        this->numberOfCartridgesInTheClip = 2;
        this->numberOfClips = 10;
        this->accuracy = 30;
        this->rateOfFire = 120;
    }
};

class Character {

protected:

    unsigned short hp = 100;

    unsigned short speed = 255;

    unsigned short armor = 0;

    unsigned short stamina = 0;


public:

    void search(Character) {}

    unsigned short gethealth() {
        return hp;
    }
};

class Bot : public Character {

};

class Player : public Character {
protected:
    string name;
    Weapon* weapon;

public:
    void setName(string name) { this->name = name; }
    string getName() { return this->name; }

    void setWeapon(Weapon* weapon) {
        this->weapon = weapon;
    }

    void takeDamage(int damageAmount) {
        this->hp -= damageAmount;
    }

    void attack(Player& target) {
        weapon->attack(target);
    }
};


int main()
{
    Player plr1,plr2;
    Glock glock17;

    plr1.setWeapon(&glock17);
    cout << plr2.gethealth() << endl;
    plr1.attack(plr2);
    cout << plr2.gethealth() << endl;


}