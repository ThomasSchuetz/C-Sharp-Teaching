using System.Collections.Generic;
using System.Linq;

namespace RefactoringWithLINQ
{
    public class Library
    {
        private readonly List<Book> books = new List<Book>();
        
        public void AddBook(Book book) => books.Add(book);

        public List<Book> BooksOfAuthor(string author) => FilterBooks(book => book.Author == author);

        public List<Book> BooksWrittenAfter(int year) => FilterBooks(book => book.PublicationYear > year);

        private List<Book> FilterBooks(System.Func<Book, bool> filter) => books.Where(filter).ToList();

        // Alternative solution for filtering:
        //public List<Book> BooksOfAuthor(string author) => books.Where(book => book.Author == author).ToList();
        //public List<Book> BooksWrittenAfter(int year) => books.Where(book => book.PublicationYear > year).ToList();

        public List<Book> SortBooksByYear() => books.OrderBy(book => book.PublicationYear).ToList();
    }
}
