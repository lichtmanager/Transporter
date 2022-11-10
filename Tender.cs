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
        this.Good = TenderPropertiesGenerator.ChooseRandomGood();
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