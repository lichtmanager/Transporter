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
    public static (int goodsType, int truckType) RandomTypesGeneratorMappedToTruckType()
    {
        Random rnd = new Random();
        int goodsType = rnd.Next(0, Goods.MappedGoodsType(0).Length);
        Console.WriteLine(goodsType.ToString());

        int truckType;

        switch (goodsType)
        {
            case <=2:
                truckType = 1;
                return (goodsType, truckType);
            case <= 5 and >= 3:
                truckType = 0;
                return (goodsType, truckType);
            case <= 8 and >= 6:
                truckType = 2;
                return (goodsType, truckType);
            default: return (goodsType = 0, truckType = 0);
        }

    }

    public static int RandomTotalWeight(int goodsType)
    {
        Random rnd = new Random();

        int totalWeight;
        switch (goodsType)
        {
            
            case <= 2: 
                totalWeight = rnd.Next(1, 11);
                return totalWeight;
            case <= 5 and >= 3:
                totalWeight = rnd.Next(1, 6);
                return totalWeight;
            case <= 8 and >= 6:
                totalWeight = rnd.Next(1, 11);
                return totalWeight;
            default: return totalWeight = 0;
        }

    }
}