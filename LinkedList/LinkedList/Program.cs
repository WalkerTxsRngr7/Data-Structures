using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList testList = new LinkedList(5, 8, 3);


            Console.WriteLine("--------------------------");
            Console.Write($"Front: {testList.GetFront().GetData()}\nCurrent: {testList.GetCurrent().GetData()}\nBack: {testList.GetBack().GetData()}\n");
            Console.WriteLine("------------------");
            Console.WriteLine($"Front points to {testList.GetFront().GetNext().GetData()}");
            Console.WriteLine($"Current points to {testList.GetCurrent().GetNext().GetData()}");

            Console.WriteLine("--------------------------");
            LLNode newnum1 = new LLNode(4);
            testList.SetFront(newnum1);
            Console.WriteLine($"Front has been set to:{testList.GetFront().GetData()}");
            LLNode newnum2 = new LLNode(17);
            testList.SetBack(newnum2);
            Console.WriteLine($"Back has been set to:{testList.GetBack().GetData()}");
            Console.WriteLine("--------------------------");

            Console.Write($"Front: {testList.GetFront().GetData()}\nCurrent: {testList.GetCurrent().GetData()}\nBack: {testList.GetBack().GetData()}\n");
            Console.WriteLine("------------------");
            Console.WriteLine($"Front points to {testList.GetFront().GetNext().GetData()}");
            Console.WriteLine($"Current points to {testList.GetCurrent().GetNext().GetData()}");
            Console.WriteLine("--------------------------");




            Console.ReadKey();
        }
    }

    class LLNode
    {
        private int data;
        private LLNode next;

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

        public void SetData(int d)
        {
            this.data = d;
        }

        public void SetNext(LLNode n)
        {
            this.next = n;   
        }

        public int GetData()
        {
            return this.data;
        }

        public LLNode GetNext()
        {
            return this.next;
        }
    }

    class LinkedList
    {
        private LLNode front;
        private LLNode back;
        private LLNode current;

        public LinkedList(int f, int b, int c)
        {
            this.back = new LLNode(b);
            this.current = new LLNode(c, this.back);
            this.front = new LLNode(f, this.current);    
        }

        public void SetFront(LLNode newFront)
        {
            LLNode currentFront = this.front;
            this.front = newFront;
            this.front.SetNext(currentFront);
        }

        public void SetBack(LLNode back)
        {
            LLNode currentback = this.back;
            this.back.SetNext(currentback);
            this.back = back;
        }

        public void SetCurrent(LLNode current)
        {
            this.current = current;
        }

        public LLNode GetFront()
        {
            return this.front;
        }

        public LLNode GetBack()
        {
            return this.back;
        }

        public LLNode GetCurrent()
        {
            return this.current;
        }
    }
}
