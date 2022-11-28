using Transporter.Controller;
using Transporter.Models;
using Transporter.View;

namespace Transporter;

public static class Main_
{
    public static void Main(string[] args)

    {
        /*Comments
         // Call NameSelectionController to test, if a name looks good. 
         // NameSelectionController.getUserInput();
 
         // City[] cities = Initializer.InitializeCities();
 
         // City.PrintCities(cities);
         // City.ChooseCity(cities);
         // City.ChooseStart(cities);
         // City.ChooseEnd(cities);
         // City.CalculateAndPrintDistance(cities);
 
         // DriverController.GenerateProperties();
         // Driver.InitializeNDrivers(5);
 
         // Initializer.InitializeNTrucks(5);
 
         // Initializer.InitializeNTenders(10);
         */

        // BusinessLogic.RenderMainMenu();

        City hello = CityGenerator.GenerateRandomCity();
        Console.WriteLine(hello.CityName);
    }
}