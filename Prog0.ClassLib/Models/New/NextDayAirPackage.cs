namespace Prog0.ClassLib.Models.New;

/// <summary>
/// A concrete class detailing a priority package transported through air.
/// </summary>
public class NextDayAirPackage : AirPackage
{
    /// <summary>
    /// Defines a constructor that passes along required parameters to <see cref="AirPackage"/> with an additional <see cref="ExpressFee"/>.
    /// </summary>
    /// <param name="originAddress">Passed to base <see cref="AirPackage"/>.</param>
    /// <param name="destinationAddress">Passed to base <see cref="AirPackage"/>.</param>
    /// <param name="length">Passed to base <see cref="AirPackage"/>.</param>
    /// <param name="width">Passed to base <see cref="AirPackage"/>.</param>
    /// <param name="height">Passed to base <see cref="AirPackage"/>.</param>
    /// <param name="weight">Passed to base <see cref="AirPackage"/>.</param>
    /// <param name="expressFee">Fee to apply during cost calculation. Cannot be negative.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
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

    /// <summary>
    /// A positive fee that is applied during <see cref="CalcCost"/>.
    /// </summary>
    public decimal ExpressFee { get; }

    /// <summary>
    /// Calculates the cost of the air package with an additional <see cref="ExpressFee"/> and heavy and large package surcharges applied.
    /// </summary>
    /// <returns></returns>
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
