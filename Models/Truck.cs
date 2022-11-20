using System.Collections.Concurrent;
using System.Globalization;
using System.Reflection;
using ConsoleTables;

namespace Abgabe_1_2;

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

    public Truck(int truckType, int truckAge, int truckLocation, int truckSize, int truckPerformance,
        int truckMaxPayload,
        int truckConsumption, double truckPrice)
    {
        this.TruckType = truckType;
        this.TruckAge = truckAge;
        this.TruckLocation = truckLocation;
        this.TruckSize = truckSize;
        this.TruckPerformance = truckPerformance;
        this.TruckMaxPayload = truckMaxPayload;
        this.TruckConsumption = truckConsumption;
        this.TruckPrice = truckPrice;
    }


    private static string MappedTruckType(int randomTruckType)
    {
        List<string> truckTypesList = new List<string>()
            { "Kühllastwagen", "Pritschenwagen", "Tanklaster" };
        string mappedTruckType = truckTypesList[randomTruckType];

        return mappedTruckType;
    }

    public static string MappedTruckLocation(int randomTruckLocation)
    {
        List<string> availableCities = new List<string>()
            { "Amsterdam", "Berlin", "Esslingen", "Rom", "Lissabon", "Istanbul", "Aarhus", "Tallinn" };
        string loc = availableCities[randomTruckLocation];

        return loc;
    }

    private static string MappedTruckSize(int randomTruckSize)
    {
        List<string> availibleSizes = new List<string>()
            { "Klein", "Medium", "Groß", "Riesig" };
        string size = availibleSizes[randomTruckSize];

        return size;
    }

    private static string MappedTruckAge(int randomTruckAge)
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

    public static void PrintOut(List<Truck> trucks)
    {
        var table = new ConsoleTable("#", "Type", "Age", "Location", "Performane", "Payload",
            "Consumption", "Price");
        for (int i = 0; i < trucks.Count; i++)
        {
            table.AddRow($"{i + 1}",
                $"{MappedTruckType(trucks[i].TruckType)}",
                $"{MappedTruckAge(trucks[i].TruckAge)}",
                $"{MappedTruckLocation(trucks[i].TruckLocation)}",
                $"{trucks[i].TruckPerformance} hp",
                $"{trucks[i].TruckMaxPayload.ToString()}t",
                $"{trucks[i].TruckConsumption} l/100km",
                $"{trucks[i].TruckPrice:C}");
        }

        table.Write();
        System.Console.WriteLine();
    }

    public static void HandlePurchase(int stroke)
    {
        if (stroke == 0)
        {
            BusinessLogic.RenderMainMenu();
        }

        int listIndex = stroke - 1;


        StorageController.ownedTrucks.Add((StorageController.availTrucks[listIndex]));

        StorageController.company.Balance -= StorageController.availTrucks[listIndex].TruckPrice;

        StorageController.availTrucks.Remove(StorageController.availTrucks[listIndex]);
    }
}