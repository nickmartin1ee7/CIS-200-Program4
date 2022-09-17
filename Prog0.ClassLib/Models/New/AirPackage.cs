namespace Prog0.ClassLib.Models.New;

/// <summary>
/// An abstraction representing an air package that detemines whether the package is heavy or large.
/// </summary>
public abstract class AirPackage : Package
{
    private const double HEAVY_WEIGHT = 75; // Weight in pounds that determines if the package is heavy
    private const double LARGE_SIZE = 100; // Total dimentions in inches determines if the package is large

    /// <summary>
    /// Defines a constructor that passes along required parameters to <see cref="Package"/>.
    /// </summary>
    /// <param name="originAddress">Passed to base <see cref="Package"/>.</param>
    /// <param name="destinationAddress">Passed to base <see cref="Package"/>.</param>
    /// <param name="length">Passed to base <see cref="Package"/>.</param>
    /// <param name="width">Passed to base <see cref="Package"/>.</param>
    /// <param name="height">Passed to base <see cref="Package"/>.</param>
    /// <param name="weight">Passed to base <see cref="Package"/>.</param>
    public AirPackage(Address originAddress,
        Address destinationAddress,
        double length,
        double width,
        double height,
        double weight)
        : base(originAddress, destinationAddress, length, width, height, weight)
    {
    }

    /// <summary>
    /// Detemines if the package's weight is considered heavy (surcharge fee).
    /// </summary>
    /// <returns>true if above 75 pounds; otherwise, false</returns>
    public bool IsHeavy() => Weight >= HEAVY_WEIGHT;

    /// <summary>
    /// Detemines if the package's total dimentions is considered long (surcharge fee).
    /// </summary>
    /// <returns>true if above 100 inches; otherwise, false</returns>
    public bool IsLarge() => Length + Width + Height >= LARGE_SIZE;

    /// <summary>
    /// Creates a textual representation of this instance.
    /// </summary>
    /// <returns>The base ToString with additional Is Heavy and Is Large sections.</returns>
    public override string ToString() =>
        base.ToString() +
        Environment.NewLine +
        $"Is Heavy: {IsHeavy()}; Is Large: {IsLarge()}";
}
