namespace Prog0.ClassLib.Models.New;

public class TwoDayAirPackage : AirPackage
{
    private Delivery _deliveryType; // Backing field

    /// <summary>
    /// Defines a constructor that passes along required parameters to <see cref="AirPackage"/> with an additional <see cref="ExpressFee"/>.
    /// </summary>
    /// <param name="originAddress">Passed to base <see cref="AirPackage"/>.</param>
    /// <param name="destinationAddress">Passed to base <see cref="AirPackage"/>.</param>
    /// <param name="length">Passed to base <see cref="AirPackage"/>.</param>
    /// <param name="width">Passed to base <see cref="AirPackage"/>.</param>
    /// <param name="height">Passed to base <see cref="AirPackage"/>.</param>
    /// <param name="weight">Passed to base <see cref="AirPackage"/>.</param>
    /// <param name="deliveryType">The service level to use during cost calculation.</param>
    public TwoDayAirPackage(Address originAddress,
            Address destinationAddress,
            double length,
            double width,
            double height,
            double weight,
            Delivery deliveryType)
            : base(originAddress, destinationAddress, length, width, height, weight)
    {
        DeliveryType = deliveryType;
    }

    /// <summary>
    /// The service level to use during cost calculation.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Validated to be a valid <see cref="DeliveryType"/>; otherwise, throws</exception>
    public Delivery DeliveryType
    {
        get => _deliveryType;
        set
        {
            if (!Enum.GetValues<Delivery>().Contains(value))
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid delivery type");

            _deliveryType = value;
        }
    }

    /// <summary>
    /// Calculates the cost of the air package with a discount applied for Saver deliver type.
    /// </summary>
    /// <returns></returns>
    public override decimal CalcCost()
    {
        const decimal dimentionMultiplier = 0.18M;
        const decimal weightMultiplier = 0.20M;

        const decimal saverMultiplier = 0.15M;

        decimal discount = DeliveryType == Delivery.Saver ? 1M - saverMultiplier : 1M;

        decimal dimentions = (decimal)(Length + Width + Height);
        decimal decimalWeight = (decimal)Weight;

        return dimentionMultiplier * dimentions
            + weightMultiplier * decimalWeight
            * discount;
    }

    /// <summary>
    /// The deliver service level for the package.
    /// </summary>
    public enum Delivery
    {
        Early,
        Saver // Discounted cost
    }
}
