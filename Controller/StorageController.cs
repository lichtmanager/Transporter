using Transporter.Models;

namespace Transporter.Controller;

public static class StorageController
{
    public static City[] Cities = Initializer.InitializeCities();

    internal const int NumOfTrucksToCreate = 8;
    private const int NumOfDriversToCreate = 5;
    private const int NumOfTendersToCreate = 8;


    public static List<Truck> AvailTrucks = Initializer.InitializeNTrucks(NumOfTrucksToCreate);
    public static List<Driver> AvailDrivers = Initializer.InitializeNDrivers(NumOfDriversToCreate);
    public static List<Tender> AvailTenders = Initializer.InitializeNTenders(NumOfTendersToCreate);

    public static List<Truck> OwnedTrucks = new List<Truck>();
    public static List<Driver> EmployedDrivers = new List<Driver>();
    public static List<Tender> AcceptedTenders = new List<Tender>();

    public static Company Company = Initializer.InitializeCompany();
}