using Transporter.Controller;
using Xunit;

namespace Transporter.Tests;

public class TruckActionsTest
{
    [Fact]
    internal void Test_CalculateArrivalDate()
    {
        const int assertedHours = 155;
        const int expectedDays = 20;

        DateTime calculatedDate = TruckActions.CalculateArrivalDate(assertedHours);

        DateTime expectedDate = DateTime.Today.AddDays(expectedDays);

        Assert.Equal(expectedDate, calculatedDate);
    }

    [Fact]
    internal void Test_CalculateTravelTimeInHours()
    {
    }

    [Fact]
    internal void Test_SpeedOfTruck()
    {
    }

    [Fact]
    internal void Test_CalculateFuelPrice()
    {
    }
}