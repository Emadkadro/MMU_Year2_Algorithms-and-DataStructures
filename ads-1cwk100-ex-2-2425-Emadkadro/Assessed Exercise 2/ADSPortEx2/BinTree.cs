using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    //Task A2: Binary Tree implementation:

    class BinTree<T> where T : IComparable
    {
        //Variables 
        protected Node<T> root;
        public BinTree()
        {
            root = null;    //Constructor set to null
        }
        // Constructor initialises the tree root
        public BinTree(Node<T> node)
        {// Set the provided node as the root of the tree
            node = root; 
        }

        //Functions for Task A2:

        //In Order 
        public void InOrder(ref string buffer)
        {
            inOrder(root, ref buffer);
        }
        public void inOrder(Node<T> tree, ref string buffer)
        {
            //Check tree if Not empty, sort items in oredr
            if (tree != null)
            {
                inOrder(tree.Left, ref buffer);     // Recursively traverse the left subtree
                buffer += tree.Data.ToString() + " , "; // Add the current node's data to the buffer
                inOrder(tree.Right, ref buffer);    // Recursively traverse the right subtree
            }
        }

        //PreOrder
        public void PreOrder(ref string buffer)
        {
            preOrder(root, ref buffer); 
        }
        private void preOrder(Node<T> tree, ref string buffer)
        {
            //Check tree if Not empty, sort items in oredr
            if (tree != null)
            {
                buffer += tree.Data.ToString() + " , ";// Add the current node's data to the buffer
                preOrder(tree.Left, ref buffer);    // Recursively traverse the left subtree
                preOrder(tree.Right, ref buffer);   // Recursively traverse the right subtree
            }
        }

        //Post Order
        public void PostOrder(ref string buffer)
        {
            postOrder(root, ref buffer);
        }
        private void postOrder(Node<T> tree, ref string buffer)
        {
            //Check tree if Not empty, sort items in oredr
            if (tree != null)
            {
                preOrder(tree.Left, ref buffer);    // Recursively traverse the left subtree
                preOrder(tree.Right, ref buffer);   // Recursively traverse the right subtree
                buffer += tree.Data.ToString() + " , ";// Add the current node's data to the buffer
            }
        }
    }
}
