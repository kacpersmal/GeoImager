using AutoMapper;
using GeoImagerApi.Data;
using GeoImagerApi.Data.Models;
using GeoImagerApi.DataTransferObjects.Request;
using GeoImagerApi.DataTransferObjects.Response;
using GeoImagerApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.Services.Implementations
{
    public class UserPostService : IUserPostService
    {
        private readonly AppDbContext _dbContext;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public UserPostService(AppDbContext dbContext, IImageService imageService, IMapper mapper)
        {
            _dbContext = dbContext;
            _imageService = imageService;
            _mapper = mapper;
        }
        public Task<CommentPostResponse> CommentPost(CommentUserPostRequest req)
        {
            throw new NotImplementedException();
        }

        public async Task<CreatePostResponse> CreatePost(CreatePostRequest req)
        {
            var userProfileOwner = await _dbContext.UserProfiles.Include(x => x.User).Where(x => x.User.Id == req.UserId).FirstOrDefaultAsync();
            var response = new CreatePostResponse();
            if (userProfileOwner != null)
            {
                var imagePaths = await _imageService.UploadImages(Enums.ImageTypeEnum.POST_PICTURE, req.PostImages);
                var mappedPaths = _mapper.Map<ICollection<UserImagePostModel>>(imagePaths);
                var postModel = new UserPostModel { PostDescription = req.PostDescription, CreationDate = DateTime.UtcNow, Latitude = req.Latitude, Longitude = req.Longitude, Owner = userProfileOwner, Photos = mappedPaths };
                response = _mapper.Map<CreatePostResponse>(postModel);

                await _dbContext.UserPosts.AddAsync(postModel);
                await _dbContext.SaveChangesAsync();
            }
           return response;
        }

        public Task<DeleteCommentPostResponse> DeleteComment(DeleteUserPostCommentRequest req)
        {
            throw new NotImplementedException();
        }

        public async Task<DeletePostResponse> DeletePost(DeletePostRequest req)
        {
            var userProfile = await _dbContext.UserProfiles.Include(x => x.User).Where(x => x.User.Id == req.UserId).FirstOrDefaultAsync();
            if(userProfile != null)
            {
                var post = await _dbContext.UserPosts.Where(x => x.Owner == userProfile && x.Id == req.Id).FirstOrDefaultAsync();
                if(post != null)
                {
                    
                     _dbContext.UserPosts.Remove(post);
                     _dbContext.SaveChanges();
                    return new DeletePostResponse { Succes = true };
                }
            }
        return new DeletePostResponse { Succes = false };
        }

        public Task<CreatePostResponse> EditPost(EditPostRequest req)
        {
            throw new NotImplementedException();
        }

        public Task<GetPaginatedLocationPostsResponse> GetPaginatedPostsByLocation(GetPaginatedLocationPostsRequest req)
        {
            throw new NotImplementedException();
        }

        public Task<GetFeedPostsPaginatedResponse> GetUserPaginatedFeed(GetFeedPostsPaginatedRequest req)
        {
            throw new NotImplementedException();
        }

        public Task<UserPostsPaginatedResponse> GetUserPaginatedPosts(GetAllUserPostsPaginatedRequest req)
        {
            throw new NotImplementedException();
        }
    }
}
