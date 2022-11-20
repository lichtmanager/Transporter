using Xunit;

namespace Abgabe_1_2;

public class TenderTest
{
    [Fact]
    public void TenderIsRemovedFromAvailTenders()
    {
        int stroke = 6;
        List<Tender> availTenders = StorageController.availTenders;
        Tender chosenTender = StorageController.availTenders[stroke - 1];

        Tender.HandlePurchase(stroke);

        Assert.DoesNotContain(chosenTender, availTenders);
    }

    [Fact]
    public void TenderIsAddedToCompany()
    {
        int stroke = 3;
        List<Tender> acceptedTenders = StorageController.ownedTenders;
        Tender chosenTender = StorageController.availTenders[stroke - 1];
        Tender.HandlePurchase(stroke);

        Assert.Contains(chosenTender, acceptedTenders);
    }
}