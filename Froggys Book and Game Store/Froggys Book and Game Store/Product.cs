using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Froggys_Book_and_Game_Store
{
    class Product
    {
        //variables
        protected string itemCode;
        protected string name;
        protected string desc;
        protected decimal price;

        public string ItemCode { get => itemCode; }
        public string Name { get => name; }
        public string Desc { get => desc; }
        public decimal Price { get => price; }
        

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
