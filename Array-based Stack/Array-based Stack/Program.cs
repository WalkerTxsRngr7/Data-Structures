using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_based_Stack
{
    /// <summary>
    /// Developer: Walker Gross
    /// Date: 10/12/2020
    /// Purpose: Array-based Stack to test Push, Pop, and Peek methods.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();      //create stack
            stack.Push(1);                  //add values to the end of stack
            stack.Push(2); 
            stack.Push(3);
            Console.WriteLine("The last value is: " + stack.Peek());//write last value in stack
            Console.WriteLine("\nPopping the last index.");
            stack.Pop();                    //remove last index from stack
            Console.WriteLine("The last value is: " + stack.Peek());
            Console.WriteLine("\nPopping the last index.");
            stack.Pop();
            Console.WriteLine("The last value is: " + stack.Peek());
            Console.WriteLine("\nPopping the last index.");
            stack.Pop();

            Console.ReadKey();
        }
    }

    class Stack
    {
        int size = 0;
        int capacity = 50;
        int[] stack;
        
        public Stack()
        {
        }

        public void Push(int num)   //Add num to the end of stack
        {
            if (size < capacity)
            {
                size++;
                int[] newStack = new int[size];
                if (size > 1)
                {
                    for (int i = 0; i < size - 1; i++)
                    {
                        newStack[i] = this.stack[i];
                    }
                }
                
                this.stack = newStack;
                this.stack[size-1] = num;

            }
            else
                Console.WriteLine("Stack Overflow");
        }

        public void Pop()   //Remove the last index of stack
        {
            if (size > 0)
            {
                size--;
                int[] newStack = new int[size];
                if (size >= 1)
                {
                    for (int i = 0; i < size; i++)
                    {
                        newStack[i] = this.stack[i];
                    }
                }
                this.stack = newStack;
            }
            else
                Console.WriteLine("Stack is Empty");
        }

        public int Peek()   //Return value of last index of stack
        {
            return stack[size - 1];
        }
    }
}
