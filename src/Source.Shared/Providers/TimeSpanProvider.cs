using Source.Shared.Common.Enums;

namespace Source.Shared.Providers;
public interface ITimeSpanProvider
{
    TimeSpan TwentyFourHours { get; }
    TimeSpan TwelveHours { get; }

    /// <summary>
    /// Calculate time until the next desired execution
    /// </summary>
    /// <param name="desiredTime"></param>
    /// <returns>timespan</returns>
    TimeSpan CalculateTimeUntilNextExecution(TimeSpan desiredTime);
    TimeSpan Create(int numberPeriod, DateTimeIntervalEnum interval);
}

public class TimeSpanProvider
{
    public TimeSpan TwentyFourHours => TimeSpan.FromHours(24);
    public TimeSpan TwelveHours => TimeSpan.FromHours(12);

    public TimeSpan CalculateTimeUntilNextExecution(TimeSpan desiredTime)
    {
        DateTime now = DateTime.Now;
        DateTime desiredDateTime = now.Date.Add(desiredTime);

        // If the desired time has already passed today, set it for tomorrow
        if (now > desiredDateTime)
        {
            desiredDateTime = desiredDateTime.AddDays(1);
        }

        return desiredDateTime - now;
    }

    public TimeSpan Create(int numberPeriod, DateTimeIntervalEnum interval)
        => interval switch
        {
            DateTimeIntervalEnum.Year => TimeSpan.FromDays(numberPeriod * 365.25), // Approximating a year as 365.25 days
            DateTimeIntervalEnum.Month => TimeSpan.FromDays(numberPeriod * 30.436875), // Approximate a month as 30.436875 days (average number of days in a month over a year)
            DateTimeIntervalEnum.Hour => TimeSpan.FromHours(numberPeriod),
            DateTimeIntervalEnum.Minute => TimeSpan.FromMinutes(numberPeriod),
            DateTimeIntervalEnum.Second => TimeSpan.FromSeconds(numberPeriod),
            DateTimeIntervalEnum.Millisecond => TimeSpan.FromMilliseconds(numberPeriod),
            DateTimeIntervalEnum.Day or _ => TimeSpan.FromDays(numberPeriod)
        };
}
