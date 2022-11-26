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
                SelectTruckAndDriverForUnassignment();
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
            case 6:
                GetUserInputForTruckDestination();
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
            "\n3. Assing Tender to Truck \n4. Show bought Trucks \n5. Show emplyed Drivers \n6. Move Truck to location \n0. Return to Main Menu \n\n");
        Console.Write("Please choose in order proceed and hit the equivalent number: ");
    }

    // -----------------------------------------------------------------------------------------------------------------

    private static void SelectTruckAndDriverForAssignment()
    {
        CheckPreconditionsForTruckDriverAssignment();

        int strokeForTruck = GetUserInputForTruck();
        if (StorageController.OwnedTrucks[strokeForTruck - 1].TruckDriver != null)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Truck already has a driver. Consider removing it first. ++++++++++++++");
            GetUserInputForTruck();
        }

        var strokeForDriver = GetUserInputForDriver(strokeForTruck);
        if (StorageController.EmployedDrivers[strokeForDriver - 1].AssignedTruck != null)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Driver already is assigned to a Truck. Consider removing it first. ++++++++++++++");
            GetUserInputForTruck();
        }

        AssignDriverToTruck(strokeForTruck, strokeForDriver);

        BusinessLogic.ClearConsoleScreen();
    }

    private static int GetUserInputForDriver(int strokeForTruck)
    {
        Console.WriteLine("Employed Drivers");
        ConsolePrintOuts.PrintOut(StorageController.EmployedDrivers);
        Console.WriteLine(
            "Choose a Driver to/from which you would like to (un)assign a Truck or return to Company Actions with 0");
        int strokeForDriver = BusinessLogic.GetUserInput();

        if (strokeForDriver == 0)
        {
            RenderMenu();
        }


        return strokeForDriver;
    }

    private static int GetUserInputForTruck()
    {
        Console.WriteLine("Owned Trucks");
        ConsolePrintOuts.PrintOut(StorageController.OwnedTrucks);
        Console.WriteLine(
            "Choose a truck or return to Company Actions with 0");

        int strokeForTruck = BusinessLogic.GetUserInput();
        if (strokeForTruck == 0)
        {
            RenderMenu();
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
        StorageController.EmployedDrivers[indexForDriverList].AssignedTruck =
            StorageController.OwnedTrucks[indexForTruckList];
    }

    private static void UnassignDriverFromTruck(int strokeForTruck, int strokeForDriver)
    {
        int indexForTruckList = strokeForTruck - 1;
        int indexForDriverList = strokeForDriver - 1;

        StorageController.OwnedTrucks[indexForTruckList].TruckDriver = null;
        StorageController.EmployedDrivers[indexForDriverList].AssignedTruck = null;
    }

    private static void SelectTruckAndDriverForUnassignment()
    {
        CheckPreconditionsForTruckDriverAssignment();

        int strokeForTruck = GetUserInputForTruck();
        if (StorageController.OwnedTrucks[strokeForTruck - 1].TruckState != Truck.Status.Available)
        {
            Console.WriteLine(
                "++++++++++++++ The Truck you chose is not available for this action. Try again when the Status of the Truck is <Available>. ++++++++++++++");
        }

        if (StorageController.OwnedTrucks[strokeForTruck - 1].TruckDriver is null)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Truck doesn't have a driver. ++++++++++++++");
            GetUserInputForTruck();
        }

        var strokeForDriver = GetUserInputForDriver(strokeForTruck);
        if (StorageController.EmployedDrivers[strokeForDriver - 1].AssignedTruck != null)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Driver isn't assigned to a Truck. ++++++++++++++");
            GetUserInputForTruck();
        }

        UnassignDriverFromTruck(strokeForTruck, strokeForDriver);

        BusinessLogic.ClearConsoleScreen();
    }

    private static void AssignTenderToTruck()
    {
    }

    private static void GetUserInputForTruckDestination()
    {
        if (StorageController.OwnedTrucks.Count == 0)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine("+++++++++++ You don't own any trucks you could move. +++++++++++");
            RenderMenu();
        }


        int strokeForTruck = GetUserInputForTruck();
        if (StorageController.OwnedTrucks[strokeForTruck - 1].TruckState != Truck.Status.Available)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine(
                "+++++++++++ The Truck you chose is not up for disposal. +++++++++++");
            RenderMenu();
        }

        int strokeForCity = GetUserInputForCity();

        StorageController.OwnedTrucks[strokeForTruck - 1].Destination = StorageController.Cities[strokeForCity - 1];
    }

    private static int GetUserInputForCity()
    {
        Console.WriteLine();
        ConsolePrintOuts.PrintCities(StorageController.Cities);
        Console.WriteLine("Choose the City the truck should move to or return to Company actions with 0");

        int strokeForCity = BusinessLogic.GetUserInput();
        if (strokeForCity == 0)
        {
            RenderMenu();
        }

        return strokeForCity;
    }
}