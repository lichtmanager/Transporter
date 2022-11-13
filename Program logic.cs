using System.Reflection;
using System.Security.AccessControl;
using ConsoleTables;

namespace Abgabe_1_2;

public class GuiLogic
{

    public static Company StartupProcess()
    {
        Company company = Initialize.InitializeCompany();
        Company.PrintOutCompanyStatus(company);
        Navigation();
        return company;
    }


    private static void Navigation()
    {
        PrintOutAvailableNavOptions();
        var stroke = GetUserInput();
        DetermineActionOnInput(stroke);
    }

    private static void DetermineActionOnInput(int stroke)
    {
        switch (stroke)
        {
            case 1:
                Console.WriteLine("kaufen");
                break;
            case 2:
                Console.WriteLine("einstellen");
                break;
            case 3:
                Console.WriteLine("annehmen");
                break;
            case 4:
                Console.WriteLine("beenden");
                break;
            default:
                Console.WriteLine("0");
                break;
        }
    }

    private static void PrintOutAvailableNavOptions()
    {
        Console.Write("1. Buy Truck \n2. Hire Driver \n3. Accept Tenders \n4. End tour\n");
        Console.WriteLine();
    }

    private static int GetUserInput()
    {
        Console.Write("Please choose the number to proceed and hit the equivalent key: ");
        var userInput = Console.ReadKey(true);
        int stroke = int.Parse(userInput.KeyChar.ToString());
        return stroke;
    }
}