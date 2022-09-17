using Prog0.ClassLib.Models.New;

namespace Prog0.Tests
{
    public class GroundPackageTests
    {

        [TestCase(-1, 0, 0, 0)]
        [TestCase(0, -1, 0, 0)]
        [TestCase(0, 0, -1, 0)]
        [TestCase(0, 0, 0, -1)]
        public void Ctor_ShouldThrow_WhenPassedNegativeArguments(double length, double width, double height, double weight)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var origin = new Address("TestA", "123 Unit Test Rd.", "Louisville", "KY", 10000);
                var destination = new Address("TestB", "456 Unit Test Rd.", "Louisville", "KY", 50000);

                new GroundPackage(origin, destination, length, width, height, weight);
            });
        }

        [TestCase(1000, 2000, -1)]
        [TestCase(5000, 1000, 4)]
        public void ZoneDistance_ShouldCalculateDifference(int originZip, int destZip, int difference)
        {
            var origin = new Address("TestA", "123 Unit Test Rd.", "Louisville", "KY", originZip);
            var destination = new Address("TestB", "456 Unit Test Rd.", "Louisville", "KY", destZip);

            var groundPackage = new GroundPackage(origin, destination, 1, 1, 1, 1);

            Assert.That(groundPackage.ZoneDistance, Is.EqualTo(difference));
        }

        [TestCase(1, 1, 1, 1, 2000, 1000, 0.59)]
        [TestCase(10, 10, 10, 10, 5000, 1000, 8)]
        [TestCase(100, 100, 100, 100, 1000, 5000, 24)]
        public void CalcCost_ShouldCalculate(double length, double width, double height, double weight, int originZip, int destZip, decimal cost)
        {
            var origin = new Address("TestA", "123 Unit Test Rd.", "Louisville", "KY", originZip);
            var destination = new Address("TestB", "456 Unit Test Rd.", "Louisville", "KY", destZip);

            var groundPackage = new GroundPackage(origin, destination, length, width, height, weight);

            Assert.That(groundPackage.CalcCost(), Is.EqualTo(cost));
        }
    }
}