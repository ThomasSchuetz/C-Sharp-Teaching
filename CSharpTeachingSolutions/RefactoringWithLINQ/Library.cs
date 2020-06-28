using System.Collections.Generic;
using System.Linq;

namespace RefactoringWithLINQ
{
    public class Library
    {
        private readonly List<Book> books = new List<Book>();

        public void AddBook(Book book) => books.Add(book);

        public List<Book> BooksOfAuthor(string author)
        {
            return (from book in this.books where book.Author == author select book).ToList();
            return this.books.Where(book => book.Author == author).ToList();
        }

        public List<Book> BooksWrittenAfter(int year)
        {
            return (from book in this.books where book.PublicationYear > year select book).ToList();
            return this.books.Where(book => book.PublicationYear > year).ToList();
        }

        public List<Book> SortBooksByYear()
        {
            return (from book in this.books orderby book.PublicationYear select book).ToList();
            return this.books.OrderBy(b => b.PublicationYear).ToList();
        }
    }
}
