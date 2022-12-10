using Transporter.Controller;
using Transporter.Models;

namespace Transporter.View;

public static class BusinessLogic
{
    private static readonly bool _runProgram = true;

    public static void RenderMainMenu()
    {
        do
        {
            Console.WriteLine("\n");
            Console.WriteLine(StorageController.Company.ToString());
            PrintOutAvailableNavOptions();
            var stroke = GetUserInput();
            DetermineActionOnMenuInput(stroke);
        } while (_runProgram);
    }

    private static void PrintOutAvailableNavOptions()
    {
        Console.Write(
            "1. Buy Truck \n2. Hire Driver \n3. Accept Tenders \n4. End tour\n5. Show Company Resources \n0. End Program \n\n");
        Console.Write("Please choose in order proceed and hit the equivalent number: ");
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
            case 5:
                CompanyActions.RenderMenu();
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                RenderMainMenu();
                break;
        }
    }

    public static void EndDay()
    {
        foreach (var truck in StorageController.OwnedTrucks)
        {
            CheckIf.ArrivalDateWasReached();
            // truck.TruckState = Truck.Status.Available;

            if (Truck.MappedTruckLocation(truck.TruckLocation) == "")
            {
                if (truck.Destination != null) truck.TruckLocation = Truck.MapCityToTruckLocation(truck.Destination);
                truck.Destination = null;
            }
        }

        StorageController.Company.Date = StorageController.Company.Date.AddDays(1);
        ConsolePrintOuts.ClearConsoleScreen();
    }

    private static void SelectTruck()
    {
        if (StorageController.AvailTrucks.Count > 0)
        {
            Console.WriteLine("Trucks");
            ConsolePrintOuts.PrintOut(StorageController.AvailTrucks);
            Console.WriteLine("Choose the truck to buy or return to RenderMainMenu with 0");

            var stroke = GetUserInput();
            PurchaseTruck(stroke);
            ConsolePrintOuts.ClearConsoleScreen();
        }
        else
        {
            ConsolePrintOuts.ClearConsoleScreen();
            Console.WriteLine("+++++++++++ There are no more trucks to buy +++++++++++");
        }
    }

    private static void SelectDriver()
    {
        Console.WriteLine("Drivers");
        if (StorageController.AvailDrivers.Count > 0)
        {
            ConsolePrintOuts.PrintOut(StorageController.AvailDrivers);
            Console.WriteLine("Choose the Driver to employ or return to RenderMainMenu with 0");
            var stroke = GetUserInput();
            EmployDriver(stroke);
            ConsolePrintOuts.ClearConsoleScreen();
        }
        else
        {
            ConsolePrintOuts.ClearConsoleScreen();
            Console.WriteLine("+++++++++++ There are no more Drivers to employ +++++++++++");
        }
    }

    private static void SelectTender()
    {
        Console.WriteLine("Tender");
        if (StorageController.AvailTenders.Count > 0)
        {
            ConsolePrintOuts.PrintOut(StorageController.AvailTenders);
            Console.WriteLine("Choose the Tender to accept or return to the main menu with 0");
            var stroke = GetUserInput();
            AcceptTender(stroke);
            ConsolePrintOuts.ClearConsoleScreen();
        }
        else
        {
            ConsolePrintOuts.ClearConsoleScreen();
            Console.WriteLine("+++++++++++ There are no more Tenders to accept +++++++++++");
        }
    }

    public static int GetUserInput()
    {
        var userInput = Console.ReadKey(false);
        try
        {
            var stroke = int.Parse(userInput.KeyChar.ToString());
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

    public static void PurchaseTruck(int stroke)
    {
        var indexForList = stroke - 1;
        CheckIf.StrokeIsZero(stroke);

        if (stroke > StorageController.AvailTrucks.Count)
        {
            ConsolePrintOuts.DisplayOutOfRangeMessage();
            RenderMainMenu();
        }

        StorageController.OwnedTrucks.Add(StorageController.AvailTrucks[indexForList]);

        StorageController.Company.Balance -= StorageController.AvailTrucks[indexForList].TruckPrice;

        StorageController.AvailTrucks.Remove(StorageController.AvailTrucks[indexForList]);
    }

    public static void AcceptTender(int stroke)
    {
        CheckIf.StrokeIsZero(stroke);

        var listIndex = stroke - 1;

        if (stroke > StorageController.AvailTenders.Count)
        {
            ConsolePrintOuts.DisplayOutOfRangeMessage();
            RenderMainMenu();
        }


        StorageController.AcceptedTenders.Add(StorageController.AvailTenders[listIndex]);

        StorageController.AvailTenders.Remove(StorageController.AvailTenders[listIndex]);
    }

    public static void EmployDriver(int stroke)
    {
        CheckIf.StrokeIsZero(stroke);

        var indexForList = stroke - 1;

        if (stroke > StorageController.AvailDrivers.Count)
        {
            ConsolePrintOuts.DisplayOutOfRangeMessage();
            RenderMainMenu();
        }

        StorageController.EmployedDrivers.Add(StorageController.AvailDrivers[indexForList]);
        StorageController.AvailDrivers.Remove(StorageController.AvailDrivers[indexForList]);
    }

    // -----------------------------------------------------------------------------------------------------------------
}