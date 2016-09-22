using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            int iChoice;

            Console.WriteLine(  "1. Stack"+
                                "\n2. Queue" +
                                "\n3. Dictionary" + 
                                "\n4. Exit");

            Console.WriteLine("\nPick a menu item");
            iChoice = Convert.ToInt32(Console.ReadLine());

            if (iChoice == 1)
            {
                Console.WriteLine("\n1. Add one time to Stack" +
                                 "\n2. Add Huge List of Items to Stack" +
                                 "\n3. Display Stack" +
                                 "\n4. Delete from Stack" +
                                 "\n5. Clear Stack" +
                                 "\n6. Search Stack" +
                                 "\n7. Return to Main Menu");
            }
            else if ( iChoice == 2)
            {
                Console.WriteLine("\n1. Add one time to Queue" +
                                    "\n2. Add Huge List of Items to Queue" +
                                    "\n3. Display Queue" +
                                    "\n4. Delete from Queue" +
                                    "\n5. Clear Queue" +
                                    "\n6. Search Queue" +
                                    "\n7. Return to Main Menu");
            }
            else if (iChoice == 3)
            {
                Console.WriteLine("\n1. Add one item to Dictionary" +
                                    "\n2. Add Huge List of Items to Dictionary" +
                                    "\n3. Display Dictionary" +
                                    "\n4. Delete from Dictionary" +
                                    "\n5. Clear Dictionary" +
                                    "\n6. Search Dictionary" +
                                    "\n7. Return to Main Menu");
            }
            else if (iChoice == 4)
            {
                System.Environment.Exit(1);
            }

            Console.Read();
        }
    }
}
