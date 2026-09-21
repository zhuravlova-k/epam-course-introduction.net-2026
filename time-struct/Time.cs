using System;

namespace TimeStruct
{
    public readonly struct Time : IEquatable<Time>
    {
        public Time(int minutes)
            : this(0, minutes)
        {
        }

        public Time(int hours, int minutes)
        {
            int totalMinutes = (hours * 60) + minutes;

            this.Minutes = ((totalMinutes % 60) + 60) % 60;

            int totalHours = (int)Math.Floor(totalMinutes / 60.0);
            this.Hours = ((totalHours % 24) + 24) % 24;
        }

        public int Hours { get; }

        public int Minutes { get; }

        public static bool operator ==(Time left, Time right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Time left, Time right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"{this.Hours:D2}:{this.Minutes:D2}";
        }

        public void Deconstruct(out int hours, out int minutes)
        {
            hours = this.Hours;
            minutes = this.Minutes;
        }

        public bool Equals(Time other)
        {
            return this.Hours == other.Hours && this.Minutes == other.Minutes;
        }

        public override bool Equals(object? obj)
        {
            return obj is Time time && this.Equals(time);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Hours, this.Minutes);
        }
    }
}