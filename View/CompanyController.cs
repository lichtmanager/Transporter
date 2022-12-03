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
                ShowEmployedDrivers();
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

        var strokeForTruck = SelectTruck();

        var strokeForDriver = SelectDriver();

        AssignDriverToTruck(strokeForTruck, strokeForDriver);

        BusinessLogic.ClearConsoleScreen();
    }

    private static int SelectDriver()
    {
        var strokeForDriver = GetUserInputForDriver();
        CheckIf.AssignedTruckIsNull(strokeForDriver);

        return strokeForDriver;
    }


    private static int SelectTruck()
    {
        int strokeForTruck = GetUserInputForTruck();
        CheckIf.TruckDriverIsNotNull(strokeForTruck);

        return strokeForTruck;
    }


    private static int SelectTender()
    {
        int strokeForTender = GetUserInputForTender();
        CheckIf.TenderIsNull(strokeForTender);

        return strokeForTender;
    }


    private static int GetUserInputForDriver()
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

        if (strokeForDriver > StorageController.EmployedDrivers.Count)
        {
            ConsolePrintOuts.PrintOutOutOfRange();
            GetUserInputForTruck();
        }


        return strokeForDriver;
    }

    public static int GetUserInputForTruck()
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

        if (strokeForTruck > StorageController.OwnedTrucks.Count)
        {
            ConsolePrintOuts.PrintOutOutOfRange();
            GetUserInputForTruck();
        }

        return strokeForTruck;
    }

    public static int GetUserInputForTender()
    {
        Console.WriteLine("Owned Tenders");
        ConsolePrintOuts.PrintOut(StorageController.AcceptedTenders);
        Console.WriteLine(
            "Choose a tender or return to Company Actions with 0");

        int strokeForTender = BusinessLogic.GetUserInput();
        if (strokeForTender == 0)
        {
            RenderMenu();
        }

        if (strokeForTender > StorageController.AcceptedTenders.Count)
        {
            ConsolePrintOuts.PrintOutOutOfRange();
            GetUserInputForTruck();
        }

        return strokeForTender;
    }

    private static void CheckPreconditionsForTruckDriverAssignment()
    {
        CheckIf.BoughtTrucksListIsNotZero();

        CheckIf.EmployedTrucksListIsNotZero();
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
        CheckIf.TruckStatusIsNotAvailable(strokeForTruck);

        CheckIf.TruckDriverIsNotNull(strokeForTruck);


        var strokeForDriver = GetUserInputForDriver();
        CheckIf.AssignedTruckIsNotNull(strokeForDriver);

        UnassignDriverFromTruck(strokeForTruck, strokeForDriver);

        BusinessLogic.ClearConsoleScreen();
    }


    private static void AssignTenderToTruck()
    {
        CheckIf.PreconditionsForTenderAssignment();
        var indexForTenderList = SelectTender() - 1;
        var indexForTruckList = SelectTruck() - 1;

        CheckIf.TruckMatchesTenderConditions(StorageController.AcceptedTenders[indexForTenderList],
            StorageController.OwnedTrucks[indexForTruckList]);


        StorageController.OwnedTrucks[indexForTruckList].Tender =
            StorageController.AcceptedTenders[indexForTenderList];

        //ToDo abfragen und Einschränkungen fehlen

        BusinessLogic.ClearConsoleScreen();
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

        if (StorageController.OwnedTrucks[strokeForTruck - 1].TruckDriver is null)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Truck doesn't hava a Driver. Please assign a Driver and try again. ++++++++++++++");
            RenderMenu();
        }


        int strokeForCity = GetUserInputForCity();


        StorageController.OwnedTrucks[strokeForTruck - 1].Destination = StorageController.Cities[strokeForCity - 1];
        StorageController.OwnedTrucks[strokeForTruck - 1].TruckLocation = 8;
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

    private static void ShowEmployedDrivers()
    {
        ConsolePrintOuts.PrintOut(StorageController.EmployedDrivers);
        Console.WriteLine("See employed Drivers above");
    }
}