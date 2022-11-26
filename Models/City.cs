namespace Transporter.Models;

public class City
{
    public string CityName { get; }
    private int Easting { get; }
    private int Northing { get; }


    public City(string cityName, int easting, int northing)
    {
        this.CityName = cityName;
        this.Easting = easting;
        this.Northing = northing;
    }


    private static City GetUserInputForCitySelection(City[] cities)
    {
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("is empty, try again!: ");
            return GetUserInputForCitySelection(cities);
        }


        try
        {
            int desiredCity = Convert.ToInt16(input);
            if (desiredCity >= 1 && desiredCity < cities.Length)
            {
                return cities[desiredCity - 1];
            }
            else
            {
                Console.Write(
                    $"<{input}> not in the possible list of options. --> Please choose from the given range (1 - {cities.Length - 1}): ");
                return GetUserInputForCitySelection(cities);
            }
        }
        catch (Exception)
        {
            Console.Write(
                $"Wrong Input <{input}>. Did you maybe use a letter instead of a number? \nPlease choose from the given range (1 - {cities.Length - 1}): ");
            return GetUserInputForCitySelection(cities);
        }
    }

    public static void ChooseCity(City[] cities)
    {
        System.Console.WriteLine("Geben Sie die entsprechende Zahl für Ihren Wunschort ein: ");
        GetUserInputForCitySelection(cities);
    }

    public static City ChooseStartCity(City[] cities)
    {
        System.Console.WriteLine("Wählen Sie den Startort: ");

        return GetUserInputForCitySelection(cities);
    }

    internal static City ChooseEndCity(City[] cities)
    {
        System.Console.WriteLine("Wählen Sie den Zielort: ");

        return GetUserInputForCitySelection(cities);
    }

    public static void CalculateAndPrintDistance(City[] cities)
    {
        City startCity = ChooseStartCity(cities);
        City endCity = ChooseEndCity(cities);

        int distance = (int)Math.Sqrt(Math.Pow(startCity.Northing - endCity.Northing, 2) +
                                      Math.Pow(startCity.Easting - endCity.Easting, 2));

        System.Console.WriteLine($"Die Distanz beträgt: {distance / 1000} km");
    }
}