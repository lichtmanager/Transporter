namespace Transporter.Models;

public class Company
{
    public string CName;
    public double Balance;
    public List<Truck> AvailTrucks;
    public List<Driver> OwnedDrivers;
    public List<Tender> OwnedTenders;
    public DateTime Date;

    public Company(string cName, int balance, DateTime date, List<Truck> ownedTrucks, List<Driver> ownedDrivers,
        List<Tender> ownedTenders)
    {
        CName = cName;
        Balance = balance;
        AvailTrucks = ownedTrucks;
        OwnedDrivers = ownedDrivers;
        OwnedTenders = ownedTenders;
        Date = date;
    }

    //ToDo toStrings in anderen Klassen implementieren
    public override string ToString()
    {
        return (
            $"{CName} | {Balance:C0} | {Date.ToShortDateString()} | {AvailTrucks.Count} Trucks | " +
            $"{OwnedDrivers.Count} Drivers | {OwnedTenders.Count} Tenders");
    }
}