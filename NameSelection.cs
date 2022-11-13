namespace Abgabe_1_2;

public class NameHelper
{
    public static string NameSelection()
    {
        Console.Write("What's your company name? ");

        string nameOfFirmToTest = Console.ReadLine() ?? "***no entry found***";

        Console.WriteLine("> " + nameOfFirmToTest + " <");

        return nameOfFirmToTest;
    }
}