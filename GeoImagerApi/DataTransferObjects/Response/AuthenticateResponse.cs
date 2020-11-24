using GeoImagerApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.DataTransferObjects.Result
{
    public class AuthenticateResponse
    {
        public bool Authenticated { get; set; }
        public List<String> Errors { get; set; }
        public UserPayload  Payload{get; set;}
    }
}
