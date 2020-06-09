using System.Collections.Generic;

namespace RefactoringWithLINQ
{
    public class Library
    {
        private readonly List<Book> books = new List<Book>();
        
        public void AddBook(Book book) => books.Add(book);
        
        public List<Book> BooksOfAuthor(string author)
        {
            var result = new List<Book>();
            foreach (var book in books)
            {
                if (book.Author == author)
                {
                    result.Add(book);
                }
            }
            return result;
        }

        public List<Book> BooksWrittenAfter(int year)
        {
            var result = new List<Book>();
            foreach (var book in books)
            {
                if (book.PublicationYear > year)
                {
                    result.Add(book);
                }
            }
            return result;
        }

        public List<Book> SortBooksByYear()
        {
            var booksCopy = new List<Book>();
            foreach (var book in books)
            {
                booksCopy.Add(book);
            }

            booksCopy.Sort((b1, b2) => b1.PublicationYear > b2.PublicationYear ? 1 : b2.PublicationYear > b1.PublicationYear ? -1 : 0);

            return booksCopy;
        }
    }
}
