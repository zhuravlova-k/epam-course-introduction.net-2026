using System;
using CountdownTimer.EventArgsClasses;
using CountdownTimer.Interfaces;

namespace CountdownTimer.Implementation;

/// <inheritdoc/>
public class CountdownNotifier : ICountdownNotifier
{
    private readonly Timer timer;

    public CountdownNotifier(Timer timer)
    {
        ArgumentNullException.ThrowIfNull(timer);
        this.timer = timer;
    }

    /// <inheritdoc/>
    public void Init(EventHandler<StartedEventArgs>? startHandler, EventHandler<StoppedEventArgs>? stopHandler, EventHandler<TickEventArgs>? tickHandler)
    {
        if (startHandler != null)
        {
            this.timer.Started += startHandler;
        }

        if (stopHandler != null)
        {
            this.timer.Stopped += stopHandler;
        }

        if (tickHandler != null)
        {
            this.timer.Tick += tickHandler;
        }
    }

    /// <inheritdoc/>
    public void Run()
    {
        this.timer.Run();
    }
}
