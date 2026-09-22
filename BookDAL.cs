using System;
using System.Collections.Generic;
using System.IO;

namespace homework1
{
    public class BookDAL
    {
        private string filePath = "books.txt";
        private string backupPath = "books_backup.txt";


        public void AddBook(Book book)
        {
            Console.WriteLine(book == null);

            using (FileStream fs = new FileStream(filePath, FileMode.Append))
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine(book.Id + "," + book.Title + "," + book.Author + "," + book.Price);
            }
        }


        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            if (!File.Exists(filePath))
            {
                return books;
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs))
            {
                string line = sr.ReadLine();

                while (line != null)
                {
                    string[] data = line.Split(',');

                    Book book = new Book(
                        int.Parse(data[0]),
                        data[1],
                        data[2],
                        int.Parse(data[3])
                    );

                    books.Add(book);

                    line = sr.ReadLine();
                }
            }

            return books;
        }


        public Book FindBookById(int id)
        {
            List<Book> books = GetAllBooks();

            foreach (Book book in books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }

            return null;
        }


        public void CreateBackup()
        {
            using (FileStream source = new FileStream(filePath, FileMode.Open))
            using (FileStream destination = new FileStream(backupPath, FileMode.Create))
            {
                int data;

                while ((data = source.ReadByte()) != -1)
                {
                    destination.WriteByte((byte)data);
                }
            }

            Console.WriteLine("Backup created successfully.");
        }
    }
}