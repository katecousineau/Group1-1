using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataStructuresGROUP
{
    class Program
    {
        static void Main(string[] args)
        {
            

            List<MasterStructure> myStructure = new List<MasterStructure>();
            myStructure.Add(new myStack());
            myStructure.Add(new myQueue());
            myStructure.Add(new myDictionary());

            // Create Dictionary object for the Main Menu options
            Dictionary<int, string> dMainMenu = new Dictionary<int, string>()
            {
                {1 , "Stack" },
                {2 , "Queue" },
                {3 , "Dictionary" },
                {4 , "Exit" }
            };


            bool bStayMainMenu = true;
            bool bStaySecMenu = true;
            while (bStayMainMenu)
            {
                bStaySecMenu = true;
                Console.Clear();

                // Loop through the dictionary and write menu to the console
                Console.WriteLine("  ----- MAIN MENU -----");
                foreach (KeyValuePair<int, string> option in dMainMenu)
                {
                    Console.WriteLine(option.Key + ". " + option.Value);
                }

                // Read and validate user input
                int iMainMenuSelect = ReadInt(dMainMenu.Count);

                
                if (iMainMenuSelect == 4)
                {
                    bStayMainMenu = false;
                    bStaySecMenu = false;
                }

                Console.Clear();

                Console.WriteLine
                (
                    "  ----- TASK MENU -----" +
                    "\n1. Add One Item to " + dMainMenu[iMainMenuSelect] +
                    "\n2. Add Huge List of Items to " + dMainMenu[iMainMenuSelect] +
                    "\n3. Display " + dMainMenu[iMainMenuSelect] +
                    "\n4. Delete from " + dMainMenu[iMainMenuSelect] +
                    "\n5. Clear " + dMainMenu[iMainMenuSelect] +
                    "\n6. Search " + dMainMenu[iMainMenuSelect] +
                    "\n7. Return to Main Menu\n"
                );

                
                while (bStaySecMenu)
                {

                    // Read and validate user input
                    int iSecMenuSelect = ReadInt(7);

                    switch (iSecMenuSelect)
                    {
                        case 1:
                            Console.WriteLine(myStructure[iMainMenuSelect - 1].AddOne());
                            break;

                        case 2:
                            Console.WriteLine(myStructure[iMainMenuSelect - 1].AddHuge());
                            break;

                        case 3:
                            Console.WriteLine(myStructure[iMainMenuSelect - 1].Display());
                            break;

                        case 4:
                            Console.WriteLine(myStructure[iMainMenuSelect - 1].Delete());
                            break;

                        case 5:
                            Console.WriteLine(myStructure[iMainMenuSelect - 1].Clear());
                            break;

                        case 6:
                            Console.WriteLine(myStructure[iMainMenuSelect - 1].Search());
                            break;

                        case 7:
                            bStaySecMenu = false;
                            break;
                    }

                    Console.Write("\nGo ahead and choose another task...or press 7 to return to the Main Menu  ");
                }
            }

            Console.Clear();
            Console.Write("\nNice work structuring data! We hope you're back soon! :)");
            Thread.Sleep(1700);
        }



        // Method used to ask the user to input an integer and then check the input to make
        // sure it is an integer and is greater than 0. 
        public static int ReadInt(int iMenuLength)
        {
            // Declare variables
            bool bCheck = true;
            int iNum;
            int iCount = 0;
            string sUserInput;

            // Prompt the user to enter an int using the question parameter

            sUserInput = Console.ReadLine();

            // Program stays in the while loop until a valid integer greater than 0 is inputed
            // by the user.
            while (bCheck)
            {
                // Checks to see if the input from the user is an integer or not
                if (int.TryParse(sUserInput, out iNum))
                {
                    // Checks to see if the integer is greater than zero
                    if (iNum > 0 && iNum <= iMenuLength)
                    {
                        // When the user inputs a valid integer the invalid entries are erased
                        // and the valid integer is displayed next to the original question
                        bCheck = false;

                        while (iCount >= 0)
                        {
                            Console.CursorTop--;
                            Console.Write("                                                                                     ");
                            Console.CursorLeft = 0;
                            iCount--;
                        }

                        //Console.WriteLine(sUserInput);
                    }
                    else
                    {
                        // If the user input is an integer but not greater than 0 then the user 
                        // is prompted to enter a different number
                        Console.Write("   Please enter a number from 1 - " + iMenuLength + ": ");
                        sUserInput = Console.ReadLine();
                        iCount++;
                    }
                }
                else
                {
                    // If the user input is not an integer the user is prompted to enter a 
                    // valid number.
                    Console.Write("   Please enter a valid number: ");
                    sUserInput = Console.ReadLine();
                    iCount++;
                }
            }

            return iNum = Convert.ToInt32(sUserInput);
        }
    }
}
