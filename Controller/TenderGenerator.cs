using System.Globalization;
using Transporter.Models;

namespace Transporter.Controller;

public static class TenderPropertiesController
{
    public static Good ChooseRandomGood()
    {
        Random rnd = new Random();
        List<Good> goodsList = Initializer.InitializeGood();

        return goodsList[rnd.Next(0, goodsList.Count)];
    }

    public static string GenerateDeliveryDate(Good good)
    {
        Random rnd = new Random();

        int days = rnd.Next(3, good.MaxDeliveryDays + 1);

        DateTime deliveryDate = DateTime.Today.AddDays(days);
        return deliveryDate.ToShortDateString();
    }

    public static string GenerateStartingCity()
    {
        string startingCity = Truck.MappedTruckLocation(TruckPropertiesController.GenerateRandomTruckLocation());
        return startingCity;
    }

    public static string GenerateEndingCity()
    {
        string endingCity = Truck.MappedTruckLocation(TruckPropertiesController.GenerateRandomTruckLocation());
        return endingCity;
    }

    public static int DetermineCompensation(Good goodForTender, int rndWeight, string deliveryDate)
    {
        var days = ReconstructDays(deliveryDate);


        Random rnd = new Random();
        double bonusFactor = 1 + (0.2 + days / goodForTender.MaxDeliveryDays) * rnd.NextDouble();
        int compensation = (int)(goodForTender.MinPricePerTon * rndWeight * bonusFactor);

        return compensation;
    }

    private static int ReconstructDays(string deliveryDate)
    {
        var cultureInfo = new CultureInfo("de-DE");
        DateTime dateTime = DateTime.Parse(deliveryDate, cultureInfo);
        int days = dateTime.Day - DateTime.Today.Day;
        return days;
    }

    public static int DeterminePenalty(int compensation)
    {
        Random rnd = new Random();
        int penalty = rnd.Next(50, 201) * compensation / 100;

        return penalty;
    }
}