using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using static System.Reflection.Metadata.BlobBuilder;

namespace libirarytask
{
    class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public   string  isbn{ get; set; }
        public bool availabality { get; set; }

        public Book(string title, string author, string isbn)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.availabality = true;
        }

    }
    class libirary
    {
         List<Book> Books = new List<Book>();

        public libirary()
        {
        }

        public libirary(List<Book> books)
        {
            Books = books;
        }

        public bool AddBook(Book book)
        {
            Books.Add(book);
            return true;
        }
       
        public  void BorrowBook(string searchbook)
        {
            // Find the first book that matches the title or author

            Book book = Books.FirstOrDefault(b =>
                b.title.Equals(searchbook, StringComparison.OrdinalIgnoreCase) ||
                b.author.Equals(searchbook, StringComparison.OrdinalIgnoreCase));

            if (book != null && !book.availabality)
            {
                book.availabality = true;
                Console.WriteLine($"You borrowed the book: {book.title} by {book.author}");
            }
            else if (book != null && book.availabality)
            {
                Console.WriteLine($"The book '{book.title}' by {book.author} is already borrowed.");
            }
            else
            {
                Console.WriteLine($"No book found matching '{searchbook}'.");
            }


        }
        public void ReturnBook(string searchbook)
        {
            // Find the first book that matches the title or author
            Book book = Books.FirstOrDefault(b =>
                b.title.Equals(searchbook, StringComparison.OrdinalIgnoreCase) ||
                b.author.Equals(searchbook, StringComparison.OrdinalIgnoreCase));

            if (book != null && !book.availabality)
            {
               
                Console.WriteLine($"You returned the book: {book.title} by {book.author}");
            }
            else if (book != null && book.availabality)
            {
                book.availabality = false;
                Console.WriteLine($"The book '{book.title}' by {book.author}' is already back to the library.");
            }
            else
            {
                Console.WriteLine($"No book found matching '{searchbook}'.");
            }
        }









    }
    internal class Program
    { 
        static void Main(string[] args)
        {
            libirary library = new libirary();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("the Great Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("The Great Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

            Console.ReadLine();
        }
    }
}
