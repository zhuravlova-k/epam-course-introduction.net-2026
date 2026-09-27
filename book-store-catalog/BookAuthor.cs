using System;

namespace BookStoreCatalog;

public class BookAuthor
{
    public BookAuthor(string authorName)
    {
        ArgumentNullException.ThrowIfNull(authorName);

        if (string.IsNullOrWhiteSpace(authorName))
        {
            throw new ArgumentException("Author name cannot be empty or consist of white-space only.", nameof(authorName));
        }

        this.AuthorName = authorName;
        this.HasIsni = false;
    }

    public BookAuthor(string authorName, string isniCode)
        : this(authorName, isniCode is null ? throw new ArgumentNullException(nameof(isniCode)) : new NameIdentifier(isniCode))
    {
    }

    public BookAuthor(string authorName, NameIdentifier nameIdentifier)
        : this(authorName)
    {
        if (nameIdentifier is not null)
        {
            this.Isni = nameIdentifier;
            this.HasIsni = true;
        }
        else
        {
            throw new ArgumentNullException(nameof(nameIdentifier));
        }
    }

    public string AuthorName { get; private set; }

    public bool HasIsni { get; private set; }

    public NameIdentifier Isni { get; private set; } = null!;

    public override string ToString()
    {
        if (this.HasIsni)
        {
            return $"{this.AuthorName} (ISNI:{this.Isni.Code})";
        }

        return this.AuthorName;
    }
}
