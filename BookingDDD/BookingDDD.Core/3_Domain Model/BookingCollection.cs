namespace BookingDDD.Core._3_Domain_Model
{
    // Domain helper for overlap checks across existing bookings.
    internal class BookingCollection
    {
        private readonly IEnumerable<Booking> _bookings;

        public BookingCollection(IEnumerable<Booking> bookings)
        {
            _bookings = bookings;
        }

        public bool IsOverlapping(BookingPeriod bookingPeriod)
        {
            // Only active bookings can block a new booking.
            return _bookings
                .Where(booking => booking.IsActive)
                .Any(bookingPeriod.IsOverlapping);

            /*
               foreach (var booking in _bookings)
               {
                   var overlaps = bookingPeriod.IsOverlapping(booking);

                   if (overlaps)
                   {
                       return true;
                   }
               }

               return false;
             */
        }

        public Result<Booking> Book(BookingPeriod period)
        {
            // Domain-level guard against double-booking.
            if (IsOverlapping(period))
            {
                return Result<Booking>.Fail("Booking overlaps with an existing booking.");
            }

            var booking = new Booking(period);
            return Result<Booking>.Success(booking);
        }
    }
}