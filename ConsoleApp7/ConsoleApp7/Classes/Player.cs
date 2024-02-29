using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Player
    {
        private int hp = 100;
        private int weightLimit = 100;
        private int speed = 10;
        private int accuracy = 50;
        private int armor = 0;
        private List<object> inventory = new List<object>();
        public void showPlayerInventory()
        {
            foreach (var item in inventory)
            {
                Console.WriteLine();
            }
        }
        public int getHP() { return this.hp; }
        public void setHp(int newHP) { this.hp = newHP; }

        public int getWL() { return this.weightLimit; }
        public void setWL(int newWL) { this.weightLimit = newWL; }

        public void setSP(int newSP) { this.speed = newSP; }
        public int getSP() { return this.speed; }

        public void setAcc(int newAcc) { this.accuracy = newAcc; }
        public int getAcc() { return this.accuracy; }

        public void setArm(int newArm) { this.armor = newArm; }
        public int getArm() { return this.armor; }

        public void Use(string itemName)
        {
            foreach (Equipment item in inventory)
            {
                if (item.getName() == itemName)
                {
                    item.UseItem(this);
                }
            }
        }
        public void check()
        {

        }
    }
}
