namespace Prog0.ClassLib.BusinessLogic;

public class DestinationZipParcelComparer : IComparer<Parcel>
{
    /// <summary>
    /// Use <see cref="Default"/> instead of creating a new instance.
    /// </summary>
    protected DestinationZipParcelComparer()
    {
    }

    /// <summary>
    /// Avoids additional allocations by returning the same comparer object every time.
    /// </summary>
    public static DestinationZipParcelComparer Default { get; } = new();

    /// <summary>
    /// A <see cref="Parcel"/> comparer that compares the destination of <see cref="y"/>'s Zip to <see cref="x"/>'s Zip.
    /// </summary>
    /// <param name="x">The first parcel to compare.</param>
    /// <param name="y">The second parcel to compare.</param>
    /// <returns>
    /// -1 if <see cref="y"/>'s destination zip is less than <see cref="x"/>'s destination zip.
    /// 0 if <see cref="y"/>'s destination zip is equal to <see cref="x"/>'s destination zip.
    /// 1 if <see cref="y"/>'s destination zip is greater than <see cref="x"/>'s destination zip.
    /// </returns>
    /// <exception cref="ArgumentNullException">Inputs cannot be null.</exception>
    public int Compare(Parcel? x, Parcel? y)
    {
        _ = x ?? throw new ArgumentNullException(nameof(x));
        _ = y ?? throw new ArgumentNullException(nameof(y));
        
        return y.DestinationAddress.Zip.CompareTo(x.DestinationAddress.Zip);
    }
}