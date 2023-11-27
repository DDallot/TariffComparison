using Api.TariffComparison.Services.TariffComparison.v1.Tariffs;

namespace Api.TariffComparison.Xunit.TariffComparison.v1.Tariffs;

[TestFixture]
public class BasicElectricityTariffUnitTest
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(3500, 5, 22, 830)]
    [TestCase(4500, 5, 22, 1050)]
    public void CalculateAnnualCostsTest(int consumptionKwh, decimal baseCost, decimal additionalKwhCost, decimal expectedCost)
    {
        // Arrange
        var basicElectricityTariff = new BasicElectricityTariff(baseCost, additionalKwhCost);

        // Act
        var result = basicElectricityTariff.CalculateAnnualCosts(consumptionKwh);

        // Assert
        Assert.That(result, Is.EqualTo(expectedCost));
    }
}