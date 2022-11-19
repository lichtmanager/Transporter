namespace Abgabe_1_2;

public static class Initializer
{
    public static (List<string> firstNames, List<string> lastNames) LoadNamesFromFile()
    {
        string filePath = "/Users/philipplichtmannegger/Development/dotNET/names.txt";
        string allNamesString = File.ReadAllText(@filePath);

        List<string> namesList = NameController.DivideNamesToList(allNamesString);

        var (firstNames, lastNames) = NameController.DivideFirstLastName(namesList);
        return (firstNames, lastNames);
    }

    public static City[] InitializeCities()
    {
        City[] cityArray = new City[8];
        cityArray[0] = new City("Amsterdam", 868851, 297477);
        cityArray[1] = new City("Berlin", 1442341, 404144);
        cityArray[2] = new City("Esslingen", 1232391, -71899);
        cityArray[3] = new City("Rom", 1605258, -786717);
        cityArray[4] = new City("Lissabon", -220417, -1218006);
        cityArray[5] = new City("Istanbul", 3015490, -498084);
        cityArray[6] = new City("Aarhus", 1156381, 763352);
        cityArray[7] = new City("Tallinn", 1889074, 1368933);
        return cityArray;
    }

    public static List<Truck> InitializeNTrucks(int numberOfTrucksToCreate)
    {
        List<Truck> listOfTrucks = new List<Truck>();
        for (int i = 0; i < numberOfTrucksToCreate; i++)
        {
            int size = TruckPropertiesController.GenerateRandomTruckSize();
            int type = TruckPropertiesController.GenerateRandomTruckType();
            int age = TruckPropertiesController.GenerateRandomTruckAge();
            int loc = TruckPropertiesController.GenerateRandomTruckLocation();
            int perf = TruckPropertiesController.DetermineTruckPerformanceBySize(size);
            int payload = TruckPropertiesController.DetermineMaxPayload(size, type);
            int cons = TruckPropertiesController.DetermineTruckConsumption(type, size, age);
            double price = TruckPropertiesController.CalculateTruckPrice(age, size, type);

            Truck truck = new Truck(
                type, age, loc, size, perf, payload, cons, price);

            listOfTrucks.Add(truck);
        }

        return listOfTrucks;
    }

    public static List<Driver> InitializeNDrivers(int numOfDriversToCreate)
    {
        List<Driver> listOfTruckers = new List<Driver>();
        var (firstNames, lastNames) = Initializer.LoadNamesFromFile();

        for (int i = 0; i < numOfDriversToCreate; i++)
        {
            Driver driverInstance = new Driver(
                NameController.GenerateDriverName(firstNames, lastNames), DriverController.GenerateSalary(),
                DriverController.GenerateWorkingMode());
            listOfTruckers.Add(driverInstance);
        }


        return listOfTruckers;
    }

    public static List<Tender> InitializeNTenders(int numOfTendersToCreate)
    {
        List<Tender> listOfTenders = new List<Tender>();
        for (int i = 0; i < numOfTendersToCreate; i++)
        {
            Good goodForTender = TenderPropertiesController.ChooseRandomGood();
            Random rnd = new Random();
            int rndWeight = rnd.Next(1, goodForTender.MaxWeight + 1);

            string startingCity = "";
            string endingCity = "";

            string deliveryDate = TenderPropertiesController.GenerateDeliveryDate(goodForTender);
            double compensation =
                TenderPropertiesController.DetermineCompensation(goodForTender, rndWeight, deliveryDate);
            double penalty = TenderPropertiesController.DeterminePenalty(compensation);

            do
            {
                startingCity = TenderPropertiesController.GenerateStartingCity();
                endingCity = TenderPropertiesController.GenerateEndingCity();
            } while (startingCity == endingCity);

            listOfTenders.Add(new Tender(goodForTender, rndWeight, startingCity, endingCity, deliveryDate, compensation,
                penalty, deliveryDate));
        }

        return listOfTenders;
    }


    public static List<Good> InitializeGood()
    {
        List<Good> goodsTypesList = new List<Good>();

        goodsTypesList.Add(new Good("Zigaretten", "Pritschenwagen", 10, 20, 100));
        goodsTypesList.Add(new Good("Textilien", "Pritschenwagen", 10, 20, 50));
        goodsTypesList.Add(new Good("Schokolade", "Pritschenwagen", 10, 10, 120));
        goodsTypesList.Add(new Good("Früchte", "Kühllastwagen", 6, 14, 150));
        goodsTypesList.Add(new Good("Eiscreme", "Kühllastwagen", 6, 10, 180));
        goodsTypesList.Add(new Good("Fleisch", "Kühllastwagen", 6, 14, 130));
        goodsTypesList.Add(new Good("Rohöl", "Tanklaster", 10, 14, 120));
        goodsTypesList.Add(new Good("Heizöl", "Tanklaster", 10, 25, 90));
        goodsTypesList.Add(new Good("Benzin", "Tanklaster", 10, 28, 80));

        return goodsTypesList;
    }

    public static Company InitializeCompany()
    {
        string cName = "Bärchenlogistik";
        // string cName = NameSelectionController.getUserInput();
        //ToDo: remove static name!

        int balance = 50000;

        Company company = new Company(cName, balance, DateTime.Today, StorageController.ownedTrucks,
            StorageController.ownedDrivers,
            StorageController.ownedTenders);

        return company;
    }
}