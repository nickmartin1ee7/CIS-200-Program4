/* Author: Nick Martin (5111752)
 * Program: 1B
 * Due: 10/08/2022
 * 
 * Notes:
 *    Tests are performed in Prog0.Tests
 */

using Prog0.ClassLib.BusinessLogic;
using Prog0.ClassLib.Models.New;

using static System.Console;

namespace Prog0;

class Program
{
    // Precondition:  None
    // Postcondition: Small list of Parcels is created and displayed
    static void Main(string[] args)
    {
        var addresses = new List<Address>
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

        var parcels = new List<Parcel>
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

        // Display data
        WriteLine("Program 1B - List of Parcels\n");

        foreach (Parcel p in parcels)
        {
            WriteLine(p);
            WriteLine("--------------------");
        }

        WriteLine("# Select all Parcels and order by destination zip (descending)");
        WriteLine(string.Join(Environment.NewLine, parcels.OrderByDestinationZip()));

        WriteLine("# Select all Parcels and order by cost (ascending)");
        WriteLine(string.Join(Environment.NewLine, parcels.OrderByCost()));

        WriteLine("# Select all Parcels and order by Parcel type (ascending) and then cost (descending)");
        WriteLine(string.Join(Environment.NewLine, parcels.OrderByTypeAscendingThenByCostDescending()));

        WriteLine("# Select all AirPackage objects that are heavy and order by weight (descending)");
        WriteLine(string.Join(Environment.NewLine, parcels.OrderByAirPackageWeightDescending()));
    }
}
