using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.Data.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public UserPostModel Post { get; set; }
        public UserModel Commenter { get; set; }
        public String CommentContent { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
