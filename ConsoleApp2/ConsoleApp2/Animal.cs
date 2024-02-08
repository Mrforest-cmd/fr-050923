using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Animal
{
    class Animal
    {
        public string Name { get; set; }
        virtual public void Sound()
        {
            Console.WriteLine("Sound of an animal");
        }
    }
    class Dog : Animal
    {
        public string Sound_t { get; set; }
        public Dog(string Name_i, string Sound)
        {
            this.Name = Name_i;
            this.Sound_t = Sound;
        }
        public override void Sound()
        {
            Console.WriteLine(Sound_t);
        }
    }
    class Cat : Animal
    {
        public string Sound_t { get; set; }
        public Cat(string Name_i, string Sound)
        {
            this.Name = Name_i;
            this.Sound_t = Sound;
        }
        public override void Sound()
        {
            Console.WriteLine(Sound_t);
        }
    }
}
