namespace BookingDDD.Core._3_Domain_Model;

// Value object describing a time range that can be booked.
public sealed record BookingPeriod
{
    public DateTime Start { get; }
    public DateTime End { get; }

    private BookingPeriod(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }
    public bool HasStarted(DateTime now)
        {
            return Start <= now;
        }

    public static Result<BookingPeriod> Create(DateTime start, DateTime end)
    {
        // Factory keeps period validation in one place.
        if (start >= end)
        {
            return Result<BookingPeriod>.Fail("Start must be before end.");
        }

        if (start.Minute != 0 || end.Minute != 0)
        {
            return Result<BookingPeriod>.Fail("Only whole hours can be booked.");
        }

        return Result<BookingPeriod>.Success(new BookingPeriod(start, end));
    }

    public bool IsOverlapping(BookingPeriod other) =>
        other.Start < End && other.End > Start;

    // Convenience overload used by collections/resources.
    public bool IsOverlapping(Booking booking) =>
        IsOverlapping(booking.Period);
}