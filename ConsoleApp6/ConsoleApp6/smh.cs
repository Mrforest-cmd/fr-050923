using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smh
{
    public interface IAnimal
    {

        void Sound();
        void Eat();
    };
    public abstract class Mammal : IAnimal
    {
        public Mammal() { }

        public string type_of_food;

        public string description;
        public abstract void Eat();

        public abstract void Sound();

    }
}
