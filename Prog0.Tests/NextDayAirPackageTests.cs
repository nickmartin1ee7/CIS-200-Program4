using Prog0.ClassLib.Models.New;

namespace Prog0.Tests;

public class NextDayAirPackageTests
{
    [TestCase(-1, 0, 0, 0, 0)]
    [TestCase(0, -1, 0, 0, 0)]
    [TestCase(0, 0, -1, 0, 0)]
    [TestCase(0, 0, 0, -1, 0)]
    [TestCase(0, 0, 0, 0, -1)]
    public void Ctor_ShouldThrow_WhenPassedNegativeArguments(double length, double width, double height, double weight,
        decimal expressFee)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var origin = new Address("TestA", "123 Unit Test Rd.", "Louisville", "KY", 10000);
            var destination = new Address("TestB", "456 Unit Test Rd.", "Louisville", "KY", 50000);

            new NextDayAirPackage(origin, destination, length, width, height, weight, expressFee);
        });
    }

    [TestCase(1, 1, 1, 1, 1, 2.3)]
    [TestCase(10, 10, 10, 10, 10, 23)]
    [TestCase(100, 100, 100, 100, 100, 316)]
    public void CalcCost_ShouldCalculate(double length, double width, double height, double weight, decimal expressFee,
        decimal cost)
    {
        var origin = new Address("TestA", "123 Unit Test Rd.", "Louisville", "KY", 1);
        var destination = new Address("TestB", "456 Unit Test Rd.", "Louisville", "KY", 2);

        var nextDayAirPackage = new NextDayAirPackage(origin, destination, length, width, height, weight, expressFee);

        Assert.That(nextDayAirPackage.CalcCost(), Is.EqualTo(cost));
    }
}