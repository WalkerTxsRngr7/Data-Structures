using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Froggys_Book_and_Game_Store
{
    class CartItem
    {
        //variables
        private string itemPurchased;
        private int qty;
        private double cartPrice;
        
        public string ItemPurchased { get => itemPurchased; set => itemPurchased = value; }
        public int Qty { get => qty; set => qty = value; }
        public double CartPrice { get => cartPrice; set => cartPrice = value; }

        //constructor needing all data entered
        public CartItem(string cItemPurchased, int cQty, double cCartPrice)
        {
            itemPurchased = cItemPurchased;
            qty = cQty;
            cartPrice = cCartPrice;
        }

        public void DisplayItemTotal()      //Display item price and qty
        {
            WriteLine($"\nQty: {qty}");
            WriteLine($"Item: {itemPurchased}");
            WriteLine($"Price: ${cartPrice}");
            WriteLine($"Subtotal: ${(Math.Round(cartPrice * qty, 2))}");
        }
    }
}
