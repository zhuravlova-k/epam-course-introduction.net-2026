#pragma warning disable SA1633
#pragma warning disable SA1636
namespace UsingTimeClass;

public class TimeManager
{
    private Time currentTime;

    public TimeManager(int hour, int minutes, int seconds)
    {
        this.currentTime = new Time(hour, minutes, seconds);
    }

    public static int GetHoursInDay()
    {
        return Time.HoursInDay;
    }

    public static int GetMinutesInHour()
    {
        return Time.MinutesInHour;
    }

    public static int GetSecondsInMinute()
    {
        return Time.SecondsInMinute;
    }

    public string GetCurrentTime()
    {
        return this.currentTime.ToString();
    }

    public void SetCurrentTime(int hours, int minutes, int seconds)
    {
        this.currentTime = new Time(hours, minutes, seconds);
    }

    public void AddSecondsToCurrentTime(int seconds)
    {
        this.currentTime = this.currentTime.AddSeconds(seconds);
    }

    public void AddMinutesToCurrentTime(int minutes)
    {
        this.currentTime = this.currentTime.AddMinutes(minutes);
    }

    public void AddHoursToCurrentTime(int hours)
    {
        this.currentTime = this.currentTime.AddHours(hours);
    }

    public int CompareTimes(Time otherTime)
    {
        return Time.Compare(this.currentTime, otherTime);
    }

    public void SetCurrentTimeFromTotalSeconds(int totalSeconds)
    {
        this.currentTime = Time.FromTotalSeconds(totalSeconds);
    }
}
