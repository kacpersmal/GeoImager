using GeoImagerApi.Data.Models;
using GeoImagerApi.DataTransferObjects.Request;
using GeoImagerApi.DataTransferObjects.Response;
using GeoImagerApi.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.Services.Interfaces
{
    public interface IImageService
    {
        public Task<String> UploadImage(ImageTypeEnum type, UploadImageRequest req);
        public Task<List<String>> UploadImages(ImageTypeEnum type, ICollection<IFormFile> images);

        public void DeleteImage(String name);
        public Task<ImageResponse> GetImage(ImageTypeEnum type, UserProfileModel mod);
    }
}
