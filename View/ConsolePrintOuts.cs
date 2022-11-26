using ConsoleTables;
using Transporter.Controller;
using Transporter.Models;

namespace Transporter.View;

public class ConsolePrintOuts
{
    public static void PrintCities(City[] cities)
    {
        for (var i = 0; i < cities.Length; i++)
        {
            Console.WriteLine((i + 1) + " " + cities[i].CityName);
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
            "Compensation", "Penalty");

        for (int i = 0; i < tenders.Count; i++)
        {
            table.AddRow($"{i + 1}", $"{tenders[i].Good.GoodsName}", $"{tenders[i].Good.ReqTruckForTransport}",
                $"{tenders[i].StartingCity}", $"{tenders[i].EndingCity}", $"{tenders[i].Weight:F1}t",
                $"{tenders[i].DeliveryDate}", $"{tenders[i].Compensation:C0}",
                $"{tenders[i].Penalty:C0}");
        }

        table.Write();
        Console.WriteLine();
    }

    public static void PrintOut(List<Truck> trucks)
    {
        var table = new ConsoleTable("#", "Type", "Age", "Location", "Destination", "Performance", "Payload",
            "Consumption", "Price", "Driver", "Status");
        for (int i = 0; i < trucks.Count; i++)
        {
            table.AddRow($"{i + 1}",
                $"{Truck.MappedTruckType(trucks[i].TruckType)}",
                $"{Truck.MappedTruckAge(trucks[i].TruckAge)}",
                $"{Truck.MappedTruckLocation(trucks[i].TruckLocation)}",
                $"{trucks[i].Destination.CityName}",
                $"{trucks[i].TruckPerformance} hp",
                $"{trucks[i].TruckMaxPayload.ToString()}t",
                $"{trucks[i].TruckConsumption} l/100km",
                $"{trucks[i].TruckPrice:C}",
                $"{trucks[i].TruckDriver?.TruckerName}",
                $"{trucks[i].TruckState}");
        }

        table.Write();
        Console.WriteLine();
    }
}