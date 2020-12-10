using GeoImagerApi.Data.Models;
using GeoImagerApi.DataTransferObjects.Request;
using GeoImagerApi.DataTransferObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.Services.Interfaces
{
    public interface IUserProfileService
    {
        public Task<UserProfileResponse> SetProfilePicture(UploadImageRequest req,int userId);
        public Task<UserProfileResponse> SetProfileBackground(UploadImageRequest req, int userId);

        public Task<UserProfileResponse> EditUserProfileAsync(EditUserProfileRequest req);
        public Task<UserProfileResponse> GetUserProfileByUserNameAsync(String name);
        public UserProfileFollowersResponse GetUserProfileFollowers(GetUserProfileFollowersRequest req);
        public UserProfileFollowingResponse GetUserProfileFollowing(GetUserProfileFollowingRequest req);
        public Task<bool> FollowUser(FollowRequest req);
        public Task<ImageResponse> GetUserProfilePicture(String username);
        public Task<ImageResponse> GetUserBackgroundPicture(String username);


    }
}
