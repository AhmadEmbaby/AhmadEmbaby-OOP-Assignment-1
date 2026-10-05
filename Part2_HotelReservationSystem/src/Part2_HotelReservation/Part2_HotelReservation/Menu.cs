namespace Part2_HotelReservation
{
    internal class Menu
    {
        private readonly HotelSystem _hotelSystem;

        public Menu(HotelSystem hotelSystem)
        {
            _hotelSystem = hotelSystem;
        }


        //--------------------------------------------------

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n1. Add Guest");
                Console.WriteLine("2. Add Room");
                Console.WriteLine("3. Create Reservation");
                Console.WriteLine("4. Confirm Reservation");
                Console.WriteLine("5. Check In");
                Console.WriteLine("6. Check Out");
                Console.WriteLine("7. Cancel Reservation");
                Console.WriteLine("8. Start Room Maintenance");
                Console.WriteLine("9. End Room Maintenance");
                Console.WriteLine("10. Print Guests");
                Console.WriteLine("11. Print Rooms");
                Console.WriteLine("12. Print Reservations");
                Console.WriteLine("13. Exit\n");

                Console.Write("Choose: ");

                string? choice = Console.ReadLine();

                try
                {
                    if (choice == "1")
                    {
                        AddGuest();
                    }
                    else if (choice == "2")
                    {
                        AddRoom();
                    }
                    else if (choice == "3")
                    {
                        CreateReservation();
                    }
                    else if (choice == "4")
                    {
                        ConfirmReservation();
                    }
                    else if (choice == "5")
                    {
                        CheckIn();
                    }
                    else if (choice == "6")
                    {
                        CheckOut();
                    }
                    else if (choice == "7")
                    {
                        CancelReservation();
                    }
                    else if (choice == "8")
                    {
                        StartMaintenance();
                    }
                    else if (choice == "9")
                    {
                        EndMaintenance();
                    }
                    else if (choice == "10")
                    {
                        _hotelSystem.PrintGuests();
                    }
                    else if (choice == "11")
                    {
                        _hotelSystem.PrintRooms();
                    }
                    else if (choice == "12")
                    {
                        _hotelSystem.PrintReservations();
                    }
                    else if (choice == "13")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        private void AddGuest()
        {
            Console.Write("Guest Id: ");
            int id = int.Parse(Console.ReadLine()!);

            Console.Write("Full Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Phone Number: ");
            string phone = Console.ReadLine()!;

            Guest guest = new(id, name, phone);

            _hotelSystem.AddGuest(guest);

            Console.WriteLine("Guest added");
        }


        private void AddRoom()
        {
            Console.Write("Room Number: ");
            int number = int.Parse(Console.ReadLine()!);

            Console.Write("Room Type: ");
            string type = Console.ReadLine()!;

            Console.Write("Nightly Rate: ");
            decimal rate = decimal.Parse(Console.ReadLine()!);

            Room room = new(number, type, rate);

            _hotelSystem.AddRoom(room);

            Console.WriteLine("Room added");
        }


        //--------------------------------------------------

        private void CreateReservation()
        {
            Console.Write("Reservation Id: ");
            int id = int.Parse(Console.ReadLine()!);

            Console.Write("Guest Id: ");
            int guestId = int.Parse(Console.ReadLine()!);

            Console.Write("Room Number: ");
            int roomNumber = int.Parse(Console.ReadLine()!);

            Console.Write("Check In: ");
            DateTime checkIn = DateTime.Parse(Console.ReadLine()!);

            Console.Write("Check Out: ");
            DateTime checkOut = DateTime.Parse(Console.ReadLine()!);

            Guest? guest = _hotelSystem.FindGuestById(guestId);
            Room? room = _hotelSystem.FindRoomByNumber(roomNumber);

            if (guest is null)
            {
                Console.WriteLine("Guest not found");
                return;
            }

            if (room is null)
            {
                Console.WriteLine("Room not found");
                return;
            }

            Reservation reservation =
                new(id, guest, room, checkIn, checkOut);

            _hotelSystem.AddReservation(reservation);

            Console.WriteLine("Reservation created");
        }


        private void ConfirmReservation()
        {
            Console.Write("Reservation Id: ");
            int id = int.Parse(Console.ReadLine()!);

            Reservation? reservation = _hotelSystem.FindReservationById(id);

            if (reservation is null)
            {
                Console.WriteLine("Reservation not found");
                return;
            }

            reservation.Confirm();

            Console.WriteLine("Reservation confirmed");
        }


        private void CheckIn()
        {
            Console.Write("Reservation Id: ");
            int id = int.Parse(Console.ReadLine()!);

            Reservation? reservation = _hotelSystem.FindReservationById(id);

            if (reservation is null)
            {
                Console.WriteLine("Reservation not found");
                return;
            }

            reservation.CheckInGuest();

            Console.WriteLine("Guest checked in");
        }


        //--------------------------------------------------

        private void CheckOut()
        {
            Console.Write("Reservation Id: ");
            int id = int.Parse(Console.ReadLine()!);

            Reservation? reservation = _hotelSystem.FindReservationById(id);

            if (reservation is null)
            {
                Console.WriteLine("Reservation not found");
                return;
            }

            reservation.CheckOutGuest();

            Console.WriteLine("Guest checked out");
        }


        private void CancelReservation()
        {
            Console.Write("Reservation Id: ");
            int id = int.Parse(Console.ReadLine()!);

            Reservation? reservation = _hotelSystem.FindReservationById(id);

            if (reservation is null)
            {
                Console.WriteLine("Reservation not found");
                return;
            }

            reservation.Cancel();

            Console.WriteLine("Reservation cancelled");
        }


        private void StartMaintenance()
        {
            Console.Write("Room Number: ");
            int roomNumber = int.Parse(Console.ReadLine()!);

            Room? room = _hotelSystem.FindRoomByNumber(roomNumber);

            if (room is null)
            {
                Console.WriteLine("Room not found");
                return;
            }

            room.StartMaintenance();

            Console.WriteLine("Maintenance started");
        }


        private void EndMaintenance()
        {
            Console.Write("Room Number: ");
            int roomNumber = int.Parse(Console.ReadLine()!);

            Room? room = _hotelSystem.FindRoomByNumber(roomNumber);

            if (room is null)
            {
                Console.WriteLine("Room not found");
                return;
            }

            room.EndMaintenance();

            Console.WriteLine("Maintenance ended");
        }
    }
}