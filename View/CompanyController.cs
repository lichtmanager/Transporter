using System.Runtime.Intrinsics.Arm;
using Transporter.Controller;
using Transporter.Models;

namespace Transporter.View;

public class CompanyController
{
    public static void RenderMenu()
    {
        while (true)
        {
            Console.WriteLine("\n");
            Console.WriteLine(StorageController.Company.ToString());
            PrintOutAvailableNavOptions();
            var stroke = BusinessLogic.GetUserInput();
            DetermineActionOnMenuInput(stroke);
        }
    }

    private static void DetermineActionOnMenuInput(int stroke)
    {
        Console.WriteLine("\n");
        switch (stroke)
        {
            case 1:
                SelectTruckAndDriverForAssignment();
                break;
            case 2:
                UnassignDriverFromTruck();
                break;
            case 3:
                AssignTenderToTruck();
                break;
            case 4:
                ConsolePrintOuts.PrintOut(StorageController.OwnedTrucks);
                break;
            case 5:
                ConsolePrintOuts.PrintOut(StorageController.EmployedDrivers);
                break;
            case 0:
                BusinessLogic.RenderMainMenu();
                break;
            default:
                BusinessLogic.RenderMainMenu();
                break;
        }
    }


    private static void PrintOutAvailableNavOptions()
    {
        //ToDo Hieraus könnte man enums machen!?
        Console.Write(
            "1. Assign Driver to Truck \n2. Unassing driver from truck " +
            "\n3. Assing Tender to Truck \n4. Show bought Trucks \n5. Show emplyed Drivers \n0. Return to Main Menu \n\n");
        Console.Write("Please choose in order proceed and hit the equivalent number: ");
    }

    private static void SelectTruckAndDriverForAssignment()
    {
        CheckPreconditionsForTruckDriverAssignment();

        int strokeForTruck = GetUserInputForTruck();

        var strokeForDriver = GetUserInputForDriver(strokeForTruck);

        AssignDriverToTruck(strokeForTruck, strokeForDriver);

        BusinessLogic.ClearConsoleScreen();
    }

    private static int GetUserInputForDriver(int strokeForTruck)
    {
        Console.WriteLine("Employed Drivers");
        ConsolePrintOuts.PrintOut(StorageController.EmployedDrivers);
        Console.WriteLine("Choose a free Driver");
        int strokeForDriver = BusinessLogic.GetUserInput();

        if (StorageController.EmployedDrivers[strokeForDriver - 1].AssignedTruck != null)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Driver already is assigned to a Truck. Consider removing it first. ++++++++++++++");
            GetUserInputForTruck();
        }

        return strokeForDriver;
    }

    private static int GetUserInputForTruck()
    {
        Console.WriteLine("Owned Trucks");
        ConsolePrintOuts.PrintOut(StorageController.OwnedTrucks);
        Console.WriteLine(
            "Choose a truck to which you would like to assign a driver to or return to Company Actions with 0");

        int strokeForTruck = BusinessLogic.GetUserInput();

        if (StorageController.OwnedTrucks[strokeForTruck - 1].TruckDriver != null)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Truck already has a driver. Consider removing it first. ++++++++++++++");
            GetUserInputForTruck();
        }

        return strokeForTruck;
    }

    private static void CheckPreconditionsForTruckDriverAssignment()
    {
        if (StorageController.OwnedTrucks.Count == 0)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine("+++++++++++ You don't own any trucks+++++++++++");
            RenderMenu();
        }

        if (StorageController.EmployedDrivers.Count == 0)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine("+++++++++++ You don't have any employed drivers +++++++++++");
            RenderMenu();
        }
    }

    private static void AssignDriverToTruck(int strokeForTruck, int strokeForDriver)
    {
        int indexForTruckList = strokeForTruck - 1;
        int indexForDriverList = strokeForDriver - 1;

        StorageController.OwnedTrucks[indexForTruckList].TruckDriver =
            StorageController.EmployedDrivers[indexForDriverList];
    }

    private static void UnassignDriverFromTruck()
    {
    }

    private static void AssignTenderToTruck()
    {
    }
}