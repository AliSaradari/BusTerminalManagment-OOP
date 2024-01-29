namespace BusTerminalManagment_OOP.Entities
{
    public class Ticket
    {

        public int Id { get; set; }
        public string BusName { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        public TicketType Type { get; set; }
        public int TravelId { get; set; }

    }
    public enum TicketType
    {
        Reserved = 1,
        Sold = 2
    }
}
