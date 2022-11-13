using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using ConsoleTables;

namespace Abgabe_1_2;

public class GuiLogic
{
    public static Company StartupProcess()
    {
        Company company = Initialize.InitializeCompany();
        Company.PrintOutCompanyStatus(company);

        return company;
    }

    public static void Navigation()
    {
        PrintOutAvailableNavOptions();
        var stroke = GetUserInput();
        Market market = Initialize.InitializeMarket(8, 5, 8);

        DetermineActionOnNavigationInput(stroke, market);
    }

    private static void DetermineActionOnNavigationInput(int stroke, Market market)
    {
        switch (stroke)
        {
            case 1:
                TruckSelection(market);
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

    private static void TruckSelection(Market market)
    {
        Console.WriteLine("Choose the truck to buy or return to Navigation with 0");
        Truck.PrintOut(market.AvailTrucks);
        int stroke = GetUserInput();

        Truck.HandlePurchase(market, stroke);
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
}