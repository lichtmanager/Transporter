using System.Globalization;
using ConsoleTables;

namespace Abgabe_1_2;

public class Tender
{
    public Good Good;
    public int Weight;
    public string StartingCity;
    public string EndingCity;
    public string DeliveryDate;
    public double Compensation;
    public double Penalty;


    public Tender(Good good, int weight, string startingCity, string endingCity, string date, double compensation,
        double penalty, string deliveryDate)
    {
        this.Good = TenderGenerator.ChooseRandomGood();
        this.Weight = weight;
        this.StartingCity = startingCity;
        this.EndingCity = endingCity;
        this.Compensation = compensation;
        this.Penalty = penalty;
        this.DeliveryDate = deliveryDate;
    }

    public static void PrintoutTenders(List<Tender> tenders, int numOfTenders)
    {
        var table = new ConsoleTable("#", "Good", "Type", "Origin", "Destination", "Weight", "Delivery-date",
            "Compensation", "Penalty");

        for (int i = 0; i < numOfTenders; i++)
        {
            table.AddRow($"{i + 1}", $"{tenders[i].Good.GoodsName}", $"{tenders[i].Good.ReqTruckForTransport}",
                $"{tenders[i].StartingCity}", $"{tenders[i].EndingCity}", $"{tenders[i].Weight.ToString()}t",
                $"{tenders[i].DeliveryDate}", $"{tenders[i].Compensation.ToString(CultureInfo.CurrentCulture)}€",
                $"{tenders[i].Penalty.ToString(CultureInfo.CurrentCulture)}€");
        }

        table.Write();
        Console.WriteLine();
        Console.ReadKey();
    }
}

public class TenderGenerator
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