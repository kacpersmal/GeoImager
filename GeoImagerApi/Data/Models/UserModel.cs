using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.Data.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public String Email { get; set; }
        public String HashedPassword { get; set; }
        public bool Verified { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
