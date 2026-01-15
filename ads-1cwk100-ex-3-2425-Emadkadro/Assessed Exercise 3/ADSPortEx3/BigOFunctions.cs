using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx3
{
    class BigOFunctions
    {//Big O Functions Calculation


        public void ExampleQuestion()
        {
            //F.C
            Console.WriteLine("Enter a number 1:");          // 1
            int num1 = Int32.Parse(Console.ReadLine());      // 1

            Console.WriteLine("Enter a number 2:");          // 1
            int num2 = Int32.Parse(Console.ReadLine());      // 1

            for (int i = 1; i <= num2; i++)                  // n + 1
            {
                Console.WriteLine(num1.ToString() + " X "
                    + i.ToString() + " = " + (num1 * i));   // n
            }

            Console.WriteLine("End of program...");         // 1

            Console.ReadLine();                             // 1


            //Working out

            // 7 + 2n - All F.Cs added together
            // 2n     - Constants removed
            // n      - Coefficients removed
            // O(n)   - Final answer
        }


        //Task A: Big O calculation for Assessed Exercise 3A
        public void QuestionOne()
        {
            Console.WriteLine("Inventory initialisation");  //1

            Console.WriteLine("Define X dimension size: "); //1

            int x = Int32.Parse(Console.ReadLine());        //1

            Console.WriteLine("Define Y dimension size: "); //1

            int y = Int32.Parse(Console.ReadLine());        //1


            Item[,] inventory = new Item[x, y];             //1

            Console.WriteLine("Now loading inventory");     //1

            for (int i = 0; i < x; i++)                     //n+1
            {

                Console.WriteLine("Starting on row " + (i + 1));//n

                for (int j = 0; j < y; j++)                 //n(n+1)
                {
                    Console.WriteLine("Current Coords. " + i + " , " + j); //n(n)

                    Item test = new Item((i + " , " + j), 1, 1); //n(n)

                    inventory[i, j] = test;                     //n(n)
                    Console.WriteLine("Added " + test.Name + " at Coords."); //n(n)

                }
            }

            Console.WriteLine("Inventory finished loading.");   //1
            Console.WriteLine("Happy travels!");                //1
            Console.ReadLine();                                 //1


            //WORKIN OUT
            // 10 + n + (n+1) + n(n+1) + 3(n²)  - All F.Cs added together 
            // n + (n+1) +n(n+1) + 3(n²)        - Constants removed
            // n + n²                           - Coefficients removed

            //Picking the most significant tearm 
            //  Big O = n²                      - Final answer
        }

        public void QuestionTwo()
        {
            Console.WriteLine("How many items to analyse?: ");      //1

            int n = Int32.Parse(Console.ReadLine());                //1

            Item[] items = new Item[n];                             //1

            //TODO LoadItemManifesto(), yeah well I hardly see you pulling your finger out of your **** Dave - Steve

            for (int i = 0; i < (n - 1); i++)                       //n+1
            {
                Item current = items[i];                            //n
                Console.WriteLine("Displaying value of: " + current.Name);  //n
                Console.Write(current.Value);                       //n

            }

            Console.WriteLine("Items analysed");                    //1

            Console.ReadLine();                                     //1

            //WORKIN OUT

            // 6 + 4(n)    - All F.Cs added together 
            // 4(n)        - Constants removed
            // n           - Coefficients removed

            //Picking the most significant tearm 
            //  Big O = n  - Final answer
        }

    }
}
