using System.Reflection;
using System.Security.AccessControl;

namespace Abgabe_1_2;

public class GuiLogic
{
    public static void StartupProcess()
    {
        NameHelper.NameSelection();
        Navigation();
    }

    public static void Navigation()
    {
        Console.Write("1. Buy Truck \n2. Employe Driver \n3. Accept Tenders \n4. End tour\n");
        Console.Write("Please choose the number to proceed and hit the equivalent key: ");
        var userInput = Console.ReadKey(true);

        int stroke = int.Parse(userInput.KeyChar.ToString());

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
}