namespace CreatingMethods;

public static class MethodsWithTuples
{
    public static (bool trueValue, bool falseValue) ReturnBoolValues() => (true, false);

    public static (char lowerCaseA, char upperCaseA) ReturnCharValues() => ('a', 'A');

    public static (float minFloatValue, float maxFloatValue) ReturnFloatValues() => (float.MinValue, float.MaxValue);

    public static (int minIntValue, int maxIntValue) ReturnIntValues() => (int.MinValue, int.MaxValue);

    public static (long minLongValue, long maxLongValue) ReturnLongValues() => (long.MinValue, long.MaxValue);

    public static (string stringValue, int length) ReturnStringAndLength(string input)
    {
        ArgumentNullException.ThrowIfNull(input);
        return (input, input.Length);
    }

    public static (DateTime date, DayOfWeek dayOfWeek) ReturnDateAndDay(DateTime date) => (date, date.DayOfWeek);
}
