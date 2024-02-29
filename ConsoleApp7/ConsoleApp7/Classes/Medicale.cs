using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Patch : Medicale
    {
        Patch() {
            setName("patch");
            setWeight(1);
            setHeal(15);
        }
    }
    public class Bandage : Medicale
    {
        public Bandage()
        {
            setName("Bandage");
            setWeight(2);
            setHeal(10);
        }
    }

    public class FirstAidKit : Medicale
    {
        public FirstAidKit()
        {
            setName("First Aid Kit");
            setWeight(5);
            setHeal(25);
        }
    }

    public class Morphine : Medicale
    {
        public Morphine()
        {
            setName("Morphine");
            setWeight(1);
            setHeal(5);
        }
    }

    public class Defibrillator : Medicale
    {
        public Defibrillator()
        {
            setName("Defibrillator");
            setWeight(10);
            setHeal(50);
        }
    }
}
