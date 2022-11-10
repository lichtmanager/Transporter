namespace Abgabe_1_2;

using System.Globalization;

public static class TenderPropertiesGenerator
{
    public static Good ChooseRandomGood()
    {
        Random rnd = new Random();
        List<Good> goodsList = Good.InitializeGood();

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
        string startingCity = Truck.MappedTruckLocation(TruckPropertiesGenerator.GenerateRandomTruckLocation());
        return startingCity;
    }

    public static string GenerateEndingCity()
    {
        string endingCity = Truck.MappedTruckLocation(TruckPropertiesGenerator.GenerateRandomTruckLocation());
        return endingCity;
    }

    public static double DetermineCompensation(Good goodForTender, int rndWeight, string deliveryDate)
    {
        var days = ReconstructDays(deliveryDate);


        Random rnd = new Random();
        double bonusFactor = 1 + (0.2 + days / goodForTender.MaxDeliveryDays) * rnd.Next(0, 2);
        double compensation = goodForTender.MinPricePerTon * rndWeight * bonusFactor;

        return compensation;
    }

    private static int ReconstructDays(string deliveryDate)
    {
        var cultureInfo = new CultureInfo("de-DE");
        DateTime dateTime = DateTime.Parse(deliveryDate, cultureInfo);
        int days = dateTime.Day - DateTime.Today.Day;
        return days;
    }

    public static double DeterminePenalty(double compensation)
    {
        Random rnd = new Random();
        double penalty = rnd.Next(50, 201) * compensation / 100;

        return penalty;
    }
}