using AutoMapper;
using GeoImagerApi.Data;
using GeoImagerApi.Data.Models;
using GeoImagerApi.DataTransferObjects.Request;
using GeoImagerApi.DataTransferObjects.Response;
using GeoImagerApi.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.Services.Implementations
{
    public class UserProfileService : IUserProfileService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IImageService _imageService;
        public UserProfileService(AppDbContext context,IMapper mapper, IConfiguration configuration, IImageService imageService)
        {
            _dbContext = context;
            _mapper = mapper;
            _configuration = configuration;
            _imageService = imageService;
        }

        public async Task<UserProfileResponse> EditUserProfileAsync(EditUserProfileRequest req)
        {
            var profileModel = await _dbContext.UserProfiles.Include(prof => prof.User).Where(x => x.User.Id == req.UserId).FirstOrDefaultAsync();
            if (profileModel == null)
            {
                var errorResp = new UserProfileResponse { Succes = false, Errors = new List<string>() };
                errorResp.Errors.Add("User with such id does not exist!");
                return errorResp;
            }

            profileModel.ProfileDescription = req.ProfileDescription;
            _dbContext.UserProfiles.Update(profileModel);
            _dbContext.SaveChanges();

            var resp = _mapper.Map<UserProfileModel, UserProfileResponse>(profileModel);
            return await Task.FromResult<UserProfileResponse>(resp);
        }

        public async Task<UserProfileResponse> GetUserProfileByUserNameAsync(String name)
        {
            var profileModel = await _dbContext.UserProfiles.Include(prof => prof.User).Include(prof => prof.Followers).Include(prof => prof.Following).Where(x => x.User.Username == name).FirstOrDefaultAsync();
            if(profileModel == null)
            {
                var errorResp = new UserProfileResponse { Succes = false, Errors = new List<string>() };
                errorResp.Errors.Add("User with such a name does not exist!");
                return errorResp;
            }
           

            var resp = _mapper.Map<UserProfileModel,UserProfileResponse>(profileModel);
            return resp;
        }

        public UserProfileFollowersResponse GetUserProfileFollowers(GetUserProfileFollowersRequest req)
        {
            throw new NotImplementedException();
        }

        public UserProfileFollowingResponse GetUserProfileFollowing(GetUserProfileFollowingRequest req)
        {
            throw new NotImplementedException();
        }

        public async Task<UserProfileResponse> SetProfilePicture(UploadImageRequest req, int userId)
        {
            var profileModel = await _dbContext.UserProfiles.Include(prof => prof.User).Where(x => x.User.Id == userId).FirstOrDefaultAsync();
            if (profileModel == null)
            {
                var errorResp = new UserProfileResponse { Succes = false, Errors = new List<string>() };
                errorResp.Errors.Add("User with such id does not exist!");
                return errorResp;
            }

            var newAvatarName = await _imageService.UploadImage(Enums.ImageTypeEnum.PROFILE_PICTURE, req);

            if (profileModel.ProfilePicturePath != "\\images\\avatars\\default.png") _imageService.DeleteImage(profileModel.ProfilePicturePath);

            profileModel.ProfilePicturePath = newAvatarName;
            _dbContext.Update(profileModel);
            _dbContext.SaveChanges();

            var response = _mapper.Map<UserProfileResponse>(profileModel);
            return response;
        }

        public async Task<ImageResponse> GetUserProfilePicture(String username)
        {
            var profileModel = await _dbContext.UserProfiles.Include(prof => prof.User).Where(x => x.User.Username == username).FirstOrDefaultAsync();
            var res = await _imageService.GetImage(Enums.ImageTypeEnum.PROFILE_PICTURE, profileModel);
            return res;
        }

        public async Task<ImageResponse> GetUserBackgroundPicture(String username)
        {
            var profileModel = await _dbContext.UserProfiles.Include(prof => prof.User).Where(x => x.User.Username == username).FirstOrDefaultAsync();
            var res = await _imageService.GetImage(Enums.ImageTypeEnum.BACKGROUND_PICTURE, profileModel);
            return res;
        }

        public async Task<UserProfileResponse> SetProfileBackground(UploadImageRequest req, int userId)
        {
            var profileModel = await _dbContext.UserProfiles.Include(prof => prof.User).Where(x => x.User.Id == userId).FirstOrDefaultAsync();
            if (profileModel == null)
            {
                var errorResp = new UserProfileResponse { Succes = false, Errors = new List<string>() };
                errorResp.Errors.Add("User with such id does not exist!");
                return errorResp;
            }

            var newBackgroundName = await _imageService.UploadImage(Enums.ImageTypeEnum.BACKGROUND_PICTURE, req);

            if (profileModel.ProfileBackgroundPath != "\\images\\backdrounds\\default.png") _imageService.DeleteImage(profileModel.ProfileBackgroundPath);

            profileModel.ProfileBackgroundPath = newBackgroundName;
            _dbContext.Update(profileModel);
            _dbContext.SaveChanges();

            var response = _mapper.Map<UserProfileResponse>(profileModel);
            return response;
        }

        public async Task<bool> FollowUser(FollowRequest req)
        {
            var user = await _dbContext.UserProfiles.Include(x => x.User).Where(x => x.User.Id == req.UserId).FirstOrDefaultAsync();
            var follow = await _dbContext.UserProfiles.Include(x => x.User).Include(x => x.Followers).Where(x => x.User.Id == req.FollowedUserId).FirstOrDefaultAsync();

            if(user != null && follow != null)
            {
                if (user != follow)
                {
                    if (follow.Followers.Contains(user))
                    {
                        follow.Followers.Remove(user);
                    }
                    else
                    {
                        follow.Followers.Add(user);
                    }
                    await _dbContext.SaveChangesAsync();
                    return true;

                }
            }
            return false;
        }
    }
}
