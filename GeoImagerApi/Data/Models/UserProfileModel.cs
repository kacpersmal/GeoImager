using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.Data.Models
{
    public class UserProfileModel
    {
        public int Id { get; set; }

        public String ProfilePictureName { get; set; }
        public String ProfileDescription { get; set; }

        public ICollection<UserProfileModel> Followers { get; set; }
        public ICollection<UserProfileModel> Following { get; set; }

        public int UserId { get; set; }
        public virtual UserModel User { get; set; }


        public UserProfileModel() 
        { 
            ProfileDescription = "No description :(";
            ProfilePictureName = "default.png"; 
        }
    }
}
