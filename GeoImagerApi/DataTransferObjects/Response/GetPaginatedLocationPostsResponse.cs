using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.DataTransferObjects.Response
{
    public class GetPaginatedLocationPostsResponse
    {
        public int Page { get; set; }
        public int MaxPerPage { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<GetPostResponse> Posts { get; set; }
    }
}
