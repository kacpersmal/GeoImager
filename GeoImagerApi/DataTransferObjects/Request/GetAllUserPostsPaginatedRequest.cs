using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.DataTransferObjects.Request
{
    public class GetAllUserPostsPaginatedRequest
    {
        public int UserId { get; set; }
        public int Page { get; set; }
        public int MaxPerPage { get; set; }
    }
}
