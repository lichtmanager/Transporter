using Transporter.Controller;
using Transporter.Models;

namespace Transporter.View;

public static class CompanyActions
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
                SelectTenderAndTruckForAssignment();
                break;
            case 4:
                ConsolePrintOuts.PrintOut(StorageController.OwnedTrucks);
                Console.WriteLine("Owned Trucks");
                break;
            case 5:
                ShowEmployedDrivers();
                break;
            case 6:
                GetUserInputToMoveTruckToDestination();
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
            "\n3. Assing Tender to Truck \n4. Show bought Trucks \n5. Show employed Drivers \n6. Move Truck to location \n0. Return to Main Menu \n\n");
        Console.Write("Please choose in order proceed and hit the equivalent number: ");
    }
// -----------------------------------------------------------------------------------------------------------------------

    private static void SelectTruckAndDriverForAssignment()
    {
        CheckIf.BoughtTrucksListIsNotZero();
        CheckIf.EmployedTrucksListIsNotZero();

        var strokeForTruck = SelectTruck();
        CheckIf.TruckDriverIsNull(strokeForTruck);

        var strokeForDriver = SelectDriver();
        CheckIf.AssignedTruckIsNull(strokeForDriver);

        AssignDriverToTruck(strokeForTruck, strokeForDriver);

        ConsolePrintOuts.ClearConsoleScreen();
    }

    private static void SelectTruckAndDriverForUnassignment()
    {
        CheckIf.BoughtTrucksListIsNotZero();
        CheckIf.EmployedTrucksListIsNotZero();

        int strokeForTruck = GetUserInputForTruck();
        CheckIf.TruckStatusIsAvailable(strokeForTruck);

        CheckIf.TruckDriverIsNotNull(strokeForTruck);


        var strokeForDriver = GetUserInputForDriver();
        CheckIf.AssignedTruckIsNotNull(strokeForDriver);

        UnassignDriverFromTruck(strokeForTruck, strokeForDriver);

        ConsolePrintOuts.ClearConsoleScreen();
    }

    private static void SelectTenderAndTruckForAssignment()
    {
        CheckIf.PreconditionsForTenderAssignment();
        var indexForTenderList = SelectTender() - 1;
        var indexForTruckList = SelectTruck() - 1;

        CheckIf.TruckMatchesTenderConditions(StorageController.AcceptedTenders[indexForTenderList],
            StorageController.OwnedTrucks[indexForTruckList]);

        var truck = StorageController.OwnedTrucks[indexForTruckList];
        var tender = StorageController.AcceptedTenders[indexForTenderList];


        int distance = City.CalculateDistance(tender.StartingCity, tender.EndingCity);
        int travelTime = TruckActions.CalculateTravelTimeInHours(distance, truck, tender);
        int avgSpeed = TruckActions.SpeedOfTruck(truck, tender);
        DateTime arrivalDate = TruckActions.CalculateArrivalDate(travelTime);

        AssignTenderToTruck(truck, tender, arrivalDate, avgSpeed);
    }


    private static int SelectDriver()
    {
        var strokeForDriver = GetUserInputForDriver();

        return strokeForDriver;
    }

    private static int SelectTruck()
    {
        int strokeForTruck = GetUserInputForTruck();

        return strokeForTruck;
    }

    private static int SelectTender()
    {
        int strokeForTender = GetUserInputForTender();
        //  CheckIf.TenderInTruckIsNotNull(strokeForTender);

        return strokeForTender;
    }


    private static int GetUserInputForDriver()
    {
        ConsolePrintOuts.PrintOut(StorageController.EmployedDrivers);

        Console.WriteLine("Employed Drivers");
        Console.WriteLine(
            "Choose a Driver to/from which you would like to (un)assign a Truck or return to Company Actions with 0");
        Console.WriteLine();

        int strokeForDriver = BusinessLogic.GetUserInput();
        if (strokeForDriver == 0)
        {
            RenderMenu();
        }

        if (strokeForDriver > StorageController.EmployedDrivers.Count)
        {
            ConsolePrintOuts.OutOfRange();
            GetUserInputForTruck();
        }


        return strokeForDriver;
    }

    public static int GetUserInputForTruck()
    {
        ConsolePrintOuts.PrintOut(StorageController.OwnedTrucks);

        Console.WriteLine("Owned Trucks");
        Console.WriteLine(
            "Choose a truck or return to Company Actions with 0");
        Console.WriteLine();

        int strokeForTruck = BusinessLogic.GetUserInput();
        if (strokeForTruck == 0)
        {
            RenderMenu();
        }

        if (strokeForTruck > StorageController.OwnedTrucks.Count)
        {
            ConsolePrintOuts.OutOfRange();
            GetUserInputForTruck();
        }

        return strokeForTruck;
    }

    public static int GetUserInputForTender()
    {
        ConsolePrintOuts.PrintOut(StorageController.AcceptedTenders);

        Console.WriteLine("Owned Tenders");
        Console.WriteLine(
            "Choose a tender or return to Company Actions with 0");
        Console.WriteLine();

        int strokeForTender = BusinessLogic.GetUserInput();
        if (strokeForTender == 0)
        {
            RenderMenu();
        }

        if (strokeForTender > StorageController.AcceptedTenders.Count)
        {
            ConsolePrintOuts.OutOfRange();
            GetUserInputForTruck();
        }

        return strokeForTender;
    }

    private static void GetUserInputToMoveTruckToDestination()
    {
        if (StorageController.OwnedTrucks.Count == 0)
        {
            ConsolePrintOuts.ClearConsoleScreen();
            Console.WriteLine("+++++++++++ You don't own any trucks you could move. +++++++++++");
            RenderMenu();
        }

        int strokeForTruck = GetUserInputForTruck();

        if (StorageController.OwnedTrucks[strokeForTruck - 1].TruckState != Truck.Status.Available)
        {
            ConsolePrintOuts.ClearConsoleScreen();
            Console.WriteLine(
                "+++++++++++ The Truck you chose is not up for disposal. +++++++++++");
            RenderMenu();
        }

        if (StorageController.OwnedTrucks[strokeForTruck - 1].TruckDriver is null)
        {
            ConsolePrintOuts.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Truck doesn't hava a Driver. Please assign a Driver and try again. ++++++++++++++");
            RenderMenu();
        }


        int strokeForCity = GetUserInputForCity();


        SetTruckDestination(strokeForTruck, strokeForCity);
    }

    private static void SetTruckDestination(int strokeForTruck, int strokeForCity)
    {
        StorageController.OwnedTrucks[strokeForTruck - 1].Destination = StorageController.Cities[strokeForCity - 1];
        StorageController.OwnedTrucks[strokeForTruck - 1].TruckLocation = 8;
        StorageController.OwnedTrucks[strokeForTruck - 1].TruckState = Truck.Status.Moving;
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


    internal static void AssignDriverToTruck(int strokeForTruck, int strokeForDriver)
    {
        int indexForTruckList = strokeForTruck - 1;
        int indexForDriverList = strokeForDriver - 1;

        StorageController.OwnedTrucks[indexForTruckList].TruckDriver =
            StorageController.EmployedDrivers[indexForDriverList];
        StorageController.EmployedDrivers[indexForDriverList].AssignedTruck =
            StorageController.OwnedTrucks[indexForTruckList];
    }

    internal static void UnassignDriverFromTruck(int strokeForTruck, int strokeForDriver)
    {
        int indexForTruckList = strokeForTruck - 1;
        int indexForDriverList = strokeForDriver - 1;

        StorageController.OwnedTrucks[indexForTruckList].TruckDriver = null;
        StorageController.EmployedDrivers[indexForDriverList].AssignedTruck = null;
    }

    public static void AssignTenderToTruck(Truck truck, Tender tender, DateTime arrivalDate, int avgSpeed)
    {
        truck.Tender = tender;
        truck.TruckState = Truck.Status.Booked;
        tender.Truck = truck;
        truck.Destination = tender.EndingCity;
        truck.AvgSpeed = avgSpeed;
        truck.ArrivalDate = arrivalDate;
    }


    private static void ShowEmployedDrivers()
    {
        ConsolePrintOuts.PrintOut(StorageController.EmployedDrivers);
        Console.WriteLine("See employed Drivers above");
        Console.WriteLine();
    }
}