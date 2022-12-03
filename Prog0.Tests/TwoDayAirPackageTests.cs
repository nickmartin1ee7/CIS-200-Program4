using Prog0.ClassLib.Models.New;

namespace Prog0.Tests;

public class TwoDayAirPackageTests
{
    [TestCase(-1, 0, 0, 0, 0)]
    [TestCase(0, -1, 0, 0, 0)]
    [TestCase(0, 0, -1, 0, 0)]
    [TestCase(0, 0, 0, -1, 0)]
    [TestCase(0, 0, 0, 0, -1)]
    public void Ctor_ShouldThrow_WhenPassedNegativeArguments(double length, double width, double height, double weight,
        TwoDayAirPackage.Delivery deliveryType)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var origin = new Address("TestA", "123 Unit Test Rd.", "Louisville", "KY", 10000);
            var destination = new Address("TestB", "456 Unit Test Rd.", "Louisville", "KY", 50000);

            new TwoDayAirPackage(origin, destination, length, width, height, weight, deliveryType);
        });
    }

    [TestCase(1, 1, 1, 1, 0, 0.74)]
    [TestCase(1, 1, 1, 1, 1, 0.71)]
    [TestCase(10, 10, 10, 10, 0, 7.4)]
    [TestCase(10, 10, 10, 10, 1, 7.1)]
    [TestCase(100, 100, 100, 100, 0, 74)]
    [TestCase(100, 100, 100, 100, 1, 71)]
    public void CalcCost_ShouldCalculate(double length, double width, double height, double weight,
        TwoDayAirPackage.Delivery deliveryType, decimal cost)
    {
        var origin = new Address("TestA", "123 Unit Test Rd.", "Louisville", "KY", 1);
        var destination = new Address("TestB", "456 Unit Test Rd.", "Louisville", "KY", 2);

        var twoDayAirPackage = new TwoDayAirPackage(origin, destination, length, width, height, weight, deliveryType);

        Assert.That(twoDayAirPackage.CalcCost(), Is.EqualTo(cost));
    }
}