using Transporter.Controller;
using Transporter.View;
using Xunit;


namespace Transporter.Tests;

public class CompanyTest
{
    [Fact]
    public void DayIsEnded()
    {
        DateTime expectedDate = StorageController.company.Date.AddDays(1);

        BusinessLogic.EndDay();

        DateTime nextDay = StorageController.company.Date;

        Assert.Equal(expectedDate, nextDay);
    }
}