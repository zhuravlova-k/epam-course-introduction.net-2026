using System;

namespace Strings;

public static class Manipulations
{
    public static string GetHelloGreeting1(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        const string template = "Hello, !";
        return template.Insert(7, name);
    }

    public static string GetGreeting1(string greeting, string name)
    {
        ArgumentNullException.ThrowIfNull(greeting);
        ArgumentNullException.ThrowIfNull(name);
        return $"{greeting}, {name.ToUpperInvariant()}!";
    }

    public static string GetHelloGreeting2(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        const string template = "Hello, !";
        return template.Insert(7, name.Trim());
    }

    public static string GetGreeting2(string greeting, string name)
    {
        ArgumentNullException.ThrowIfNull(greeting);
        ArgumentNullException.ThrowIfNull(name);
        return $"{greeting.Trim()}, {name.Trim().ToLowerInvariant()}!";
    }

    public static string GetHelloGreeting3(string template, string name)
    {
        ArgumentNullException.ThrowIfNull(template);
        ArgumentNullException.ThrowIfNull(name);
        return template.Replace("{name}", name, StringComparison.InvariantCulture);
    }

    public static string GetGreeting3(string template, string greeting, string name)
    {
        ArgumentNullException.ThrowIfNull(template);
        ArgumentNullException.ThrowIfNull(greeting);
        ArgumentNullException.ThrowIfNull(name);

        string greetingLower = greeting.ToLowerInvariant();
        string tempResult = template.Replace("{greeting}", greetingLower, StringComparison.InvariantCulture);

        string nameUpper = name.ToUpperInvariant();
        string finalResult = tempResult.Replace("{name}", nameUpper, StringComparison.InvariantCulture);

        return finalResult;
    }

    public static string GetRefinedCode(string code)
    {
        ArgumentNullException.ThrowIfNull(code);
        return code.Remove(3, 3);
    }

    public static string GetRefinedDate(string date)
    {
        ArgumentNullException.ThrowIfNull(date);
        return date.Remove(5, 1).Remove(2, 1);
    }
}
