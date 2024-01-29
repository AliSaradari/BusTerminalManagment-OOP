using BusTerminalManagment_OOP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusTerminalManagment_OOP
{
    public static class Terminal
    {
        private static List<Bus> _buses = new List<Bus>();
        private static List<Travel> _travels = new List<Travel>();
        private static List<Ticket> _tickets = new List<Ticket>();

        public static void AddBus(string name, int type)
        {
            switch (type)
            {

                case 1:
                    {
                        var bus = new NormalBus(name)
                        {
                            Type = BusType.Normal,
                        };
                        _buses.Add(bus);
                        Console.WriteLine("***Bus Added Successfully***");
                        break;
                    }
                case 2:
                    {
                        var bus = new VipBus(name)
                        {
                            Type = BusType.Vip,
                        };
                        _buses.Add(bus);
                        Console.WriteLine("***Bus Added Successfully***");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Option! try agian.");
                        break;
                    }
            }
        }
        public static void ShowBuses(int busType)
        {
            switch (busType)
            {
                case 1:
                    {
                        var normalBuses = _buses
                            .Where(_ => _.Type == BusType.Normal)
                            .ToList();
                        foreach (var bus in normalBuses)
                        {
                            Console.WriteLine("-------------------------" +
                                "--------------------------");
                            Console.WriteLine($"Bus Name: {bus.Name} | Bus Type: " +
                                $"{bus.Type}");
                            Console.WriteLine("--------------------------" +
                                "-------------------------");
                        }
                        break;
                    }
                case 2:
                    {
                        var vipBuses = _buses.Where(_ => _.Type == BusType.Vip).ToList();
                        foreach (var bus in vipBuses)
                        {
                            Console.WriteLine("---------------------------" +
                                "------------------------");
                            Console.WriteLine($"Bus Name: {bus.Name} | Bus Type: " +
                                $"{bus.Type}");
                            Console.WriteLine("------------------------" +
                                "---------------------------");
                        }
                        break;
                    }
            }
        }
        public static void AddTravel(int id, string busName, string origin
           , string destination, decimal price)
        {
            var bus = _buses.FirstOrDefault(_ => _.Name == busName);
            var travel = new Travel(origin, destination)
            {
                Bus = bus,
                Price = price,
                Id = id

            };
            _travels.Add(travel);
            Console.WriteLine("***Travel Added Successfully***");

        }
        public static void ShowTravels()
        {
            foreach (var travel in _travels)
            {
                Console.WriteLine("--------------------------------------------" +
                    "------------------------------------------------------------");
                Console.WriteLine($"| {travel.Id}- Bus Name: {travel.Bus.Name}" +
                    $" | Bus Type: {travel.Bus.Type}" +
                    $" | Origin: {travel.Origin}" +
                    $" | Destination: {travel.Destination}" +
                    $" | Ticket Price: {travel.Price} |");
                Console.WriteLine("------------------------------------------------" +
                    "--------------------------------------------------------");
            }
        }
        public static void ShowBusSeats(int travelId)
        {
            var bus = _travels.SingleOrDefault(_ => _.Id == travelId).Bus;
            bus.ShowSeats();
        }
        public static void ChangeStatus(int travelId, int seatNumber, SeatStatus status)
        {
            var busSeats = _travels.Single(_ => _.Id == travelId).Bus.Seats;
            var seat = busSeats.Single(_ => _.Number == seatNumber);

            seat.Status = status;
            //seat.Condition = "rr";
            if (status == SeatStatus.Empty)
            {
                seat.Condition = seat.Number.ToString("00");
            }
            if (status == SeatStatus.Reserved)
            {
                seat.Condition = "rr";
            }
            if (status == SeatStatus.Sold)
            {
                seat.Condition = "bb";
            }
        }

        public static void TicketReservation(int seatNumber, int travelId, int ticketId)
        {
            var seatStatus = _travels
                .SingleOrDefault(_ => _.Id == travelId)
                .Bus.Seats.SingleOrDefault(_ => _.Number == seatNumber);

            if (seatStatus.Status == SeatStatus.Reserved || seatStatus.Status == SeatStatus.Sold)
            {
                throw new Exception("!!! This Seat is not Empty !!!");
            }
            else
            {
                var travel = _travels.Single(_ => _.Id == travelId);
                var busName = travel.Bus.Name;
                var ticketPrice = travel.Price * 0.3M;

                var ticket = new Ticket()
                {
                    Id = travelId,
                    Price = ticketPrice,
                    BusName = busName,
                    SeatNumber = seatNumber,
                    Type = TicketType.Reserved,
                    TravelId = travelId,
                };
                travel.Tickets.Add(ticket);
                //_tickets.Add(ticket);
                ChangeStatus(travelId, seatNumber, SeatStatus.Reserved);
                Console.WriteLine("***Ticket Reserved***");
            }

        }
        public static void TicketSales(int seatNumber, int travelId, int ticketId)
        {
            var seatStatus = _travels
                .SingleOrDefault(_ => _.Id == travelId)
                .Bus.Seats.SingleOrDefault(_ => _.Number == seatNumber);

            if (seatStatus.Status == SeatStatus.Reserved)
            {
                throw new Exception("!!! This Seat is not Empty !!!");
            }
            else
            {
                var travel = _travels.Single(_ => _.Id == travelId);
                var busName = travel.Bus.Name;
                var ticketPrice = travel.Price;

                var ticket = new Ticket()
                {
                    Id = ticketId,
                    Price = ticketPrice,
                    BusName = busName,
                    SeatNumber = seatNumber,
                    Type = TicketType.Sold,
                    TravelId = travelId,
                };
                travel.Tickets.Add(ticket);
                ChangeStatus(travelId, seatNumber, SeatStatus.Sold);
                Console.WriteLine("***Ticket Sold***");
            }
        }
        public static void TicketCanselation(int seatNumber, int travelId)
        {
            var travel = _travels.SingleOrDefault(_ => _.Id == travelId);
            var seatStatus = travel.Bus.Seats.SingleOrDefault(_ => _.Number == seatNumber);
            var canseledTicket =
            travel.Tickets.Where(_ => _.TravelId == travelId)
            .SingleOrDefault(_ => _.SeatNumber == seatNumber);

            if (seatStatus.Status == SeatStatus.Empty)
            {
                throw new Exception("!!! This Seat is Empty !!!");
            }
            else
            {
                if (canseledTicket.Type == TicketType.Sold)
                {
                    canseledTicket.Price = canseledTicket.Price * 0.1M;
                    travel.SoldTicketsCanseledCount++;

                }
                if (canseledTicket.Type == TicketType.Reserved)
                {
                    canseledTicket.Price = canseledTicket.Price * 0.2M;
                    travel.ReservedTicketsCanseledCount++;
                }
                ChangeStatus(travelId, canseledTicket.SeatNumber, SeatStatus.Empty);
                Console.WriteLine($"***Ticket with ID: {canseledTicket.Id} Canseled! ***");
            }
        }
        public static void ShowTravelReport(int travelId)
        {
            var travel = _travels.SingleOrDefault(_ => _.Id == travelId);
            var netIncome = travel.Tickets.Select(_ => _.Price).Sum();
            var emptySeats = travel.Bus.Seats.Where(_ => _.Status == SeatStatus.Empty).Count();
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Travel {travelId} Report:\n" +
                $"Net Income: {netIncome}\n" +
                $"Empty Seats: {emptySeats}\n" +
                $"Number of canceled reservations: {travel.ReservedTicketsCanseledCount}\n" +
                $"Number of canceled purchases: {travel.SoldTicketsCanseledCount}");
            Console.WriteLine("-----------------------------");

        }
    }
}
