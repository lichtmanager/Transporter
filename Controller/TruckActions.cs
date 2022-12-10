using Transporter.Models;

namespace Transporter.Controller;

public static class TruckActions
{
    internal static DateTime CalculateArrivalDate(int travelHours)
    {
        const int maxHours = 8;

        int days = travelHours / maxHours;
        if (travelHours % maxHours != 0) days += 1;


        var arrivalDate = DateTime.Today.AddDays(days);


        Console.WriteLine("------------");
        Console.WriteLine("Arrival Date");
        Console.WriteLine(travelHours);
        Console.WriteLine(maxHours);
        Console.WriteLine(days);
        Console.WriteLine("------------");

        return arrivalDate;
    }

    public static int CalculateTravelTimeInHours(int distance, Truck truck, Tender tender)
    {
        int travelTime = distance / truck.AvgSpeed;
        Console.WriteLine("------------");
        Console.WriteLine(distance);
        Console.WriteLine(truck.AvgSpeed);
        Console.WriteLine("------------");


        return travelTime;
    }
}