namespace Abgabe_1_2;

public class Driver
{
    public static void LoadNamesfromFile()
    {
        /*string loadedNamesString = System.IO.File.ReadAllText(@"/Users/philipplichtmannegger/Developement/dotNET/Abgabe 2/names.txt");
       // print loaded string
       Console.WriteLine(loadedNamesString);*/

        /*  String[] namesAsArray = loadedNamesString.Split(",");
               foreach (var Name in namesAsArray)
               {
                   Console.WriteLine(Name);
                   
               }*/
       
       
              
        var filestream = new System.IO.FileStream(@"/Users/philipplichtmannegger/Developement/dotNET/Abgabe 2/names.txt",
            System.IO.FileMode.Open,
            System.IO.FileAccess.Read,
            System.IO.FileShare.ReadWrite);
        var loadedNamesString = new System.IO.StreamReader(filestream, System.Text.Encoding.UTF8, true, 128);

       
       
         
       
    }
}