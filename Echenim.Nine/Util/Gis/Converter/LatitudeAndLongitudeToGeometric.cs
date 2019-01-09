using System;
using System.Data.Spatial;

namespace Echenim.Nine.Util.Gis.Converter
{
    public static class LatitudeAndLongitudeToGeometric
    {
        /// <summary>
        /// Create a GeoLocation point based on latitude and longitude
        /// </summary>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <param name="sRid">spatial reference id, default is 4326</param>
        /// <returns></returns>
        public static DbGeometry CreatePoint(double latitude, double longitude, int sRid)
        {
            var text = $"POINT({longitude} {latitude})";
            // 4326 is most common coordinate system used by GPS/Maps
            return DbGeometry.PointFromText(text, sRid);
        }

        /// <summary>
        /// Create a GeoLocation point based on latitude and longitude
        /// </summary>
        /// <param name="latitudeLongitude">
        /// String should be two values either single comma or space delimited
        /// 45.710030,-121.516153
        /// 45.710030 -121.516153
        /// </param>
        /// <param name="sRid">spatial reference id, default is 4326</param>
        /// <returns></returns>
        public static DbGeometry CreatePoint(string latitudeLongitude, int sRid)
        {
            var tokens = latitudeLongitude.Split(',', ' ');
            if (tokens.Length != 2)
                throw new ArgumentException("Invalid Location String Passed");
            var text = $"POINT({tokens[1]} {tokens[0]})";
            return DbGeometry.PointFromText(text, sRid);
        }


    }
}
