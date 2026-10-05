namespace Part2_HotelReservation
{
    internal class Room
    {
        public int RoomNumber { get; }
        public string Type { get; }
        public decimal NightlyRate { get; private set; }

        public bool IsUnderMaintenance { get; private set; }


        public Room(int roomNumber, string type, decimal nightlyRate)
        {
            if (roomNumber <= 0)
                throw new ArgumentOutOfRangeException(nameof(roomNumber));

            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Room type can not be empty", nameof(type));

            if (nightlyRate <= 0)
                throw new ArgumentOutOfRangeException(nameof(nightlyRate));

            RoomNumber = roomNumber;
            Type = type;
            NightlyRate = nightlyRate;
        }

        public void ChangePrice(decimal nightlyRate)
        {
            if (nightlyRate <= 0)
                throw new ArgumentOutOfRangeException(nameof(nightlyRate));

            NightlyRate = nightlyRate;
        }


        //--------------------------------------------------

        public void StartMaintenance()
        {
            IsUnderMaintenance = true;
        }

        public void EndMaintenance()
        {
            IsUnderMaintenance = false;
        }
    }
}