using System.Diagnostics;
using Transporter.Models;
using Transporter.View;

namespace Transporter.Controller;

public static class TruckActions
{
    internal static DateTime CalculateArrivalDate(int travelHours)
    {
        const int maxHours = 8;

        int days = travelHours / maxHours;
        if (travelHours % maxHours != 0) days += 1;

        var arrivalDate = DateTime.Today.AddDays(days);

        return arrivalDate;
    }

    public static int CalculateTravelTimeInHours(int distance, Truck truck, Tender tender)
    {
        int travelTime = distance / truck.AvgSpeed;

        return travelTime;
    }

    internal static int SpeedOfTruck(Truck truck, Tender tender)
    {
        int speed = 1;
        double weightFactor = 1;
        double driverFactor = 1;
        int avgSpeed = 70;

        var truckOverloadWeight = CheckIf.TruckIsOverloaded(truck, tender);

        if (truckOverloadWeight != 0)
        {
            weightFactor = GenerateWeightFactor(truckOverloadWeight);
        }

        driverFactor = GenerateDriverFactor(truck);

        speed = (int)Math.Ceiling(avgSpeed * driverFactor * weightFactor);
        return speed;
    }

    private static double GenerateDriverFactor(Truck truck)
    {
        Debug.Assert(truck.TruckDriver != null,
            $"truck.TruckDriver != null, {truck.TruckDriver.TruckerName},{Truck.MappedTruckType(truck.TruckType)},{truck.Destination?.CityName ?? truck.TruckLocation.ToString()}");

        double driverFactor =
            truck.TruckDriver.WorkingMode
                switch // Erfahren, aber alt, Rennfahrer, Verträumt, Liebt den Job, Unauffällig
                {
                    0 => 0.95,
                    1 => 1.15,
                    2 => 0.9,
                    3 => 1.05,
                    4 => 1.0,
                    _ => 1
                };

        return driverFactor;
    }

    private static double GenerateWeightFactor(int overloadWeight)
    {
        // für jede Tonne zu viel gehen 5% Geschwindigkeit verloren
        double percentage = overloadWeight * 0.05;

        return (1 - percentage);
    }

    public static double CalculateFuelPrice(Tender tender)
    {
        double pricePerLiter = 1;

        int distance = City.CalculateDistance(tender.StartingCity,
            tender.EndingCity);

        double driverFactor = GenerateDriverFactor(tender.Truck!);

        int truckConsumption = TruckPropertiesController.DetermineTruckConsumption(tender.Truck!.TruckType,
            tender.Truck.TruckSize, tender.Truck.TruckAge);

        double actualTruckConsumption = truckConsumption * driverFactor;
        double actualRouteConsumption = actualTruckConsumption * distance / 100;

        double fuelCosts = actualRouteConsumption * pricePerLiter;

        return fuelCosts;
    }
}