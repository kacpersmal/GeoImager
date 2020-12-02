using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeoImagerApi.DataTransferObjects.Request;
using GeoImagerApi.DataTransferObjects.Response;
using GeoImagerApi.DataTransferObjects.Result;
using GeoImagerApi.DataTransferObjects.Validation;
using GeoImagerApi.Helpers;
using GeoImagerApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace GeoImagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUserPostService _postService;
        public PostController(IUserPostService postService)
        {
            _postService = postService;
        }

        [Authorize]
        [HttpPost("/create")]
        public async Task<CreatePostResponse> CreatePost([FromForm, FormFileDescriptor("ProfilePicture", "The project as a JSON file", true, 52_428_800)] CreatePostRequest req)
        {
            var payload = (UserPayload)HttpContext.Items["User"];
            req.UserId = payload.Id;
            var result = await _postService.CreatePost(req);
         
            return result;
        }

        [Authorize]
        [HttpPost("/delete")]
        public async Task<DeletePostResponse> DeletePost(DeletePostRequest req)
        {
            var payload = (UserPayload)HttpContext.Items["User"];
            req.UserId = payload.Id;
            var result = await _postService.DeletePost(req);

            return result;
        }

        [HttpPost("/userposts")]
        public async Task<UserPostsPaginatedResponse> GetPaginatedUserPosts(GetAllUserPostsPaginatedRequest req)
        {
            var result = await _postService.GetUserPaginatedPosts(req);

            return result;
        }
    }
}
