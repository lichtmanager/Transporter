using System.Runtime.Serialization;

namespace Abgabe_1_2;

public class Company
{
    private string _cName;
    private double _balance;
    public List<Truck> AvailTrucks;
    public List<Driver> OwnedDrivers;
    public List<Tender> OwnedTenders;

    public Company(string cName, int balance, List<Truck> ownedTrucks, List<Driver> ownedDrivers,
        List<Tender> ownedTenders)
    {
        this._cName = cName;
        this._balance = balance;
        this.AvailTrucks = ownedTrucks;
        this.OwnedDrivers = ownedDrivers;
        this.OwnedTenders = ownedTenders;
    }


    public static void PrintOutCompanyStatus(Company company)
    {
        Console.WriteLine(
            $"{company._cName} | {company._balance} EUR | {DateTime.Today.ToShortDateString()} | {company.AvailTrucks.Count} Trucks | " +
            $"{company.OwnedDrivers.Count} Drivers | {company.OwnedTenders.Count} Tenders");
        Console.WriteLine();
    }
}