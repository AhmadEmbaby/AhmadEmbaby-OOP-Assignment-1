namespace Part2_HotelReservation
{
    internal class Guest
    {
        public int GuestId { get; }
        public string FullName { get; }
        public string PhoneNumber { get; }

        private List<Reservation> _reservations = [];

        public IReadOnlyList<Reservation> Reservations => _reservations;


        public Guest(int guestId, string fullName, string phoneNumber)
        {
            if (guestId < 0)
                throw new ArgumentOutOfRangeException(nameof(guestId));

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name can not be empty", nameof(fullName));

            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number can not be empty", nameof(phoneNumber));

            GuestId = guestId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }


        //--------------------------------------------------

        public void AddReservation(Reservation reservation)
        {
            if (reservation is null)
                throw new ArgumentNullException(nameof(reservation));

            _reservations.Add(reservation);
        }
    }
}