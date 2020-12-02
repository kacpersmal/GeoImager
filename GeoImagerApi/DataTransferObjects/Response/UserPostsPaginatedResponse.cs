using GeoImagerApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.DataTransferObjects.Response
{
    public class UserPostsPaginatedResponse
    {
        public int Page { get; set; }
        public int MaxPerPage { get; set; }
        public List<GetPostResponse>  Posts {get; set;}
    }
}
