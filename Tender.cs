namespace Abgabe_1_2;

public class Tender
{
    public Good Good;
    public int Weight;

    public Tender(Good good, int weight)
    {
        this.Good = TenderGenerator.ChooseRandomGood();
        this.Weight = weight;
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
    
}