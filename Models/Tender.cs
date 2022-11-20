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
        this.Good = TenderPropertiesController.ChooseRandomGood();
        this.Weight = weight;
        this.StartingCity = startingCity;
        this.EndingCity = endingCity;
        this.Compensation = compensation;
        this.Penalty = penalty;
        this.DeliveryDate = deliveryDate;
    }

    public static void PrintOut(List<Tender> tenders)
    {
        var table = new ConsoleTable("#", "Good", "Type", "Origin", "Destination", "Weight", "Delivery-date",
            "Compensation", "Penalty");

        for (int i = 0; i < tenders.Count; i++)
        {
            table.AddRow($"{i + 1}", $"{tenders[i].Good.GoodsName}", $"{tenders[i].Good.ReqTruckForTransport}",
                $"{tenders[i].StartingCity}", $"{tenders[i].EndingCity}", $"{tenders[i].Weight:F1}t",
                $"{tenders[i].DeliveryDate}", $"{tenders[i].Compensation:C}",
                $"{tenders[i].Penalty:C}");
        }

        table.Write();
        System.Console.WriteLine();
    }

    public static void HandlePurchase(int stroke)
    {
        int listIndex = stroke - 1;

        if (stroke == 0)
        {
            BusinessLogic.RenderMainMenu();
        }

        StorageController.ownedTenders.Add((StorageController.availTenders[listIndex]));

        StorageController.availTenders.Remove(StorageController.availTenders[listIndex]);
    }
}