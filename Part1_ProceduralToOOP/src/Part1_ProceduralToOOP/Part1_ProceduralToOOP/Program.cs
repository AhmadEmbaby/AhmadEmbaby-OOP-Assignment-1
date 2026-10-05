namespace Part1_ProceduralToOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SystemData systemData = new();

            Menu menu = new(systemData);

            menu.Run();


        }
    }
}
