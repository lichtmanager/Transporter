namespace Abgabe_1_2;

public static class Main_
{
    public static void Main(string[] args)

    {
        /*Comments
         // Call NameHelper to test, if a name looks good. 
         // NameHelper.NameSelection();
 
         // City[] cities = Initialize.InitializeCities();
 
         // City.PrintAllCities(cities);
         // City.ChooseCity(cities);
         // City.ChooseStart(cities);
         // City.ChooseEnd(cities);
         // City.CalculateAndPrintDistance(cities);
 
         // DriverGenerator.GenerateProperties();
         // Driver.InitializeNDrivers(5);
 
         // Initialize.InitializeNTrucks(5);
 
         // Initialize.InitializeNTenders(10);
         */


        Company company = GuiLogic.StartupProcess();


        GuiLogic.Navigation();
    }
}