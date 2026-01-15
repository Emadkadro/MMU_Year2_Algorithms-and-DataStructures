using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{ 
    //Task C: AVL Tree implementation 
    class AVLTree<T> : BSTree<T> where T : IComparable
    { //Balance the tree using Left / Right Rotation

        //1. Rotate to the right
        private Node<T> RightRotation(Node<T> y)
        {
            //Avoid error if y = null or y.left == null
            if (y == null || y.Left == null)
            {
                return y;
            }

            Node<T> x = y.Left;
            Node<T> T2 = x.Right;

            //Preform Rotation 
            x.Right = y;
            y.Left = T2;

            //Update height and balance of the tree
            y.Height = Math.Max(height(y.Left), height(y.Right)) + 1;
            x.Height = Math.Max(height(x.Left), height(x.Right)) + 1;

            y.BalanceFactor = height(y.Left) - height(y.Right);
            x.BalanceFactor = height(x.Left) - height(x.Right);

            //Return new root 'RightRotation'
            return x;
        }

        //2. Rotate to the Left
        private Node<T> LeftRotation(Node<T> x)
        {
            //Avoid error if x = null or x.Right == null
            if (x == null || x.Right == null)
            {
                return x;
            }

            Node<T> y = x.Right;
            Node<T> T2 = y.Left;

            //Preform Rotation 
            y.Left = x;
            x.Right = T2;

            //Update height and balance of the tree
            x.Height = Math.Max(height(x.Left), height(x.Right)) + 1;
            y.Height = Math.Max(height(y.Left), height(y.Right)) + 1;

            x.BalanceFactor = height(x.Left) - height(x.Right);
            y.BalanceFactor = height(y.Left) - height(y.Right);

            //Return new root 'LeftRotatio'
            return y;
        }

        //Balance the tree using Left / Right Rotation
        private void BalancedTree (ref Node<T> tree)
        {
            if (tree.BalanceFactor > 1)
            {
                //Left heavy subtree
                if (tree.Left.BalanceFactor >= 0)
                {
                    tree = LeftRotation(tree); // Left-Left
                }
                else
                {
                    tree.Left = LeftRotation(tree.Left);
                    tree = RightRotation(tree); //Left-Right
                }
            }
            else if (tree.BalanceFactor < -1)
            {
                //Right heavy subtree
                if (tree.Right.BalanceFactor <= 0)
                {
                    tree = LeftRotation(tree); // Right-Right
                }
                else
                {
                    tree.Right = RightRotation(tree.Right);
                    tree = LeftRotation(tree); //Left-Right
                }
            }
        }

        //Task C2: Insert balanced Item using the AVLTree
        public new void InsertItemAVL(T item)
        {
            insertItemAVL(item, ref root);
        }
        private void insertItemAVL(T item, ref Node<T> tree)
        {
            // Avoid adding NULL values 
            if (tree == null)
            {
                tree = new Node<T>(item);
            }
            //If the added item < above node, insert the new item on the Left.
            else if (item.CompareTo(tree.Data) < 0)
            {
                insertItemAVL(item, ref tree.Left);
            }
            //If the added item > above node, insert the new item on the Right.
            else if (item.CompareTo(tree.Data) > 0)
            {
                insertItemAVL(item, ref tree.Right);
            }
            else
            {
                Console.WriteLine("Avoid duplicate items!");
                Console.ReadKey();
                return;
            }

            // Update height and balance factor of current node
            tree.Height = 1 + Math.Max(height(tree.Left), height(tree.Right));
            tree.BalanceFactor = height(tree.Left) - height(tree.Right);

            // Perform rotations if needed to maintain AVL property
            BalancedTree(ref tree);
        }

        // Task C3: remove Item Implementation
        public new void RemoveItem(T item)
        {
            removeItem(ref root, item);
        }
        private void removeItem (ref Node<T> tree, T item)
        {
            if (tree == null) return;   //Nothing to return, empty tree

            if (item.CompareTo(tree.Data) < 0)  //item < current node 
            {
                removeItem(ref tree.Left, item);
            }
            else if (item.CompareTo(tree.Data) > 0)  //item > current node 
            {
                removeItem(ref tree.Right, item);
            }
            else
            {// If the item matches current node 
                if (tree.Left == null)
                {//Promote to the right if no left child 
                    tree = tree.Right;
                }
                else if (tree.Right == null)
                {//Promote to the left if no right child 
                    tree = tree.Left;
                }
                else
                {
                    Node<T> SmallestNode = FindMinimum(tree.Right);
                    tree.Data = SmallestNode.Data;
                    removeItem(ref tree.Right, SmallestNode.Data);
                }
            }

            if (tree == null) return;
            // Update height and balance of the Tree
            tree.Height = 1 + Math.Max(height(tree.Left), height(tree.Right));
            tree.BalanceFactor = height(tree.Left) - height(tree.Right);
            // Rotate if needed to maintain AVL property
            BalancedTree(ref tree);
        }

        private Node<T> FindMinimum(Node<T> tree)
        {
            while (tree.Left != null)   //if the tree is not empty
            {
                tree = tree.Left;       //find the last left node 
            }
            return tree;
        }
    }
}
