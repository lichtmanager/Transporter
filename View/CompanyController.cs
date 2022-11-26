using Transporter.Controller;
using Transporter.Models;

namespace Transporter.View;

public class CompanyController
{
    public static void RenderMenu()
    {
        Console.WriteLine("\n");
        Console.WriteLine(StorageController.company.ToString());
        PrintOutAvailableNavOptions();
        var stroke = BusinessLogic.GetUserInput();
        DetermineActionOnMenuInput(stroke);
    }

    private static void DetermineActionOnMenuInput(int stroke)
    {
        Console.WriteLine("\n");
        switch (stroke)
        {
            case 1:
                AssignDriverToTruck();
                break;
            case 2:
                UnassignDriverFromTruck();
                break;
            case 3:
                AssignTenderToTruck();
                break;
            case 0:
                BusinessLogic.RenderMainMenu();
                break;
            default:
                BusinessLogic.RenderMainMenu();
                break;
        }
    }


    private static void PrintOutAvailableNavOptions()
    {
        //ToDo Hieraus könnte man enums machen!?
        Console.Write(
            "1. Assign Driver to Truck \n2. Unassing driver from truck " +
            "\n3. Assing Tender to Truck \n 0. Return to Main Menu \n\n");
        Console.Write("Please choose in order proceed and hit the equivalent number: ");
    }

    private static void AssignDriverToTruck()
    {
    }

    private static void UnassignDriverFromTruck()
    {
    }

    private static void AssignTenderToTruck()
    {
    }
}