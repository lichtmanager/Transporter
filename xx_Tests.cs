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
        List<Truck> storageTrucks = storage.availTrucks;
        List<Truck> boughtTrucks = storage.ownedTrucks;
        Truck chosenTruck = storageTrucks[stroke - 1];

        Truck.HandlePurchase(stroke);

        Assert.Contains(chosenTruck, boughtTrucks);
    }

    [Fact]
    public void PriceIsSubstracedFromBalance()
    {
        int stroke = 3;

        double balanceBeforePurchase = storage.company.Balance;

        double expectedBalanace = 50000 - storage.availTrucks[stroke - 1].TruckPrice;

        Truck.HandlePurchase(stroke);

        double balanceAfterPurchase = storage.company.Balance;

        Assert.Equal(balanceAfterPurchase, expectedBalanace);
    }

    [Fact]
    public void TruckIsRemovedFromAvailTrucks()
    {
        int stroke = 5;
        List<Truck> storageTrucks = storage.availTrucks;
        Truck chosenTruck = storageTrucks[stroke - 1];

        Truck.HandlePurchase(stroke);

        Assert.DoesNotContain(chosenTruck, storageTrucks);
    }

    [Fact]
    public void DriverIsRemovedFromAvailDrivers()
    {
        int stroke = 4;
        List<Driver> availDrivers = storage.availDrivers;
        Driver chosenDriver = storage.availDrivers[stroke - 1];

        Driver.HandlePurchase(stroke);

        Assert.DoesNotContain(chosenDriver, availDrivers);
    }

    [Fact]
    public void lala()
    {
    }
}