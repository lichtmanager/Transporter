using System.Security.Cryptography;
using ConsoleTables;
using Transporter.Controller;
using Transporter.View;

namespace Transporter.Models;

public class Driver
{
    internal string TruckerName { get; }
    internal int Salary { get; }
    internal int WorkingMode { get; }

    internal Truck? AssignedTruck;


    public Driver(string truckerName, int salary, int randomWorkingMode, Truck? assignedTruck)
    {
        TruckerName = truckerName;
        Salary = salary;
        WorkingMode = randomWorkingMode;
        AssignedTruck = assignedTruck;
    }

    internal static string MappedWorkingMode(int workingMode)
    {
        List<string> wokringModeCategories = new List<string>()
            { "Erfahren, aber alt", "Rennfahrer", "Verträumt", "Liebt den Job", "Unauffällig" };

        string mappedWorkingMode = wokringModeCategories[workingMode];

        return mappedWorkingMode;
    }
}