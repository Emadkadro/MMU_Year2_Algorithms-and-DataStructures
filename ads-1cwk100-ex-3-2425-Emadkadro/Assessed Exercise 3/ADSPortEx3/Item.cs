using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx3
{
    class Item : IComparable
    {
        //Task C1: Implementation of the Class item
        private string name;
        private int values;
        private double weight;

        // Initialise Constructors
        public Item(string name, int value, double weight)
        {
            this.name = Name;
            this.values = value;
            this.weight = weight;
        }
        // Public Access and assign value to the Name variable
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        // Public Access and assign value to the Value variable
        public int Value
        {
            get { return values; }
            set { values = value; }
        }
        // Public Access and assign value to the Weight variable
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        // Public Access and assign value to the ValRatio variable
        public double ValRatio
        {
            get { return Value / Weight; }
        }
        // Compare Items objects based on the ValRatio property
        public int CompareTo(object obj)
        { // Check if the object is of type Item
            if (obj is Item other)
            {
                return other.ValRatio.CompareTo(this.ValRatio);
            }
            throw new ArgumentException("Object is not an item");
        }
    }
}
