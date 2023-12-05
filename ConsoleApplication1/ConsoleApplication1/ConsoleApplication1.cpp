#include <iostream>
#include <ctime>

using namespace std;

class Player;

class Weapon {
protected:
    unsigned short damage;

    unsigned short weight;

    unsigned short numberOfCartridgesInTheClip;

    unsigned short numberOfClips;

    unsigned short accuracy;

public:

    

    double rateOfFire; 


    unsigned short getDamage() { return this->damage; }
    unsigned short getaccuracy() { return accuracy; }
    unsigned short get_weight() { return weight; }
    unsigned short getnumberOfCartridgesInTheClip() { return numberOfCartridgesInTheClip; }

};

class Empty : public Weapon {
public:
    Empty() {
        this->damage = 5;
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
        this->damage = 15;
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
        this->damage = 25;
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
        this->damage = 20;
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
        this->damage = 35;
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

    unsigned short armor = rand() % 100;

    unsigned short stamina = 100;

    unsigned short weight = 0;

    


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
    unsigned short stamina_lose_tick = 1;
    unsigned short numberOfCartridgesInTheClip = 2;
    unsigned short numberOfClips = 1;
public:
    void setName(string name) { this->name = name; }
    string getName() { return this->name; }

    void setWeapon(Weapon* weapon) {
        this->weapon = weapon;
        this->weight += weapon->get_weight();
        this->numberOfCartridgesInTheClip = numberOfCartridgesInTheClip;
    }

    void tdmg(int damageAmount) {
        if (!this->armor) {
            this->hp -= damageAmount;
        }
        else {
            if (this->armor >= damageAmount) {
                this->armor -= damageAmount;
            }
            else {
                this->hp -= damageAmount - armor;
            }
            
        }
    }

    void attack(Player& target, unsigned short amount_of_shots) {
        if (weight > 100) {
            cout << "Too much weight, lose some. \n";
            return;
        }
        else if (weight > 70) {
            this->stamina_lose_tick += 5;
        }
        for (int i = 0; i < amount_of_shots; i++) {
            if (stamina <= 0) {
                cout << "Not enough stamina.\n";
                return;
            }
            if (!numberOfCartridgesInTheClip && typeid(weapon).name() != "Empty") {
                cout << "0 ammo in the clip, reload needed\n";
                break;
            }
            if (rand() % 100 > weapon->getaccuracy()) {
                cout << "Miss";
                numberOfCartridgesInTheClip -= 1;
                this->stamina -= stamina_lose_tick;
            }
            else {
                target.tdmg(weapon->getDamage());
                numberOfCartridgesInTheClip -= 1;
                this->stamina -= stamina_lose_tick;
            }
        }
    }

    void reload() {
        if (!this->numberOfClips) {
            cout << "No more clips, find some. \n";
            return;
        }
        this->numberOfClips -= 1;
        this->numberOfCartridgesInTheClip += weapon->getnumberOfCartridgesInTheClip();
        if (numberOfCartridgesInTheClip > weapon->getnumberOfCartridgesInTheClip()) {
            numberOfCartridgesInTheClip -= (numberOfCartridgesInTheClip - weapon->getnumberOfCartridgesInTheClip());
        }
    }

    void rest() {
        if (weight > 50 && weight < 70) {
            stamina += 50;
        }
        else if (weight > 70 && weight < 90) {
            stamina += 35;
        }
        else if (weight > 90 && weight < 100) {
            stamina += 25;
        }
        else if (weight >= 100) {
            stamina += 20;
        }
        else {
            stamina += 70;
        }
    }

    unsigned short getarmor() {
        return armor;
    }
};


int main()
{
    Player plr1,plr2;
    Glock glock17;

    plr1.setWeapon(&glock17);
    cout << "Health: " << plr2.gethealth() << endl << "Armor: " << plr2.getarmor() << endl;
    plr1.attack(plr2, 1);
    cout << "Health: " << plr2.gethealth() << endl << "Armor: " << plr2.getarmor() << endl;
    plr1.attack(plr2, 1);
    cout << "Health: " << plr2.gethealth() << endl << "Armor: " << plr2.getarmor() << endl;
    plr1.attack(plr2, 1);
    cout << "Health: " << plr2.gethealth() << endl << "Armor: " << plr2.getarmor() << endl;
}