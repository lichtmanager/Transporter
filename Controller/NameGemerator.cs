namespace Abgabe_1_2;

public class NameSelectionController
{
    public static string GetUserInput()
    {
        System.Console.Write("What's your company name? ");

        string nameOfFirmToTest = System.Console.ReadLine() ?? "***no entry found***";

        System.Console.WriteLine("> " + nameOfFirmToTest + " <");

        return nameOfFirmToTest;
    }
}