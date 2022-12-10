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
        return arrivalDate;
    }

    public static int CalculateTravelTimeInHours(int distance, Truck truck, Tender tender)
    {
        int travelTime = distance / truck.AvgSpeed;

        return travelTime;
    }
}