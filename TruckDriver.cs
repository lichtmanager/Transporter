namespace Abgabe_1_2;

public class TruckDriver
{
    

    private string TruckerName { get; }
    private int Salary { get; }
    private int WorkingMode { get; }


    private TruckDriver(string truckerName, int salary, int randomWorkingMode)
    {
        this.TruckerName = truckerName;
        this.Salary = salary;
        this.WorkingMode = randomWorkingMode;
    }

    public static void InitializeNDrivers(int numOfDriversToCreate)
    {
        List<TruckDriver> listOfTruckers = new List<TruckDriver>();
        var (firstNames, lastNames) = DriverGenerator.LoadNamesFromFile();

        for (int i = 0; i < numOfDriversToCreate; i++)
        {
            TruckDriver driverInstance = new TruckDriver(
                NameGenerator.GenerateDriverName(firstNames, lastNames), DriverGenerator.GenerateSalary(),
                DriverGenerator.GenerateWorkingMode());
            listOfTruckers.Add(driverInstance);
        }
        PrintoutDrivers(numOfDriversToCreate, listOfTruckers);
    }

    private static void PrintoutDrivers(int numOfDriversToCreate, List<TruckDriver> listOfTruckers)
    {
        for (int i = 0; i < numOfDriversToCreate; i++)
        {
            Console.WriteLine(
                $"{i + 1}: {listOfTruckers[i].TruckerName}\t{listOfTruckers[i].Salary.ToString()}€" +
                $"\t{MappedWorkingMode(listOfTruckers[i].WorkingMode)}");
        }
    }

    private static string MappedWorkingMode(int workingMode)
    {
        List<string> wokringModeCategories = new List<string>()
            { "Erfahren, aber alt", "Rennfahrer", "Verträumt", "Liebt den Job", "Unauffällig" };

        string mappedWorkingMode = wokringModeCategories[workingMode];

        return mappedWorkingMode;
    }
    
}