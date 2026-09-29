using System;
using System.Globalization;

namespace BookStoreCatalog;

public class BookPublication
{
    public BookPublication(string authorName, string title, string publisher, DateTime published, BookBindingKind bookBinding, string isbnCode)
        : this(new BookAuthor(authorName), title, publisher, published, bookBinding, new BookNumber(isbnCode))
    {
    }

    public BookPublication(string authorName, string isniCode, string title, string publisher, DateTime published, BookBindingKind bookBinding, string isbnCode)
        : this(new BookAuthor(authorName, isniCode), title, publisher, published, bookBinding, new BookNumber(isbnCode))
    {
    }

    public BookPublication(BookAuthor author, string title, string publisher, DateTime published, BookBindingKind bookBinding, BookNumber isbn)
    {
        ArgumentNullException.ThrowIfNull(author);
        ArgumentNullException.ThrowIfNull(title);
        ArgumentNullException.ThrowIfNull(publisher);
        ArgumentNullException.ThrowIfNull(isbn);

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title cannot be empty or consist of white-space only.", nameof(title));
        }

        if (string.IsNullOrWhiteSpace(publisher))
        {
            throw new ArgumentException("Publisher cannot be empty or consist of white-space only.", nameof(publisher));
        }

        this.Author = author;
        this.Title = title;
        this.Publisher = publisher;
        this.Published = published;
        this.BookBinding = bookBinding;
        this.Isbn = isbn;
    }

    public BookAuthor Author { get; init; } = null!;

    public string Title { get; init; } = null!;

    public string Publisher { get; init; } = null!;

    public DateTime Published { get; init; }

    public BookBindingKind BookBinding { get; init; }

    public BookNumber Isbn { get; init; } = null!;

    public string GetPublicationDateString()
    {
        return this.Published.ToString("MMMM, yyyy", CultureInfo.InvariantCulture);
    }

    public override string ToString()
    {
        return $"{this.Title} by {this.Author.AuthorName}";
    }
}
