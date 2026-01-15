using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    //Task A1: Implementing the Film class

    class Film : IComparable
    {
        //Implementing the required variables
        private string title;
        private string director;
        private int quantity;

        // Initialise Constructor
        public Film(string title, string director, int quantity)
        {
            this.title = title;
            this.director = director;
            this.quantity = quantity;
        }
        //Public property to access and modify Title variable
        public string Title
        {
            get { return title; }
            set {title = value; }
        }
        //Public property to access and modify Director variable
        public string Director
        {
            get { return director; }
            set { director = value; }
        }
        //Public property to access and modify Quantity variable
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        //The compareTo will use the title as a unique value,
        //means each film will have a unique title. 
        public int CompareTo(object obj)
        {
            Film other = (Film)obj;
            return Title.CompareTo(other.Title);
        }

        public override string ToString()
        {
            return ($"The title is: '{title}' Directed by: '{Director}', quantity available ({Quantity}). & ");
        }

    }// End of class
}
