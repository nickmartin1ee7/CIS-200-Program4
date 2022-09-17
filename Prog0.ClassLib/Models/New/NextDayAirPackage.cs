namespace Prog0.ClassLib.Models.New;

public class NextDayAirPackage : AirPackage
{
    public NextDayAirPackage(Address originAddress,
        Address destinationAddress,
        double length,
        double width,
        double height,
        double weight,
        decimal expressFee)
        : base(originAddress, destinationAddress, length, width, height, weight)
    {
        ExpressFee = expressFee < 0 ? throw new ArgumentOutOfRangeException(nameof(expressFee), "Value cannot be negative") : expressFee;
    }

    public decimal ExpressFee { get; }

    public override decimal CalcCost()
    {
        const decimal dimentionMultiplier = 0.35M;
        const decimal weightMultiplier = 0.25M;

        const decimal heavyMultiplier = 0.2M;
        const decimal largeMultiplier = 0.22M;

        decimal dimentions = (decimal)(Length + Width + Height);
        decimal decimalWeight = (decimal)Weight;

        decimal heavySurcharge = IsHeavy() ? heavyMultiplier * decimalWeight : 0M;
        decimal largeSurcharge = IsLarge() ? largeMultiplier * dimentions : 0M;

        return dimentionMultiplier * dimentions
            + weightMultiplier * decimalWeight
            + ExpressFee
            + heavySurcharge
            + largeSurcharge;
    }
}
