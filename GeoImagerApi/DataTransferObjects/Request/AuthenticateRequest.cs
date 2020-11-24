using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.DataTransferObjects.Request
{
    public class AuthenticateRequest
    {
        public String Email { get; set; }
        public String Password { get; set; }
    }
}
