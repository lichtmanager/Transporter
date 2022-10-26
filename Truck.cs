namespace Abgabe_1_2;

public class Truck
{
    private int TruckType;
    private int TruckAge;
    private int TruckLocation;
    private int TruckSize;
    private int TruckPerformance;
    private int TruckMaxPayload;
    private int TruckConsumption;
    private double TruckPrice;

    private Truck(int truckType, int truckAge, int truckLocation, int truckSize, int truckPerformance,
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

    public static void InitializeNewTrucks(int numberOfTrucksToCreate)
    {
        List<Truck> listOfTrucks = new List<Truck>();
        for (int i = 0; i < numberOfTrucksToCreate; i++)
        {
            int size = Generator.GenerateTruckSize();
            int type = Generator.GenerateTruckType();
            int age = Generator.GenerateTruckAge();
            int loc = Generator.GenerateTruckLocation();
            int perf = Generator.GenerateTruckPerformance(size);
            int payload = Generator.GenerateMaxPayload(size, type);
            int cons = Generator.GenerateTruckConsumption(type, size, age);
            double price = Generator.GenerateTruckPrice(age, size, type);

            Truck truck = new Truck(
                type, age, loc, size, perf, payload, cons, price);
            listOfTrucks.Add(truck);
        }


        for (int i = 0; i < numberOfTrucksToCreate; i++)
        {
            Console.WriteLine(
                $"{i + 1}: {MappedTruckType(listOfTrucks[i].TruckType)}   \t {MappedTruckAge(listOfTrucks[i].TruckAge)}\t Standort: {MappedTruckLocation(listOfTrucks[i].TruckLocation)} " +
                $" \t Perf: {listOfTrucks[i].TruckPerformance.ToString()} " +
                $" \t max. Load: {listOfTrucks[i].TruckMaxPayload.ToString()} \t Cons:{listOfTrucks[i].TruckConsumption.ToString()} \t Preis: {listOfTrucks[i].TruckPrice.ToString("0")}€");
        }
    }

    private static string MappedTruckType(int randomTruckType)
    {
        List<string> truckTypesList = new List<string>()
            { "Kühllastwagen", "Pritschenwagen", "Tanklaster" };
        string mappedTruckType = truckTypesList[randomTruckType];

        return mappedTruckType;
    }

    private static string MappedTruckLocation(int randomTruckLocation)
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
        string ageString;
        if (randomTruckAge == 0)
        {
            ageString = "- neu -";
            return ageString;
        }
        else
        {
            ageString = $"{randomTruckAge} Jahre";

            return ageString;
        }
    }
}