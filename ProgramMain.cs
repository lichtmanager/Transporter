using System.Reflection.Metadata;

namespace Abgabe_1_2;

public class ProgramMain
{
    public static void Main(string[] args)

    {
        // Call NameHelper to test, if a name looks good. 
        // NameHelper.NameTester();


        // Initialice.InitialiceCities();

        City[] c1 = new City[8];
        c1[0] = new City("Amsterdam", 868851, 297477);
        c1[1] = new City("Berlin", 1442341, 404144);
        c1[2] = new City("Esslingen", 1232391, -71899);
        c1[3] = new City("Rom", 1605258, -786717);
        c1[4] = new City("Lissabon", -220417, -1218006);
        c1[5] = new City("Istanbul", 3015490, -498084);
        c1[6] = new City("Aarhus", 1156381, 763352);
        c1[7] = new City("Tallinn", 1889074, 1368933);


        // City.PrintAllCities(c1);
        //    City.ChooseCity(c1);
        //    City.ChooseStart(c1);
        //    City.ChooseEnd(c1);
        //    City.printStartEnd(c1);
        //City.CalculateDistance(c1);
        Driver.LoadNamesfromFile();
       
        //ToDo create Driver randomly.
    }
}