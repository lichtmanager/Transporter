using Transporter.Controller;
using Transporter.Models;
using Transporter.View;
using Xunit;

namespace Transporter.Tests;

public class DriverTest
{
    [Fact]
    public void DriverIsRemovedFromAvailDrivers()
    {
        int stroke = 4;
        List<Driver> availDrivers = StorageController.availDrivers;
        Driver chosenDriver = StorageController.availDrivers[stroke - 1];

        BusinessLogic.EmployDriver(stroke);

        Assert.DoesNotContain(chosenDriver, availDrivers);
    }

    [Fact]
    public void DriverIsAddedToCompany()
    {
        int stroke = 2;
        List<Driver> employedDrivers = StorageController.ownedDrivers;
        Driver chosenDriver = StorageController.availDrivers[stroke - 1];
        BusinessLogic.EmployDriver(stroke);

        Assert.Contains(chosenDriver, employedDrivers);
    }
}