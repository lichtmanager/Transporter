namespace Abgabe_1_2;

public static class DriverController
{
    public static (string driversName, int salary, int workingMode) GenerateProperties()
    {
        var (firstNames, lastNames) = Initializer.LoadNamesFromFile();

        string driversName = NameController.GenerateDriverName(firstNames, lastNames);

        Console.WriteLine(driversName);

        int salary = GenerateSalary();
        int workingMode = GenerateWorkingMode();

        return (driversName, salary, workingMode);
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