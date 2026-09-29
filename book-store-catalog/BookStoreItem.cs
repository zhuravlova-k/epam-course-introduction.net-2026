using System;

namespace BookStoreCatalog;

public class BookStoreItem
{
    private BookPublication publication = null!;
    private BookPrice price = null!;
    private int amount;

    public BookStoreItem(string authorName, string isniCode, string title, string publisher, DateTime published, BookBindingKind bookBinding, string isbn, decimal priceAmount, string priceCurrency, int amount)
        : this(new BookPublication(authorName, isniCode, title, publisher, published, bookBinding, isbn), new BookPrice(priceAmount, priceCurrency), amount)
    {
    }

    public BookStoreItem(BookPublication publication, BookPrice price, int amount)
    {
        ArgumentNullException.ThrowIfNull(publication);
        ArgumentNullException.ThrowIfNull(price);

        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be less than zero.");
        }

        this.Publication = publication;
        this.Price = price;
        this.Amount = amount;
    }

    public BookPublication Publication
    {
        get => this.publication;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            this.publication = value;
        }
    }

    public BookPrice Price
    {
        get => this.price;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            this.price = value;
        }
    }

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

    public override string ToString()
    {
        string priceString = this.Price.ToString();

        if (priceString.Contains(',', StringComparison.Ordinal))
        {
            priceString = $"\"{priceString}\"";
        }

        return $"{this.Publication.Title} by {this.Publication.Author}, {priceString}, {this.Amount}";
    }
}
