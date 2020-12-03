using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.Helpers
{
    public class CoordinateHelper
    {
        public static bool IsCoordinateInRange(double latFrom, double longFrom, double latTo, double longTo, int km)
        {
            double distance = HaversineFormula(latFrom, longFrom, latTo, longTo);

            return (distance <= km) ? true : false;
        }

        //stolen from: https://github.com/sahgilbert/parallel-haversine-formula-dotnetcore/blob/master/SimonGilbert.Blog/HaversineService.cs
        public static double HaversineFormula(double latFrom, double longFrom, double latTo, double longTo)
        {
            const double EquatorialRadiusOfEarth = 6371D;
            const double DegreesToRadians = (Math.PI / 180D);

            var deltalat = (latTo - latFrom) * DegreesToRadians;
            var deltalong = (longTo - longFrom) * DegreesToRadians;

            var a = Math.Pow(
                Math.Sin(deltalat / 2D), 2D) +
                Math.Cos(latFrom * DegreesToRadians) *
                Math.Cos(latTo * DegreesToRadians) *
                Math.Pow(Math.Sin(deltalong / 2D), 2D);

            var c = 2D * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1D - a));

            var d = EquatorialRadiusOfEarth * c;

            return d;
        }
    }
}
