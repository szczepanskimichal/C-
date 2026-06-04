namespace BookingDDD.Core._3_Domain_Model;

// Resource enforces booking policies: opening hours and overlap prevention.
public sealed class Resource
{
    public Guid Id { get; }
    public OpeningHours OpeningHours { get; }
    private readonly List<Booking> _bookings;

    public Resource(Guid id, OpeningHours openingHours, IEnumerable<Booking> bookings)
    {
        Id = id;
        OpeningHours = openingHours;
        _bookings = bookings.ToList();
    }

    public Result<Booking> Book(BookingPeriod period)
    {
        // Resource-level policy: period must fit opening hours.
        if (!OpeningHours.Contains(period))
        {
            return Result<Booking>.Fail("Booking must be within opening hours.");
        }

        // Resource-level policy: no overlap with other active bookings.
        if (_bookings.Any(booking => booking.IsActive & booking.IsOverlapping(period)))
        {
            return Result<Booking>.Fail("Booking overlaps with an existing booking.");
        }

        var booking = new Booking(period);
        _bookings.Add(booking);

        return Result<Booking>.Success(booking);
    }
}

