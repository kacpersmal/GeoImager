using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.DataTransferObjects.Request
{
    public class GetPaginatedLocationPostsRequest
    {
        public int Page { get; set; }
        public int MaxPerPage { get; set; }
        public int Range { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
