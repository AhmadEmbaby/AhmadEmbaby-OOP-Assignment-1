namespace Part2_HotelReservation
{
    internal class HotelSystem
    {
        public List<Guest> GuestsList { get; } = [];
        public List<Room> RoomsList { get; } = [];
        public List<Reservation> ReservationsList { get; } = [];


        public void AddGuest(Guest guest)
        {
            foreach (var existingGuest in GuestsList)
            {
                if (existingGuest.GuestId == guest.GuestId)
                    throw new InvalidOperationException("Guest Id already exists");
            }

            GuestsList.Add(guest);
        }


        public void AddRoom(Room room)
        {
            foreach (var existingRoom in RoomsList)
            {
                if (existingRoom.RoomNumber == room.RoomNumber)
                    throw new InvalidOperationException("Room number already exists");
            }

            RoomsList.Add(room);
        }


        //--------------------------------------------------

        public Guest? FindGuestById(int id)
        {
            foreach (var guest in GuestsList)
            {
                if (guest.GuestId == id)
                    return guest;
            }

            return null;
        }

        public Room? FindRoomByNumber(int roomNumber)
        {
            foreach (var room in RoomsList)
            {
                if (room.RoomNumber == roomNumber)
                    return room;
            }

            return null;
        }

        public Reservation? FindReservationById(int id)
        {
            foreach (var reservation in ReservationsList)
            {
                if (reservation.Id == id)
                    return reservation;
            }

            return null;
        }


        public void AddReservation(Reservation reservation)
        {
            foreach (var existingReservation in ReservationsList)
            {
                if (existingReservation.Id == reservation.Id)
                    throw new InvalidOperationException("Reservation Id already exists");
            }


            foreach (var existingReservation in ReservationsList)
            {
                if (existingReservation.Room.RoomNumber != reservation.Room.RoomNumber)
                    continue;

                if (existingReservation.Status == "Cancelled" ||
                    existingReservation.Status == "CheckedOut")
                    continue;

                if (reservation.CheckIn < existingReservation.CheckOut &&
                    reservation.CheckOut > existingReservation.CheckIn)
                {
                    throw new InvalidOperationException(
                        "Room is already booked for these dates");
                }
            }

            ReservationsList.Add(reservation);

            reservation.Guest.AddReservation(reservation);
        }


        //--------------------------------------------------

        public void PrintGuests()
        {
            if (GuestsList.Count == 0)
            {
                Console.WriteLine("Guests list is empty");
                return;
            }

            foreach (var guest in GuestsList)
            {
                Console.WriteLine(
                    $"ID: {guest.GuestId}, Name: {guest.FullName}, Phone: {guest.PhoneNumber}");
            }
        }

        public void PrintRooms()
        {
            if (RoomsList.Count == 0)
            {
                Console.WriteLine("Rooms list is empty");
                return;
            }

            foreach (var room in RoomsList)
            {
                Console.WriteLine(
                    $"Room: {room.RoomNumber}, Type: {room.Type}, Price: {room.NightlyRate}, Maintenance: {room.IsUnderMaintenance}");
            }
        }

        public void PrintReservations()
        {
            if (ReservationsList.Count == 0)
            {
                Console.WriteLine("Reservations list is empty");
                return;
            }

            foreach (var reservation in ReservationsList)
            {
                Console.WriteLine(
                    $"ID: {reservation.Id}, Guest: {reservation.Guest.FullName}, Room: {reservation.Room.RoomNumber}, Status: {reservation.Status}, Total: {reservation.CalculateTotalCost()}");
            }
        }
    }
}   