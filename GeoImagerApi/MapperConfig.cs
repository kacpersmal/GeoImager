using AutoMapper;
using GeoImagerApi.Data.Models;
using GeoImagerApi.DataTransferObjects.Request;
using GeoImagerApi.DataTransferObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<UserModel, UserProfileFollowerResponse>()
             .ForMember(x => x.Id, a => a.MapFrom(x => x.Id))
             .ForMember(x => x.Name, a => a.MapFrom(x => x.Username))
             .ForMember(x => x.ProfilePicture, a => a.MapFrom(x => x.UserProfile.ProfilePicturePath));

            CreateMap<UserProfileModel, UserProfileResponse>()
                .ForMember(x => x.CreationDate, a => a.MapFrom(x => x.User.CreationDate))
                .ForMember(x => x.Email, a => a.MapFrom(x => x.User.Email))
                .ForMember(x => x.Id, a => a.MapFrom(x => x.Id))
                .ForMember(x => x.ProfileDescription, a => a.MapFrom(x => x.ProfileDescription))
                .ForMember(x => x.ProfilePicturePath, a => a.MapFrom(x => x.ProfilePicturePath))
                .ForMember(x => x.ProfileBackgroundPath, a => a.MapFrom(x => x.ProfileBackgroundPath))
                .ForMember(x => x.UserId, a => a.MapFrom(x => x.User.Id))
                .ForMember(x => x.Username, a => a.MapFrom(x => x.User.Username))
                .ForMember(x => x.Followers, a => a.MapFrom(x => x.Followers))
                .ForMember(x => x.Following, a => a.MapFrom(x => x.Following))
                .ForMember(x => x.Succes, a => a.MapFrom(x => true))
                .ForMember(x => x.Errors, a => a.MapFrom(x => new List<String>()));
            
            CreateMap<String, UserImagePostModel>()
                .ForMember(x => x.ImageAdress, a => a.MapFrom(x => x));

            CreateMap<UserPostModel, CreatePostResponse>();
            
            CreateMap<UserImagePostModel, ImageResponse>()
                .ForMember(x => x.ImageAdress, src => src.MapFrom(x => x.ImageAdress));

            CreateMap<UserPostModel, GetPostResponse>();

            CreateMap<Follower, UserProfileFollowerResponse>()
                .ForMember(x => x.Id, s => s.MapFrom(x => x.FollowedById))
                .ForMember(x => x.Name, s => s.MapFrom(x => x.FollowedBy.User.Username))
                .ForMember(x => x.ProfilePicture, s => s.MapFrom(x => x.FollowedBy.ProfilePicturePath));

            
        }
    }
}
