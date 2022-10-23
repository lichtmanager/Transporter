using System.Dynamic;
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
    }

    public static string GenerateDriverName(List<string> firstNames, List<string> lastNames)
    {
        Random rnd = new Random();
        string generatedFullName =
            firstNames[rnd.Next(0, firstNames.Count)] + " " + lastNames[rnd.Next(0, lastNames.Count)];
        // Console.Write(generatedFullName);
        return generatedFullName;
    }

    public static (string driversName, int salary, int workingMode) GenerateProperties()
    {
        var (firstNames, lastNames) = Driver.LoadNamesfromFile();

        string driversName = Driver.GenerateDriverName(firstNames, lastNames);
        // int workingMode = Driver.GeneateWorkingMode();
        Console.WriteLine(driversName);

        int salary = GenerateSalary();
        int workingMode = GenerateWorkindMode();

        return (driversName, salary, workingMode);
    }


    public static int GenerateSalary()
    {
        int salary = 1;

        Random rnd = new Random();
        salary = rnd.Next(2000, 5000);

        return salary;
    }


    public static int GenerateWorkindMode()
    {
        Random rnd = new Random();
        int workingMode = rnd.Next(0, 4);
        return workingMode;
    }
}

public class TruckDriver
{
    private string truckerName { get; set; }
    private int salary { get; set; }
    private string workingMode { get; set; }


    public TruckDriver(string truckerName, int salary, int randomWorkingMode)
    {
        this.truckerName = truckerName;
        this.salary = salary;
        this.workingMode = MappedWorkingMode(randomWorkingMode);
    }

    private string MappedWorkingMode(int randomWorkingMode)
    {
        List<string> wokringModeCategories = new List<string>()
            { "Erfahren, aber alt", "Rennfahrer", "Verträumt", "Liebt den Job", "Unauffällig" };

        string mappedWorkingMode = wokringModeCategories[randomWorkingMode];

        return mappedWorkingMode;
    }

    public static void InitializeNDrivers(int numOfDriversToCreate)
    {
        List<TruckDriver> listOfTruckers = new List<TruckDriver>();
        var (firstNames, lastNames) = Driver.LoadNamesfromFile();
        
        for (int i = 0; i < numOfDriversToCreate; i++)
        {
            TruckDriver driverInstance = new TruckDriver(
                Driver.GenerateDriverName(firstNames,lastNames),Driver.GenerateSalary(), Driver.GenerateWorkindMode());
            listOfTruckers.Add(driverInstance);
            //Console.WriteLine( driverInstance.truckerName.ToString() + driverInstance.salary.ToString() + driverInstance.workingMode.ToString());
        }

        for (int i = 0; i < numOfDriversToCreate; i++)
        {
            /*Console.WriteLine(
                i+1 + listOfTruckers[i].truckerName.ToString() + listOfTruckers[i].salary.ToString() +
                listOfTruckers[i].workingMode.ToString());*/
            
              Console.WriteLine($"{i+1}: {listOfTruckers[i].truckerName.ToString()} \t {listOfTruckers[i].salary.ToString()} " +
                                $"\t {listOfTruckers[i].workingMode.ToString()}" );
        };
          
        }
        
    }

