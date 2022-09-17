namespace Prog0.ClassLib.Models.New;

public abstract class AirPackage : Package
{
    private const double HEAVY_WEIGHT = 75;
    private const double LARGE_SIZE = 100;

    public AirPackage(Address originAddress,
        Address destinationAddress,
        double length,
        double width,
        double height,
        double weight)
        : base(originAddress, destinationAddress, length, width, height, weight)
    {
    }

    public bool IsHeavy() => Weight >= HEAVY_WEIGHT;

    public bool IsLarge() => Length + Width + Height >= LARGE_SIZE;

    public override string ToString() =>
        base.ToString() +
        Environment.NewLine +
        $"Is Heavy: {IsHeavy()}; Is Large: {IsLarge()}";
}
