using System;
using System.Globalization;

namespace BookStoreCatalog;

public class BookPrice
{
    private decimal amount;
    private string currency;

    public BookPrice()
        : this(0m, "USD")
    {
    }

    public BookPrice(decimal amount, string currency)
    {
        ThrowExceptionIfAmountIsNotValid(amount, nameof(amount));
        ThrowExceptionIfCurrencyIsNotValid(currency, nameof(currency));

        this.amount = amount;
        this.currency = currency;
    }

    public decimal Amount
    {
        get => this.amount;
        set
        {
            ThrowExceptionIfAmountIsNotValid(value, nameof(value));
            this.amount = value;
        }
    }

    public string Currency
    {
        get => this.currency;
        set
        {
            ThrowExceptionIfCurrencyIsNotValid(value, nameof(value));
            this.currency = value;
        }
    }

    public override string ToString()
    {
        return $"{this.Amount.ToString("N2", CultureInfo.InvariantCulture)} {this.Currency}";
    }

    private static void ThrowExceptionIfAmountIsNotValid(decimal amount, string parameterName)
    {
        if (amount < 0)
        {
            throw new ArgumentException("amount cannot be less than zero.", parameterName);
        }
    }

    private static void ThrowExceptionIfCurrencyIsNotValid(string currency, string parameterName)
    {
        if (currency is null)
        {
            throw new ArgumentNullException(parameterName);
        }

        if (currency.Length != 3)
        {
            throw new ArgumentException("Currency must have exactly 3 characters.", parameterName);
        }

        foreach (char c in currency)
        {
            if (!char.IsLetter(c))
            {
                throw new ArgumentException("Currency must contain only letters.", parameterName);
            }
        }
    }
}
