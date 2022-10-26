

namespace Abgabe_1_2;

public class Driver
{
    public static (string driversName, int salary, int workingMode) GenerateProperties()
    {
        var (firstNames, lastNames) = Driver.LoadNamesFromFile();

        string driversName = Driver.GenerateDriverName(firstNames, lastNames);

        Console.WriteLine(driversName);

        int salary = GenerateSalary();
        int workingMode = GenerateWorkingMode();

        return (driversName, salary, workingMode);
    }

    public static (List<string> firstNames, List<string> lastNames) LoadNamesFromFile()
    {
        string allNamesString =
            File.ReadAllText(
                @"/Users/philipplichtmannegger/Developement/dotNET/Abgabe 1/Transporter/names.txt");

        List<string> namesList = DivideNamesToList(allNamesString);

        var (firstNames, lastNames) = DivideFirstLastName(namesList);
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
    }

    public static string GenerateDriverName(List<string> firstNames, List<string> lastNames)
    {
        Random rnd = new Random();

        string generatedFullName =
            firstNames[rnd.Next(0, firstNames.Count)] + " " + lastNames[rnd.Next(0, lastNames.Count)];

        return generatedFullName;
    }


    public static int GenerateSalary()
    {
        Random rnd = new Random();
        int salary = rnd.Next(2000, 5001);

        return salary;
    }


    public static int GenerateWorkingMode()
    {
        Random rnd = new Random();
        int workingMode = rnd.Next(0, 5);

        return workingMode;
    }
}