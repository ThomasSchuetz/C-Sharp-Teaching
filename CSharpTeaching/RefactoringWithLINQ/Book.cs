using System;

namespace RefactoringWithLINQ
{
    public class Book
    {
        public string Author { get; }
        public string Title { get; }
        public int PublicationYear { get; }

        public Book(string title, string author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }

        public override string ToString() => $"{Title} by {Author}, published in {PublicationYear}";

        public override bool Equals(object obj) => obj switch
        {
            null => false,
            Book book => book.Author == Author && book.Title == Title && book.PublicationYear == PublicationYear,
            _ => false
        };

        public override int GetHashCode() => HashCode.Combine(Author, Title, PublicationYear);
    }
}
