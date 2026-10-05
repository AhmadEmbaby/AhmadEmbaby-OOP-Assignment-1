namespace Part2_HotelReservation
{
    internal class Program
    {
        static void Main(string[] args)
        {


            HotelSystem hotelSystem = new();


            Menu menu = new(hotelSystem);


            menu.Run();



        }


    }
}