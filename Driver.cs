namespace Abgabe_1_2;

public class Driver
{
    

    private string TruckerName { get; }
    private int Salary { get; }
    private int WorkingMode { get; }


    public Driver(string truckerName, int salary, int randomWorkingMode)
    {
        this.TruckerName = truckerName;
        this.Salary = salary;
        this.WorkingMode = randomWorkingMode;
    }

    public static void PrintoutDrivers(int numOfDriversToCreate, List<Driver> listOfTruckers)
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