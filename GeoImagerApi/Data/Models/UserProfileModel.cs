﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.Data.Models
{
    public class UserProfileModel
    {
        public int Id { get; set; }

        public String ProfilePicturePath { get; set; }
        public String ProfileBackgroundPath { get; set; }

        public String ProfileDescription { get; set; }

        public ICollection<Follower> Followers { get; set; }
        public ICollection<Follower> Following { get; set; }
        public ICollection<UserPostModel> Posts { get; set; }
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }


        public UserProfileModel() 
        { 
            ProfileDescription = "No description :(";
            ProfilePicturePath = "\\images\\avatars\\default.png";
            ProfileBackgroundPath = "\\images\\backgrounds\\default.png";
        }
    }
}
