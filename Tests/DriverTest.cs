using Xunit;

namespace Abgabe_1_2.Tests;

public class DriverTest
{
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
}