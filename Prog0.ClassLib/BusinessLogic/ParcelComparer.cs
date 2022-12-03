public class ParcelComparer : IComparer<Parcel>
{
    public int Compare(Parcel? x, Parcel? y)
    {
        return y.DestinationAddress.Zip.CompareTo(x.DestinationAddress.Zip);
    }
}