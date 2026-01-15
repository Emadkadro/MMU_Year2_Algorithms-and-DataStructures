using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task A3: Create a Menu driven interface here so a user can interact with your implementations

            AVLTree<Film> filmTree = new AVLTree<Film>();
            while (true)
            {
                Console.Clear();
                //Task A Menu Driven Interface 
                Console.WriteLine("\n--------> Film Collection Management <--------\n"); //Adding Menu Title        
                Console.WriteLine("1. Insert New Film");
                Console.WriteLine("2. Display Available Films");
                Console.WriteLine("3. Display Collection's Height");
                //Task B Menu Driven Interface 
                Console.WriteLine("4. Count Available Films");
                Console.WriteLine("5. Updae Film Details");
                // Task C Menu Driven Interface
                Console.WriteLine("6. Remove Film");
                Console.WriteLine("7. Exit the program");

                //User Selection 
                Console.Write("\n Select a valid option: ");
                string choice = Console.ReadLine();

                //Switch Function
                switch (choice)
                {//Task A:
                    case "1":
                        // InsertFilm(filmTree);    Task A
                        InsertItemAVL(filmTree);    //Task C
                        break;
                    case "2":
                        DisplayFilm(filmTree);
                        break;
                    case "3":
                        //ObtainHeight(filmTree);         Task A
                        ObtainUpdatedHeight(filmTree);  //Task C
                        break;

                //Task B:
                    case "4":
                        CountFilm(filmTree);
                        break;

                    case "5":
                        UpdateFilmDetails(filmTree);
                        break;

                    //Task C:
                    case "6":
                        RemoveFilm(filmTree);
                        break;

                    case "7":
                        Console.WriteLine("Leaving Film Collection Management! ");
                        Console.ReadKey();
                        return;
          

                    default:
                        Console.WriteLine("Invalid Choice, Please try again! ");
                        Console.ReadKey();
                        break;
                }
            }  
        }



        //Task A Assigning Functions 

        // 1. Insert New Film
        static void InsertFilm(BSTree<Film> filmTree)
        {
            Console.WriteLine("\n--------> Insert New Film <--------\n");

            //Validate the Title input using Trim and 'IF' for unexpected space, wrong input or empty
            Console.Write("Insert Title: ");
            string title = Console.ReadLine().Trim(); //Read input
            if (String.IsNullOrEmpty(title))
            {
                Console.WriteLine("Title cannot be empty. Please try again!");
                Console.ReadKey();
                return;
            }

            //Validate the Director input using Trim and 'IF' for unexpected space, wrong input or empty
            Console.Write("Insert Director: ");
            string director = Console.ReadLine().Trim(); //Read input
            if (String.IsNullOrEmpty(director))
            {
                Console.WriteLine("Director cannot be empty. Please try again!");
                Console.ReadKey(); 
                return;
            }

            //Validate the Quantity input using int.TryParse and 'IF' for unexpected string, invalid input or empty
            Console.Write("Insert Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 1)
            {
                Console.WriteLine("Quantity cannot be empty  or invalid number. Please try again!");
                Console.ReadKey ();
                return;
            }

            Film film = new Film(title, director, quantity); //Add the film 
            filmTree.InsertItem(film);
            Console.WriteLine($"Film: '{title}' Directed by: '{director}' with quentity of '{quantity}'");
            Console.ReadKey();
        }

        // 2. Display Available Films
        private static void DisplayFilm(BSTree<Film> filmTree)
        {
            Console.WriteLine("\n--------> Display Available Films <--------\n");
            //Task A:
            Console.WriteLine("\n Select the Display Order:");
            Console.WriteLine("1. In Order");
            Console.WriteLine("2. Pre Order");
            Console.WriteLine("3. Post Order");
            //Task B:
            Console.WriteLine("4. Count Available Films");
            Console.WriteLine("5. Update Film Details");

            //Read the user choice 
            Console.WriteLine("\n Your choice: ");
            string choice = Console.ReadLine().Trim();
            string buffer = string.Empty;

            //Available options:
            switch (choice)
            {
            //Task A
                case "1": //In Order
                    filmTree.InOrder(ref buffer);
                    if (buffer.Length > 0) { Console.WriteLine(buffer);}
                    else { Console.WriteLine("\n The Tree is empty. Nothing to display!");}
                    break;

                case "2": //Pre Order
                    filmTree.PreOrder(ref buffer);
                    if (buffer.Length > 0) { Console.WriteLine(buffer); }
                    else { Console.WriteLine("\n The Tree is empty. Nothing to display!"); }
                    break;

                case "3": //Post Order
                    filmTree.PostOrder(ref buffer);
                    if (buffer.Length > 0) { Console.WriteLine(buffer); }
                    else { Console.WriteLine("\n The Tree is empty. Nothing to display!"); }
                    break;


                default: // Invalid choice
                    Console.WriteLine("\n Invalid choice. Choose 1, 2 or 3 to continue. ");
                    Console.ReadKey();
                    return;
            }
            Console.ReadKey();
        }

        // 3. Display Collection's Height
        static void ObtainHeight(BSTree<Film> filmTree)
        {
            Console.WriteLine("\n-------- > Display Collection's Height < --------\n");
            Console.WriteLine($"\n The height of this tree is: '{filmTree.Height()}'");
            Console.ReadKey();
        }



        //Task B2 Assigning Functions 

        //4. Count Available Films
        static void CountFilm(BSTree<Film> filmTree)
        {
            Console.WriteLine("\n--------> Count Available Films <--------\n");
            int count = filmTree.Count();
            Console.WriteLine($"\n Total number of Available Films: '{count}'");
            Console.ReadKey();
        }

        //5. Update Film Details
        static void UpdateFilmDetails(BSTree<Film> filmTree)
        {
            Console.WriteLine("\n--------> Updae Film Details <--------");

            //Validate Title inputs using 'IF' and Trim function
            Console.Write("Enter the Title of the film you want to update: ");
            string title = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Title cannot be empty. Please try again!");
                Console.ReadKey();
                return;
            }

            //Check if the film exists in th tree
            Film existingFilm = new Film (title, string.Empty, 0); //Consider the title only
            if (!filmTree.ContainsItem(existingFilm))
            {
                Console.WriteLine($"Film: '{title}' does not exist in the Film Collection.");
                Console.ReadKey();
                return;
            }

            //New Director validation input
            Console.Write("Enter the New Director: ");
            string director = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(director))
            {
                Console.WriteLine("Director cannot be empty. Please try again!");
                Console.ReadKey();
                return;
            }

            //New Quantity validation input.
            Console.Write("Enter New Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
            {
                Console.WriteLine("Invalid quantity!");
                Console.ReadKey();
                return;
            }

            Film updatedFilm = new Film(title, director, quantity);
            filmTree.UpdateItem(updatedFilm);
            Console.WriteLine($"Film '{title}' updated successfully.");
            Console.ReadKey();
        }


        //Task C1: Assigning Functions 

        // Task C1. Update display Collection's Height using the new Tree 'AVLTree'
        static void ObtainUpdatedHeight(AVLTree<Film> filmTree)
        {
            Console.WriteLine("\n-------- > Display Collection's Height < --------\n");
            Console.WriteLine($"\n The height of this tree is: '{filmTree.Height()}'");
            Console.ReadKey();
        }

        // Task C2. Update Insert New Film
        static void InsertItemAVL(AVLTree<Film> filmTree)
        {
            Console.WriteLine("\n--------> Insert New Film <--------\n");

            //Validate the Title input using Trim and 'IF' for unexpected space, wrong input or empty
            Console.Write("Insert Title: ");
            string title = Console.ReadLine().Trim(); //Read input
            if (String.IsNullOrEmpty(title))
            {
                Console.WriteLine("Title cannot be empty. Please try again!");
                Console.ReadKey();
                return;
            }

            //Validate the Director input using Trim and 'IF' for unexpected space, wrong input or empty
            Console.Write("Insert Director: ");
            string director = Console.ReadLine().Trim(); //Read input
            if (String.IsNullOrEmpty(director))
            {
                Console.WriteLine("Director cannot be empty. Please try again!");
                Console.ReadKey();
                return;
            }

            //Validate the Quantity input using int.TryParse and 'IF' for unexpected string, invalid input or empty
            Console.Write("Insert Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 1)
            {
                Console.WriteLine("Quantity cannot be empty  or invalid number. Please try again!");
                Console.ReadKey();
                return;
            }

            Film film = new Film(title, director, quantity); //Add the film 
            filmTree.InsertItem(film);
            Console.WriteLine($"Film: '{title}' Directed by: '{director}' with quentity of '{quantity}' added successfully!");
            Console.ReadKey();
            return;
        }

        // Task C3: remove Item Implementation
        static void RemoveFilm (AVLTree<Film> filmTree)
        {
            Console.WriteLine("\n--------> Remove Film <--------\n");

            //Evaluate input
            Console.WriteLine("Enter the Title of the film you want to remove: ");
            string title = Console.ReadLine().Trim();
            if (String.IsNullOrEmpty(title))
            {
                Console.WriteLine("Title cannot be empty. Please try again!");
                Console.ReadKey();
                return;
            }

            Film filmToRemove = new Film (title, string.Empty, 0);
            if (!filmTree.ContainsItem(filmToRemove))
            {
                Console.WriteLine($"Film: '{title}' does not exist in the Film Collection.");
                Console.ReadKey();
                return;
            }
            else
            {
                filmTree.RemoveItem(filmToRemove);
                Console.WriteLine($"Film: '{title}' removed successfully. ");
            }
            Console.ReadKey ();
        }

    }
}