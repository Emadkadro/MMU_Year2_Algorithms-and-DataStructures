using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx3
{
    //Generic insert sort implementation for Assessed Exercise 3

    class SortUtils
    {
        //B1: Understanding the Function and how to adapt it for generic types
        static public void InsertSort(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                int value = a[i];
                int j = i;

                for (; j > 0 && value < a[j - 1]; j--)
                {
                    a[j] = a[j - 1];
                }
                a[j] = value;
            }
        }

        //B2: Implement the Generic Version of the Insert Sort Function.
        static public void InsertSortGen<T>(T[] a) where T : IComparable
        {// Start from the second element (index 1) and iterate through the array
            for (int i = 1; i < a.Length; ++i)
            {
                T value = a[i];// Store the value to be inserted into the sorted part of the array
                int j = i;// Initialise j to the current index i
                while (j > 0 && a[j - 1].CompareTo(value) > 0) // Shift elements that are greater than 'value' to the right
                {
                    a[j] = a[j - 1]; // Move element one to the right
                    j--; // Move j to the left to check the next element
                }
                a[j] = value; // Place the value in the correct position in the sorted array
            }
        }
    }
}
