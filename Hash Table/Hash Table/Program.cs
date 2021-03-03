using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

/// <summary>
/// Developer: Walker Gross
/// Date: 12/12/2020
/// Purpose: Hash Table containing people and phone numbers.
/// </summary>
namespace Hash_Table
{
    class Program
    {
        public static int count = 0;
        //Hash table creation
        public static Hashtable phonebook = new Hashtable();

        static void Main(string[] args)
        {

            //Read text file "phoneBook.txt", create "people" array of Person objects
            #region ReadInPeople
            Person[] people = new Person[10];

            using (StreamReader file = new StreamReader("../../phoneBook.txt")) //address to phoneBook.txt file
            {
                string line;
                //Loops through all lines in file
                while ((line = file.ReadLine()) != null)
                {
                    string[] person = line.Split(' ');
                    people[count] = new Person(person[0], person[1]);
                    count++;
                }
            }
            #endregion

            //Call FillPhoneBook function to fill hash table with names read from file held in people array
            FillPhoneBook(people);

            //Ask user for name of person to look for their phonenumber
            string cont = "y";
            while (cont == "y")
            {
                Console.WriteLine("Enter who's phone number you would like to find.");
                FindNumber(Console.ReadLine()); //call FindNumber, passing inputed name

                Console.WriteLine("Would you like to search another name? (y/n)");
                cont = Console.ReadLine();
                Console.WriteLine();
            }
        }

       
        //Hash function to get hash code for entry
        //Sum ascii values and modulus of the array size
        public static int GetHashCode(string name)
        {
            char[] letters = name.ToCharArray();
            int sum = 0;
            foreach (var letter in letters)
            {
                sum += letter;
            }

            return sum % count;
        }


        //Add Person objects to phonebook HashTable using calculated HashCode
        public static void FillPhoneBook(Person[] people)
        {
            for (int i = 0; i < count; i++)
            {
                Person person = people[i];
                int code = GetHashCode(person.GetName());

                if (phonebook[code] == null)    //if key location is empty in Hash Table
                {
                    phonebook.Add(code, person);
                }
                else    //if key location is filled
                {
                    Person current = new Person();
                    current = (Person)phonebook[code];
                    while (current.GetNext() != null)   //loop moving down the linkedlist until current node is last
                    {
                        current = current.GetNext();
                    }
                    
                    current.SetNext(person);    //set current last node's "next" to the new person node
                }
            }
        }


        //Return phone number of person being searched for
        public static void FindNumber(string name)
        {
            int code = GetHashCode(name);
            
            if (phonebook[code] == null)    //if key location of hash table is empty
            {
                Console.WriteLine("No Entries");
            }
            else    //if key location of hash table has at least one name
            {
                Person current = new Person();
                current = (Person)phonebook[code];
                while (current != null && current.GetName() != name)   //loop until find name searching for
                {
                    current = current.GetNext();
                }
                if (current != null)
                    Console.WriteLine(current.GetPhoneNumber());
                else
                    Console.WriteLine("No Entries");
            }
        }
    }
    
    //Object holding each person and the location of next person in linkedlist
    class Person
    {
        private string name, phoneNumber;
        private Person next;

        //Constructors
        public Person(string name, string phoneNumber)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
        }
        public Person()
        {
        }

        //return Person's name
        public string GetName()
        {
            return this.name;
        }

        //return Person's phoneNumber
        public string GetPhoneNumber()
        {
            return this.phoneNumber;
        }

        //set next to next Person object in the linkedlist
        public void SetNext(Person next)
        {
            this.next = next;
        }

        //returns the next Person object in the linkedlist
        public Person GetNext()
        {
            return this.next;
        }
    }

}
