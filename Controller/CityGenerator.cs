using Transporter.Models;

namespace Transporter.Controller;

public static class CityGenerator
{
    public static City GenerateRandomCity()
    {
        Random rnd = new Random();

        City randomCity = StorageController.Cities[rnd.Next(0, 8)];
        return randomCity;
    }
}