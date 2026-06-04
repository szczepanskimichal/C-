namespace BookingDDD.Core._3_Domain_Model;

// Value object describing when bookings are allowed for a resource.
public sealed record OpeningHours
{
    public int OpensAtHour { get; }
    public int ClosesAtHour { get; }

    public OpeningHours(int opensAtHour, int closesAtHour)
    {
        OpensAtHour = opensAtHour;
        ClosesAtHour = closesAtHour;
    }

    // Business rule owned by the resource context, not by BookingPeriod itself.
    public bool Contains(BookingPeriod period) =>
        period.Start.Hour >= OpensAtHour && period.End.Hour <= ClosesAtHour;
}

