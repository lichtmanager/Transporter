namespace Transporter.Controller;

public class NameSelectionController
{
    public static string GetUserInput()
    {
        Console.Write("What's your company name? ");

        string nameOfFirmToTest = System.Console.ReadLine() ?? "***no entry found***";

        Console.WriteLine("> " + nameOfFirmToTest + " <");

        return nameOfFirmToTest;
    }
}