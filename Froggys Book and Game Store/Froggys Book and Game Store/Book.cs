using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Froggys_Book_and_Game_Store
{
    class Book : Product
    {
        //variables
        private string author;

        public string Author { get => author; }

        //constructor needing all data entered
        public Book(string bItemCode, string bName, string bDesc, decimal bPrice, string bAuthor)
        {
            itemCode = bItemCode;
            name = bName;
            desc = bDesc;
            price = bPrice;
            author = bAuthor;
        }

        public List<string> GetDetails()    //Return list with item details
        {
            List<string> details = new List<string>();
            details.Add(itemCode);
            details.Add(name);
            details.Add(desc);
            details.Add(Convert.ToString(price));
            details.Add(author);
            return details;
        }

        public override string ToString()
        {
            return $"{ItemCode} {Name}";
        }
    }
}
