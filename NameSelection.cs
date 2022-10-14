namespace Abgabe_1_2;

public class NameHelper
{
    public static void NameTester()
    {
        Console.Write("Bitte hier den Kandidaten für die Firma eingeben: ");

        string? nameOfFirmToTest = Console.ReadLine();

        Console.WriteLine("* " + nameOfFirmToTest + " *");
    }
}