using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace Froggys_Book_and_Game_Store
{
    /// <summary>
    /// App: FroggysBookAndGameStore
    /// Developer: Walker Gross
    /// Date: 8/30/20
    /// Purpose: POS system to display inventory, allow purchasing items, and create receipt. 
    /// </summary>
    

    //Default File locations are in Solution folder/bin/debug
   
    class Program
    {
        private List<Book> bookList = new List<Book>();
        private List<Game> gameList = new List<Game>();

        static void Main(string[] args)
        {
            Program p = new Program();
            p.GetBookInventory();
            p.GetGameInventory();
            p.DisplayMenu();
            ReadKey();
        }

        //Default File locations are in Solution folder/bin/debug
        private void GetBookInventory()
        {
            string record;

            try     //Try to read Book file and get inventory
            {
                StreamReader filBooksIn = new StreamReader(@"Books.txt"); //Item code, Name of book, Desc of book, Price, Author

                while ((record = filBooksIn.ReadLine()) != null)
                {
                    string[] details = record.Split(',');
                    Book book = new Book(details[0], details[1], details[2], Convert.ToDecimal(details[3]), details[4]);
                    bookList.Add(book);
                }
                filBooksIn.Close();
            }
            catch (System.IO.IOException exc)
            {
                WriteLine("Could Not Get Books Inventory");
            }
        }

        //Default File locations are in Solution folder/bin/debug
        private void GetGameInventory()
        {
            string record;

            //init the array list
            //gameList = new List<Game>();

            try     //Try to read Game file and get inventory
            {
                StreamReader filGamesIn = new StreamReader(@"Games.txt"); //Item code, Name of game, Desc of game, Price, Rating

                while ((record = filGamesIn.ReadLine()) != null)
                {
                    string[] details = record.Split(',');
                    Game game = new Game(details[0], details[1], details[2], Convert.ToDecimal(details[3]), details[4]);
                    gameList.Add(game);
                }
                filGamesIn.Close();
            }
            catch (System.IO.IOException exc)
            {
                WriteLine("Could Not Get Games Inventory");
            }
        }

        private void DisplayMenu()      //Display main menu
        {
            string custName, prodCode, cont;
            int prodNum, qty;
            Book book;
            Game game;
            CartItem cartItem;
            List<string> details = new List<string>();
            //List<CartItem> cartItems = new List<CartItem>();

            WriteLine("WELCOME TO FROGGY'S BOOK & GAME STORE!");
            WriteLine("What is your name?");
            custName = ReadLine();

            Customer cust = new Customer(custName);

            do      //Display items available and repeat until customer is done
            {
                WriteLine("Here is the list of items we have:");
                DisplayProducts();

                do //Validate selected item
                {    
                    WriteLine("\nWhich would you like? ");
                    prodCode = ReadLine();
                    prodNum = FindProduct(prodCode);
                } while (prodNum == -1);

                if (prodCode[0] == 'B') //If product would be in Books
                {
                    book = bookList[prodNum];
                    details = book.GetDetails();
                }
                else if (prodCode[0] == 'G')   //If product would be in Games
                {
                    game = gameList[prodNum];
                    details = game.GetDetails();
                }

                Write($"You chose {details[1]}. How many would you like? ");
                qty = Convert.ToInt32(ReadLine());

                cartItem = new CartItem(details[1], qty, Convert.ToDouble(details[3]));
                cust.AddItem(cartItem);

                cartItem.DisplayItemTotal();

                Write("Would you like another item? Y or N ");
                cont = ReadLine();
                WriteLine("\n\n");
            } while (cont == "Y");
            
            cust.SaveReceipt();
        }

        private void DisplayProducts()      //Display inventory of books and games
        {
            WriteLine("**********BOOKS**********");
            foreach (var book in bookList)
            {
                WriteLine(book);
            }
            WriteLine("**********GAMES**********");
            foreach (var game in gameList)
            {
                WriteLine(game);
            }
        }

        private int FindProduct(string prodCode)    //Find item location in list using Item code
        {
            int i = 0;

            if (prodCode[0] == 'B') //If product would be in Books
            {
                foreach (var book in bookList)
                {
                    if (book.ItemCode == prodCode)
                    {
                        return i;
                    }
                    i++;
                }
            }
            else if (prodCode[0] == 'G') //If product would be in Games
            {
                foreach (var game in gameList)
                {
                    if (game.ItemCode == prodCode)
                    {
                        return i;
                    }
                    i++;
                }
            }
            WriteLine("Product Not Found");
            return -1; //Product not found
        }
    }
}
