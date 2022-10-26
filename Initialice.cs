namespace Abgabe_1_2;

public class Initialice
{
    public Initialice()
    {
    }

    public static City[] InitialiceCities()
    {
        City[] cityArray = new City[8];
        cityArray[0] = new City("Amsterdam", 868851, 297477);
        cityArray[1] = new City("Berlin", 1442341, 404144);
        cityArray[2] = new City("Esslingen", 1232391, -71899);
        cityArray[3] = new City("Rom", 1605258, -786717);
        cityArray[4] = new City("Lissabon", -220417, -1218006);
        cityArray[5] = new City("Istanbul", 3015490, -498084);
        cityArray[6] = new City("Aarhus", 1156381, 763352);
        cityArray[7] = new City("Tallinn", 1889074, 1368933);
        return cityArray;
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
                $"{i + 1}: {Truck.MappedTruckType(listOfTrucks[i].TruckType)}   \t {Truck.MappedTruckAge(listOfTrucks[i].TruckAge)}  \t" +
                $" Standort: {Truck.MappedTruckLocation(listOfTrucks[i].TruckLocation)}  \t Perf: {listOfTrucks[i].TruckPerformance.ToString()} " +
                $"  \t max. Load: {listOfTrucks[i].TruckMaxPayload.ToString()}   \t Cons:{listOfTrucks[i].TruckConsumption.ToString()}" +
                $"   \t Preis: {listOfTrucks[i].TruckPrice:0.##}€");
        }
    }
    public static void InitializeNDrivers(int numOfDriversToCreate)
    {
        List<TruckDriver> listOfTruckers = new List<TruckDriver>();
        var (firstNames, lastNames) = DriverGenerator.LoadNamesFromFile();

        for (int i = 0; i < numOfDriversToCreate; i++)
        {
            TruckDriver driverInstance = new TruckDriver(
                NameGenerator.GenerateDriverName(firstNames, lastNames), DriverGenerator.GenerateSalary(),
                DriverGenerator.GenerateWorkingMode());
            listOfTruckers.Add(driverInstance);
        }
        TruckDriver.PrintoutDrivers(numOfDriversToCreate, listOfTruckers);
    }
    
}