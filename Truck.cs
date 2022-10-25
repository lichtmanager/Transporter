namespace Abgabe_1_2;

public class Truck
{
    private int TruckType;
    private int TruckAge;
    private int TruckLocation;
    private int Size;
    private int Performance;
    private int MaxPayload;
    private int Consumption;

    private Truck(int truckType, int truckAge, int truckLocation, int truckSize, int performance, int maxPayload,
        int consumption)
    {
        this.TruckType = truckType;
        this.TruckAge = truckAge;
        this.TruckLocation = truckLocation;
        this.Size = truckSize;
        this.Performance = performance;
        this.MaxPayload = maxPayload;
        this.Consumption = consumption;
    }

    public static void InitializeNewTrucks(int numberOfTrucksToCreate)
    {
        List<Truck> listOfTrucks = new List<Truck>();
        for (int i = 0; i < numberOfTrucksToCreate; i++)
        {
            int size = GenerateTruckSize();
            int type = GenerateTruckType();
            int age = GenerateTruckAge();
            int loc = GenerateTruckLocation();
            int perf = GenerateTruckPerformance(size);
            int payload = GenerateMaxPayload(size, type);
            int cons = GenerateTruckConsumption(type, size, age);

            Truck truck = new Truck(
                type, age, loc, size, perf, payload, cons);
            listOfTrucks.Add(truck);
        }

        //prints generated trucks
        for (int i = 0; i < numberOfTrucksToCreate; i++)
        {
            Console.WriteLine(
                    $"{i + 1}: {MappedTruckType(listOfTrucks[i].TruckType)}   \t {MappedTruckAge(listOfTrucks[i].TruckAge)}\t Standort: {MappedTruckLocation(listOfTrucks[i].TruckLocation)} " +
                    $" \t Größe: {MappedTruckSize(listOfTrucks[i].Size)} \t Perf: {listOfTrucks[i].Performance.ToString()} " +
                    $" \t max. Load: {listOfTrucks[i].MaxPayload.ToString()} \t Cons:{listOfTrucks[i].Consumption.ToString()}");
            
            
        } 
    }

    private static int GenerateTruckType()
    {
        Random rnd = new Random();
        int truckType = rnd.Next(0, 3);
      //  Console.WriteLine($"Typengereator: {truckType}");
        return truckType;
    }

    private static int GenerateTruckAge()
    {
        Random rnd = new Random();
        int truckAge = rnd.Next(0, 10);

        return truckAge;
    }

    private static int GenerateTruckLocation()
    {
        Random rnd = new Random();
        int truckLocation = rnd.Next(0, 8);

        return truckLocation;
    }

    private static int GenerateTruckSize()
    {
        Random rnd = new Random();
        int size = rnd.Next(0, 4);
        Console.WriteLine($"Größengenerator: {size}");

        return size;
    }

    private static int GenerateTruckPerformance(int size)
    {
        Random rnd = new Random();
        var perf = 0;
        switch (size)
        {
            case 0:
                perf = rnd.Next(10, 26);
                //Console.WriteLine("perf. klein");
                return perf;
            case 1:
                perf = rnd.Next(30, 51);
               // Console.WriteLine("perf. medium");
                return perf;
            case 2:
                perf = rnd.Next(40, 71);
               // Console.WriteLine("perf. groß");
                return perf;
            case 3:
                perf = rnd.Next(60, 81);
               // Console.WriteLine("perf. rießig");
                return perf;
            default:
                return perf = 0;
        }
    }

    private static int GenerateMaxPayload(int size, int type)
    {
        var payload = 0;

        return size switch
        {
            0 => type switch
            {
                0 => payload = 3,
                1 => payload = 4,
                2 => payload = 2,
                _ => payload = 0
            },
            1 => type switch
            {
                0 => payload = 4,
                1 => payload = 6,
                2 => payload = 4,
                _ => payload = 0
            },
            2 => type switch
            {
                0 => payload = 5,
                1 => payload = 7,
                2 => payload = 8,
                _ => payload = 0
            },
            3 => type switch
            {
                0 => payload = 6,
                1 => payload = 10,
                2 => payload = 10,
                _ => payload = 0
            },
            _ => payload
        };
    }

    private static int GenerateTruckConsumption(int type, int size, int age)
    {
        var consumption = 0;
        switch (age)
        {
            case <= 2:
                consumption += 1;
                break;
            case var n and >= 3 and <= 5:
                consumption += 2;
                break;
            case var n and >= 6 and <= 8:
                consumption += 3;
                break;
            case > 9:
                consumption += 4;
                break;
        }

        switch (size)
        {
            case 0:
                return type switch
                {
                    0 => consumption += 14,
                    1 => consumption += 10,
                    2 => consumption += 14,
                    _ => consumption += 0
                };

            case 1:
                return type switch
                {
                    0 => consumption += 18,
                    1 => consumption += 12,
                    2 => consumption += 18,
                    _ => consumption += 0
                };

            case 2:
                return type switch
                {
                    0 => consumption += 20,
                    1 => consumption += 16,
                    2 => consumption + 20,
                    _ => consumption += 0
                };

            case 3:
                return type switch
                {
                    0 => consumption += 30,
                    1 => consumption += 22,
                    2 => consumption += 30,
                    _ => consumption += 0
                };
        }

        return consumption;
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