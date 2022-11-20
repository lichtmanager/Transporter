namespace Transporter.Models;

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
}