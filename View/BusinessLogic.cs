using Transporter.Controller;
using Transporter.Models;

namespace Transporter.View;

public static class BusinessLogic
{
    public static void RenderMainMenu()
    {
        do
        {
            Console.WriteLine("\n");
            Console.WriteLine(StorageController.company.ToString());
            PrintOutAvailableNavOptions();
            var stroke = GetUserInput();
            DetermineActionOnMenuInput(stroke);
        } while (true);
    }

    private static void DetermineActionOnMenuInput(int stroke)
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
                RenderMainMenu();
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
    }

    private static void SelectTruck()
    {
        if (StorageController.availTrucks.Count > 0)
        {
            Console.WriteLine("Trucks");
            ConsolePrintOuts.PrintOut(StorageController.availTrucks);
            Console.WriteLine("Choose the truck to buy or return to RenderMainMenu with 0");

            int stroke = GetUserInput();
            PurchaseTruck(stroke);
            ClearConsoleScreen();
        }
        else
        {
            ClearConsoleScreen();
            Console.WriteLine("+++++++++++ There are no more trucks to buy +++++++++++");
        }
    }

    private static void SelectDriver()
    {
        Console.WriteLine("Drivers");
        if (StorageController.availDrivers.Count > 0)
        {
            ConsolePrintOuts.PrintOut(StorageController.availDrivers);
            Console.WriteLine("Choose the Driver to employ or return to RenderMainMenu with 0");
            int stroke = GetUserInput();
            EmployDriver(stroke);
            ClearConsoleScreen();
        }
        else
        {
            ClearConsoleScreen();
            Console.WriteLine("+++++++++++ There are no more Drivers to employ +++++++++++");
        }
    }

    private static void SelectTender()
    {
        Console.WriteLine("Tender");
        if (StorageController.availTenders.Count > 0)
        {
            ConsolePrintOuts.PrintOut(StorageController.availTenders);
            Console.WriteLine("Choose the Tender to accept or return to the main menu with 0");
            int stroke = GetUserInput();
            AcceptTender(stroke);
            ClearConsoleScreen();
        }
        else
        {
            ClearConsoleScreen();
            Console.WriteLine("+++++++++++ There are no more Tenders to accept +++++++++++");
        }
    }

    private static void PrintOutAvailableNavOptions()
    {
        Console.Write("1. Buy Truck \n2. Hire Driver \n3. Accept Tenders \n4. End tour\n");
        Console.Write("Please choose in order proceed and hit the equivalent number: ");
    }

    private static int GetUserInput()
    {
        var userInput = Console.ReadKey(true);
        try
        {
            int stroke = int.Parse(userInput.KeyChar.ToString());
            return stroke;
        }
        catch (Exception)
        {
            Console.WriteLine(
                "An error occured. You might have not pressed a number. Please hit a number key: ");
            RenderMainMenu();
            throw;
        }
    }

    private static void ClearConsoleScreen()
    {
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine();
        }
    }

    public static void PurchaseTruck(int stroke)
    {
        int indexForList = stroke - 1;
        CheckIfStrokeIsZero(stroke);

        if (indexForList >= StorageController.availTrucks.Count)
        {
            DisplayOutOfRangeMessage();
            RenderMainMenu();
        }

        StorageController.ownedTrucks.Add((StorageController.availTrucks[indexForList]));

        StorageController.company.Balance -= StorageController.availTrucks[indexForList].TruckPrice;

        StorageController.availTrucks.Remove(StorageController.availTrucks[indexForList]);
    }

    public static void AcceptTender(int stroke)
    {
        CheckIfStrokeIsZero(stroke);

        int listIndex = stroke - 1;

        if (listIndex >= StorageController.availTenders.Count)
        {
            DisplayOutOfRangeMessage();
            RenderMainMenu();
        }


        StorageController.ownedTenders.Add((StorageController.availTenders[listIndex]));

        StorageController.availTenders.Remove(StorageController.availTenders[listIndex]);
    }

    public static void EmployDriver(int stroke)
    {
        CheckIfStrokeIsZero(stroke);

        int indexForList = stroke - 1;

        if (indexForList >= StorageController.availDrivers.Count)
        {
            DisplayOutOfRangeMessage();
            RenderMainMenu();
        }

        StorageController.ownedDrivers.Add(StorageController.availDrivers[indexForList]);
        StorageController.availDrivers.Remove(StorageController.availDrivers[indexForList]);
    }

    private static void CheckIfStrokeIsZero(int stroke)
    {
        if (stroke == 0)
        {
            ClearConsoleScreen();
            RenderMainMenu();
        }
    }

    private static void DisplayOutOfRangeMessage()
    {
        ClearConsoleScreen();
        Console.WriteLine(
            "Nopes, definitely the wrong number. Try again with one inside the offered range ¯\\_(ツ)_/¯");
    }
}