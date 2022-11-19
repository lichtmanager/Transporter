using Xunit;
using Xunit.Sdk;

namespace Abgabe_1_2;

public class Tests
{
    [Fact]
    public void Test_that_1_plus_1_equals_2()
    {
        var actual = 1 + 1;
        Assert.Equal(2, actual);
    }

    [Fact]
    public void SelectedTruckIsAddedToCompany()
    {
        int stroke = 5;
        List<Truck> storageTrucks = StorageController.availTrucks;
        List<Truck> boughtTrucks = StorageController.ownedTrucks;
        Truck chosenTruck = storageTrucks[stroke - 1];

        Truck.HandlePurchase(stroke);

        Assert.Contains(chosenTruck, boughtTrucks);
    }

    [Fact]
    public void PriceIsSubstracedFromBalance()
    {
        int stroke = 3;

        double balanceBeforePurchase = StorageController.company.Balance;

        double expectedBalanace = 50000 - StorageController.availTrucks[stroke - 1].TruckPrice;

        Truck.HandlePurchase(stroke);

        double balanceAfterPurchase = StorageController.company.Balance;

        Assert.Equal(balanceAfterPurchase, expectedBalanace);
    }

    [Fact]
    public void TruckIsRemovedFromAvailTrucks()
    {
        var stroke = 5;
        var storageTrucks = StorageController.availTrucks;
        var chosenTruck = storageTrucks[stroke - 1];

        Truck.HandlePurchase(stroke);

        Assert.DoesNotContain(chosenTruck, storageTrucks);
    }

    [Fact]
    public void DriverIsRemovedFromAvailDrivers()
    {
        int stroke = 4;
        List<Driver> availDrivers = StorageController.availDrivers;
        Driver chosenDriver = StorageController.availDrivers[stroke - 1];

        Driver.HandleEmployment(stroke);

        Assert.DoesNotContain(chosenDriver, availDrivers);
    }

    [Fact]
    public void DriverIsAddedToCompany()
    {
        int stroke = 2;
        List<Driver> employedDrivers = StorageController.ownedDrivers;
        Driver chosenDriver = StorageController.availDrivers[stroke - 1];
        Driver.HandleEmployment(stroke);

        Assert.Contains(chosenDriver, employedDrivers);
    }

    [Fact]
    public void TenderIsRemovedFromAvailTenders()
    {
        int stroke = 6;
        List<Tender> availTenders = StorageController.availTenders;
        Tender chosenTender = StorageController.availTenders[stroke - 1];

        Tender.HandlePurchase(stroke);

        Assert.DoesNotContain(chosenTender, availTenders);
    }

    [Fact]
    public void TenderIsAddedToCompany()
    {
        int stroke = 3;
        List<Tender> acceptedTenders = StorageController.ownedTenders;
        Tender chosenTender = StorageController.availTenders[stroke - 1];
        Tender.HandlePurchase(stroke);

        Assert.Contains(chosenTender, acceptedTenders);
    }
/*
    [Fact]
    public void DayIsEnded()
    {
        DateTime expectedDate = storage.company.Date.AddDays(1);

        TransporterConsole.EndDay();

        DateTime nextDay = storage.company.Date;

        Assert.Equal<string>(expectedDate.ToShortDateString(), nextDay.ToShortDateString());
    }*/


//ToDo truckAge mit -1 testen
}