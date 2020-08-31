using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Froggys_Book_and_Game_Store
{
    class Game : Product
    {
        //variables
        private string rating;

        public string Rating { get => rating; }

        //constructor needing all data entered
        public Game(string gItemCode, string gName, string gDesc, decimal gPrice, string gRating)
        {
            itemCode = gItemCode;
            name = gName;
            desc = gDesc;
            price = gPrice;
            rating = gRating;
        }

        public List<string> GetDetails()    //Return list with item details
        {
            List<string> details = new List<string>();
            details.Add(itemCode);
            details.Add(name);
            details.Add(desc);
            details.Add(Convert.ToString(price));
            details.Add(rating);
            return details;
        }

        public override string ToString()
        {
            return $"{ItemCode} {Name}";
        }
    }
}
