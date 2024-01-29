namespace BusTerminalManagment_OOP.Entities
{
    public class Travel
    {

        public Travel(string origin, string destination)
        {
            Origin = origin;
            Destination = destination;
            Tickets = new();
            ReservedTicketsCanseledCount = 0;
            SoldTicketsCanseledCount = 0;

        }

        public int Id { get; set; }
        public Bus Bus { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Price { get; set; }
        public List<Ticket> Tickets { get; set; }
        public int ReservedTicketsCanseledCount { get; set; }
        public int SoldTicketsCanseledCount { get; set; }
    }
}
