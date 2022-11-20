using Transporter.Controller;
using Transporter.Models;
using Transporter.View;
using Xunit;

namespace Transporter.Tests;

public class TruckTest
{
    [Fact]
    public void SelectedTruckIsAddedToCompany()
    {
        int stroke = 5;
        List<Truck> storageTrucks = StorageController.availTrucks;
        List<Truck> boughtTrucks = StorageController.ownedTrucks;
        Truck chosenTruck = storageTrucks[stroke - 1];

        BusinessLogic.PurchaseTruck(stroke);

        Assert.Contains(chosenTruck, boughtTrucks);
    }

    [Fact]
    public void PriceIsSubtractedFromBalance()
    {
        int stroke = 3;


        double expectedBalanace = 50000 - StorageController.availTrucks[stroke - 1].TruckPrice;

        BusinessLogic.PurchaseTruck(stroke);

        double balanceAfterPurchase = StorageController.company.Balance;

        Assert.Equal(balanceAfterPurchase, expectedBalanace);
    }

    [Fact]
    public void TruckIsRemovedFromAvailTrucks()
    {
        var stroke = 5;
        var storageTrucks = StorageController.availTrucks;
        var chosenTruck = storageTrucks[stroke - 1];

        BusinessLogic.PurchaseTruck(stroke);

        Assert.DoesNotContain(chosenTruck, storageTrucks);
    }
}