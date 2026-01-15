using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ADSPortEx2
{
    //Task A2: Node (tree) implementation:

    class Node<T> where T : IComparable
    {
        //Variables 
        private T data; // The data stored in the node
        public Node<T> Left, Right; // References to the left and right children of the node
        //Task A3: 
        private int height = 0; // Add height and st the value to 0
        //Task C: 
        private int balanceFactor = 0; //Rotation based on balance Factor with value starts with 0

        // Initialise Constructor
        public Node(T item)
        {//Task A
            data = item; // Set the data of the node to the given item
            // Initialise left and right children as null
            Left = null; 
            Right = null;
        //Task B:
            height = 1;         // Set the height of the node to 1
        //Task C   
            balanceFactor = 0;  //Initialize the balance factor to 0
        }
        //Constroctor for A: Public property to access and modify the Data factor of the node
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        //Constroctor for B: Public property to access and modify the Height factor of the node
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        //Constroctor for C: Public property to access and modify the balance factor of the node
        public int BalanceFactor
        {
            get { return balanceFactor; }
            set { balanceFactor = value; }
        }
    } // End of class
}
