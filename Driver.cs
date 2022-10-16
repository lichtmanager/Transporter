using System.Linq;
using System.Runtime.Intrinsics.Arm;

namespace Abgabe_1_2;

public class Driver
{
    public static void LoadNamesfromFile()
    {
        string allNamesString =
            System.IO.File.ReadAllText(
                @"/Users/philipplichtmannegger/Developement/dotNET/Abgabe 1/Transporter/names.txt");

        List<string> names = DivideNamesToList(allNamesString);

        DivideFirstLastName(names);
    }

    private static void DivideFirstLastName(List<string> names)
    {
        List<string> firstNames = new List<string>();
        List<string> lastNames = new List<string>();

        for (int i = 0; i < names.Count; i++)
        {
            if (i % 2 == 0)
                firstNames.Add(names[i]);
            else
                lastNames.Add(names[i]);
        }

        foreach (var fn in firstNames)
        {
            Console.WriteLine(fn);
        }

        foreach (var ln in lastNames)
        {
            Console.WriteLine(ln);
        }
    }

    private static List<string> DivideNamesToList(string allNamesString)
    {
        char[] separators = { ' ', ',' };
        List<string> names = new List<string>(allNamesString.Split(separators, StringSplitOptions.RemoveEmptyEntries));
        return names;
    }

    public static void CreateName()
    {
        throw new NotImplementedException();
    }


   
}