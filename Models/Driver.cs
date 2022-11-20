using ConsoleTables;
using Transporter.Controller;
using Transporter.View;

namespace Transporter.Models;

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

    public static void PrintOut(List<Driver> listOfDrivers)
    {
        var table = new ConsoleTable("#", "Name", "Salary", "WorkingMode");
        for (int i = 0; i < listOfDrivers.Count; i++)
        {
            table.AddRow(
                $"{i + 1}",
                $"{listOfDrivers[i].TruckerName}",
                $"{listOfDrivers[i].Salary:C}",
                $"{MappedWorkingMode(listOfDrivers[i].WorkingMode)}");
        }

        table.Write();
        Console.WriteLine();
    }

    private static string MappedWorkingMode(int workingMode)
    {
        List<string> wokringModeCategories = new List<string>()
            { "Erfahren, aber alt", "Rennfahrer", "Verträumt", "Liebt den Job", "Unauffällig" };

        string mappedWorkingMode = wokringModeCategories[workingMode];

        return mappedWorkingMode;
    }
}