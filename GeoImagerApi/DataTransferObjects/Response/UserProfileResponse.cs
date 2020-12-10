using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.DataTransferObjects.Response
{
    public class UserProfileResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public String Username { get; set; }
        public String Email { get; set; }
        public String ProfilePicturePath { get; set; }
        public String ProfileBackgroundPath { get; set; }
        public String ProfileDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public List<UserProfileFollowerResponse> Followers { get; set; }
        public List<UserProfileFollowerResponse> Following { get; set; }

        public bool Succes { get; set; }
        public List<String> Errors { get; set; }
    }
}
