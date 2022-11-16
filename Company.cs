using System.Runtime.Serialization;

namespace Abgabe_1_2;

public class Company
{
    public string cName;
    public double balance;
    public List<Truck> AvailTrucks;
    public List<Driver> OwnedDrivers;
    public List<Tender> OwnedTenders;

    public Company(string cName, int balance, List<Truck> ownedTrucks, List<Driver> ownedDrivers,
        List<Tender> ownedTenders)
    {
        this.cName = cName;
        this.balance = balance;
        this.AvailTrucks = ownedTrucks;
        this.OwnedDrivers = ownedDrivers;
        this.OwnedTenders = ownedTenders;
    }


    public static void PrintOutCompanyStatus(Company company)
    {
        Console.WriteLine(
            $"{company.cName} | {company.balance} EUR | {DateTime.Today.ToShortDateString()} | {company.AvailTrucks.Count} Trucks | " +
            $"{company.OwnedDrivers.Count} Drivers | {company.OwnedTenders.Count} Tenders");
        Console.WriteLine();
    }
}