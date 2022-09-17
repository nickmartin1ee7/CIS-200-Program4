namespace Prog0.ClassLib.Models.New;

public class TwoDayAirPackage : AirPackage
{
    private Delivery _deliveryType;

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

    public enum Delivery
    {
        Early,
        Saver
    }
}
