using System;

namespace Strings;

public static class Interpolation
{
    public static string GetHelloGreeting(string name)
    {
        return $"Hello, {name}!";
    }

    public static string GetGreeting(string greeting, string name)
    {
        return $"{greeting}, {name}!";
    }

    public static string GetSquareNumber(int i)
    {
        return $"The square number of {i} is {i * i}.";
    }

    public static string GetTotalPrice(double price, int items, double discount)
    {
        return $"The price of all items is {price * items * discount}.";
    }

    public static string GetSequenceOfNumbers(int[] numbers)
    {
        return $"The sequence is {{{string.Join(',', numbers)}}}.";
    }

    public static string GetSequenceOfNumbersLength(string sequence)
    {
        int length = string.IsNullOrEmpty(sequence) ? 0 : sequence.Split(',').Length;
        return $"The sequence length is {length}.";
    }

    public static string GetDocumentPath(string username, string filename, string extension)
    {
        return $@"c:\users\{username}\Documents\{filename}.{extension}";
    }

    public static string GetNetworkPath(string workstation, string userFolder, string filename, string extension)
    {
        return $@"\\{workstation}\users\{userFolder}\{filename}.{extension}";
    }
}
