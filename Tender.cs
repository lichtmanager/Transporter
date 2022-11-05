using System.Globalization;

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
        double penalty)
    {
        this.Good = TenderGenerator.ChooseRandomGood();
        this.Weight = weight;
        this.StartingCity = startingCity;
        this.EndingCity = endingCity;
        this.Compensation = compensation;
        this.Penalty = penalty;
    }

    public static void PrintoutTenders(List<Tender> tenders, int numOfTenders)
    {
        for (int i = 0; i < numOfTenders; i++)
        {
            Console.WriteLine($"{i + 1}: {tenders[i].Good.GoodsName}  \t{tenders[i].Good.ReqTruckForTransport}" +
                              $"\t{tenders[i].StartingCity} to {tenders[i].EndingCity}  \t \t{tenders[i].Weight.ToString()}t" +
                              $"{tenders[i].DeliveryDate}  \t{tenders[i].Compensation.ToString()}€  " +
                              $"\t{tenders[i].Penalty.ToString(CultureInfo.CurrentCulture)}€");
        }
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