using BookingDDD.Core._3_Domain_Model;

namespace BookingDDD.Core._2_DomainServices;

// Repository contract for loading and saving bookings.
public interface IBookingRepository
{
    // Persistence contract used by the application layer.
    Task<List<Booking>> GetAllAsync();
    Task<Booking?> GetAsync(Guid bookingId);
    Task AddAsync(Booking booking);
    Task UpdateAsync(Booking booking);
}