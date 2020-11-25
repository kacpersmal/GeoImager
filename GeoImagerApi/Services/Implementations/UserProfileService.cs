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
        private readonly IWebHostEnvironment _environment;

        public UserProfileService(AppDbContext context,IMapper mapper, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _dbContext = context;
            _mapper = mapper;
            _configuration = configuration;
            _environment = environment;
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
            var profileModel = await _dbContext.UserProfiles.Include(prof => prof.User).Where(x => x.User.Username == name).FirstOrDefaultAsync();
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

        public async Task<UserProfileResponse> ChangeAvatar(ChangeAvatarRequest req, int userId)
        {
            var profileModel = await _dbContext.UserProfiles.Include(prof => prof.User).Where(x => x.User.Id == userId).FirstOrDefaultAsync();
            if (profileModel == null)
            {
                var errorResp = new UserProfileResponse { Succes = false, Errors = new List<string>() };
                errorResp.Errors.Add("User with such id does not exist!");
                return errorResp;
            }

            var fileName = RandomName() + Path.GetExtension(req.Image.FileName);
            var root = Path.Combine(_environment.WebRootPath, "images", "avatars");
            var path = Path.Combine(root, fileName);
            var newAvatarName = await UploadImage(req.Image, path,fileName);

            if (profileModel.ProfilePictureName != "default.png") DeleteImage(profileModel.ProfilePictureName);

            profileModel.ProfilePictureName = newAvatarName;
            _dbContext.Update(profileModel);
            _dbContext.SaveChanges();

            var response = _mapper.Map<UserProfileResponse>(profileModel);
            return response;
        }

        public async Task<UserImageResponse> GetUserProfilePicture(String username)
        {
            var profileModel = await _dbContext.UserProfiles.Include(prof => prof.User).Where(x => x.User.Username == username).FirstOrDefaultAsync();
            var wwwRootImages = Path.Combine("images", "avatars");
            var root = Path.Combine(_environment.WebRootPath, wwwRootImages);
           
            if (profileModel == null)
            {
                return new UserImageResponse { ImageAdress = Path.Combine(wwwRootImages, "default.png") };
            }
            if (!File.Exists(Path.Combine(root, profileModel.ProfilePictureName)))
            {
                return new UserImageResponse { ImageAdress = Path.Combine(wwwRootImages, "default.png") };
            }

            return new UserImageResponse { ImageAdress = Path.Combine(wwwRootImages, profileModel.ProfilePictureName) };
        }

        public async Task<UserImageResponse> GetUserBackgroundPicture(String username)
        {
            var profileModel = await _dbContext.UserProfiles.Include(prof => prof.User).Where(x => x.User.Username == username).FirstOrDefaultAsync();
            var wwwRootImages = Path.Combine("images", "backgrounds");
            var root = Path.Combine(_environment.WebRootPath, wwwRootImages);
            if (!File.Exists(Path.Combine(root, profileModel.ProfilePictureName)) || profileModel == null)
            {
                return new UserImageResponse { ImageAdress = Path.Combine(wwwRootImages, "default.png") };
            }

            return new UserImageResponse { ImageAdress = Path.Combine(wwwRootImages, profileModel.ProfilePictureName) };
        }

        private void DeleteImage(String name)
        {
            var path = Path.Combine(_environment.WebRootPath, "images", "avatars",name);

            File.Delete(path);
        }

        private async Task<String> UploadImage(IFormFile file, String path,String name)
        {  
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return name;
        }
        private String RandomName()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[32];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

    }
}
