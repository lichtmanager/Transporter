using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using ConsoleTables;

namespace Abgabe_1_2;

public static class BusinessLogic
{
    public static void RenderMainMenu()
    {
        Console.WriteLine("\n");
        Console.WriteLine(StorageController.company.ToString());
        PrintOutAvailableNavOptions();
        var stroke = GetUserInput();
        DetermineActionOnNavigationInput(stroke);
    }

    private static void DetermineActionOnNavigationInput(int stroke)
    {
        Console.WriteLine("\n");
        switch (stroke)
        {
            case 1:
                SelectTruck();
                break;
            case 2:
                SelectDriver();
                break;
            case 3:
                SelectTender();
                break;
            case 4:
                EndDay();
                break;
            default:
                RenderMainMenu();
                break;
        }
    }

    public static void EndDay()
    {
        StorageController.company.Date = StorageController.company.Date.AddDays(1);
        ClearConsoleScreen();
        RenderMainMenu();
    }

    private static void SelectTruck()
    {
        if (StorageController.availTrucks.Count > 0)
        {
            Console.WriteLine("Trucks");
            Console.WriteLine("Choose the truck to buy or return to RenderMainMenu with 0");

            Truck.PrintOut(StorageController.availTrucks);

            int stroke = GetUserInput();
            Truck.HandlePurchase(stroke);
            ClearConsoleScreen();
            RenderMainMenu();
        }
        else
        {
            ClearConsoleScreen();
            System.Console.WriteLine("+++++++++++ There are no more trucks to buy +++++++++++");
            for (int i = 0; i < 5; i++)
            {
                System.Console.WriteLine();
            }

            RenderMainMenu();
        }
    }

    private static void SelectDriver()
    {
        Console.WriteLine("Drivers");
        if (StorageController.availDrivers.Count > 0)
        {
            System.Console.WriteLine("Choose the Driver to employ or return to RenderMainMenu with 0");
            Driver.PrintOut(StorageController.availDrivers);
            int stroke = GetUserInput();
            Driver.HandleEmployment(stroke);
            ClearConsoleScreen();
            RenderMainMenu();
        }
        else
        {
            ClearConsoleScreen();
            System.Console.WriteLine("+++++++++++ There are no more Drivers to employ +++++++++++");
            for (int i = 0; i < 5; i++)
            {
                System.Console.WriteLine();
            }

            RenderMainMenu();
        }
    }

    private static void SelectTender()
    {
        Console.WriteLine("Tender");
        if (StorageController.availTenders.Count > 0)
        {
            System.Console.WriteLine("Choose the Tender to accept or return to RenderMainMenu with 0");
            Tender.PrintOut(StorageController.availTenders);
            int stroke = GetUserInput();
            Tender.HandlePurchase(stroke);
            ClearConsoleScreen();
            RenderMainMenu();
        }
        else
        {
            ClearConsoleScreen();
            System.Console.WriteLine("+++++++++++ There are no more Tenders to accept +++++++++++");
            for (int i = 0; i < 5; i++)
            {
                System.Console.WriteLine();
            }

            RenderMainMenu();
        }
    }

    private static void PrintOutAvailableNavOptions()
    {
        Console.Write("1. Buy Truck \n2. Hire Driver \n3. Accept Tenders \n4. End tour\n");
        Console.Write("Please choose in order proceed and hit the equivalent number: ");
    }

    private static int GetUserInput()
    {
        var userInput = System.Console.ReadKey(true);
        try
        {
            int stroke = int.Parse(userInput.KeyChar.ToString());
            return stroke;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(
                "An error occured. You might have not pressed a number. Please hit a number key: ");
            GetUserInput();
            throw;
        }
    }

    private static void ClearConsoleScreen()
    {
        for (int i = 0; i < 20; i++)
        {
            System.Console.WriteLine();
        }
    }
}