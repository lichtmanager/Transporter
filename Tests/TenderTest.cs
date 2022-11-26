using Transporter.Controller;
using Transporter.Models;
using Transporter.View;
using Xunit;

namespace Transporter.Tests;

public class TenderTest
{
    [Fact]
    public void TenderIsRemovedFromAvailTenders()
    {
        int stroke = 6;
        List<Tender> availTenders = StorageController.availTenders;
        Tender chosenTender = StorageController.availTenders[stroke - 1];

        BusinessLogic.AcceptTender(stroke);

        Assert.DoesNotContain(chosenTender, availTenders);
    }

    [Fact]
    public void TenderIsAddedToCompany()
    {
        int stroke = 3;
        List<Tender> acceptedTenders = StorageController.acceptedTenders;
        Tender chosenTender = StorageController.availTenders[stroke - 1];
        BusinessLogic.AcceptTender(stroke);

        Assert.Contains(chosenTender, acceptedTenders);
    }
}