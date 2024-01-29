namespace BusTerminalManagment_OOP.Entities
{
    public abstract class Bus
    {
        private int _id;
        private string _name;
        protected int _seatNumber;
        protected Bus(string name)
        {
            Name = name;
            Seats = new();
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
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name Cannot be Empty");
                }
                _name = value;
            }
        }
        public BusType Type { get; set; }
        public List<Seat> Seats { get; set; }

        public abstract void ShowSeats();
    }
    public enum BusType
    {
        Normal = 1,
        Vip = 2
    }
}
