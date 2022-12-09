using Transporter.Models;

namespace Transporter.Controller;

public class TruckActions
{
    internal int CalculateTravelTime(int distance)
    {
        const int hours = 8;
        int travelTime = 1;


        return travelTime;
    }

    public static int CalculateTravelTimeInHours(int distance, Truck truck, Tender tender)
    {
        int travelTime = distance / truck.AvgSpeed;

        return travelTime;
    }
}