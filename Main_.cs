namespace Abgabe_1_2;

public static class Main_
{
    public static void Main(string[] args)

    {
        // Call NameHelper to test, if a name looks good. 
        // NameHelper.NameTester();

        // City[] cities = Initialize.InitializeCities();

        // City.PrintAllCities(cities);
        // City.ChooseCity(cities);
        // City.ChooseStart(cities);
        // City.ChooseEnd(cities);
        // City.CalculateAndPrintDistance(cities);

        // DriverGenerator.GenerateProperties();
        // Driver.InitializeNDrivers(5);

        // Initialize.InitializeNewTrucks(5);

        for (int i = 0; i < 15; i++)
        {
            GoodsPropertiesGenerator.RandomTypesGeneratorMappedToTruckType();
        }
    }
}