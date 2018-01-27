using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_
{
    public class Library//Class Created 
    {//non-static instances of the object
        public string title;
        public decimal price = 0;
        public int NOfPages = 0;
        public int IBSN;
        public string Type;
        public int Antiquity = 0;
        public static int BookForLibrary = 0;
        public bool returnbook = false;

        public Library(string title, decimal price, int NOfPages, int IBSN, string Type, int Antiquity)
        {
            this.title = title;
            this.price = price;
            this.NOfPages = NOfPages;
            this.IBSN = IBSN;
            this.Type = Type;
            this.Antiquity = Antiquity;
            this.returnbook = false;
            //BookForLibrary++;
        }

        public static void DisplayAlbooks(List<Library> bookList)
        {
            Console.WriteLine("\nTHE DETAILS OF THE BOOKS: \n");

            //go through the BOOK list
            
                foreach (Library item in bookList)
                {
                //decimal totalbooks = 0;
                
                    Console.WriteLine(" Title:{0}\n Price:£{1:N0}\n Number of pages:{2}\n IBSN:{3}\n Type:{4}\n Antiquity:{5}.\n", item.title, item.price, item.NOfPages, item.IBSN, item.Type, item.Antiquity);
                }
        }

    }
        class Book : Library//INHERITANCE FROM LYBRARY

        {
            public Book(string title, decimal price, int NOfPages, int IBSN, string Type, int Antiquity) : base(title, price, NOfPages, IBSN, Type, Antiquity)
            {

            }
        }
        class Program
        {
            static void Main(string[] args)
            {
            //List<Library> bookList2 = new List<Library>();// CREATE A LIST FOR THE BOOK RETURNED BY THE USER
            List<Library> bookList = new List<Library>();//CREATE THE LIST OF BOOKS FOR THE OBJECTS DECLARED BELLOW

                string[] booksarray = new string[1];
            
                string title;
                decimal price = 0;
                int NOfPages = 0;
                int IBSN = 0;
                string Type = "";
                int Antiquity = 0;
                char input;
                int index;
            //ENTER THE BOOKS IN TO THE LIST=============================================================

                Book book1 = new Book("Lord Of The Rings", 21.50m, 1289, 12569, "Fantasy", 12);
                bookList.Add(book1);
                Book book2 = new Book("Sapiens", 9.99m, 480, 45789, "Science", 4);
                bookList.Add(book2);
                Book book3 = new Book("Sherlok Holmes", 12.69m, 380, 95616, "Mistery", 26);
                bookList.Add(book3);

            do 
            {
                Console.WriteLine("***************************THIS IS THE ELECTRONIC LIBRARY************************************");
                Console.WriteLine("Please type:\n A)Return the book, please be aware you can just return a book because of our policy\n B)Display books avaliable\n S)Sort out the list\n F)Find a book in our list\n D)Delete books\n X)Exit\n");
                input = Convert.ToChar(Console.ReadLine().ToLower());

                switch (input)//VERY IMPORTANT!!!! WE NEED SWITCH CASE BECAUSE OF THE FOREACH, IF WE USED "IF" STATEMENT WILL HAVE AN ENDLESS LOOP
                {
                    case 'a'://GET THE BOOKS RETURNED FROM THE USER

                        Console.WriteLine("\nType the name of the book:");
                        title = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Type the price of the book:");
                        price = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Type the Number of pages of the book:");
                        NOfPages = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Type the IBSN of the book:");
                        IBSN = Convert.ToInt32(Console.ReadLine());
                        //===============ADD BOOK================================
                        Library book = new Book(title, price, NOfPages, IBSN, Type, Antiquity);
                        bookList.Add(book);
                        //======================================================

                        Console.WriteLine("Now I'm going to display your book to make sure is all good:\n");
                        
                        Console.WriteLine("Title: {0}\nPrice: £{1:N0}\nNumber of pages: {2}\nISBN: {3}.", title, price, NOfPages, IBSN);//prints out the book inserted by the user
                        break;

                    case 'b'://DISPLAY BOOKS

                        Console.WriteLine("\nNow I will display all the books avaliable:");
                        //foreach (string i in bookList)//FOREACH TO DISPLAY EVERY ELEMENT OF THE LIST
                        {
                            Library.DisplayAlbooks(bookList);//FUNCTION DISPLAY BOOKS
                        }
                        break;

                    case 's'://SORT OUT THE LIST IN ALPHABETIC ORDER
                        bookList = bookList.OrderBy(Book => Book.title).ToList();
                        Console.WriteLine("The list of books has been sorted");
                        break;

                    case 'f'://FIN THE BOOK ON THE LIST
                        Console.WriteLine("Please enter the title of the book you want to find:");
                        title = Console.ReadLine();
                        
                        index = bookList.FindIndex(item => item.title == title);
                        if (index >= 0)
                        {
                            Console.WriteLine("{0} is in the list", title);  
                        }
                        else
                        {
                            Console.WriteLine("{0} was not found in the list.", title);
                        }
                        break;

                    case 'd'://DELETE A BOOK
                        
                        Console.WriteLine("Please enter the title of the book you want to delete:");

                        title = Console.ReadLine();
                        index = bookList.FindIndex(item => item.title == title);
                        if ((index >= 0) && (index < bookList.Count))
                        {
                            bookList.Remove(bookList[index]);
                            Console.WriteLine("{0} has been deleted from the list", title);
                        }
                        else
                        {
                            Console.WriteLine("{0} was not found in the list.", title);
                        }
                        break;
                }
             } while (input != 'x');

            }//VOID MAIN
        }//CLASS PROGRAM
    }