using Prog0.ClassLib.BusinessLogic;
using Prog0.ClassLib.Models.New;

namespace Prog0.Tests
{
    internal class LinqTests
    {
        private List<Address> _addresses;
        private List<Parcel> _parcels;

        [SetUp]
        public void Setup()
        {
            _addresses = new List<Address>
            {
                new Address("John Smith", "123 Any St.", "Apt. 45", "Louisville", "KY", 40000),
                new Address("Smith Smith", "123 Any St.", "Apt. 45", "Louisville", "KY", 40202),
                new Address("Jane Doe", "987 Main St.", "Beverly Hills", "CA", 90210),
                new Address("James Kirk", "654 Roddenberry Way", "Suite 321", "El Paso", "TX", 79901),
                new Address("John Crichton", "678 Pau Place", "Apt. 7", "Portland", "ME", 04101),
                new Address("Crichton John", "123 Any St.", "Apt. 45", "Louisville", "KY", 40204),
                new Address("Jane Doe", "987 Main St.", "Beverly Hills", "CA", 90290),
                new Address("James Kirk", "654 Roddenberry Way", "Suite 321", "El Paso", "TX", 79902),
            };

            _parcels = new List<Parcel>
            {
                new Letter(_addresses[0], _addresses[1], 0.50M),
                new Letter(_addresses[2], _addresses[3], 1.20M),
                new Letter(_addresses[3], _addresses[1], 1.70M),
                new GroundPackage(_addresses[0], _addresses[1], 100, 100, 100, 100),
                new GroundPackage(_addresses[0], _addresses[1], 1, 1, 1, 1),
                new NextDayAirPackage(_addresses[2], _addresses[3], 5, 5, 5, 5, 250.99M),
                new NextDayAirPackage(_addresses[2], _addresses[3], 100, 100, 100, 100, 250.99M),
                new TwoDayAirPackage(_addresses[2], _addresses[3], 5, 5, 5, 5, TwoDayAirPackage.Delivery.Early),
                new TwoDayAirPackage(_addresses[2], _addresses[3], 5, 5, 5, 5, TwoDayAirPackage.Delivery.Saver),
                new TwoDayAirPackage(_addresses[2], _addresses[3], 100, 100, 100, 75, TwoDayAirPackage.Delivery.Early),
                new TwoDayAirPackage(_addresses[2], _addresses[3], 100, 100, 100, 80, TwoDayAirPackage.Delivery.Saver),
                new Letter(_addresses[4], _addresses[5], 0.50M),
                new Letter(_addresses[6], _addresses[7], 1.20M),
                new Letter(_addresses[7], _addresses[4], 1.70M),
                new GroundPackage(_addresses[4], _addresses[5], 100, 100, 100, 100),
                new GroundPackage(_addresses[4], _addresses[5], 1, 1, 1, 1),
                new NextDayAirPackage(_addresses[6], _addresses[7], 5, 5, 5, 5, 250.99M),
                new NextDayAirPackage(_addresses[6], _addresses[7], 100, 100, 100, 100, 250.99M),
                new TwoDayAirPackage(_addresses[6], _addresses[7], 5, 5, 5, 5, TwoDayAirPackage.Delivery.Early),
                new TwoDayAirPackage(_addresses[6], _addresses[7], 5, 5, 5, 5, TwoDayAirPackage.Delivery.Saver),
                new TwoDayAirPackage(_addresses[6], _addresses[7], 100, 100, 100, 999, TwoDayAirPackage.Delivery.Early),
                new TwoDayAirPackage(_addresses[6], _addresses[7], 100, 100, 100, 1000, TwoDayAirPackage.Delivery.Saver)
            };
        }

        [TestCase]
        public void OrderByDestinationZip_ShouldBe_Descending()
        {
            var ordered = _parcels.OrderByDestinationZip();

            Assert.That(
                    ordered.Select(p => p.DestinationAddress.Zip).First(),
                Is.GreaterThan(
                    ordered.Select(p => p.DestinationAddress.Zip).Last()));
        }

        [TestCase]
        public void OrderByCost_ShouldBe_Ascending()
        {
            var costs = _parcels.OrderByCost()
                .Select(p => p.CalcCost())
                .ToList(); // Avoid multiple enumerations

            Assert.That(
                    costs.First(),
                Is.LessThan(
                    costs.Last()));
        }

        [TestCase]
        public void OrderByTypeAscendingThenByCostDescending_ShouldBe_ParcelAscending()
        {
            var ordered = _parcels.OrderByTypeAscendingThenByCostDescending()
                .Select(p => p.GetType().Name)
                .ToList(); // Avoid multiple enumerations

            Assert.That(
                    ordered.First(),
                Is.LessThan(
                    ordered.Last()));
        }

        [TestCase]
        public void OrderByTypeAscendingThenByCostDescending_ShouldBe_CostDescending()
        {
            var costs = _parcels.OrderByTypeAscendingThenByCostDescending()
                .Select(p => p.CalcCost())
                .ToList(); // Avoid multiple enumerations

            Assert.That(
                    costs.First(),
                Is.GreaterThan(
                    costs.Last()));
        }

        [TestCase]
        public void OrderByAirPackageWeightDescending_ShouldBe_OnlyHeavy()
        {
            var heavyAirPackages = _parcels.OrderByAirPackageWeightDescending()
                .Select(p => p as AirPackage)
                .Where(airP => airP?.IsHeavy() ?? false)
                .Count();

            Assert.That(heavyAirPackages, Is.EqualTo(6));
        }

        [TestCase]
        public void OrderByAirPackageWeightDescending_ShouldBe_WeightDescending()
        {
            var weights = _parcels.OrderByAirPackageWeightDescending()
                .Select(p => p as AirPackage)
                .Select(p => p?.Weight)
                .ToList(); // Avoid multiple enumerations

            Assert.That(
                    weights.First(),
                Is.GreaterThan(
                    weights.Last()));
        }
    }
}
