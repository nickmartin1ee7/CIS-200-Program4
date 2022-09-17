namespace Prog0.ClassLib.Models.New;

public class GroundPackage : Package
{
    private const decimal DIMENTION_MULTIPLIER = 0.15M;
    private const decimal ZONE_MULTIPLIER = 0.07M;

    public GroundPackage(Address originAddress,
        Address destinationAddress,
        double length,
        double width,
        double height,
        double weight)
        : base(originAddress, destinationAddress, length, width, height, weight)
    {
    }

    public int ZoneDistance =>
        $"{OriginAddress.Zip}"[0] - $"{DestinationAddress.Zip}"[0];

    public override decimal CalcCost() =>
        DIMENTION_MULTIPLIER * (decimal)(Length + Weight + Height) + ZONE_MULTIPLIER * (ZoneDistance + 1) * (decimal)Weight;

    public override string ToString() =>
        base.ToString() +
        Environment.NewLine +
        $"Zone Distance: {ZoneDistance}";
}
