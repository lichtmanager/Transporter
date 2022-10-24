namespace Abgabe_1_2;

public class Truck
{
    private string TruckType;
    private int TruckAge;
    private string TruckLocation;
    private string Size;
    private int Performance;
    private int MaxPayload;
    private int consumption;


    public Truck(int truckType, int truckAge, int truckLocation, int size, int performance, int maxPayload,
        int consumption)
    {
        this.TruckType = MappedTruckType(GenerateTruckType());
        this.TruckAge = GenerateTruckAge();
        this.TruckLocation = MappedTruckLocation(GenerateTruckLocation());
        this.Size = MappedTruckSize(GenerateTruckSize());
        this.Performance = GenerateTruckPerformance(GenerateTruckSize());
        this.MaxPayload = GenerateMaxPayload(GenerateTruckSize(), GenerateTruckType());
        this.consumption = GenerateTruckConsumption();
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

    private static int GenerateTruckSize()
    {
        Random rnd = new Random();
        int size = rnd.Next(0, 3);

        return size;
    }

    private static int GenerateTruckPerformance(int size)
    {
        Random rnd = new Random();
        int perf;
        switch (size)
        {
            case 0:
                perf = rnd.Next(10, 25);
                return perf;
            case 1:
                perf = rnd.Next(30, 50);
                return perf;
            case 2:
                perf = rnd.Next(40, 70);
                return perf;
            case 3:
                perf = rnd.Next(60, 80);
                return perf;

            default: return perf = 0;
        }
    }

    private static int GenerateMaxPayload(int size, int type)
    {
        int payload = 0;

        switch (size)
        {
            case 0:
                switch (type)
                {
                    case 0:
                        return payload = 3;
                        break;
                    case 1:
                        return payload = 4;
                        break;
                    case 2:
                        return payload = 2;
                        break;
                    default:
                        payload = 0;
                        break;
                }

                break;


            case 1:
                switch (type)
                {
                    case 0:
                        return payload = 4;
                        break;
                    case 1:
                        return payload = 6;
                        break;
                    case 2:
                        return payload = 4;
                        break;
                    default:
                        payload = 0;
                        break;
                }

                break;
            case 2:
                switch (type)
                {
                    case 0:
                        return payload = 5;
                        break;
                    case 1:
                        return payload = 7;
                        break;
                    case 2:
                        return payload = 8;
                        break;
                    default:
                        payload = 0;
                        break;
                }

                break;
            case 3:
                switch (type)
                {
                    case 0:
                        return payload = 6;
                        break;
                    case 1:
                        return payload = 10;
                        break;
                    case 2:
                        return payload = 10;
                        break;
                    default:
                        payload = 0;
                        break;
                }

                break;
        }
        
        return payload;
    }

    private static int GenerateTruckConsumption()
    {
        int consumption = 0;
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

    
        public static void InitializeTrucks(int numberOfTrucksToCreate)
    {
        List<Truck> listOfTrucks = new List<Truck>();
        for (int i = 0; i < numberOfTrucksToCreate; i++)
        {
            Truck truck = new Truck(
                GenerateTruckType(), GenerateTruckAge(), GenerateTruckLocation(), MappedTruckSize(GenerateTruckSize()),
                GenerateTruckPerformance(),GenerateMaxPayload(GenerateTruckSize(), GenerateTruckType()));
            listOfTrucks.Add(truck);
        }

        for (int i = 0; i < numberOfTrucksToCreate; i++)
        {
            if (listOfTrucks[i].TruckAge == 0)
            {
                Console.WriteLine(
                    $"{i + 1}: {listOfTrucks[i].TruckType.ToString()},\t- neu -\t Standort: {listOfTrucks[i].TruckLocation.ToString()}");
            }
            else
            {
                Console.WriteLine(
                    $"{i + 1}: {listOfTrucks[i].TruckType.ToString()},\t{listOfTrucks[i].TruckAge.ToString()} Jahre\t Standort: {listOfTrucks[i].TruckLocation.ToString()}");
            }
        }
    }
}