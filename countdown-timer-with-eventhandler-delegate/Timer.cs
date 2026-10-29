using System;
using System.Threading;
using CountdownTimer.EventArgsClasses;

namespace CountdownTimer;

public class Timer
{
    private readonly string timerName;
    private readonly int ticks;
    
    public Timer(string timerName, int ticks)
    {
        if (string.IsNullOrEmpty(timerName))
        {
            throw new ArgumentException("Timer name cannot be null or empty.", nameof(timerName));
        }

        if (ticks <= 0)
        {
            throw new ArgumentException("Ticks must be greater than zero.", nameof(ticks));
        }

        this.timerName = timerName;
        this.ticks = ticks;
    }

    public event EventHandler<StartedEventArgs>? Started;

    public event EventHandler<TickEventArgs>? Tick;

    public event EventHandler<StoppedEventArgs>? Stopped;

    public void Run()
    {
        this.Started?.Invoke(this, new StartedEventArgs(this.timerName, this.ticks));

        for (int i = this.ticks - 1; i >= 0; i--)
        {
            Thread.Sleep(10);
            this.Tick?.Invoke(this, new TickEventArgs(this.timerName, i));
        }

        this.Stopped?.Invoke(this, new StoppedEventArgs(this.timerName));
    }
}
