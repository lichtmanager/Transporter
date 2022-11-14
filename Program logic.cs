using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using ConsoleTables;

namespace Abgabe_1_2;

public class GuiLogic
{
    public static void StartupProcess()
    {
    }

    public static void Navigation()
    {
        Company.PrintOutCompanyStatus(storage.company);
        PrintOutAvailableNavOptions();
        var stroke = GetUserInput();
        //Market market = Initialize.InitializeMarket(8, 5, 8);

        DetermineActionOnNavigationInput(stroke);
    }

    private static void DetermineActionOnNavigationInput(int stroke)
    {
        switch (stroke)
        {
            case 1:
                TruckSelection();
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

    private static void TruckSelection()
    {
        if (storage.availTrucks.Count > 0)
        {
            Console.WriteLine("Choose the truck to buy or return to Navigation with 0");
            Truck.PrintOut(storage.availTrucks);
            int stroke = GetUserInput();
            Truck.HandlePurchase(stroke);
            Navigation();
        }
        else
        {
            ClearConsoleScreen();
            Console.WriteLine("+++++++++++ There are no more trucks to buy +++++++++++");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }

            Navigation();
        }
    }

    private static void PrintOutAvailableNavOptions()
    {
        Console.Write("1. Buy Truck \n2. Hire Driver \n3. Accept Tenders \n4. End tour\n");
        Console.Write("Please choose in order proceed and hit the equivalent number: ");
        Console.WriteLine();
    }

    private static int GetUserInput()
    {
        var userInput = Console.ReadKey(true);
        try
        {
            int stroke = int.Parse(userInput.KeyChar.ToString());
            return stroke;
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occured. You might have not pressed a number. Please hit a number key: ");
            GetUserInput();
            throw;
        }
    }

    public static void ClearConsoleScreen()
    {
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine();
        }
    }
}