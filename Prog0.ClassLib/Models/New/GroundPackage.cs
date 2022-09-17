namespace Prog0.ClassLib.Models.New;

/// <summary>
/// A concrete class detailing a package transported through ground.
/// </summary>
public class GroundPackage : Package
{
    private const decimal DIMENTION_MULTIPLIER = 0.15M; // Applied rate to package's total dimentions
    private const decimal ZONE_MULTIPLIER = 0.07M; // Applied rate to package's difference in zipcode (Zone Distance)

    /// <summary>
    /// Defines a constructor that passes along required parameters to <see cref="Package"/>.
    /// </summary>
    /// <param name="originAddress">Passed to base <see cref="Package"/>.</param>
    /// <param name="destinationAddress">Passed to base <see cref="Package"/>.</param>
    /// <param name="length">Passed to base <see cref="Package"/>.</param>
    /// <param name="width">Passed to base <see cref="Package"/>.</param>
    /// <param name="height">Passed to base <see cref="Package"/>.</param>
    /// <param name="weight">Passed to base <see cref="Package"/>.</param>
    public GroundPackage(Address originAddress,
        Address destinationAddress,
        double length,
        double width,
        double height,
        double weight)
        : base(originAddress, destinationAddress, length, width, height, weight)
    {
    }

    /// <summary>
    /// Represents the difference in the first digit's of the origin and destination zip code.
    /// Ex: 40213 - 31000 -> 4 - 3 = 1
    /// </summary>
    public int ZoneDistance =>
        GetFirstDigit(OriginAddress.Zip) - GetFirstDigit(DestinationAddress.Zip);

    /// <summary>
    /// Calculates the cost of the ground package based on the dimentions, zone distance, and weight.
    /// </summary>
    /// <returns>The cost for the ground parcel.</returns>
    public override decimal CalcCost() =>
        DIMENTION_MULTIPLIER * (decimal)(Length + Weight + Height) + ZONE_MULTIPLIER * (ZoneDistance + 1) * (decimal)Weight;

    public override string ToString() =>
        base.ToString() +
        Environment.NewLine +
        $"Zone Distance: {ZoneDistance}";

    /// <summary>
    /// Helper method that converts a number to a string in order to grab the first character, then convert that first character into an integer.
    /// </summary>
    /// <param name="number">An integer to get the first digit of.</param>
    /// <returns>The first digit of the provided integer.</returns>
    private int GetFirstDigit(int number) =>
        int.Parse($"{$"{Math.Abs(number)}"[0]}");
}
