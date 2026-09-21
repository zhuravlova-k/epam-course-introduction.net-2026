using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace BookStoreItem;

/// <summary>
/// Represents an item in a book store.
/// </summary>
public class BookStoreItem
{
    private readonly string authorName;
    private readonly string? isni;
    private readonly bool hasIsni;
    private decimal price;
    private string currency;
    private int amount;

    /// <summary>
    /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>.
    /// </summary>
    /// <param name="authorName">A book author's name.</param>
    /// <param name="title">A book title.</param>
    /// <param name="publisher">A book publisher.</param>
    /// <param name="isbn">A book ISBN.</param>
    public BookStoreItem(string authorName, string title, string publisher, string isbn)
        : this(authorName, null, title, publisher, isbn, null, string.Empty, 0m, "USD", 0)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="isni"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>.
    /// </summary>
    /// <param name="authorName">A book author's name.</param>
    /// <param name="isni">A book author's ISNI.</param>
    /// <param name="title">A book title.</param>
    /// <param name="publisher">A book publisher.</param>
    /// <param name="isbn">A book ISBN.</param>
    public BookStoreItem(string authorName, string? isni, string title, string publisher, string isbn)
        : this(authorName, isni, title, publisher, isbn, null, string.Empty, 0m, "USD", 0)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>, <paramref name="published"/>, <paramref name="bookBinding"/>, <paramref name="price"/>, <paramref name="currency"/> and <paramref name="amount"/>.
    /// </summary>
    /// <param name="authorName">A book author's name.</param>
    /// <param name="title">A book title.</param>
    /// <param name="publisher">A book publisher.</param>
    /// <param name="isbn">A book ISBN.</param>
    /// <param name="published">A book publishing date.</param>
    /// <param name="bookBinding">A book binding type.</param>
    /// <param name="price">An amount of money that a book costs.</param>
    /// <param name="currency">A price currency.</param>
    /// <param name="amount">An amount of books in the store's stock.</param>
    [SuppressMessage("Major Code Smell", "S107:Methods should not have too many parameters", Justification = "Required by task specification.")]
    public BookStoreItem(string authorName, string title, string publisher, string isbn, DateTime? published, string bookBinding = "", decimal price = 0m, string currency = "USD", int amount = 0)
        : this(authorName, null, title, publisher, isbn, published, bookBinding, price, currency, amount)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="isni"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>, <paramref name="published"/>, <paramref name="bookBinding"/>, <paramref name="price"/>, <paramref name="currency"/> and <paramref name="amount"/>.
    /// </summary>
    /// <param name="authorName">A book author's name.</param>
    /// <param name="isni">A book author's ISNI.</param>
    /// <param name="title">A book title.</param>
    /// <param name="publisher">A book publisher.</param>
    /// <param name="isbn">A book ISBN.</param>
    /// <param name="published">A book publishing date.</param>
    /// <param name="bookBinding">A book binding type.</param>
    /// <param name="price">An amount of money that a book costs.</param>
    /// <param name="currency">A price currency.</param>
    /// <param name="amount">An amount of books in the store's stock.</param>
    [SuppressMessage("Major Code Smell", "S107:Methods should not have too many parameters", Justification = "Required by task specification.")]
    public BookStoreItem(string authorName, string? isni, string title, string publisher, string isbn, DateTime? published, string bookBinding = "", decimal price = 0m, string currency = "USD", int amount = 0)
    {
        if (string.IsNullOrWhiteSpace(authorName) || !authorName.Any(char.IsLetter))
        {
            throw new ArgumentException("Author name is invalid.", nameof(authorName));
        }

        if (string.IsNullOrWhiteSpace(title) || !title.Any(char.IsLetter))
        {
            throw new ArgumentException("Title is invalid.", nameof(title));
        }

        if (string.IsNullOrWhiteSpace(publisher) || !publisher.Any(char.IsLetter))
        {
            throw new ArgumentException("Publisher is invalid.", nameof(publisher));
        }

        if (isni != null)
        {
            if (!ValidateIsni(isni))
            {
                throw new ArgumentException("Invalid ISNI.", nameof(isni));
            }

            this.isni = isni;
            this.hasIsni = true;
        }
        else
        {
            this.isni = null;
            this.hasIsni = false;
        }

        if (!ValidateIsbnFormat(isbn) || !ValidateIsbnChecksum(isbn))
        {
            throw new ArgumentException("Invalid ISBN.", nameof(isbn));
        }

        ThrowExceptionIfCurrencyIsNotValid(currency);

        ArgumentOutOfRangeException.ThrowIfNegative(price);

        if (amount >= 0)
        {
            this.authorName = authorName;
            this.Title = title;
            this.Publisher = publisher;
            this.Isbn = isbn;
            this.Published = published;
            this.BookBinding = bookBinding ?? string.Empty;
            this.price = price;
            this.currency = currency;
            this.amount = amount;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(amount));
        }
    }

    /// <summary>
    /// Gets a book author's name.
    /// </summary>
    public string AuthorName => this.authorName;

    /// <summary>
    /// Gets an International Standard Name Identifier (ISNI) that uniquely identifies a book author.
    /// </summary>
    public string? Isni => this.isni;

    /// <summary>
    /// Gets a value indicating whether an author has an International Standard Name Identifier (ISNI).
    /// </summary>
    public bool HasIsni => this.hasIsni;

    /// <summary>
    /// Gets a book title.
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// Gets a book publisher.
    /// </summary>
    public string Publisher { get; private set; }

    /// <summary>
    /// Gets a book International Standard Book Number (ISBN).
    /// </summary>
    public string Isbn { get; private set; }

    /// <summary>
    /// Gets or sets a book publishing date.
    /// </summary>
    public DateTime? Published { get; set; }

    /// <summary>
    /// Gets or sets a book binding type.
    /// </summary>
    public string BookBinding { get; set; }

    /// <summary>
    /// Gets or sets an amount of money that a book costs.
    /// </summary>
    public decimal Price
    {
        get => this.price;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Price cannot be less than zero.");
            }

            this.price = value;
        }
    }

    /// <summary>
    /// Gets or sets a price currency.
    /// </summary>
    public string Currency
    {
        get => this.currency;
        set
        {
            ThrowExceptionIfCurrencyIsNotValid(value);
            this.currency = value;
        }
    }

    /// <summary>
    /// Gets or sets an amount of books in the store's stock.
    /// </summary>
    public int Amount
    {
        get => this.amount;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Amount cannot be less than zero.");
            }

            this.amount = value;
        }
    }

    /// <summary>
    /// Gets a <see cref="Uri"/> to the contributor's page at the isni.org website.
    /// </summary>
    /// <returns>A <see cref="Uri"/> to the contributor's page at the isni.org website.</returns>
    public Uri GetIsniUri()
    {
        if (!this.HasIsni)
        {
            throw new InvalidOperationException("ISNI is not set.");
        }

        return new Uri($"https://isni.org/isni/{this.Isni}");
    }

    /// <summary>
    /// Gets an <see cref="Uri"/> to the publication page on the isbnsearch.org website.
    /// </summary>
    /// <returns>an <see cref="Uri"/> to the publication page on the isbnsearch.org website.</returns>
    public Uri GetIsbnSearchUri()
    {
        return new Uri($"https://isbnsearch.org/isbn/{this.Isbn}");
    }

    /// <summary>
    /// Returns the string that represents a current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        string priceFormatted = this.Price.ToString("N2", CultureInfo.InvariantCulture);
        string priceAndCurrency = $"{priceFormatted} {this.Currency}";

        if (priceAndCurrency.Contains(',', StringComparison.Ordinal))
        {
            priceAndCurrency = $"\"{priceAndCurrency}\"";
        }

        string isniString = this.HasIsni ? this.Isni! : "ISNI IS NOT SET";

        return $"{this.Title}, {this.AuthorName}, {isniString}, {priceAndCurrency}, {this.Amount}";
    }

    private static bool ValidateIsni(string isni)
    {
        if (string.IsNullOrEmpty(isni) || isni.Length != 16)
        {
            return false;
        }

        foreach (char c in isni)
        {
            if (!char.IsDigit(c) && c != 'X')
            {
                return false;
            }
        }

        return true;
    }

    private static bool ValidateIsbnFormat(string isbn)
    {
        if (string.IsNullOrEmpty(isbn) || isbn.Length != 10)
        {
            return false;
        }

        foreach (char c in isbn)
        {
            if (!char.IsDigit(c) && c != 'X')
            {
                return false;
            }
        }

        return true;
    }

    private static bool ValidateIsbnChecksum(string isbn)
    {
        if (!ValidateIsbnFormat(isbn))
        {
            return false;
        }

        int sum = 0;
        for (int i = 0; i < 10; i++)
        {
            int value = isbn[i] == 'X' ? 10 : (isbn[i] - '0');
            sum += value * (11 - (i + 1));
        }

        return sum % 11 == 0;
    }

    private static void ThrowExceptionIfCurrencyIsNotValid(string currency)
    {
        if (string.IsNullOrEmpty(currency) || currency.Length != 3 || !currency.All(char.IsLetter))
        {
            throw new ArgumentException("Currency is not valid.", nameof(currency));
        }
    }
}
