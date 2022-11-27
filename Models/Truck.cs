using ConsoleTables;
using Transporter.Controller;
using Transporter.View;

namespace Transporter.Models;

public class Truck
{
    public int TruckType;
    public int TruckAge;
    public int TruckLocation;
    private int TruckSize;
    public int TruckPerformance;
    public int TruckMaxPayload;
    public int TruckConsumption;
    public double TruckPrice;
    public Driver? TruckDriver;
    public Status TruckState;
    public City? Destination;


    public Truck(int truckType, int truckAge, int truckLocation, int truckSize, int truckPerformance,
        int truckMaxPayload, int truckConsumption, double truckPrice, Driver? truckDriver, Status truckTruckState,
        City? destination)
    {
        TruckType = truckType;
        TruckAge = truckAge;
        TruckLocation = truckLocation;
        TruckSize = truckSize;
        TruckPerformance = truckPerformance;
        TruckMaxPayload = truckMaxPayload;
        TruckConsumption = truckConsumption;
        TruckPrice = truckPrice;
        TruckDriver = truckDriver;
        TruckState = truckTruckState;
        Destination = destination;
    }

    public enum Status
    {
        Available,
        Moving,
        Booked,
        Returning
    }

    internal static string MappedTruckType(int? randomTruckType)
    {
        if (randomTruckType is null)
        {
            return "";
        }

        List<string> truckTypesList = new List<string>()
            { "Kühllastwagen", "Pritschenwagen", "Tanklaster" };

        string mappedTruckType = truckTypesList[(int)randomTruckType];


        return mappedTruckType;
    }

    public static string MappedTruckLocation(int? truckLocation)
    {
        if (truckLocation is null)
        {
            return "";
        }

        List<string> availableCities = new List<string>()
            { "Amsterdam", "Berlin", "Esslingen", "Rom", "Lissabon", "Istanbul", "Aarhus", "Tallinn" };
        string loc = availableCities[(int)truckLocation];

        return loc;
    }

    private static string MappedTruckSize(int randomTruckSize)
    {
        List<string> availibleSizes = new List<string>()
            { "Klein", "Medium", "Groß", "Riesig" };
        string size = availibleSizes[randomTruckSize];

        return size;
    }

    internal static string MappedTruckAge(int randomTruckAge)
    {
        if (randomTruckAge < 0)
        {
            return "invalid Age";
        }

        if (randomTruckAge == 0)
        {
            return "- neu -";
        }

        if (randomTruckAge == 1)
        {
            return $"{randomTruckAge} Jahr";
        }

        return $"{randomTruckAge} Jahre";
    }

    public override string ToString()
    {
        return
            $"{MappedTruckType(TruckType)}   \t {MappedTruckAge(TruckAge)}  \t" +
            $" Standort: {MappedTruckLocation(TruckLocation)}  \t Perf: {TruckPerformance.ToString()} " +
            $"  \t max. Load: {TruckMaxPayload.ToString()}   \t Cons:{TruckConsumption.ToString()}" +
            $"   \t Preis: {TruckPrice:0.##}€";
    }
}