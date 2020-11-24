using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.DataTransferObjects.Result
{
    public class RegisterResponse
    {
        public bool Succeed { get; set; }
        public List<String> Errors { get; set; }
    }
}
