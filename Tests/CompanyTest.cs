using Xunit;
using Xunit.Sdk;

namespace Abgabe_1_2;

public class CompanyTest
{
    [Fact]
    public void DayIsEnded()
    {
        DateTime expectedDate = StorageController.company.Date.AddDays(1);

        BusinessLogic.EndDay();

        DateTime nextDay = StorageController.company.Date;

        Assert.Equal(expectedDate.ToShortDateString(), nextDay.ToShortDateString());
        // Assert.Matches(expectedDate.ToShortDateString(), nextDay.ToShortDateString());
    }
}