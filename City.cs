namespace Abgabe_1_2;

public class City
{
    private string CityName { get; }
    private int Easting { get; }
    private int Northing { get; }


    public City(string cityName, int easting, int northing)
    {
        this.CityName = cityName;
        this.Easting = easting;
        this.Northing = northing;
    }
    

    public static void PrintAllCities(City[] cities)
    {
        for (var i = 0; i < cities.Length; i++)
        {
            Console.WriteLine((i + 1) + " " + cities[i].CityName);
        }
    }

    private static City GetUserInputForCitySelection(City[] cities)
    {
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("is empty, try again!: ");
            return GetUserInputForCitySelection(cities);
        }
        else
        {
            try
            {
                int desiredCity = Convert.ToInt16(input);
                if (desiredCity >= 1 && desiredCity < cities.Length)
                {
                    return cities[desiredCity - 1];
                }
                else
                {
                    Console.Write($"<{input}> not in the possible list of options. --> Please choose from the given range (1 - {cities.Length -1}): ");
                    return GetUserInputForCitySelection(cities);
                }
            }
            catch (Exception e)
            {
                Console.Write($"Wrong Input <{input}>. Did you maybe use a letter instead of a number? \nPlease choose from the given range (1 - {cities.Length -1 }): ");
                return GetUserInputForCitySelection(cities);
            }
        }
    }

    public static void ChooseCity(City[] cities)
    {
        Console.WriteLine("Geben Sie die entsprechende Zahl für Ihren Wunschort ein: ");
        GetUserInputForCitySelection(cities);
    }

    private static City ChooseStartCity(City[] cities)
    {
        Console.WriteLine("Wählen Sie den Startort: ");

        return GetUserInputForCitySelection(cities);
    }

    private static City ChooseEndCity(City[] cities)
    {
        Console.WriteLine("Wählen Sie den Zielort: ");

        return GetUserInputForCitySelection(cities);
    }

    public static void PrintStartEnd(City[] cities)
    {
        Console.WriteLine(ChooseStartCity(cities).CityName);
        Console.WriteLine(ChooseEndCity(cities).CityName);
    }


    public static void CalculateAndPrintDistance(City[] cities)
    {
        City startCity = ChooseStartCity(cities);
        City endCity = ChooseEndCity(cities);

        int distance = (int)Math.Sqrt(Math.Pow(startCity.Northing - endCity.Northing, 2) +
                                      Math.Pow(startCity.Easting - endCity.Easting, 2));

        Console.WriteLine($"Die Distanz beträgt: {distance / 1000} km");
    }
}