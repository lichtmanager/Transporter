using Transporter.Models;
using Transporter.View;

namespace Transporter.Controller;

public static class CheckIf
{
    public static void StrokeIsZero(int stroke)
    {
        if (stroke == 0)
        {
            BusinessLogic.ClearConsoleScreen();
            BusinessLogic.RenderMainMenu();
        }
    }

    public static void TruckDriverIsNull(int strokeForTruck)
    {
        if (StorageController.OwnedTrucks[strokeForTruck - 1].TruckDriver != null)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Truck already has a driver ++++++++++++++");
            CompanyController.GetUserInputForTruck();
        }
    }

    public static void TruckDriverIsNotNull(int strokeForTruck)
    {
        if (StorageController.OwnedTrucks[strokeForTruck - 1].TruckDriver == null)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Truck already has a driver ++++++++++++++");
            CompanyController.GetUserInputForTruck();
        }
    }

    public static void AssignedTruckIsNotNull(int strokeForDriver)
    {
        if (StorageController.EmployedDrivers[strokeForDriver - 1].AssignedTruck == null)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Driver isn't assigned to a Truck ++++++++++++++");
            CompanyController.GetUserInputForTruck();
        }
    }

    public static void TenderInTruckIsNotNull(int strokeForTender)
    {
        BusinessLogic.ClearConsoleScreen();
        Console.WriteLine(strokeForTender);
        BusinessLogic.ClearConsoleScreen();
        if (StorageController.OwnedTrucks[strokeForTender - 1].Tender != null)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Truck already has a Tender ++++++++++++++");
            CompanyController.GetUserInputForTender();
        }
    }

    public static void AssignedTruckIsNull(int strokeForDriver)
    {
        if (StorageController.EmployedDrivers[strokeForDriver - 1].AssignedTruck != null)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Driver already has an assigned Truck ++++++++++++++");
            CompanyController.GetUserInputForTruck();
        }
    }

    public static void EmployedTrucksListIsNotZero()
    {
        if (StorageController.EmployedDrivers.Count == 0)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine("+++++++++++ You don't have any employed drivers +++++++++++");
            CompanyController.RenderMenu();
        }
    }

    public static void BoughtTrucksListIsNotZero()
    {
        if (StorageController.OwnedTrucks.Count == 0)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine("+++++++++++ You don't own any trucks +++++++++++");
            CompanyController.RenderMenu();
        }
    }

    public static void TruckMatchesTenderConditions(Tender acceptedTender, Truck ownedTruck)
    {
        if (acceptedTender.Good.ReqTruckForTransport != Truck.MappedTruckType(ownedTruck.TruckType))
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine(
                $"++++++++++++++ Fehler, Typen stimmen nicht überein ({Truck.MappedTruckType(ownedTruck.TruckType)} ausgwält und {acceptedTender.Good.ReqTruckForTransport} benötigt. .++++++++++++++");
            CompanyController.RenderMenu();
        }

        if (acceptedTender.StartingCity != null && acceptedTender.StartingCity.CityName !=
            Truck.MappedTruckLocation(ownedTruck.TruckLocation))
        {
            Console.WriteLine(
                $"++++++++++++++ The truck needs to be in {acceptedTender.StartingCity.CityName} but is in" +
                $" {Truck.MappedTruckLocation(ownedTruck.TruckLocation)} right now. Consider moving it! ++++++++++++++");
            CompanyController.RenderMenu();
        }

        if (acceptedTender.Weight > ownedTruck.TruckMaxPayload)
        {
            Console.WriteLine(
                $"++++++++++++++ The actual Payload exceeds the maximum by {acceptedTender.Weight - ownedTruck.TruckMaxPayload}t ");
        }

        if (ownedTruck.TruckState != Truck.Status.Available)
        {
            Console.WriteLine($"The truck is {ownedTruck.TruckState}");
            CompanyController.RenderMenu();
        }
    }

    public static void PreconditionsForTenderAssignment()
    {
        if (StorageController.OwnedTrucks.Count == 0)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine("+++++++++++ You don't own any trucks +++++++++++");
            CompanyController.RenderMenu();
        }

        if (StorageController.EmployedDrivers.Count == 0)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine("+++++++++++ You don't have any employed drivers +++++++++++");
            CompanyController.RenderMenu();
        }

        if (StorageController.AcceptedTenders.Count == 0)
        {
            BusinessLogic.ClearConsoleScreen();
            Console.WriteLine("+++++++++++ You don't have any accepted tenders +++++++++++");
            CompanyController.RenderMenu();
        }
    }

    public static void TruckStatusIsAvailable(int strokeForTruck)
    {
        if (StorageController.OwnedTrucks[strokeForTruck - 1].TruckState != Truck.Status.Available)
        {
            Console.WriteLine(
                $"++++++++++++++ The Truck you chose is {StorageController.OwnedTrucks[strokeForTruck - 1].TruckState}. " +
                $"Try again when the Status of the Truck is <Available>. ++++++++++++++");
        }
    }
}