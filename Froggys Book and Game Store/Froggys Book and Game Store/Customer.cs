using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Froggys_Book_and_Game_Store
{
    class Customer
    {
        //variables
        private string custName;

        public string CustName { get => custName; set => custName = value; }

        List<CartItem> cartItems = new List<CartItem>();

        //constructor needing all data entered
        public Customer(string cCustName)
        {
            custName = cCustName;
        }

        public void AddItem(CartItem cartItem)  //Add CartItem to cart list
        {
            cartItems.Add(cartItem);
        }

        public void DisplayReceipt() //Display receipt without saving to file
        {
            Double subtotal = 0, tax = 0, total = 0;
            WriteLine(String.Format("{0,-10} | {1,-20} | {2,8} | {3,8}", "Quantity", "Item", "Price", "Total"));
            WriteLine("-------------------------------------------------------");
            foreach (var item in cartItems)
            {
                WriteLine(String.Format($" {item.Qty,-9} | {item.ItemPurchased,-20} | {string.Format("{0:C2}", item.CartPrice),8} | {string.Format("{0:C2}", item.CartPrice * item.Qty),8}"));

                subtotal += item.CartPrice * item.Qty;
            }
            tax = subtotal * 0.076;
            total = subtotal + tax;

            WriteLine();
            WriteLine(String.Format($"{"Subtotal",-10} {string.Format("{0:C2}", subtotal),44}"));
            WriteLine(String.Format($"{"Tax",-10} {string.Format("{0:C2}", tax),44}"));
            WriteLine(String.Format($"{"Total",-10} {string.Format("{0:C2}", total),44}"));

        }

        //Default File locations are in Solution folder/bin/debug
        public void SaveReceipt() //Write receipt to file of name of customer
        {
            // Folder, where a file is created.  
            string folder = @"";
            // Filename  
            string fileName = $"{custName}.txt";
            // Fullpath. You can direct hardcode it if you like.  
            string fullPath = folder + fileName;
            // Write file using StreamWriter  
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                Double subtotal = 0, tax = 0, total = 0;
                writer.WriteLine(String.Format("{0,-10} | {1,-20} | {2,8} | {3,8}", "Quantity", "Item", "Price", "Total"));
                writer.WriteLine("-------------------------------------------------------");
                foreach (var item in cartItems)
                {
                    writer.WriteLine(String.Format($" {item.Qty,-9} | {item.ItemPurchased,-20} | {string.Format("{0:C2}", item.CartPrice),8} | {string.Format("{0:C2}", item.CartPrice * item.Qty),8}"));

                    subtotal += item.CartPrice * item.Qty;
                }
                tax = subtotal * 0.076;
                total = subtotal + tax;

                writer.WriteLine();
                writer.WriteLine(String.Format($"{"Subtotal",-10} {string.Format("{0:C2}", subtotal),44}"));
                writer.WriteLine(String.Format($"{"Tax",-10} {string.Format("{0:C2}", tax),44}"));
                writer.WriteLine(String.Format($"{"Total",-10} {string.Format("{0:C2}", total),44}"));

                //writer.WriteLine("Monica Rathbun");
                //writer.WriteLine("Vidya Agarwal");
                //writer.WriteLine("Mahesh Chand");
                //writer.WriteLine("Vijay Anand");
                //writer.WriteLine("Jignesh Trivedi");
            }
            // Read a file  
            string readText = File.ReadAllText(fullPath);
            Console.WriteLine(readText);
        }
    }
}
