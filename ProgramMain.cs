namespace Abgabe_1_2;

public class ProgramMain
{
    public static void Main(string[] args)

    {
        // Call NameHelper to test, if a name looks good. 
        NameHelper.NameTester();

        City[] cities = Initialice.InitialiceCities();

        // City.PrintAllCities(cities);
        // City.ChooseCity(cities);
        // City.ChooseStart(cities);
        // City.ChooseEnd(cities);
        // City.CalculateAndPrintDistance(cities);

        // Driver.GenerateProperties();
        TruckDriver.InitializeNDrivers(5);

        Truck.InitializeNewTrucks(5);
    }
}