using BookingDDD.Core._1_ApplicationServices;
using BookingDDD.Core._3_Domain_Model;
using BookingDDD.Core._2_DomainServices;

namespace BookingDDD.Test;

public class UnitTest1
{
    [Fact]
    public void Booking_IsValid_WhenDataIsCorrect()
    {
        var booking = new Booking(
            Guid.NewGuid(),
            "Jan Kowalski",
            new DateOnly(2026, 6, 1),
            new DateOnly(2026, 6, 2));

        Assert.True(booking.IsValid());
    }

    [Fact]
    public void ApplicationService_UsesDomainService()
    {
        var service = new BookingService(new BookingDomainService());
        var booking = new Booking(
            Guid.NewGuid(),
            "Jan Kowalski",
            new DateOnly(2026, 6, 1),
            new DateOnly(2026, 6, 2));

        Assert.True(service.CanCreate(booking));
    }
}
