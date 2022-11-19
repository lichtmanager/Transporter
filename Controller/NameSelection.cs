namespace Abgabe_1_2;

public class NameSelector
{
    public static string GetUserInput()
    {
        Console.Write("What's your company name? ");

        string nameOfFirmToTest = Console.ReadLine() ?? "***no entry found***";

        Console.WriteLine("> " + nameOfFirmToTest + " <");

        return nameOfFirmToTest;
    }
}