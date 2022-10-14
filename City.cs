using System.Numerics;
using System.Runtime.CompilerServices;
using Abgabe_1_2;

namespace Abgabe_1_2;

public class City
{
    private string cityName { get; }
    private int easting { get; }
    private int northing { get; }


    public City(string cityName, int easting, int northing)
    {
        this.cityName = cityName;
        this.easting = easting;
        this.northing = northing;
    }
    

    public static void PrintAllCities(City[] c1)
    {
        for (var i = 0; i < c1.Length; i++)
        {
            Console.WriteLine((i + 1) + " " + c1[i].cityName);
        }
    }

    private static City CheckInput(City[] c1)
    {
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("is empty, try again!: ");
            return CheckInput(c1);
        }
        else
        {
            try
            {
                int desiredCity = Convert.ToInt16(input);
                if (desiredCity >= 1 && desiredCity < c1.Length)
                {
                    // Console.WriteLine(c1[desiredCity - 1].cityName);
                    return c1[desiredCity - 1];
                }
                else
                {
                    Console.Write($"<{input}> not in the possible list of options. --> Please choose from the given range (1 - {c1.Length -1}): ");
                    return CheckInput(c1);
                }
            }
            catch (Exception e)
            {
                Console.Write($"Wrong Input <{input}>. Did you maybe use a letter instead of a number? \nPlease choose from the given range (1 - {c1.Length -1 }): ");
                return CheckInput(c1);
            }
        }
    }

    public static void ChooseCity(City[] c1)
    {
        Console.WriteLine("Geben Sie die entsprechende Zahl für Ihren Wunschort ein: ");
        CheckInput(c1);
    }

    private static City ChooseStart(City[] c1)
    {
        Console.WriteLine("Wählen Sie den Startort: ");

        return CheckInput(c1);
    }

    private static City ChooseEnd(City[] c1)
    {
        Console.WriteLine("Wählen Sie den Zielort: ");

        return CheckInput(c1);
    }

    public static void PrintStartEnd(City[] c1)
    {
        Console.WriteLine(ChooseStart(c1).cityName);
        Console.WriteLine(ChooseEnd(c1).cityName);
    }


    public static void CalculateDistance(City[] c1)
    {
        City startCity = ChooseStart(c1);
        City endCity = ChooseEnd(c1);

        int distance = (int)Math.Sqrt(Math.Pow(startCity.northing - endCity.northing, 2) +
                                      Math.Pow(startCity.easting - endCity.easting, 2));

        Console.WriteLine($"Die Distanz beträgt: {distance / 1000} km");
    }
}