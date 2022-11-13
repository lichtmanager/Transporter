using System.Runtime.Serialization;

namespace Abgabe_1_2;

public class Company
{
    private string _cName;
    private double _balance;
    private int _availTrucks;
    private int _availDrivers;
    private int _availTenders;

    public Company(string cName, int balance, int availTrucks, int availDrivers, int availTenders)
    {
        this._cName = cName;
        this._balance = balance;
        this._availTrucks = availTrucks;
        this._availDrivers = availDrivers;
        this._availTenders = availTenders;
    }


    public static void PrintOutCompanyStatus(Company company)
    {
        Console.WriteLine(
            $"{company._cName} | {company._balance} EUR | {DateTime.Today.ToShortDateString()} | {company._availTrucks} Trucks | " +
            $"{company._availDrivers} Drivers | {company._availTenders} Tenders");
        Console.WriteLine();
    }
}