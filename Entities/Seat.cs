using System.Security.Cryptography;

namespace BusTerminalManagment_OOP.Entities
{
    public class Seat
    {
        private int _id;
        private int _number;
        public Seat(int number)
        {
            Number = number;
            Status = SeatStatus.Empty;
            Condition = Number.ToString("00");
        }

        public int Id
        {
            get { return _id; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Id Cannot be negative");
                }
                _id = value;
            }
        }
        public int Number
        {
            get { return _number; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Number Cannot be negative");
                }
                _number = value;
            }
        }
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
