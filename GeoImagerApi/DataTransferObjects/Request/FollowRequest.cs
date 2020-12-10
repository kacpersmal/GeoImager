using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.DataTransferObjects.Request
{
    public class FollowRequest
    {
        public int UserId { get; set; }
        public int FollowedUserId { get; set; }
    }
}
