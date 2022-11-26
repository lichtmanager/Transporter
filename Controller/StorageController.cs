using Transporter.Models;

namespace Transporter.Controller;

public class StorageController
{
    public static List<Truck> availTrucks = Initializer.InitializeNTrucks(8);
    public static List<Driver> availDrivers = Initializer.InitializeNDrivers(5);
    public static List<Tender> availTenders = Initializer.InitializeNTenders(8);

    public static List<Truck> ownedTrucks = new List<Truck>();
    public static List<Driver> employedDrivers = new List<Driver>();
    public static List<Tender> acceptedTenders = new List<Tender>();

    public static Company company = Initializer.InitializeCompany();
}