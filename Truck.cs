namespace Abgabe_1_2;

public class Truck
{
    public string TruckType;
    public int TruckAge;
    public string TruckLocation;


    public Truck(int truckType, int truckAge, int truckLocation)
    {
        this.TruckType = MappedTruckType(GenerateTruckType());
        this.TruckAge = GenerateTruckAge();
        this.TruckLocation = MappedTruckLocation(GenerateTruckLocation());
    }


    private static int GenerateTruckType()
    {
        Random rnd = new Random();
        int truckType = rnd.Next(0, 2);

        return truckType;
    }

    private static int GenerateTruckAge()
    {
        Random rnd = new Random();
        int truckAge = rnd.Next(0, 9);

        return truckAge;
    }

    private static int GenerateTruckLocation()
    {
        Random rnd = new Random();
        int truckLocation = rnd.Next(0, 7);

        return truckLocation;
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



    public static void InitializeTrucks(int numberOfTrucksToCreate)
    {
        List<Truck> listOfTrucks = new List<Truck>();
        for (int i = 0; i < numberOfTrucksToCreate; i++)
        {
            Truck truck = new Truck(
                GenerateTruckType(), GenerateTruckAge(), GenerateTruckLocation());
            listOfTrucks.Add(truck);
        }

        for (int i = 0; i < numberOfTrucksToCreate; i++)
        {
            Console.WriteLine($"{i+1}: {listOfTrucks[i].TruckType.ToString()}, {listOfTrucks[i].TruckAge} Jahre,\t {listOfTrucks[i].TruckLocation.ToString()}");
        }
    }




}