using System.Data.Common;
using Transporter.Controller;
using Transporter.Models;
using Transporter.View;
using Xunit;

namespace Transporter.Tests;

public class CompanyActionsTests
{
    private void BuySomeRecourcesForTheCompany()
    {
        StorageController.OwnedTrucks = Initializer.InitializeNTrucks(5);
        StorageController.AcceptedTenders = Initializer.InitializeNTenders(5);
        StorageController.EmployedDrivers = Initializer.InitializeNDrivers(5);
    }

    [Fact]
    internal void AssignTenderToTruck_Test()
    {
        BuySomeRecourcesForTheCompany();

        var chosenTender = StorageController.AcceptedTenders[4];

        CompanyActions.AssignTenderToTruck(4, 4);

        Assert.Equal(chosenTender, StorageController.OwnedTrucks[4].Tender);
        Assert.Equal(Truck.Status.Booked, StorageController.OwnedTrucks[4].TruckState);
    }

    [Fact]
    internal void AssignDriverToTruck_Test()
    {
        BuySomeRecourcesForTheCompany();

        var chosenTruck = StorageController.OwnedTrucks[3];
        var chosenDriver = StorageController.EmployedDrivers[4];

        CompanyActions.AssignDriverToTruck(3 + 1, 4 + 1);

        Assert.Equal(chosenDriver, StorageController.OwnedTrucks[3].TruckDriver);
        Assert.Equal(chosenTruck, StorageController.EmployedDrivers[4].AssignedTruck);
    }

    [Fact]
    internal void UnassignDriverFromTruck_Test()
    {
        BuySomeRecourcesForTheCompany();
        var stroke1 = 2;
        var stroke2 = 3;

        CompanyActions.AssignDriverToTruck(stroke1, stroke2);
        var truckBeforeUnassign = StorageController.OwnedTrucks[stroke1 - 1];
        var driverBeforeUnassign = StorageController.EmployedDrivers[stroke2 - 1];

        CompanyActions.UnassignDriverFromTruck(stroke1, stroke2);
        var driverAfterUnassing = StorageController.EmployedDrivers[stroke2 - 1];


        Assert.Null(StorageController.OwnedTrucks[stroke1 - 1].TruckDriver);
        Assert.Null(StorageController.EmployedDrivers[stroke2 - 1].AssignedTruck);
        Assert.Equal(truckBeforeUnassign.TruckDriver, driverBeforeUnassign);
    }
}