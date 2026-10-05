namespace Part2_HotelReservation
{
    internal class Reservation
    {
        public int Id { get; }
        public DateTime CheckIn { get; }
        public DateTime CheckOut { get; }

        public Room Room { get; }
        public Guest Guest { get; }

        public string Status { get; private set; }


        public Reservation(
            int id,
            Guest guest,
            Room room,
            DateTime checkIn,
            DateTime checkOut)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            if (guest is null)
                throw new ArgumentNullException(nameof(guest));

            if (room is null)
                throw new ArgumentNullException(nameof(room));

            if (checkOut <= checkIn)
                throw new ArgumentException("Check out must be after check in");

            if (room.IsUnderMaintenance)
                throw new InvalidOperationException("Room is under maintenance");

            Id = id;
            Guest = guest;
            Room = room;
            CheckIn = checkIn;
            CheckOut = checkOut;

            Status = "Pending";
        }


        //--------------------------------------------------

        public void Confirm()
        {
            if (Status != "Pending")
                throw new InvalidOperationException("Reservation can not be confirmed");

            Status = "Confirmed";
        }

        public void CheckInGuest()
        {
            if (Status != "Confirmed")
                throw new InvalidOperationException("Reservation must be confirmed first");

            Status = "CheckedIn";
        }

        public void CheckOutGuest()
        {
            if (Status != "CheckedIn")
                throw new InvalidOperationException("Guest must be checked in first");

            Status = "CheckedOut";
        }

        public void Cancel()
        {
            if (Status != "Pending" && Status != "Confirmed")
                throw new InvalidOperationException("Reservation can not be cancelled");

            Status = "Cancelled";
        }


        public int CalculateNights()
        {
            return (CheckOut - CheckIn).Days;
        }

        public decimal CalculateTotalCost()
        {
            return CalculateNights() * Room.NightlyRate;
        }
    }
}