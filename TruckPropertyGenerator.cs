namespace Abgabe_1_2;

public static class TruckPropertiesGenerator
{
    public static double CalculateTruckPrice(int age, int size, int type)
    {
        int basePrice;
        double price;
        Random rnd = new Random();

        double priceFactor = (1 + rnd.Next(-20, 31) / 100.0) - age * 0.03;
        if (type == 0)
        {
            priceFactor += 0.1;
        }

        switch (size)
        {
            case 0:
                basePrice = 25000;
                return price = basePrice * priceFactor;
            case 1:
                basePrice = 60000;
                return price = basePrice * priceFactor;
            case 2:
                basePrice = 80000;
                return price = basePrice * priceFactor;

            case 3:
                basePrice = 120000;
                return price = basePrice * priceFactor;
            default: return price = 0;
        }
    }

    public static int GenerateRandomTruckType()
    {
        Random rnd = new Random();
        int truckType = rnd.Next(0, 3);

        return truckType;
    }

    public static int GenerateRandomTruckAge()
    {
        Random rnd = new Random();
        int truckAge = rnd.Next(0, 11);

        return truckAge;
    }

    public static int GenerateRandomTruckLocation()
    {
        Random rnd = new Random();
        int truckLocation = rnd.Next(0, 8);

        return truckLocation;
    }

    public static int GenerateRandomTruckSize()
    {
        Random rnd = new Random();
        int size = rnd.Next(0, 4);

        return size;
    }

    public static int DetermineTruckPerformanceBySize(int size)
    {
        Random rnd = new Random();
        var perf = 0;
        switch (size)
        {
            case 0:
                perf = rnd.Next(10, 26);

                return perf;
            case 1:
                perf = rnd.Next(30, 51);

                return perf;
            case 2:
                perf = rnd.Next(40, 71);

                return perf;
            case 3:
                perf = rnd.Next(60, 81);

                return perf;
            default:
                return perf = 0;
        }
    }

    public static int DetermineMaxPayload(int size, int type)
    {
        var payload = 0;

        return size switch
        {
            0 => type switch
            {
                0 => payload = 3,
                1 => payload = 4,
                2 => payload = 2,
                _ => payload = 0
            },
            1 => type switch
            {
                0 => payload = 4,
                1 => payload = 6,
                2 => payload = 4,
                _ => payload = 0
            },
            2 => type switch
            {
                0 => payload = 5,
                1 => payload = 7,
                2 => payload = 8,
                _ => payload = 0
            },
            3 => type switch
            {
                0 => payload = 6,
                1 => payload = 10,
                2 => payload = 10,
                _ => payload = 0
            },
            _ => payload
        };
    }

    public static int DetermineTruckConsumption(int type, int size, int age)
    {
        var consumption = 0;
        consumption += (age / 3);

        switch (size)
        {
            case 0:
                return type switch
                {
                    0 => consumption += 14,
                    1 => consumption += 10,
                    2 => consumption += 14,
                    _ => consumption += 0
                };

            case 1:
                return type switch
                {
                    0 => consumption += 18,
                    1 => consumption += 12,
                    2 => consumption += 18,
                    _ => consumption += 0
                };

            case 2:
                return type switch
                {
                    0 => consumption += 20,
                    1 => consumption += 16,
                    2 => consumption + 20,
                    _ => consumption += 0
                };

            case 3:
                return type switch
                {
                    0 => consumption += 30,
                    1 => consumption += 22,
                    2 => consumption += 30,
                    _ => consumption += 0
                };
        }

        return consumption;
    }
}