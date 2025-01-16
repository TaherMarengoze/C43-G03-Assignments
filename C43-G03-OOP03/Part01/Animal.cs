using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C43_G03_OOP03.Part01
{
    public class Animal
    {
        public string Name { get; set; }

        public Animal()
        {
            
        }

        public Animal(string name)
        {
            Name = name;
        }

        public void Eat()
        {

        }

        public void Sleep()
        {

        }
    }

    public class Cat : Animal
    {
        public Cat()
        {

        }

        public Cat(string name) : base(name)
        {
            
        }

        public void MeoMeo()
        {

        }
    }

    public class Dog : Animal
    {
        public Dog(string name) //this call Animal parameterless constructor
        {
            Name = name; //Propert Name is inherited from Animal parent class
        }
    }
}
