using Transporter.Controller;
using Transporter.View;
using Xunit;


namespace Transporter.Tests;

public class CompanyTest
{
    [Fact]
    public void DayIsEnded()
    {
        DateTime expectedDate = StorageController.Company.Date.AddDays(1);

        BusinessLogic.EndDay();

        DateTime nextDay = StorageController.Company.Date;

        Assert.Equal(expectedDate, nextDay);
    }
}