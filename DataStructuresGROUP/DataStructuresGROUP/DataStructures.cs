/* Authors: Carsen Beyer, Kate Cousineau, Joe Isabell, Kaitlyn Whipple 
 * Date: 9-26-16
 * Description: C# Data Structures Group Work
 * Write a program in C# using a console application that 
 * demonstrates the use of a Stack, Queue, and Dictionary (Map). 
 * I want you to start trying to use GitHub for this assignment.
 * Your application will be based around a simple menu. The functionality
 * of each menu item is described in more detail below. The first menu prompt should be the following:
1. Stack
2. Queue
3. Dictionary
4. Exit
 * And then more menus for each data structure
1. Add one time to (Stack, Queue, Dictionary) 
2. Add Huge List of Items to (Stack, Queue, Dictionary)
3. Display (Stack, Queue, Dictionary )
4. Delete from (Stack, Queue, Dictionary )
5. Clear (Stack, Queue, Dictionary )
6. Search (Stack, Queue, Dictionary )
7. Return to Main Menu
 * 
 * 
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;



namespace DataStructuresGROUP
{
    class MasterStructure
    {
        public Stopwatch myStopwatch = new Stopwatch();

        public static string readString(string sInput)
        {
            //variables
            string sUserInput = sInput;
            int iNum;
            bool bCheck = true;

            //exception handling for wrong data type and null inputs
            while (bCheck)
            {
                if (int.TryParse(sUserInput, out iNum))
                {
                    Console.Write("Wrong input type. Please try again: ");
                    sUserInput = Console.ReadLine();
                }
                else if (string.IsNullOrWhiteSpace(sUserInput))
                {
                    Console.Write("Whoops - you forgot to type anything. Please try again: ");
                    sUserInput = Console.ReadLine();
                }
                else
                {
                    bCheck = false;
                }
            }
            
            return sUserInput;
        }

        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        
        public virtual string AddOne()
        {
            return " ";
        }

        public virtual string AddHuge()
        {
            return " ";
        }

        public virtual string Display()
        {
            return " ";
        }

        public virtual string Delete()
        {
            return " ";
        }

        public virtual string Clear()
        {
            return " ";
        }

        public virtual string Search()
        {
            return " ";
        }
    }

    //stack menu options
    class myStack : MasterStructure
    {
        //variables 
        Stack<string> stkStructure = new Stack<string>();

        string sUserInput;
        bool bCheck = true;

        //adds one item to the stack from user
        public override string AddOne()
        {
            Console.Write("Enter a string to add to the Stack: ");
            sUserInput = readString(Console.ReadLine());
            stkStructure.Push(sUserInput);

            return base.AddOne();
        }

        //adds 2000 entries to the stack 
        public override string AddHuge()
        {
            stkStructure.Clear();
            int iNum = 2000;
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                stkStructure.Push("New Entry " + iNum--);
            }

            return base.AddHuge();
        }

        //displays items in stack and alerts user if it is empty
        public override string Display()
        {
            if (stkStructure.Count == 0)
            {
                Console.WriteLine("\nThe stack is empty");
            }
            else
            {
                Console.WriteLine("\nHere's what is in the Stack: ");
                foreach (string s in stkStructure)
                {
                    Console.WriteLine(s);
                }
            }

            return base.Display();
        }

        //deletes item in stack that user wants to delete
        //alerts user if stack is empty
        public override string Delete()
        {

            if (stkStructure.Count == 0)
            {
                Console.WriteLine("\nThe stack is empty.");
            }
            else
            {

                //creates stack place holder
                Stack<string> stackholder = new Stack<string>();

                Console.Write("Which item do you want to delete from the stack? ");
                string sDelete = readString(Console.ReadLine());


                //pops off the original stack and puts it in a stack place holder 
                bCheck = true;
                while (bCheck)
                {
                    if (stkStructure.Peek().Equals(sDelete))
                    {
                        stkStructure.Pop();
                        bCheck = false;
                    }
                    else
                    {
                        stackholder.Push(stkStructure.Pop());
                        if(stkStructure.Count == 0)
                        {
                            Console.WriteLine("Item not found. ");
                            bCheck = false;
                        }
                    }
                }

                while (stackholder.Count != 0)
                {
                    stkStructure.Push(stackholder.Pop());
                }
                
            }

            return base.Delete();
        }

        //clears the stack 
        public override string Clear()
        {
            stkStructure.Clear();
            return base.Clear();
        }

        //searches for item in stack based on user input
        //times how long it takes whether it is found or not found
        public override string Search()
        {
            Console.WriteLine("What do you want to search for in the stack?");
            myStopwatch.Start();

            sUserInput =  readString(Console.ReadLine());

            if (stkStructure.Contains(sUserInput))
            {
                myStopwatch.Stop();
                Console.WriteLine("\nIt was found!\nIt took: " + myStopwatch.Elapsed + " seconds to search.");
            }
            else
            {
                myStopwatch.Stop();
                Console.WriteLine("\nIt was not found.\nIt took: " + myStopwatch.Elapsed + " seconds to search.");
            }
            return base.Search();
        }
    }

    //queue menu options
    class myQueue : MasterStructure
    {
        Queue<string> qStructure = new Queue<string>();

        bool check = true;
        int input = 0;
        string sInput;

        //adds one item to the queue
        public override string AddOne()
        {
            Console.Write("Enter a string to add to the Queue: ");
            sInput = readString(Console.ReadLine());
            qStructure.Enqueue(sInput);

            return base.AddOne();
        }

        //adds 2000 entries to the queue
        public override string AddHuge()
        {
            qStructure.Clear();

            for (int i = 1; i < 2001; i++)
            {
                qStructure.Enqueue("New Entry " + i);
            }

            return base.AddHuge();
        }

        //displays items in the queue
        //alerts user if queue is empty
        public override string Display()
        {
            if(qStructure.Count == 0)
            {
                Console.WriteLine("\nThe queue is empty");
            }
            else
            {
                Console.WriteLine("\nHere's what is in the Queue: ");
                foreach (string value in qStructure)
                {
                    Console.WriteLine(value);
                }
            }
            
            return base.Display();
        }

        //deletes item in queue based on user input 
        //alerts user if queue is empty
        public override string Delete()
        {
            Queue<string> qplaceholder = new Queue<string>();

            if (qStructure.Count == 0)
            {
                Console.WriteLine("\nThe queue is empty.");
            }
            else
            {
                Console.Write("Which item do you want do delete from the Queue? ");

                string inputdelete = readString(Console.ReadLine());

                //queue place holder created to hold the items while it dequeues items until the desired
                // item is deleted. if not found user is alerted
                //all items are placed back into original queue
                bool checkdelete = true;
                while (checkdelete)
                {
                    if (qStructure.Peek().Equals(inputdelete))
                    {
                        qStructure.Dequeue();
                        checkdelete = false;
                        while (qStructure.Count != 0)
                        {
                            qplaceholder.Enqueue(qStructure.Dequeue());
                        }
                    }
                    else
                    {
                        qplaceholder.Enqueue(qStructure.Dequeue());
                        if(qStructure.Count == 0)
                        {
                            Console.WriteLine("Item not found");
                            checkdelete = false;
                        }
                    }

                }
                while (qplaceholder.Count != 0)
                {
                    qStructure.Enqueue(qplaceholder.Dequeue());
                }
            }
            check = true;
            return base.Delete();
        }

        //clears queue
        public override string Clear()
        {
            qStructure.Clear();
            return base.Clear();
        }

        //user searches for item in queue
        //times response whether found or not
        public override string Search()
        {
            Console.WriteLine("What do you want to search for in the queue? ");
            sInput = Console.ReadLine();

            myStopwatch.Start();
            if (qStructure.Contains(sInput))
            {
                Console.WriteLine("Found");
            }
            else if (!qStructure.Contains(sInput))
            {
                Console.WriteLine("Not Found");
            }

            myStopwatch.Stop();
            //displays the amount of time elapsed 
            Console.WriteLine("Elapsed Time: " + myStopwatch.Elapsed);
            return base.Search();
        }
    }

    //dictionary options
    class myDictionary : MasterStructure
    {
        Dictionary<string, int> dStructure = new Dictionary<string, int>();

        //variables 
        int iUserInput = 0;
        string sName;
        int iNumName;
        int iCount = 0;
        int iDictionaryOuput = 0;
        bool bUserSearch = false;
        string uResponse;
        bool res;
        int num1;
        bool uInput = false;
        bool bUserIntInput = false;

        //adds one item to the dictionary from user input
        public override string AddOne()
        {
            uInput = false;
            while (uInput == false) //while loop to ensure that they enter a valid string team name
            {

                do //loop to make sure that they don't enter an int when they need a string key
                {
                    Console.Write("Enter a string to add to the Dictionary: ");

                    sName = readString(Console.ReadLine()); //sets sName to the current team being entered
                    res = int.TryParse(sName, out num1); //res will return true if the string is a number

                    if (res == true)
                    {
                        Console.Write("Wrong input type. Try something like Billy: ");
                    }

                } while (res == true);



                Console.Write("What number would you like to be associated with " + sName + "? ");

                bUserIntInput = false;
                while (bUserIntInput == false)
                {
                    try
                    {
                        iNumName = Convert.ToInt32(Console.ReadLine()); //iNumName variable to determine number associated with key
                        bUserIntInput = true; //gets user out of the loop
                        dStructure.Add(sName, iNumName);

                    }
                    catch (Exception e)
                    {
                        Console.Write("Please enter a valid integer (e.g. 7) ");
                        uInput = false;
                    }
                }

                uInput = true;

        }
            return base.AddOne();
        }

        //adds 2000 entries to the dictionary 
        public override string AddHuge()
        {
            dStructure.Clear();

            while (iCount < 2000) //while loops adds 2000 entries to the dictionary
            {
                dStructure.Add("New Entry " + (iCount+1), iCount+1);
                iCount++;
            }

            iCount = 0; //reset iCount to 0

            return base.AddHuge();
        }

        //displays all items in dictionary
        //alerts user if dictionary is empty
        public override string Display()
        {

            if (dStructure.Count == 0)
            {
                Console.WriteLine("\nThe dictionary is empty");
            }
            else
            {
                Console.WriteLine("\nHere's what is in the Dictionary: ");
                foreach (KeyValuePair<string, int> kvp in dStructure) //used to print out each value in dictionary
                {
                    Console.WriteLine("{0} {1}", kvp.Key.PadRight(25, ' '), kvp.Value);
                }
            }
           
            return base.Display();
        }

        //deletes item in dicitionary based on user input
        //alerts user if dictionary is empty
        public override string Delete()
        {
            uInput = false;
            if (dStructure.Count == 0)
            {
                Console.WriteLine("\nThe dictionary is empty.");
            }
            else
            {
                while (!uInput)
                {
                    do //loop to make sure that they don't enter an int when they need a string key
                    {
                        Console.WriteLine("\nWhat name or string would you like to delete? (e.g.) Johnny");

                        sName = readString(Console.ReadLine()); //sets sName to the current team being entered

                        res = int.TryParse(sName, out num1); //res will return true if the string is a number
                        if (res == true)
                        {
                            Console.WriteLine("\nWrong input type. Try something like Billy");
                            Console.WriteLine(); //create some whitespace on output
                        }

                    } while (res == true);


                    do
                    { //loop runs until they find a name that they want to delete, or after trying decide to exit the loop and return to the menu
                        if (dStructure.TryGetValue(sName, out iDictionaryOuput))
                        {
                            Console.WriteLine("\nWe found the name that you were looking for, we will remove it from the dictionary."); //removes name from the dictionary
                            dStructure.Remove(sName);
                            bUserSearch = true;
                        }
                        else //name inputed is not found
                        {
                            if (dStructure["New Entry " + 1] == 1) //gives guidelines of what to search for
                            {
                                Console.WriteLine("\nWe couldn't find your name... Maybe try something along the lines of \" New Entry \" followed by a number (e.g. New Entry 1)");
                                bUserSearch = false;
                            }
                            else
                            {
                                Console.WriteLine("\nSorry, we couldn't find your name");
                                bUserSearch = false;
                            }



                            //do //loop to make sure that they don't enter an int when asked if they want to search again
                            //{
                            //    Console.WriteLine("\nWould you like to try again? (y/n)");
                            //    uResponse = UppercaseFirst(Console.ReadLine()); //converts user input to uppercase

                            //    res = int.TryParse(uResponse, out num1); //res will return true if the string is a number
                            //    if (res == true)
                            //    {
                            //        Console.WriteLine("\nWrong input type. Try something like Yes or No");
                            //        Console.WriteLine(); //create some whitespace on output


                            //    }

                            //} while (res == true);

                            //if (uResponse.StartsWith("Y"))
                            //{
                            //    bUserSearch = false;
                            //}
                            //else
                            //{
                                bUserSearch = true;
                            //}

                        } //end of if/else statement

                    } while (bUserSearch == false);

                    uInput = true;

                }
            }
            return base.Delete();
        }

        //clears the dictionary 
        public override string Clear()
        {
            dStructure.Clear();
            return base.Clear();
        }

        //searches for item in dictionary based on user input
        public override string Search()
        {
            uInput = false;

            while (!uInput)
            {
                do //loop runs until they find a name that they want to search for, or after trying they decide to exit the loop and return to the menu
                {
                    res = false;
                    do //loop to make sure that they don't enter an int when they need a string key
                    {

                        Console.WriteLine("\nWhat name do you want to search for?");
                        sName = Console.ReadLine();

                        res = int.TryParse(sName, out num1); //res will return true if the string is a number
                        if (res == true)
                        {
                            Console.WriteLine("\nWrong input type. Try something like Billy");
                            Console.WriteLine(); //create some whitespace on output
                        }

                    } while (res == true);

                    myStopwatch.Start(); //start stopwatch


                    if (dStructure.TryGetValue(sName, out iDictionaryOuput)) //user input found
                    {
                        Console.WriteLine("\nWe found the name that you were looking for! The associated number is " + iDictionaryOuput);
                        bUserSearch = true;

                        myStopwatch.Stop();
                        Console.WriteLine("\nTime elapsed: {0}", myStopwatch.Elapsed); //display how much time it took to search
                    }
                    else //user input not found
                    {
                        //problem here if entry not found
                        if (dStructure["New Entry " + 1] == 1) //guidelines to help them search next time
                        {
                            Console.WriteLine("\nWe couldn't find your name... Maybe try something along the lines of \" New Entry \" followed by a number (e.g. New Entry 1)");
                            bUserSearch = false;
                        }
                        else
                        {
                            Console.WriteLine("\nSorry, we couldn't find your name");
                            bUserSearch = false;
                        }


                        myStopwatch.Stop();
                        Console.WriteLine("\nTime elapsed: {0}", myStopwatch.Elapsed); //display how much time it took to search

                        res = false;
                        do //loop to make sure that they don't enter an int when asked if they want to search again
                        {
                            Console.WriteLine("\nWould you like to try again? (y/n)");
                            uResponse = UppercaseFirst(Console.ReadLine()); //converts user input to uppercase

                            res = int.TryParse(uResponse, out num1); //res will return true if the string is a number
                            if (res == true)
                            {
                                Console.WriteLine("\nWrong input type. Try something like Yes or No");
                                Console.WriteLine(); //create some whitespace on output

                            }

                        } while (res == true);

                        if (uResponse.StartsWith("Y"))
                        {
                            bUserSearch = false;
                        }
                        else
                        {
                            bUserSearch = true;
                        }



                    } //end of if/else statement


                } while (bUserSearch == false);

                uInput = true;
            }

            return base.Search();
        }
    }

}