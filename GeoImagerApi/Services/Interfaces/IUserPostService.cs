using GeoImagerApi.Data.Models;
using GeoImagerApi.DataTransferObjects.Request;
using GeoImagerApi.DataTransferObjects.Response;
using GeoImagerApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GeoImagerApi.Services.Interfaces
{
    public interface IUserPostService
    {
        Task<UserPostsPaginatedResponse> GetUserPaginatedPosts(GetAllUserPostsPaginatedRequest req);        
        Task<CreatePostResponse> CreatePost(CreatePostRequest req);
        Task<CreatePostResponse> EditPost(EditPostRequest req);
        Task<DeletePostResponse> DeletePost(DeletePostRequest req);
        Task<GetFeedPostsPaginatedResponse> GetUserPaginatedFeed(GetFeedPostsPaginatedRequest req);
        Task<GetPaginatedLocationPostsResponse> GetPaginatedPostsByLocation(GetPaginatedLocationPostsRequest req);
        Task<CommentPostResponse> CommentPost(CommentUserPostRequest req);
        Task<DeleteCommentPostResponse> DeleteComment(DeleteUserPostCommentRequest req);
    }
}
