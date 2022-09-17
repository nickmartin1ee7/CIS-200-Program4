namespace Prog0.ClassLib.Models.New;

public abstract class Package : Parcel
{
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

    public double Length { get; }
    public double Width { get; }
    public double Height { get; }
    public double Weight { get; }

    public override string ToString() =>
        base.ToString() +
        Environment.NewLine +
        $"Length: {Length}; Width: {Width}; Height: {Height}; Weight: {Weight}";
}
