namespace Abgabe_1_2;

public class Tender
{
    public Good Good;
    public int Weight;
    public string StartingCity;
    public string EndingCity;
    

    public Tender(Good good, int weight, string startingCity, string endingCity)
    {
        this.Good = TenderGenerator.ChooseRandomGood();
        this.Weight = weight;
        this.StartingCity = startingCity;
        this.EndingCity = endingCity;
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