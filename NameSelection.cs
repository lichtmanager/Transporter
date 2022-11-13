namespace Abgabe_1_2;

public class NameHelper
{
    public static void NameSelection()
    {
        Console.Write("What's your company name? ");

        string? nameOfFirmToTest = Console.ReadLine();

        Console.WriteLine("> " + nameOfFirmToTest + " <");
    }
}