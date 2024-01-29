namespace BusTerminalManagment_OOP.Entities
{
    public class VipBus : Bus
    {
        public VipBus(string name) : base(name)
        {
            _seatNumber = 30;
            for (int i = 1; i <= _seatNumber; i++)
            {
                Seats.Add(new Seat(i));
            }
        }
        public override void ShowSeats()
        {
            Console.WriteLine("-------VIP-------");
            Console.WriteLine();
            for (int j = 0; j < 12; j++)
            {
                if (j < 5)
                {
                    Console.WriteLine($"{Seats[j * 3].Condition}    {Seats[j * 3 + 1].Condition} {Seats[j * 3 + 2].Condition}");
                    Console.WriteLine();
                }
                if (j >= 5 && j < 8)
                {
                    Console.WriteLine($"{Seats[j + 10].Condition}");
                    Console.WriteLine();
                }
                if (j >= 8)
                {
                    Console.WriteLine($"{Seats[j * 3 - 6].Condition}    {Seats[j * 3 - 5].Condition} {Seats[j * 3 - 4].Condition}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("-----------------");
        }
    }
}
