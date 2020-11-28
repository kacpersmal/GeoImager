using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.Data.Models
{
    public class UserPostModel
    {
        public int Id { get; set; }
        public UserProfileModel Owner { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public String PostDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<UserImagePostModel> Photos { get; set; }
        public ICollection<CommentModel> Comments { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
