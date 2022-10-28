namespace Abgabe_1_2;

public class Goods
{
    public int GoodsType;
    public int ReqTruckForTransport;
    public int GoodsTotalWeight;


    public Goods(int goodsType, int reqTruckForTransport, int goodsTotalWeight)
    {
        GoodsType = goodsType;
        ReqTruckForTransport = reqTruckForTransport;
        GoodsTotalWeight = goodsTotalWeight;
    }

    public static string MappedGoodsType(int randomGoodsType)
    {
        List<string> goodsTypesList = new List<string>()
        {
            "Zigaretten", "Textilien", "Schokolade", "Früchte", "Eiscreme", "Fleisch", "Rohöl", "Heizöl", "Benzin"
        };
        string goodsName = goodsTypesList[randomGoodsType];

        return goodsName;
    }
}

public class GoodsPropertiesGenerator
{
    public static int RandomTypesGenerator()
    {
        Random rnd = new Random();
        int goodsType = rnd.Next(0, Goods.MappedGoodsType(0).Length);
        Console.WriteLine(goodsType.ToString());

        return goodsType;
    }

    public static int RandomTotalWeight(int goodsType)
    {
        Random rnd = new Random();

        switch (goodsType)
        {
            
            case int n when n<=2: 
                int totalWeight = rnd.Next(1, 10);
            case int n when (n >=3 && n <= 5):
                int totalWeight = rnd.Next(1, 6);
            case 2:
        }

    }
}