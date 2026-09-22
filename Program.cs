using System;
using System.Collections.Generic;

namespace homework1
{
    public class Program
    {
        static void Main(string[] args)
        {
            BookDAL bookdal = new BookDAL();

            int choice = 0;

            while (choice != 5)
            {
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Find Book by ID");
                Console.WriteLine("4. Create Backup");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Console.Write("Enter Book ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Book Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Enter Book Author: ");
                        string author = Console.ReadLine();

                        Console.Write("Enter Book Price: ");
                        int price = int.Parse(Console.ReadLine());

                        Book book = new Book(id, title, author, price);

                        bookdal.AddBook(book);

                        break;


                    case 2:

                        List<Book> books = bookdal.GetAllBooks();

                        if (books.Count == 0)
                        {
                            Console.WriteLine("No books found.");
                        }
                        else
                        {
                            foreach (Book b in books)
                            {
                                b.DisplayInfo();
                            }
                        }

                        break;


                    case 3:

                        Console.Write("Enter Book ID to search: ");
                        int searchId = int.Parse(Console.ReadLine());

                        Book foundBook = bookdal.FindBookById(searchId);

                        if (foundBook != null)
                        {
                            foundBook.DisplayInfo();
                        }
                        else
                        {
                            Console.WriteLine("Book not found.");
                        }

                        break;


                    case 4:

                        bookdal.CreateBackup();

                        break;


                    case 5:

                        Console.WriteLine("Exiting program...");

                        break;


                    default:

                        Console.WriteLine("Invalid choice!");

                        break;
                }
            }
        }
    }
}