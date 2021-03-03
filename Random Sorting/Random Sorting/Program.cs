using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Sorting
{
    /// <summary>
    /// Developer: Walker Gross
    /// Date: 10/13/2020
    /// Purpose: Test Counter sort method against various arrays of integers
    /// </summary>
    
    class Program
    {
        static void Main(string[] args)
        {
            string choice;
            Console.WriteLine("Program 1 (short) or 2 (long)?");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":           //short program
                    //Same values
                    int[] sameValues = new int[50];
                    for (int i = 0; i < 50; i++)
                    {
                        sameValues[i] = 1;
                    }

                    //Already Sorted
                    int[] sorted = new int[50];
                    for (int i = 0; i < 50; i++)
                    {
                        sorted[i] = i;
                    }

                    //Reverse Sorted
                    int[] revSorted = new int[50];
                    for (int i = 0; i < 50; i++)
                    {
                        revSorted[i] = 49 - i;
                    }

                    //Random values
                    int[] rand = new int[100];
                    Random rnd = new Random();
                    for (int i = 0; i < 100; i++)
                    {
                        rand[i] = rnd.Next(0, 100);
                    }


                    //Same Values
                    sameValues = counterSort(sameValues);
                    Console.Write("Same Values Sorted array is ");
                    for (int i = 0; i < sameValues.Length; ++i)
                        Console.Write(sameValues[i] + " ");
                    Console.WriteLine("\n");

                    //Already Sorted
                    sorted = counterSort(sorted);
                    Console.Write("Sorted array is ");
                    for (int i = 0; i < sorted.Length; ++i)
                        Console.Write(sorted[i] + " ");
                    Console.WriteLine("\n");

                    //Reverse Sorted
                    revSorted = counterSort(revSorted);
                    Console.Write("Reverse Sorted array is ");
                    for (int i = 0; i < revSorted.Length; ++i)
                        Console.Write(revSorted[i] + " ");
                    Console.WriteLine("\n");

                    //Random Numbers
                    rand = counterSort(rand);
                    Console.Write("Random Sorted array is ");
                    for (int i = 0; i < rand.Length; ++i)
                        Console.Write(rand[i] + " ");
                    Console.WriteLine("\n");
                    break;


                case "2":           //long program
                    int fails = 0;
                    for (int i = 0; i < 1000; i++)
                    {
                        int[] ary = new int[100000];    //inner array size
                        Random rand1 = new Random();
                        for (int j = 0; j < 100000; j++)   //loop for array size to give values to each index
                        {
                            ary[j] = rand1.Next(0, 100000);     //set random number to index j in ary
                        }
                        ary = counterSort(ary);

                        for (int j = 1; j < ary.Length; j++)
                        {
                            //Console.Write(ary[j] + " ");      //for printing each number

                            if (ary[j] < ary[j - 1]) //test for errors
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write(ary[j] + " Sorted Incorrectly! ");
                                Console.ResetColor();
                                fails++;

                            }
                        }
                        //Console.WriteLine("\n");          //for seperating each test
                    }
                    Console.WriteLine($"Test Finished with {fails} fails!");
                    break;
                    

                default:
                    Console.WriteLine("Incorrect input.");
                        break;
            }

            

            Console.ReadKey();
        }

        static int[] counterSort(int[] ary)
        {
            int n = ary.Length;

            // The output integer array that 
            // will have sorted ary
            int[] output = new int[n];

            // Create a count array to store 
            // count of individual integers 
            // and initialize count array as 0 
            int[] count = new int[n];

            for (int i = 0; i < n; ++i)
                count[i] = 0;

            // store count of each character 
            for (int i = 0; i <= n-1; i++)
                ++count[ary[i]];

            // Change count[i] so that count[i] 
            // now contains actual position of 
            // this character in output array 
            for (int i = 1; i <= n-1; ++i)
                count[i] += count[i - 1];

            // Build the output character array 
            // To make it stable we are operating in reverse order. 
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[ary[i]]-1] = ary[i];
                --count[ary[i]];
            }

            // Copy the output array to ary, so 
            // that ary now contains sorted 
            // characters 
            for (int i = 0; i < n; ++i)
                ary[i] = output[i];

            return ary;
        }
     }
}
