namespace Abgabe_1_2;

public class storage
{
    public static List<Truck> availTrucks = Initialize.InitializeNTrucks(8);
    public static List<Driver> availDrivers = Initialize.InitializeNDrivers(5);
    public static List<Tender> availTenders = Initialize.InitializeNTenders(8);

    public static List<Truck> ownedTrucks = new List<Truck>();
    public static List<Driver> ownedDrivers = new List<Driver>();
    public static List<Tender> ownedTenders = new List<Tender>();

    public static Company company = Initialize.InitializeCompany();
}