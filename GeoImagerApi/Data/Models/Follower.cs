using GeoImagerApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.Data.Models
{
 

    public class Follower
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FollowedById { get; set; }
        public FollowerType FollowerType { get; set; }
        public UserProfileModel User { get; set; }
        public UserProfileModel FollowedBy { get; set; }
    }
}
