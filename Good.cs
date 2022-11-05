using System.Runtime.CompilerServices;

namespace Abgabe_1_2;

public class Good
{
    public string GoodsName;
    public string ReqTruckForTransport;
    public int MaxWeight;
    public int MaxDeliveryDays;
    public int MinPricePerTon;


    public Good(string goodsName, string reqTruckForTransport, int maxWeight, int maxDeliveryDays, int minPricePerTon)
    {
        GoodsName = goodsName;
        ReqTruckForTransport = reqTruckForTransport;
        MaxWeight = maxWeight;
        MaxDeliveryDays = maxDeliveryDays;
        MinPricePerTon = minPricePerTon;
    }

    public static List<Good> InitializeGood()
    {
        List<Good> goodsTypesList = new List<Good>();

        goodsTypesList.Add(new Good("Zigaretten", "Pritschenwagen", 10, 20,100));
        goodsTypesList.Add(new Good("Textilien", "Pritschenwagen", 10, 20, 50));
        goodsTypesList.Add(new Good("Schokolade", "Pritschenwagen", 10, 10, 120));
        goodsTypesList.Add(new Good("Früchte", "Kühllastwagen", 6, 14,150));
        goodsTypesList.Add(new Good("Eiscreme", "Kühllastwagen", 6,10,180));
        goodsTypesList.Add(new Good("Fleisch", "Kühllastwagen", 6,14,130));
        goodsTypesList.Add(new Good("Rohöl", "Tanklaster", 10,14,120));
        goodsTypesList.Add(new Good("Heizöl", "Tanklaster", 10,25,90));
        goodsTypesList.Add(new Good("Benzin", "Tanklaster", 10,28,80));

        return goodsTypesList;
    }
}