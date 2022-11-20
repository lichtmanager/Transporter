using Transporter.Controller;
using Transporter.Models;

namespace Transporter.View;

public static class BusinessLogic
{
    public static void RenderMainMenu()
    {
        Console.WriteLine("\n");
        Console.WriteLine(StorageController.company.ToString());
        PrintOutAvailableNavOptions();
        var stroke = GetUserInput();
        DetermineActionOnMenuInput(stroke);
        RenderMainMenu();
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
            Truck.PrintOut(StorageController.availTrucks);
            Console.WriteLine("Choose the truck to buy or return to RenderMainMenu with 0");

            int stroke = GetUserInput();
            PurchaseTruck(stroke);
            ClearConsoleScreen();
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
            Driver.PrintOut(StorageController.availDrivers);
            Console.WriteLine("Choose the Driver to employ or return to RenderMainMenu with 0");
            int stroke = GetUserInput();
            EmployDriver(stroke);
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
            Tender.PrintOut(StorageController.availTenders);
            Console.WriteLine("Choose the Tender to accept or return to RenderMainMenu with 0");
            int stroke = GetUserInput();
            AcceptTender(stroke);
            ClearConsoleScreen();
            RenderMainMenu();
        }
        else
        {
            ClearConsoleScreen();
            Console.WriteLine("+++++++++++ There are no more Tenders to accept +++++++++++");
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
        var userInput = Console.ReadKey(true);
        try
        {
            int stroke = int.Parse(userInput.KeyChar.ToString());
            return stroke;
        }
        catch (Exception e)
        {
            Console.WriteLine(
                "An error occured. You might have not pressed a number. Please hit a number key: ");
            GetUserInput();
            throw;
        }
    }

    public static void ClearConsoleScreen()
    {
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine();
        }
    }


    public static void PurchaseTruck(int stroke)
    {
        int indexForList = stroke - 1;
        if (stroke == 0)
        {
            BusinessLogic.RenderMainMenu();
        }

        if (indexForList >= StorageController.availTrucks.Count)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine(
                "Nopes, definitely the wrong number. Try again with one inside the offered range ¯\\_(ツ)_/¯");
            BusinessLogic.RenderMainMenu();
        }

        StorageController.ownedTrucks.Add((StorageController.availTrucks[indexForList]));

        StorageController.company.Balance -= StorageController.availTrucks[indexForList].TruckPrice;

        StorageController.availTrucks.Remove(StorageController.availTrucks[indexForList]);
    }

    public static void AcceptTender(int stroke)
    {
        if (stroke == 0)
        {
            BusinessLogic.RenderMainMenu();
        }

        int listIndex = stroke - 1;

        if (listIndex >= StorageController.availTenders.Count)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine(
                "Nopes, definitely the wrong number. Try again with one inside the offered range ¯\\_(ツ)_/¯");
            BusinessLogic.RenderMainMenu();
        }


        StorageController.ownedTenders.Add((StorageController.availTenders[listIndex]));

        StorageController.availTenders.Remove(StorageController.availTenders[listIndex]);
    }

    public static void EmployDriver(int stroke)
    {
        if (stroke == 0)
        {
            BusinessLogic.RenderMainMenu();
        }

        int indexForList = stroke - 1;

        if (indexForList >= StorageController.availDrivers.Count)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine(
                "Nopes, definitely the wrong number. Try again with one inside the offered range ¯\\_(ツ)_/¯");
            BusinessLogic.RenderMainMenu();
        }

        StorageController.ownedDrivers.Add(StorageController.availDrivers[indexForList]);
        StorageController.availDrivers.Remove(StorageController.availDrivers[indexForList]);
    }
}