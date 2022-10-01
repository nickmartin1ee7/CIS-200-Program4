using Prog0.ClassLib.Models.New;

namespace Prog0.ClassLib.BusinessLogic
{
    public static class ParcelSortingExtensions
    {
        public static IEnumerable<Parcel> OrderByDestinationZip(this IEnumerable<Parcel> parcels)
        {
            return from p in parcels
                   orderby p.DestinationAddress.Zip descending
                   select p;
        }

        public static IEnumerable<Parcel> OrderByCost(this IEnumerable<Parcel> parcels)
        {
            return from p in parcels
                   orderby p.CalcCost() ascending
                   select p;
        }

        public static IEnumerable<Parcel> OrderByTypeAscendingThenByCostDescending(this IEnumerable<Parcel> parcels)
        {
            return from p in parcels
                   orderby p.GetType().Name ascending, p.CalcCost() descending
                   select p;
        }

        public static IEnumerable<Parcel> OrderByAirPackageWeightDescending(this IEnumerable<Parcel> parcels)
        {
            return from p in parcels
                   where p is AirPackage airP && airP.IsHeavy()
                   let airP = (AirPackage)p
                   orderby airP.Weight descending
                   select airP;
        }
    }
}
