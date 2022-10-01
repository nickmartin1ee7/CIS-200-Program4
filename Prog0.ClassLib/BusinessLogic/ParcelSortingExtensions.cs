using Prog0.ClassLib.Models.New;

namespace Prog0.ClassLib.BusinessLogic
{
    public static class ParcelSortingExtensions
    {
        public static IEnumerable<Parcel> OrderByDestinationZip(this IEnumerable<Parcel> parcels, bool descending = false)
        {
            return descending
                ? from p in parcels
                  orderby p.DestinationAddress.Zip descending
                  select p
                : from p in parcels
                  orderby p.DestinationAddress.Zip ascending
                  select p;
        }

        public static IEnumerable<Parcel> OrderByCost(this IEnumerable<Parcel> parcels, bool descending = false)
        {
            return descending
                ? from p in parcels
                  orderby p.CalcCost() descending
                  select p
                : from p in parcels
                  orderby p.CalcCost() ascending
                  select p;
        }

        public static IEnumerable<Parcel> OrderByTypeThenByCostDescending(this IEnumerable<Parcel> parcels)
        {
            return from p in parcels
                   orderby p.GetType().Name ascending
                   orderby p.CalcCost() descending
                   select p;
        }

        public static IEnumerable<Parcel> OrderByParcelWeightDescending(this IEnumerable<Parcel> parcels)
        {
            return from p in parcels
                   where p is AirPackage airP && airP.IsHeavy()
                   let airP = (AirPackage)p
                   orderby airP.Weight descending
                   select airP;
        }
    }
}
