using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public abstract class BaseProperty
    {

        private int weight { set; get; }
        private string name { set; get; }
        public int getWeight() { return this.weight; }
        public string getName() { return this.name; }
        protected void setWeight(int newWeight) { this.weight = newWeight; }
        protected void setName(string newName) { this.name = newName; }
        public char type { set; get; }
    }
    public abstract class Medicale : BaseProperty 
    {
        
        private int amount_of_heal { set; get; }

        protected void setHeal(int Hp) { amount_of_heal = Hp; }
        protected int getHeal() {  return amount_of_heal; }
        
    }
    public abstract class Weapons : BaseProperty
    {
        char WeaponType;
    }
    public abstract class ModuleForWeapons : BaseProperty
    {

    }
    public abstract class Equipment : BaseProperty
    {
        public void UseItem(Player character) { }
    }
    public abstract class Armor : BaseProperty
    {
        private int armor { get; set; }
        public int getArmor() { return this.armor; }
        public void setArmor(int newArmor) { this.armor = newArmor; }

    }
}
