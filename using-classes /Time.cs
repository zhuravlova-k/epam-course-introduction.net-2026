#pragma warning disable SA1633
#pragma warning disable SA1636
namespace UsingTimeClass;

public class Time
{
    public const int HoursInDay = 24;

    public const int MinutesInHour = 60;

    public const int SecondsInMinute = 60;

    public int Hours { get; set; }

    public int Minutes { get; set; }

    public int Seconds { get; set; }

    public Time(int hours, int minutes, int seconds)
    {
        if (hours is < 0 or > HoursInDay - 1)
        {
            throw new ArgumentOutOfRangeException(nameof(hours), $"Hours must be between 0 and {HoursInDay}.");
        }

        if (minutes is < 0 or > MinutesInHour - 1)
        {
            throw new ArgumentOutOfRangeException(nameof(minutes), $"Minutes must be between 0 and {MinutesInHour}.");
        }

        if (seconds is < 0 or > SecondsInMinute - 1)
        {
            throw new ArgumentOutOfRangeException(nameof(seconds), $"Seconds must be between 0 and {SecondsInMinute}.");
        }

        this.Hours = hours;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    /// <summary>
    /// Creates a new Time instance from the total number of seconds.
    /// </summary>
    /// <param name="totalSeconds">The total seconds to convert into a Time object.</param>
    /// <returns>A new Time object representing the time equivalent of the total seconds.</returns>
    public static Time FromTotalSeconds(int totalSeconds)
    {
        var (hours, minutes, seconds) = Normalize(totalSeconds);

        return new Time(hours, minutes, seconds);
    }

    public static int Compare(Time? t1, Time? t2)
    {
        ArgumentNullException.ThrowIfNull(t1);

        ArgumentNullException.ThrowIfNull(t2);

        var totalSeconds1 = (t1.Hours * MinutesInHour * SecondsInMinute) + (t1.Minutes * SecondsInMinute) + t1.Seconds;
        var totalSeconds2 = (t2.Hours * MinutesInHour * SecondsInMinute) + (t2.Minutes * SecondsInMinute) + t2.Seconds;

        if (totalSeconds1 > totalSeconds2)
        {
            return 1;
        }

        if (totalSeconds1 < totalSeconds2)
        {
            return -1;
        }

        return 0;
    }

    public override string ToString()
    {
        return $"{this.Hours:D2}:{this.Minutes:D2}:{this.Seconds:D2}";
    }

    public Time AddSeconds(int secondsToAdd)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(secondsToAdd);

        var totalSeconds = (this.Hours * MinutesInHour * SecondsInMinute) + (this.Minutes * SecondsInMinute) + this.Seconds + secondsToAdd;

        var (hours, minutes, seconds) = Normalize(totalSeconds);

        return new Time(hours, minutes, seconds);
    }

    public Time AddMinutes(int minutesToAdd)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(minutesToAdd);

        return this.AddSeconds(minutesToAdd * SecondsInMinute);
    }

    public Time AddHours(int hoursToAdd)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(hoursToAdd);

        return this.AddSeconds(hoursToAdd * MinutesInHour * SecondsInMinute);
    }

    private static (int hour, int minutes, int seconds) Normalize(int totalSeconds)
    {
        var hours = (totalSeconds / (MinutesInHour * SecondsInMinute)) % HoursInDay;
        var minutes = (totalSeconds / SecondsInMinute) % SecondsInMinute;
        var seconds = totalSeconds % SecondsInMinute;
        return (hours, minutes, seconds);
    }
}