using ConsoleTables;
using Transporter.Controller;
using Transporter.Models;

namespace Transporter.View;

using Transporter.Controller;
using Transporter.View;

public static class ConsolePrintOuts
{
    public static void PrintCities(City?[] cities)
    {
        for (var i = 0; i < cities.Length; i++)
        {
            Console.WriteLine((i + 1) + " " + cities[i]?.CityName);
        }
    }

    public static void PrintStartEnd(City[] cities)
    {
        System.Console.WriteLine(City.ChooseStartCity(cities).CityName);
        System.Console.WriteLine(City.ChooseEndCity(cities).CityName);
    }

    public static void PrintOut(List<Driver> drivers)
    {
        var table = new ConsoleTable("#", "Name", "Salary", "WorkingMode", "Assigned Truck");
        for (int i = 0; i < drivers.Count; i++)
        {
            table.AddRow(
                $"{i + 1}",
                $"{drivers[i].TruckerName}",
                $"{drivers[i].Salary:C}",
                $"{Driver.MappedWorkingMode(drivers[i].WorkingMode)}",
                $"{Truck.MappedTruckType(drivers[i].AssignedTruck?.TruckType)} {drivers[i].AssignedTruck?.TruckAge}");
        }

        table.Write();
        Console.WriteLine();
    }

    public static void PrintOut(List<Tender> tenders)
    {
        var table = new ConsoleTable("#", "Good", "Type", "Origin", "Destination", "Weight", "Delivery-date",
            "Compensation", "Penalty", "Assigned Truck");

        for (int i = 0; i < tenders.Count; i++)
        {
            table.AddRow($"{i + 1}", $"{tenders[i].Good.GoodsName}", $"{tenders[i].Good.ReqTruckForTransport}",
                $"{tenders[i].StartingCity?.CityName}", $"{tenders[i].EndingCity?.CityName}",
                $"{tenders[i].Weight:F1}t",
                $"{tenders[i].DeliveryDate}", $"{tenders[i].Compensation:C0}",
                $"{tenders[i].Penalty:C0}",
                $"Destination {tenders[i].Truck?.Destination?.CityName}");
        }

        table.Write();
        Console.WriteLine();
    }

    public static void PrintOut(List<Truck> trucks)
    {
        var table = new ConsoleTable("#", "Type", "Age", "Location", "Destination", "Performance", "Payload",
            "Consumption", "Price", "Driver", "Tender", "Status", "ArrivalDate");
        for (int i = 0; i < trucks.Count; i++)
        {
            table.AddRow($"{i + 1}",
                $"{Truck.MappedTruckType(trucks[i].TruckType)}",
                $"{Truck.MappedTruckAge(trucks[i].TruckAge)}",
                $"{Truck.MappedTruckLocation(trucks[i].TruckLocation)}",
                $"{trucks[i].Destination?.CityName}",
                $"{trucks[i].TruckPerformance} hp",
                $"{trucks[i].TruckMaxPayload.ToString()}t",
                $"{trucks[i].TruckConsumption} l/100km",
                $"{trucks[i].TruckPrice:C}",
                $"{trucks[i].TruckDriver?.TruckerName}",
                $"{trucks[i].Tender?.Good.GoodsName}",
                $"{trucks[i].TruckState}",
                $"{trucks[i].ArrivalDate?.ToShortDateString() ?? ""}");
        }

        table.Write();
        Console.WriteLine();
    }

    public static void PrintOutTenderAssignmentTable(List<Tender> tenders, List<Truck> trucks)
    {
        var table = new ConsoleTable("#", "Good", "Type", "Origin", "Destination", "Weight", "Delivery-date",
            "Compensation", "Penalty", "#", "Type", "Location", "Payload", "Status");
        for (int i = 0; i < tenders.Count; i++)
        {
            table.AddRow($"{i + 1}", $"{tenders[i].Good.GoodsName}", $"{tenders[i].Good.ReqTruckForTransport}",
                $"{tenders[i].StartingCity}", $"{tenders[i].EndingCity}", $"{tenders[i].Weight:F1}t",
                $"{tenders[i].DeliveryDate}", $"{tenders[i].Compensation:C0}",
                $"{tenders[i].Penalty:C0}", $"{i + 1}", $"{Truck.MappedTruckType(trucks[i].TruckType)}",
                $"{Truck.MappedTruckLocation(trucks[i].TruckLocation)}", $"{trucks[i].TruckMaxPayload.ToString()}t",
                $"{trucks[i].TruckState}");
        }
    }
// ----------------------------------------------------------------------------------------------------------------------
// error messages    


    public static void OutOfRange()
    {
        ClearConsoleScreen();
        Console.WriteLine(
            "++++++++++++++ The number you hit was not given in the list above. Please Try again! ++++++++++++++");
    }

    internal static void DisplayOutOfRangeMessage()
    {
        ClearConsoleScreen();
        Console.WriteLine(
            "Nopes, definitely the wrong number. Try again with one inside the offered range ¯\\_(ツ)_/¯");
    }

    // ----------------------------------------------------------------------------------------------------------------------
    public static void ClearConsoleScreen()
    {
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine();
        }
    }
}