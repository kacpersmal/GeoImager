﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.DataTransferObjects.Response
{
    public class UserProfileFollowingResponse
    {
        public List<UserProfileFollowerResponse> Followers { get; set; }
    }
}
