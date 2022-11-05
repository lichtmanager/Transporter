using System.Runtime.CompilerServices;

namespace Abgabe_1_2;

public class Good
{
    public string GoodsName;
    public string ReqTruckForTransport;
    public int MaxWeight;


    public Good(string goodsName, string reqTruckForTransport, int maxWeight)
    {
        GoodsName = goodsName;
        ReqTruckForTransport = reqTruckForTransport;
        MaxWeight = maxWeight;
    }

    public static List<Good> InitializeGood()
    {
        List<Good> goodsTypesList = new List<Good>();

        goodsTypesList.Add(new Good("Zigaretten", "Pritschenwagen", 10));
        goodsTypesList.Add(new Good("Textilien", "Pritschenwagen", 10));
        goodsTypesList.Add(new Good("Schokolade", "Pritschenwagen", 10));
        goodsTypesList.Add(new Good("Früchte", "Kühllastwagen", 6));
        goodsTypesList.Add(new Good("Eiscreme", "Kühllastwagen", 6));
        goodsTypesList.Add(new Good("Fleisch", "Kühllastwagen", 6));
        goodsTypesList.Add(new Good("Rohöl", "Tanklaster", 10));
        goodsTypesList.Add(new Good("Heizöl", "Tanklaster", 10));
        goodsTypesList.Add(new Good("Benzin", "Tanklaster", 10));

        return goodsTypesList;
    }
}