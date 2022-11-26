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
        List<Truck> storageTrucks = StorageController.AvailTrucks;
        List<Truck> boughtTrucks = StorageController.OwnedTrucks;
        Truck chosenTruck = storageTrucks[stroke - 1];

        BusinessLogic.PurchaseTruck(stroke);

        Assert.Contains(chosenTruck, boughtTrucks);
    }

    [Fact]
    public void PriceIsSubtractedFromBalance()
    {
        int stroke = 3;


        double expectedBalanace = 50000 - StorageController.AvailTrucks[stroke - 1].TruckPrice;

        BusinessLogic.PurchaseTruck(stroke);

        double balanceAfterPurchase = StorageController.Company.Balance;

        Assert.Equal(balanceAfterPurchase, expectedBalanace);
    }

    [Fact]
    public void TruckIsRemovedFromAvailTrucks()
    {
        var stroke = 5;
        var storageTrucks = StorageController.AvailTrucks;
        var chosenTruck = storageTrucks[stroke - 1];

        BusinessLogic.PurchaseTruck(stroke);

        Assert.DoesNotContain(chosenTruck, storageTrucks);
    }
}