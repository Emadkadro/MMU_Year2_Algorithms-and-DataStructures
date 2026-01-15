using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    //Task A2: Binary Search Tree implementation:

    class BSTree<T> : BinTree<T> where T : IComparable
    {

        public BSTree()
        {//set root to null
            root = null;
        }

        //Functions for Task A2:
        public void InsertItem(T item)
        {
            insertItem(item, ref root);
        }
        private void insertItem (T item, ref Node<T> tree)
        {
            // Avoid adding NULL values 
            if (tree == null)
            {
                tree = new Node<T>(item);
            }
            //If the added item < above node, insert the new item on the Left.
            else if (item.CompareTo(tree.Data) < 0)
            {
                insertItem((T)item, ref tree.Left);
            }
            //If the added item > above node, insert the new item on the Right.
            else if (item.CompareTo(tree.Data) > 0)
            {
                insertItem((T)item, ref tree.Right);
            }
        }

        //Functions for Task A3: find the tree's height
        public int Height()
        {
            return height(root);
        }
        protected int height(Node<T> tree)
        {
            if (tree == null) return 0; //Handle if the tree is empty.
            else
            {//From the current node, find the maximum value of the left and right height
                return 1 + Math.Max(height(tree.Left), height(tree.Right));
            }
        }

        //TASK B -------------------------------------------------------

        //Functions for Task B1: Implementing the Count function.
        public int Count()
        {
            return count(root);
        }
        private int count(Node<T> tree)
        {
            if (tree == null) return 0;
            else
            {
                return 1 + count(tree.Left) + count(tree.Right);
            }
        }

        //Functions for Task B2: Implementing the Update function.
        public void UpdateItem(T item)
        {
             updateItem(item, ref root);
        }
        public void updateItem(T item, ref Node<T> tree)
        {
            if (item == null)
            {
                Console.WriteLine("Item  not found in the tree!");
                return;
            }

            int comparison = item.CompareTo(tree.Data);
            if (comparison == 0)
            {
                Console.WriteLine($"Current data: \n'{tree.Data}'");
                tree.Data = item; //updat item
            }
            else if (comparison < 0)
            {
                updateItem(item, ref tree.Left);
            }
            else if (comparison > 0)
            {
                updateItem(item, ref tree.Right);
            }
        }

        // Task B: Adding contains boolean to check if item exist to be removed.
        public bool ContainsItem(T item)
        {
            return containsItem (item, root);
        }
        private bool containsItem(T item, Node<T> tree)
        {
            if (tree == null) return false;

            int comparison = item.CompareTo(tree.Data);
            if (comparison == 0)
            {
                return true; // Item found
            }
            else if (comparison < 0)
            {
                return containsItem(item, tree.Left); // Search in the left subtree
            }
            else
            {
                return containsItem(item, tree.Right); // Search in the right subtree
            }
        }

    }// End of class
}
