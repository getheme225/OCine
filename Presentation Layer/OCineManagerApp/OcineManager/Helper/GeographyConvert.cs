using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Types;
using OCineManagerApps.OcineManager.BingMapsService;


namespace OCineManagerApps.OcineManager.Helper
{
   public static class GeographyConvert
    {
        private static SqlGeography FromLatitudeLongitude(double latitude, double longitude)
        {
          return  Microsoft.SqlServer.Types.SqlGeography.Point(latitude, longitude, 4326);
            
        }

        public static SqlGeography ConverteGeoCodeResponse(GeocodeResponse response)
        {
            if (response == null)
            {
                return null;
            }

            return FromLatitudeLongitude(response.Results[0].Locations[0].Latitude,
                response.Results[0].Locations[0].Longitude);
        }
    }
}
