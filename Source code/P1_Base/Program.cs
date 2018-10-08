using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Base
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = -1, b = -1;
            string sa, sb;
            int[] primes = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43,
                           47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97};

            bool isContinue = true;

            while (isContinue)
            {
                bool aValid = false, bValid = false;
                Console.WriteLine("Enter the first number:");
                while (!aValid)
                {
                    sa = Console.ReadLine();
                    try
                    {
                        a = Int32.Parse(sa);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} is not a valid integer.", sa);
                    }
                    if (a < 1 || a > 100)
                        Console.WriteLine("Please enter a number between 1 and 100.");
                    else
                        aValid = true;
                }

                Console.WriteLine("Enter the second number:");
                while (!bValid)
                {
                    sb = Console.ReadLine();
                    try
                    {
                        b = Int32.Parse(sb);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} is not a valid integer.", sb);
                    }
                    if (b < 1 || b > 100)
                        Console.WriteLine("Please enter a number between 1 and 100.");
                    else
                        bValid = true;
                }

                // Enter your code here.

                List<int> listA = new List<int>();   //list to hold the prime factors of the first number
                List<int> listB = new List<int>();   //list to hold the prime factors of the second number

                Console.WriteLine("\nThe factors of " + a + " are:\n"); // outputs line preceeding prime factors of number A to screen
                int pf1 = a;
                int x1;
                for (x1 = 2; a > 1; x1++)            //calculates prime factors of the first number
                    if (a % x1 == 0)
                    {
                        int x = 0;
                        while (a % x1 == 0)
                        {
                            a /= x1;
                            x++;
                            listA.Add(x1);
                        }
                    }
                StringBuilder builderA = new StringBuilder();    //converts contents of list A to a string for formatting on screen
                foreach (int factor in listA) // Loop through all strings
                {
                    builderA.Append(factor).Append(" "); // Append string to StringBuilder
                }
                string resultA = builderA.ToString(); // Get string from StringBuilder
                Console.WriteLine(resultA);   //outputs actual prime factorsof the first number to screen


                Console.WriteLine("\nThe factors of " + b + " are:\n");  // outputs line preceeding prime factors of number B to screen
                int pf2 = b;
                int x2;
                for (x2 = 2; b > 1; x2++)       //calculates prime factors of the second number
                    if (b % x2 == 0)
                    {
                        int y = 0;
                        while (b % x2 == 0)
                        {
                            b /= x2;
                            y++;
                            listB.Add(x2);
                        }
                    }
                StringBuilder builderB = new StringBuilder();  //converts contents of list A to a string for formatting on screen
                foreach (int factor in listB) // Loop through all strings
                {
                    builderB.Append(factor).Append(" "); // Append string to StringBuilder
                }
                string resultB = builderB.ToString(); // Get string from StringBuilder
                Console.WriteLine(resultB);


                ILookup<int, int> lookupB = listB.ToLookup(i => i);

                int[] result =                                      //stores common factors into array and keeps count in order to store duplicates
                (

                  from group1 in listA.GroupBy(i => i)
                  let group2 = lookupB[group1.Key]
                  from i in (group1.Count() < group2.Count() ? group1 : group2)
                  select i

                ).ToArray();

                Console.WriteLine("\nThe common factors of " + pf1 + " and " + pf2 + " are:\n");    //outputs line preceding common factors to screen




                StringBuilder builderS = new StringBuilder();  //converts contents of array to a string for formatting on screen
                foreach (int factor in result) // Loop through all strings
                {
                    builderS.Append(factor).Append(" "); // Append string to StringBuilder
                }
                string resultS = builderS.ToString(); // Get string from StringBuilder
                Console.WriteLine(resultS);  // outputs actual common factors to screen

                int GCF = 1; // initialize GCF
                foreach (int factor in result) // multiply each common factor to eachother
                {
                    GCF *= factor;
                }
                Console.WriteLine("\nThe GCF of " + pf1 + " and " + pf2 + " is: " + GCF); //output GCF to screen


                Console.Write("\nThe LCD of " + pf1 + " and " + pf2 + " is: "); //output line of text preceeding LCD
                int LCD = 0; //initialize LCD
                int num1 = pf1;
                int num2 = pf2;
                while (pf1 != pf2)  //calculate LCD
                {
                    if (pf1 > pf2)
                    {
                        pf1 = pf1 - pf2;
                    }
                    else
                    {
                        pf2 = pf2 - pf1;
                    }
                }
                LCD = (num1 * num2) / pf1;
                Console.Write(LCD + "\n"); //output actual LCD to screen

                //End of my code

                Console.WriteLine("\nDo you want to continue? Y/N");
                string newLoop = Console.ReadLine();
                if (newLoop[0] == 'Y' || newLoop[0] == 'y')
                {
                    Console.WriteLine();
                    isContinue = true;
                }
                else
                    isContinue = false;
            }
        }
    }
}
