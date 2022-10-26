

namespace Abgabe_1_2;

public static class DriverGenerator
{
    public static (string driversName, int salary, int workingMode) GenerateProperties()
    {
        var (firstNames, lastNames) = DriverGenerator.LoadNamesFromFile();

        string driversName = NameGenerator.GenerateDriverName(firstNames, lastNames);

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

        List<string> namesList = NameGenerator.DivideNamesToList(allNamesString);

        var (firstNames, lastNames) = NameGenerator.DivideFirstLastName(namesList);
        return (firstNames, lastNames);
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