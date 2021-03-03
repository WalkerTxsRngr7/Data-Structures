using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Trees
{
    /// <summary>
    /// Developer: Walker Gross
    /// Date: 10/26/2020
    /// Purpose: Binary Tree to sort nodes being added.
    /// </summary>
    class Program
    {


        static void Main(string[] args)
        {

            BinaryTree testTree = new BinaryTree();

            testTree.Insert(3);
            testTree.Insert(5);
            testTree.Insert(1);
            testTree.Insert(-1);




            Console.ReadKey();
        }
    }
    class LLNode
    {
        private LLNode left;
        private LLNode right;
        private int data;

        //constructors
        public LLNode(int data, LLNode left, LLNode right)
        {
            this.left = left;
            this.right = right;
            this.data = data;
        }
        public LLNode(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }
        public LLNode()
        {

        }

        //getters and setters
        public void SetData(int data)
        {
            this.data = data;
        }
        public void SetLeft(LLNode left)
        {
            this.left = left;
        }
        public void SetRight(LLNode right)
        {
            this.right = right;
        }
        public int GetData()
        {
            return this.data;
        }
        public LLNode GetLeft()
        {
            return this.left;
        }
        public LLNode GetRight()
        {
            return this.right; 
        }
    }
    class BinaryTree
    {

        private LLNode temp;
        private LLNode current;
        private LLNode parent;
        private LLNode root;
        
        public BinaryTree()
        {
            this.root = new LLNode(0);
        }

        public void Insert(int data)
        {
            temp = new LLNode(data);

            //if tree is empty, create root node
            if (root == null)
            {
                root = temp;
                Console.WriteLine("New root created with value of " + root.GetData());
            }
            else
            {
                current = root;
                parent = null;

                while (true)
                {
                    parent = current;

                    //left of current node
                    if (data < parent.GetData())
                    {
                        current = current.GetLeft();

                        //insert to the left
                        if (current == null)
                        {
                            parent.SetLeft(temp);
                            Console.WriteLine("Created the value " + temp.GetData() + " to the left of " + parent.GetData());
                            return;
                        }
                    }
                    else    //right of current node
                    {
                        current = current.GetRight();

                        //insert to the right
                        if (current == null)
                        {
                            parent.SetRight(temp);
                            Console.WriteLine("Created the value " + temp.GetData() + " to the right of " + parent.GetData());
                            return;
                        }
                    }
                }

            }

        }
    }
}
