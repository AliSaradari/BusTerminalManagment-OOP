using BusTerminalManagment_OOP;
using System.Threading.Channels;

namespace BusTerminalManagment_Ef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Run();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            static void Run()
            {
                var menu = GetInt("Choose an option:\n" +
                    "1.Add Bus\n" +
                    "2.Add Travel\n" +
                    "3.Show Travels\n" +
                    "4.Reserve Ticket\n" +
                    "5.Buy Ticket\n" +
                    "6.Cansel Ticket\n" +
                    "7.Show Travel Report\n" +
                    "0.Exit\n" +
                    "(Type 00 to go back to menu)");
                switch (menu)
                {
                    case 0:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    case 1:
                        {
                            var busName = GetString("Enter Bus Name:");
                            if (busName == "00") { break; }
                            var busType = GetInt("Choose Bus Type:\n" +
                                "1.Normal\n" +
                                "2.Vip");
                            if (busType == 00) { break; }
                            Terminal.AddBus(busName, busType);
                            break;
                        }
                    case 2:
                        {
                            var busType = GetInt("Choose Bus Type:\n" +
                                "1.Normal\n" +
                                "2.Vip");
                            if (busType == 00) { break; }
                            Terminal.ShowBuses(busType);
                            var travelId = GetInt("Enter the travel number:");
                            if (travelId == 00) { break; }
                            var busName = GetString("Enter  the bus name:");
                            if (busName == "00") { break; }
                            var origin = GetString("Enter the origin of the travel:");
                            if (origin == "00") { break; }
                            var destination = GetString("Enter the destination of the travel:");
                            if (destination == "00") { break; }
                            Console.WriteLine("Enter the travel price:");
                            var price = decimal.Parse(Console.ReadLine());
                            if (price == 00) { break; }
                            Terminal.AddTravel(travelId, busName, origin, destination, price);
                            break;
                        }
                    case 3:
                        {
                            Terminal.ShowTravels();
                            var travelId = GetInt("Enter Teravel number to show bus seats:");
                            if (travelId == 00) { break; }
                            Terminal.ShowBusSeats(travelId);
                            break;
                        }
                    case 4:
                        {
                            Terminal.ShowTravels();
                            var travelId = GetInt("Enter Teravel number to show bus seats:");
                            if (travelId == 00) { break; }
                            Terminal.ShowBusSeats(travelId);
                            var seatNumber = GetInt("Enter the seat number for reserve:");
                            if (seatNumber == 00) { break; }
                            var ticketId = GetInt("Enter Passanger NationalCode: ");
                            if (ticketId == 00) { break; }
                            Terminal.TicketReservation(seatNumber, travelId , ticketId);
                            break;
                        }
                        case 5:
                        {
                            Terminal.ShowTravels();
                            var travelId = GetInt("Enter Teravel number to show bus seats:");
                            if (travelId == 00) { break; }
                            Terminal.ShowBusSeats(travelId);
                            var seatNumber = GetInt("Enter the seat number for buy:");
                            if (seatNumber == 00) { break; }
                            var ticketId = GetInt("Enter Passanger NationalCode: ");
                            if (ticketId == 00) { break; }
                            Terminal.TicketSales(seatNumber, travelId , ticketId);
                            break;
                            break;
                        }
                        case 6:
                        {
                            Terminal.ShowTravels();
                            var travelId = GetInt("Enter Teravel number to show bus seats:");
                            if (travelId == 00) { break; }
                            Terminal.ShowBusSeats(travelId);
                            var seatNumber = GetInt("Enter the seat number for Cansel Ticket:");
                            if (seatNumber == 00) { break; }
                            Terminal.TicketCanselation(seatNumber, travelId);
                            break;
                        }
                    case 7:
                        {
                            Terminal.ShowTravels();
                            var travelId = GetInt("Enter Teravel number to show report:");
                            if (travelId == 00) { break; }
                            Terminal.ShowTravelReport(travelId);
                            break;
                        }
                }
            }
            static string GetString(string message)
            {
                Console.WriteLine(message);
                var input = Console.ReadLine();
                return input;
            }
        }
        static int GetInt(string message)
        {
            Console.WriteLine(message);
            var input = int.Parse(Console.ReadLine());
            return input;
        }

    }
}

