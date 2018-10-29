using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geo
{
    public class GeoPoint
    {
        public readonly double Longitude;
        public readonly double Latitude;

        public GeoPoint(double latitude, double longitude)
        {
            if (Math.Abs(longitude)>180)
            {
                throw new ArgumentOutOfRangeException("Longitude cannot be less than -180 or more than 180");
            }
            if (Math.Abs(latitude) > 90)
            {
                throw new ArgumentOutOfRangeException("Latitude cannot be less than -90 or more than 90");
            }
            this.Longitude = longitude;
            this.Latitude = latitude;
        }

        public double GetDistance(GeoPoint secondPoint)
        {
            return GetDistance(this, secondPoint);
        }

        public static double GetDistance(GeoPoint firstPoint, GeoPoint secondPoint)
        {
            if ((firstPoint == null) || (secondPoint == null))
            {
                throw new ArgumentNullException();
            }

            var firstLatitudeRad = Math.PI * firstPoint.Latitude / 180;
            var secondLatitudeRad = Math.PI * secondPoint.Latitude / 180;
            var thetaRad = Math.PI * (firstPoint.Longitude - secondPoint.Longitude) / 180;
            var distance =
                Math.Sin(firstLatitudeRad) * Math.Sin(secondLatitudeRad) + Math.Cos(firstLatitudeRad) *
                Math.Cos(secondLatitudeRad) * Math.Cos(thetaRad);
            distance = Math.Acos(distance) * 6370.693486D;

            return distance;
        }
    }
}
