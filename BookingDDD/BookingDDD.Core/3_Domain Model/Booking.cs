namespace BookingDDD.Core._3_Domain_Model;

// Entity representing one reservation and its lifecycle rules.
public sealed class Booking
{
    public Guid Id { get; }
    // Booking now owns a value object instead of loose DateTime primitives.
    public BookingPeriod Period { get; }
    public BookingStatus Status { get; private set; }
    public bool IsActive => Status == BookingStatus.Active; 

    public Booking(BookingPeriod period)
        : this(Guid.NewGuid(), period)
    {
    }

    public Booking(Guid id, BookingPeriod period, BookingStatus status = BookingStatus.Active)
    {
        Id = id;
        Period = period;
        Status = status;
    }

    public bool IsValid() =>
        Id != Guid.Empty;

    public Result<Booking> Cancel(DateTime now)
    {
        // Domain invariant: booking cannot be cancelled after its start time.
        if (Period.HasStarted(now))
        {
            return Result<Booking>.Fail("Cannot cancel booking after it has started.");
        }

        Status = BookingStatus.Cancelled;
        return Result<Booking>.Success(this);
    }

    public bool IsOverlapping(Booking otherBooking)
    {
        return IsOverlapping(otherBooking.Period);
    }
    public bool IsOverlapping(BookingPeriod otherPeriod)
    {
        return Period.IsOverlapping(otherPeriod);
    }
}
