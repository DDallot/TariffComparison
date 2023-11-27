using Api.TariffComparison.Services.TariffComparison.v1.Tariffs;

namespace Api.TariffComparison.Xunit.TariffComparison.v1.Tariffs;

public class PackagedTariffUnitTest
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(3500, 800, 4000, 30, 800)]
    [TestCase(4500, 800, 4000, 30, 950)]
    public void CalculateAnnualCostsTest(int consumptionKwh, decimal baseCost, int includedKwh, decimal additionalKwhCost, decimal expectedCost)
    {
        // Arrange
        var packagedTariff = new PackagedTariff(baseCost, includedKwh, additionalKwhCost);

        // Act
        var result = packagedTariff.CalculateAnnualCosts(consumptionKwh);

        // Assert
        Assert.That(result, Is.EqualTo(expectedCost));
    }
}