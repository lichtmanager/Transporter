using System.Linq;
using System.Runtime.Intrinsics.Arm;

namespace Abgabe_1_2;

public class Driver
{
    public static (List<string> firstNames, List<string> lastNames) LoadNamesfromFile()
    {
        string allNamesString =
            System.IO.File.ReadAllText(
                @"/Users/philipplichtmannegger/Developement/dotNET/Abgabe 1/Transporter/names.txt");

        List<string> names = DivideNamesToList(allNamesString);

        var (firstNames, lastNames) = DivideFirstLastName(names);
        return (firstNames, lastNames);

    }

    private static List<string> DivideNamesToList(string allNamesString)
    {
        char[] separators = { ' ', ',' };
        List<string> fullNames =
            new List<string>(allNamesString.Split(separators, StringSplitOptions.RemoveEmptyEntries));
        return fullNames;
    }

    private static (List<string> firstNames, List<string> lastNames) DivideFirstLastName(List<string> names)
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

        return (firstNames, lastNames);

        /*foreach (var fn in firstNames)
        {
            Console.WriteLine(fn);
        }

        foreach (var ln in lastNames)
        {
            Console.WriteLine(ln);
        }*/
    }

    public static List<string> GenerateDriverName(int namesToGenerate, List<string> firstNames, List<string> lastNames)
    {
        Random rnd = new Random();
        List<string> generatedFullNames = new List<string>();
        for (int i = 0; i < namesToGenerate; i++)
        {
            generatedFullNames.Add(
                firstNames[rnd.Next(0, firstNames.Count)] + " " + lastNames[rnd.Next(0, lastNames.Count)]);
            Console.Write(generatedFullNames[i]);
        }

        return generatedFullNames;
    }
}

