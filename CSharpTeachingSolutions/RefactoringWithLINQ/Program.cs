using System;
using System.Collections.Generic;

namespace RefactoringWithLINQ
{
    static class Program
    {
        static void Main()
        {
            var library = InitializeLibrary();

            PrintSelection(library.BooksOfAuthor("Joanne K. Rowling"));
            PrintSelection(library.BooksWrittenAfter(1950));
            PrintSelection(library.SortBooksByYear());
        }

        static Library InitializeLibrary()
        {
            var library = new Library();
            library.AddBook(new Book("Die Blechtrommel", "Günter Grass", 1959));
            library.AddBook(new Book("Harry Potter und der Stein der Weisen", "Joanne K. Rowling", 1998));
            library.AddBook(new Book("Buddenbrooks", "Thomas Mann", 1901));
            library.AddBook(new Book("Harry Potter und die Kammer des Schreckens", "Joanne K. Rowling", 1999));
            library.AddBook(new Book("Harry Potter und der Gefangene von Askaban", "Joanne K. Rowling", 1999));
            library.AddBook(new Book("Farm der Tiere", "George Orwell", 1945));
            library.AddBook(new Book("Harry Potter und der Feuerkelch", "Joanne K. Rowling", 2000));
            library.AddBook(new Book("Harry Potter und der Orden des Phönix", "Joanne K. Rowling", 2003));
            library.AddBook(new Book("1984", "George Orwell", 1948));
            library.AddBook(new Book("Harry Potter und der Halbblutprinz", "Joanne K. Rowling", 2005));
            library.AddBook(new Book("Harry Potter und die Heiligtümer des Todes", "Joanne K. Rowling", 2007));
            return library;
        }

        static void PrintSelection(IEnumerable<Book> books)
        {
            Console.WriteLine("\n\n");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
