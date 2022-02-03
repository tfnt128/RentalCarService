using System.Globalization;
using System;
using File.Entities;
using File.Services;

namespace File
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rental data: ");
            Console.Write("Car model: ");
            String model = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy hh:mm): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Return (dd/MM/yyyy hh:mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Enter price per hour: ");
            double priceh = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            double priced = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental carRental = new CarRental(start, finish, new Vehicle(model));
            RentalService rentalService = new RentalService(priceh, priced, new BrazilTaxService());

            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("INVOICE: ");
            Console.WriteLine(carRental.Invoice);

            
        }
    }
}
