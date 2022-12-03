using Prog0.ClassLib.BusinessLogic;
using Prog0.ClassLib.Models.New;

namespace Prog0.Tests;

/// <summary>
///     This test class facilitates the requirement of the assignment "Write a simple test program that creates a  List of
///     at least 10  Parcel objects".
/// </summary>
public class ParcelSortingTests
{
    private List<Parcel> _parcels;

    [SetUp]
    public void Setup()
    {
        var addresses = new List<Address>
        {
            new("John Smith", "123 Any St.", "Apt. 45", "Louisville", "KY", 40000),
            new("Smith Smith", "123 Any St.", "Apt. 45", "Louisville", "KY", 40202),
            new("Jane Doe", "987 Main St.", "Beverly Hills", "CA", 90210),
            new("James Kirk", "654 Roddenberry Way", "Suite 321", "El Paso", "TX", 79901),
            new("John Crichton", "678 Pau Place", "Apt. 7", "Portland", "ME", 04101),
            new("Crichton John", "123 Any St.", "Apt. 45", "Louisville", "KY", 40204),
            new("Jane Doe", "987 Main St.", "Beverly Hills", "CA", 90290),
            new("James Kirk", "654 Roddenberry Way", "Suite 321", "El Paso", "TX", 79902)
        };

        _parcels = new List<Parcel>
        {
            new Letter(addresses[0], addresses[1], 0.50M),
            new Letter(addresses[2], addresses[3], 1.20M),
            new Letter(addresses[3], addresses[1], 1.70M),
            new GroundPackage(addresses[0], addresses[1], 100, 100, 100, 100),
            new GroundPackage(addresses[0], addresses[1], 1, 1, 1, 1),
            new NextDayAirPackage(addresses[2], addresses[3], 5, 5, 5, 5, 250.99M),
            new NextDayAirPackage(addresses[2], addresses[3], 100, 100, 100, 100, 250.99M),
            new TwoDayAirPackage(addresses[2], addresses[3], 5, 5, 5, 5, TwoDayAirPackage.Delivery.Early),
            new TwoDayAirPackage(addresses[2], addresses[3], 5, 5, 5, 5, TwoDayAirPackage.Delivery.Saver),
            new TwoDayAirPackage(addresses[2], addresses[3], 100, 100, 100, 100, TwoDayAirPackage.Delivery.Early),
            new TwoDayAirPackage(addresses[2], addresses[3], 100, 100, 100, 100, TwoDayAirPackage.Delivery.Saver),
            new Letter(addresses[4], addresses[5], 0.50M),
            new Letter(addresses[6], addresses[7], 1.20M),
            new Letter(addresses[7], addresses[4], 1.70M),
            new GroundPackage(addresses[4], addresses[5], 100, 100, 100, 100),
            new GroundPackage(addresses[4], addresses[5], 1, 1, 1, 1),
            new NextDayAirPackage(addresses[6], addresses[7], 5, 5, 5, 5, 250.99M),
            new NextDayAirPackage(addresses[6], addresses[7], 100, 100, 100, 100, 250.99M),
            new TwoDayAirPackage(addresses[6], addresses[7], 5, 5, 5, 5, TwoDayAirPackage.Delivery.Early),
            new TwoDayAirPackage(addresses[6], addresses[7], 5, 5, 5, 5, TwoDayAirPackage.Delivery.Saver),
            new TwoDayAirPackage(addresses[6], addresses[7], 100, 100, 100, 100, TwoDayAirPackage.Delivery.Early),
            new TwoDayAirPackage(addresses[6], addresses[7], 100, 100, 100, 100, TwoDayAirPackage.Delivery.Saver)
        }; // Test list of parcels
    }

    [Test]
    public void AscendingByCostTest()
    {
        WriteAllParcelsToConsole(_parcels); // Print original order
        _parcels.Sort();
        WriteAllParcelsToConsole(_parcels); // Print sorted order

        Assert.GreaterOrEqual(_parcels[^1].CalcCost(), _parcels[0].CalcCost());
        Assert.GreaterOrEqual(_parcels[^2].CalcCost(), _parcels[1].CalcCost());
        Assert.GreaterOrEqual(_parcels[^3].CalcCost(), _parcels[2].CalcCost());
    }

    [Test]
    public void DescendingByZipTest()
    {
        WriteAllParcelsToConsole(_parcels); // Print original order
        _parcels.Sort(DestinationZipParcelComparer.Default);
        WriteAllParcelsToConsole(_parcels); // Print destination zip sorted order
        
        Assert.GreaterOrEqual(_parcels[0].DestinationAddress.Zip, _parcels[^1].DestinationAddress.Zip);
        Assert.GreaterOrEqual(_parcels[1].DestinationAddress.Zip, _parcels[^2].DestinationAddress.Zip);
        Assert.GreaterOrEqual(_parcels[2].DestinationAddress.Zip, _parcels[^3].DestinationAddress.Zip);
    }

    /// <summary>
    /// Print out every parcel to console; delimited by newlines.
    /// </summary>
    /// <param name="parcels">Parcels to print.</param>
    private void WriteAllParcelsToConsole(IEnumerable<Parcel> parcels)
    {
        Console.WriteLine(string.Join(Environment.NewLine, parcels));
    }
}