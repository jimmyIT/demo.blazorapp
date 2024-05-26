namespace Source.Server.Application.Common.Provider;
public interface IDateTimeProvider
{
    DateTime Now();
    DateTime Today();
    DateTime UtcNow();
}

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now()
    {
        return DateTime.Now;
    }

    public DateTime Today()
    {
        return DateTime.Today;
    }

    public DateTime UtcNow()
    {
        return DateTime.UtcNow;
    }
}
