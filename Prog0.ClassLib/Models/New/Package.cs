namespace Prog0.ClassLib.Models.New;

public abstract class Package : Parcel
{
    /// <summary>
    /// An abstraction from a <see cref="Parcel"/> that includes dimentions about the parcel.
    /// </summary>
    /// <param name="originAddress">Passed to base class.</param>
    /// <param name="destinationAddress">Passed to base class.</param>
    /// <param name="length">In inches. Cannot be negative.</param>
    /// <param name="width">In inches. Cannot be negative.</param>
    /// <param name="height">In inches. Cannot be negative.</param>
    /// <param name="weight">In pounds. Cannot be negative.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if some parameters are negative.</exception>
    public Package(Address originAddress,
        Address destinationAddress,
        double length,
        double width,
        double height,
        double weight)
        : base(originAddress, destinationAddress)
    {
        OriginAddress = originAddress;
        DestinationAddress = destinationAddress;

        const string valueException = "Value cannot be negative";

        Length = length < 0 ? throw new ArgumentOutOfRangeException(nameof(length), valueException) : length;
        Width = width < 0 ? throw new ArgumentOutOfRangeException(nameof(width), valueException) : width;
        Height = height < 0 ? throw new ArgumentOutOfRangeException(nameof(height), valueException) : height;
        Weight = weight < 0 ? throw new ArgumentOutOfRangeException(nameof(weight), valueException) : weight;
    }

    /// <summary>
    /// The package's Length in inches.
    /// </summary>
    public double Length { get; }

    /// <summary>
    /// The package's Width in inches.
    /// </summary>
    public double Width { get; }

    /// <summary>
    /// The package's Height in inches.
    /// </summary>
    public double Height { get; }

    /// <summary>
    /// The package's Weight in pounds.
    /// </summary>
    public double Weight { get; }

    /// <summary>
    /// Creates a textual representation of this instance.
    /// </summary>
    /// <returns>The base ToString with additional dimentions and weight sections.</returns>
    public override string ToString() =>
        base.ToString() +
        Environment.NewLine +
        $"Length: {Length}; Width: {Width}; Height: {Height}; Weight: {Weight}";
}
