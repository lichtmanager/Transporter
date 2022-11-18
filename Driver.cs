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

    public static void PrintOut(List<Driver> listOfTruckers)
    {
        for (int i = 0; i < listOfTruckers.Count; i++)
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

    public static void HandleEmployment(int stroke)
    {
        int listIndex = stroke - 1;
        storage.ownedDrivers.Add(storage.availDrivers[listIndex]);
        storage.availDrivers.Remove(storage.availDrivers[listIndex]);
    }

    public static void HandlePurchase(int stroke)
    {
        if (stroke == 0)
        {
            GuiLogic.Navigation();
        }

        int listIndex = stroke - 1;

        storage.ownedDrivers.Add(storage.availDrivers[listIndex]);

        storage.availDrivers.Remove(storage.availDrivers[listIndex]);
    }
}