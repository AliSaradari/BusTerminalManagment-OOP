namespace BusTerminalManagment_OOP.Entities
{
    public class NormalBus : Bus
    {
        public NormalBus(string name) : base(name)
        {
            _seatNumber = 44;
            for (int i = 1; i <= _seatNumber; i++)
            {
                Seats.Add(new Seat(i));
            }
        }

        public override void ShowSeats()
        {
            Console.WriteLine("------Normal------");
            Console.WriteLine();
            for (int j = 0; j < 13; j++)
            {
                if (j < 5)
                {
                    Console.WriteLine($"{Seats[j * 4].Condition} {Seats[j * 4 + 1].Condition}    {Seats[j * 4 + 2].Condition} {Seats[j * 4 + 3].Condition}");
                    Console.WriteLine();
                }
                if (j == 5)
                {
                    Console.WriteLine($"{Seats[j * 4].Condition} {Seats[j * 4 + 1].Condition}");
                    Console.WriteLine();
                }
                if (j == 6)
                {
                    Console.WriteLine($"{Seats[j * 4 - 2].Condition} {Seats[j * 4 - 1].Condition}");
                    Console.WriteLine();
                }
                if (j >= 7 && j < 12)
                {
                    Console.WriteLine($"{Seats[j * 4 - 4].Condition} {Seats[j * 4 - 3].Condition}    {Seats[j * 4 - 2].Condition} {Seats[j * 4 - 1].Condition}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("------------------");
        }
    }
}
