using ConsoleApp7.ConsoleApp7.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7.Classes
{
    public class Glock17 : Weapons
    {
        private int weight = 15;
        private int clipSize = 8;
        public const int minDamage = 8;
        public const int maxDamage = 15;
        public const char WeaponType = 'p';
        public Cartridges Cartridge { get; set; }
        public Glock17()
        {
            setName("Glock17");
            setWeight(weight);
            Cartridge = new NineMM();
        }
    }
    public class M16A2 : Weapons
    {
        private int weight = 30;
        private int clipSize = 30;
        public const int minDamage = 15;
        public const int maxDamage = 25;
        public const char WeaponType = 'r';
        public Cartridges Cartridge { get; set; }

        public M16A2()
        {
            setName("M16A2");
            setWeight(weight);
            Cartridge = new FiveFiveSix();
        }
    }

    public class Katana : Weapons
    {
        private int weight = 12;
        private int clipSize = 1;
        public const int minDamage = 20;
        public const int maxDamage = 40;
        public const char WeaponType = 'm';
        public Cartridges Cartridge { get; set; }

        public Katana()
        {
            setName("Katana");
            setWeight(weight);
        }
    }

    public class Bow : Weapons
    {
        private int weight = 8;
        private int clipSize = 1;
        public const int minDamage = 10;
        public const int maxDamage = 25;
        public const char WeaponType = 'r';
        public Cartridges Cartridge { get; set; }
        public Bow()
        {
            setName("Bow");
            setWeight(weight);
            Cartridge = new Arrow();
        }
    }
    public class M40A5 : Weapons
    {
        private int weight = 25;
        private int clipSize = 5;
        public const int minDamage = 25;
        public const int maxDamage = 50;
        public const char WeaponType = 's';
        public Cartridges Cartridge { get; set; }
        public M40A5()
        {
            setName("M40A5");
            setWeight(weight);
            Cartridge = new SevenSixTwo();
        }
    }
}
