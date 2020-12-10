

using GeoImagerApi.DataTransferObjects.Request;
using GeoImagerApi.DataTransferObjects.Response;
using GeoImagerApi.Helpers;
using GeoImagerApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GeoImagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet]
        public async Task<UserProfileResponse> GetProfile(string name)
        {
            var profile = await _userProfileService.GetUserProfileByUserNameAsync(name);
            return profile;
        }

      
        [Authorize]
        [HttpPost]
        public async Task<UserProfileResponse> EditProfile([FromBody] EditUserProfileRequest req)
        {
            var payload = (UserPayload)HttpContext.Items["User"];
            req.UserId = payload.Id;
            var profile = await _userProfileService.EditUserProfileAsync(req);
            return profile;
        }

        [Authorize]
        [HttpPost("picture")]
        public async Task<UserProfileResponse> ChangeAvatar([FromForm, FormFileDescriptor("ProfilePicture", "The project as a JSON file", true, 52_428_800)] UploadImageRequest req)
        {
            var payload = (UserPayload)HttpContext.Items["User"];
          
            var res = await _userProfileService.SetProfilePicture(req, payload.Id);
            return res;
        }
      
        [Authorize]
        [HttpPost("background")]
        public async Task<UserProfileResponse> ChangeBackground([FromForm, FormFileDescriptor("BackgroundPicture", "The project as a JSON file", true, 52_428_800)] UploadImageRequest req)
        {
            var payload = (UserPayload)HttpContext.Items["User"];

            var res = await _userProfileService.SetProfileBackground(req, payload.Id);
            return res;
        }

        [Authorize]
        [HttpPost("/follow")]
        public async Task<bool> Follow(FollowRequest req)
        {
            var payload = (UserPayload)HttpContext.Items["User"];
            req.UserId = payload.Id;

            return await _userProfileService.FollowUser(req);
        }
    }
}
