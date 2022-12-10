using Transporter.Models;
using Transporter.View;

namespace Transporter.Controller;

public static class CheckIf
{
    public static void StrokeIsZero(int stroke)
    {
        if (stroke == 0)
        {
            ConsolePrintOuts.ClearConsoleScreen();
            BusinessLogic.RenderMainMenu();
        }
    }

    public static void TruckDriverIsNull(int strokeForTruck)
    {
        if (StorageController.OwnedTrucks[strokeForTruck - 1].TruckDriver != null)
        {
            ConsolePrintOuts.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Truck already has a driver ++++++++++++++");
            CompanyActions.GetUserInputForTruck();
        }
    }

    public static void TruckDriverIsNotNull(int strokeForTruck)
    {
        if (StorageController.OwnedTrucks[strokeForTruck - 1].TruckDriver == null)
        {
            ConsolePrintOuts.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Truck already has a driver ++++++++++++++");
            CompanyActions.GetUserInputForTruck();
        }
    }

    public static void AssignedTruckIsNotNull(int strokeForDriver)
    {
        if (StorageController.EmployedDrivers[strokeForDriver - 1].AssignedTruck == null)
        {
            ConsolePrintOuts.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Driver isn't assigned to a Truck ++++++++++++++");
            CompanyActions.GetUserInputForTruck();
        }
    }

    public static void TenderInTruckIsNotNull(int strokeForTender)
    {
        ConsolePrintOuts.ClearConsoleScreen();
        Console.WriteLine(strokeForTender);
        ConsolePrintOuts.ClearConsoleScreen();
        if (StorageController.OwnedTrucks[strokeForTender - 1].Tender != null)
        {
            ConsolePrintOuts.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Truck already has a Tender ++++++++++++++");
            CompanyActions.GetUserInputForTender();
        }
    }

    public static void AssignedTruckIsNull(int strokeForDriver)
    {
        if (StorageController.EmployedDrivers[strokeForDriver - 1].AssignedTruck != null)
        {
            ConsolePrintOuts.ClearConsoleScreen();
            Console.WriteLine(
                "++++++++++++++ The Driver already has an assigned Truck ++++++++++++++");
            CompanyActions.GetUserInputForTruck();
        }
    }

    public static void EmployedTrucksListIsNotZero()
    {
        if (StorageController.EmployedDrivers.Count == 0)
        {
            ConsolePrintOuts.ClearConsoleScreen();
            Console.WriteLine("+++++++++++ You don't have any employed drivers +++++++++++");
            CompanyActions.RenderMenu();
        }
    }

    public static void BoughtTrucksListIsNotZero()
    {
        if (StorageController.OwnedTrucks.Count == 0)
        {
            ConsolePrintOuts.ClearConsoleScreen();
            Console.WriteLine("+++++++++++ You don't own any trucks +++++++++++");
            CompanyActions.RenderMenu();
        }
    }

    public static void TruckMatchesTenderConditions(Tender acceptedTender, Truck ownedTruck)
    {
        if (acceptedTender.Good.ReqTruckForTransport != Truck.MappedTruckType(ownedTruck.TruckType))
        {
            ConsolePrintOuts.ClearConsoleScreen();
            Console.WriteLine(
                $"++++++++++++++ Fehler, Typen stimmen nicht überein ({Truck.MappedTruckType(ownedTruck.TruckType)} ausgwält und {acceptedTender.Good.ReqTruckForTransport} benötigt. .++++++++++++++");
            CompanyActions.RenderMenu();
        }

        if (acceptedTender.StartingCity != null && acceptedTender.StartingCity.CityName !=
            Truck.MappedTruckLocation(ownedTruck.TruckLocation))
        {
            Console.WriteLine(
                $"++++++++++++++ The truck needs to be in {acceptedTender.StartingCity.CityName} but is in" +
                $" {Truck.MappedTruckLocation(ownedTruck.TruckLocation)} right now. Consider moving it! ++++++++++++++");
            CompanyActions.RenderMenu();
        }

        if (acceptedTender.Weight > ownedTruck.TruckMaxPayload)
        {
            Console.WriteLine(
                $"++++++++++++++ The actual Payload exceeds the maximum by {acceptedTender.Weight - ownedTruck.TruckMaxPayload}t ");
        }

        if (ownedTruck.TruckState != Truck.Status.Available)
        {
            Console.WriteLine($"The truck is {ownedTruck.TruckState}");
            CompanyActions.RenderMenu();
        }

        if (acceptedTender.Truck != null)
        {
            Console.WriteLine("The Tender already is assigned to another truck!");
            CompanyActions.RenderMenu();
            
        }
    }

    public static void PreconditionsForTenderAssignment()
    {
        if (StorageController.OwnedTrucks.Count == 0)
        {
            ConsolePrintOuts.ClearConsoleScreen();
            Console.WriteLine("+++++++++++ You don't own any trucks +++++++++++");
            CompanyActions.RenderMenu();
        }

        if (StorageController.EmployedDrivers.Count == 0)
        {
            ConsolePrintOuts.ClearConsoleScreen();
            Console.WriteLine("+++++++++++ You don't have any employed drivers +++++++++++");
            CompanyActions.RenderMenu();
        }

        if (StorageController.AcceptedTenders.Count == 0)
        {
            ConsolePrintOuts.ClearConsoleScreen();
            Console.WriteLine("+++++++++++ You don't have any accepted tenders +++++++++++");
            CompanyActions.RenderMenu();
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

    internal static void ArrivalDateWasReached()
    {
        foreach (var truck in StorageController.OwnedTrucks)
        {
            if (truck.ArrivalDate == DateTime.Today)
            {
                truck.TruckState = Truck.Status.Available;
                truck.ArrivalDate = null;
            }   
        }
    }
}