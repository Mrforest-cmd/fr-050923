using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7.Classes
{
    public class PowerArmor : Equipment
    {
        private int weight = 30;
        private int hpBonus = 50;
        private int weightLimitBonus = 30;
        private int speedPenalty = -10;

        public PowerArmor()
        {
            setName("Power Armor");
            setWeight(weight);
        }

        public void UseItem(Player character)
        {
            character.setHp(character.getHP() + hpBonus);
            character.setWL(character.getWL() + weightLimitBonus);
            character.setSP(character.getSP() + speedPenalty);
        }
    }

    public class DexterityImplant : Equipment
    {
        private int weight = 2;
        private int speedBonus = 15;
        private int accuracyBonus = 20;

        public DexterityImplant()
        {
            setName("Dexterity Implant");
            setWeight(weight);
        }

        public void UseItem(Player character)
        {
            character.setSP(character.getSP() + speedBonus);
            character.setAcc(character.getAcc() + accuracyBonus);
        }
    }

    public class StimPack : Equipment
    {
        private int weight = 1;
        private int hpBonus = 25;
        private int speedBonus = 10;
        private int accuracyPenalty = -5;

        public StimPack()
        {
            setName("Stim Pack");
            setWeight(weight);
        }

        public void UseItem(Player character)
        {
            character.setHp(character.getHP() + hpBonus);
            character.setSP(character.getSP() + speedBonus);
            character.setAcc(character.getAcc() + accuracyPenalty);
        }
    }
}
