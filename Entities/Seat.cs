namespace BusTerminalManagment_OOP.Entities
{
    public class Seat
    {
        
        public Seat(int number)
        {
            Number = number;
            Status = SeatStatus.Empty;
            Condition = Number.ToString("00");
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public SeatStatus Status { get; set; }
        public string Condition { get; set; }

        public void ChangeStatus(SeatStatus status)
        {
            Status = status;

            if (status == SeatStatus.Empty)
            {

                Condition = Number.ToString("00");
            }
            if (status == SeatStatus.Reserved)
            {
                Condition = "rr";
            }
            if (status == SeatStatus.Sold)
            {
                Condition = "bb";
            }
        }

    }
    public enum SeatStatus
    {
        Empty = 1,
        Reserved = 2,
        Sold = 3
    }
}
