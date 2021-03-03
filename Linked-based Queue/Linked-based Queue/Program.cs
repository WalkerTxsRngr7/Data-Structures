using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_based_Queue
{
    /// <summary>
    /// Developer: Walker Gross
    /// Date: 10/12/2020
    /// Purpose: Link-based queue of integers to test Enqueue and Dequeue methods.
    /// </summary>
    
    class Program
    {
        static void Main(string[] args)
        {
            LinkedQueue testQueue = new LinkedQueue(1, 2);          //create Queue with values 1 and 2

            Console.WriteLine("Queue created with 1, 2");
            Console.WriteLine();
            Console.WriteLine($"Current in Queue:{testQueue.Peek().GetData()}");
            Console.WriteLine();
            LLNode newBack = new LLNode(3);
            Console.WriteLine($"Adding to Queue:{newBack.GetData()}");
            testQueue.Enqueue(newBack);
            Console.WriteLine();
            Console.WriteLine($"Dequeuing:{testQueue.Dequeue()}");
            Console.WriteLine($"Current in Queue:{testQueue.Peek().GetData()}");
            Console.WriteLine();
            LLNode newBack2 = new LLNode(4);
            Console.WriteLine($"Adding to Queue:{newBack2.GetData()}");
            testQueue.Enqueue(newBack2);
            Console.WriteLine();

            while (testQueue.Peek() != null)
            {
                Console.WriteLine($"Dequeuing:{testQueue.Dequeue()}");
                if (testQueue.Peek() != null)
                    Console.WriteLine($"Current in Queue:{testQueue.Peek().GetData()}");
                else
                    break;
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
    class LLNode        //class for the individual nodes
    {
        private int data;
        private LLNode next;

        //constructors
        public LLNode(int data, LLNode next)
        {
            this.next = next;
            this.data = data;
        }
        public LLNode(int data)
        {
            this.data = data;
        }
        public LLNode()
        {
        }

        public void SetData(int d)  //Set value of current node
        {
            this.data = d;
        }

        public void SetNext(LLNode n)   //set address of next node in current node
        {
            this.next = n;
        }

        public int GetData()            //return value of current node data
        {
            return this.data;
        }

        public LLNode GetNext()         //return address of next node
        {
            return this.next;
        }
    }

    class LinkedList        //class for the linked list that holds the nodes
    {
        private LLNode front;
        private LLNode back;

        //constructors
        public LinkedList()
        {
        }

        public LinkedList(int f, int b)
        {
            this.back = new LLNode(b);
            this.front = new LLNode(f, this.back);
        }

        public void SetFront(LLNode newFront)       //set front node
        {
            this.front = newFront;
        }

        public void SetBack(LLNode back)            //set back node
        {
            this.back.SetNext(back);
            this.back = back;
        }

        public LLNode GetFront()                    //return address of front node
        {
            return this.front;
        }

        public LLNode GetBack()                     //return address of back node
        {
            return this.back;
        }
    }

    class LinkedQueue
    {

        public LinkedList list = new LinkedList();\
        
        //constructors
        public LinkedQueue()
        {
            LinkedList list = new LinkedList();
        }
        public LinkedQueue(int queue, int back)
        {
            this.list = new LinkedList(queue, back);
        }

        public void Enqueue(LLNode back)            //put node in the last position of linked list
        {
            this.list.SetBack(back);
        }
        public int Dequeue()                        //remove front node from linked list
        {
            LLNode ouput = new LLNode();
            if (list.GetFront() != null)
            {
                ouput = list.GetFront();

                list.SetFront(list.GetFront().GetNext());
            }
            else
            {
                Console.WriteLine("NOTHING IN QUEUE");
            }
            
            return ouput.GetData();
        }

        public LLNode Peek()                    //return front node in linked list
        {
            if (list.GetFront() != null)
            {
                return list.GetFront();
            }
            else
            {
                Console.WriteLine("NOTHING IN QUEUE");

                return null;
            }
        }
    }
}
