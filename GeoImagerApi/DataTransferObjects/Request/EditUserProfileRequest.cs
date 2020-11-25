using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.DataTransferObjects.Request
{
    public class EditUserProfileRequest
    {
        public int UserId { get; set; }
        public String ProfileDescription { get; set; }
    }
}
