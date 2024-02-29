using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    namespace ConsoleApp7.Classes
    {

        public class Cartridges
        {
            public string Name { get; set; }
            public int Amount { get; set; }

            public Cartridges(string name, int caliber)
            {
                Name = name;
                Amount = caliber;
            }
        }

        public class NineMM : Cartridges
        {
            public NineMM() : base("9mm", 9) { }
        }

        public class FiveFiveSix : Cartridges
        {
            public FiveFiveSix() : base("5.56mm", 223) { }
        }

        public class SevenSixTwo : Cartridges
        {
            public SevenSixTwo() : base("7.62mm", 308) { }
        }
        public class Arrow : Cartridges
        {
            public Arrow() : base("Arrow", 0) { }
        }
    }
}
