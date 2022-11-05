using System.Runtime.Versioning;

namespace Abgabe_1_2;

public class Tender
{

    public Good Good;


    public Tender(Good good, string goodsName, int goodsWeiht)
    {
        this.Good = good;
    }
}

public class TenderGenerator
{
    public Good CreateGood()
    {
        Random rnd = new Random();
        Good good = Good.InitializeGood();

        return good;
    }
}