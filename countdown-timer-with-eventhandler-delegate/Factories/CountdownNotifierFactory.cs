using System;
using CountdownTimer.Implementation;
using CountdownTimer.Interfaces;

namespace CountdownTimer.Factories;

public class CountdownNotifierFactory
{
    /// <summary>
    /// Create an object of the class that implements the <see cref="ICountdownNotifier"/> interface.
    /// </summary>
    /// <param name="timer">A reference to a class CustomTimer.</param>
    /// <returns>A reference to an object of the class that implements the <see cref="ICountdownNotifier"/> interface.</returns>
    /// <exception cref="ArgumentNullException">When timer is null.</exception>
    public ICountdownNotifier CreateNotifierForTimer(Timer? timer)
    {
        ArgumentNullException.ThrowIfNull(timer);
        return new CountdownNotifier(timer);
    }
}
