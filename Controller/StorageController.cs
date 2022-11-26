using Transporter.Models;

namespace Transporter.Controller;

public static class StorageController
{
    public static List<Truck> AvailTrucks = Initializer.InitializeNTrucks(8);
    public static List<Driver> AvailDrivers = Initializer.InitializeNDrivers(5);
    public static List<Tender> AvailTenders = Initializer.InitializeNTenders(8);

    public static List<Truck> OwnedTrucks = new List<Truck>();
    public static List<Driver> EmployedDrivers = new List<Driver>();
    public static List<Tender> AcceptedTenders = new List<Tender>();

    public static Company Company = Initializer.InitializeCompany();
    public static City[] Cities = Initializer.InitializeCities();
}