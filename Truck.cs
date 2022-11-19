using System.Reflection;

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


    public static string MappedTruckType(int randomTruckType)
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
        if (randomTruckAge == 0)
        {
            return "- neu -";
        }

        return $"{randomTruckAge} Jahre";
    }

// ToDo ToString implementieren
    public static void PrintOut(List<Truck> listOfTrucks)
    {
        for (int i = 0; i < listOfTrucks.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}: {Truck.MappedTruckType(listOfTrucks[i].TruckType)}   \t {Truck.MappedTruckAge(listOfTrucks[i].TruckAge)}  \t" +
                $" Standort: {Truck.MappedTruckLocation(listOfTrucks[i].TruckLocation)}  \t Perf: {listOfTrucks[i].TruckPerformance.ToString()} " +
                $"  \t max. Load: {listOfTrucks[i].TruckMaxPayload.ToString()}   \t Cons:{listOfTrucks[i].TruckConsumption.ToString()}" +
                $"   \t Preis: {listOfTrucks[i].TruckPrice:0.##}€");
        }
    }

    public static void HandlePurchase(int stroke)
    {
        if (stroke == 0)
        {
            TransporterConsole.RenderMainMenu();
        }

        int listIndex = stroke - 1;


        storage.ownedTrucks.Add((storage.availTrucks[listIndex]));

        storage.company.Balance -= storage.availTrucks[listIndex].TruckPrice;

        storage.availTrucks.Remove(storage.availTrucks[listIndex]);
    }
}