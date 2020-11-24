using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.DataTransferObjects.Request
{
    public class RegisterRequest
    {
        public String Username { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String PasswordConfirmation { get; set; }
    }
}
