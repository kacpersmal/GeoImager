using GeoImagerApi.Data.Models;
using GeoImagerApi.DataTransferObjects.Request;
using GeoImagerApi.DataTransferObjects.Response;
using GeoImagerApi.Enums;
using GeoImagerApi.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.Services.Implementations
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly String AVATAR_ROOT;
        private readonly String BACKGROUND_ROOT;

        public ImageService(IWebHostEnvironment environment)
        {
            _environment = environment;
            AVATAR_ROOT = Path.Combine(_environment.WebRootPath, "images", "avatars");
            BACKGROUND_ROOT = Path.Combine(_environment.WebRootPath, "images", "backgrounds");

        }
        public Task<String> UploadImage(ImageTypeEnum type, UploadImageRequest req)
        {
            var newfileName = RandomName() + Path.GetExtension(req.Image.FileName);
            var path = GetPath(type,newfileName);
           

            var imagePath = UploadImageToServer(req.Image, path);

            return Task.FromResult(GetRelativePath(type, newfileName));
        }
        public void DeleteImage(string path)
        {
            path = Path.Combine(_environment.WebRootPath, path);
            DeleteImageFromServer(path);
        }

        public Task<ImageResponse> GetImage(ImageTypeEnum type, UserProfileModel mod)
        {
            var path = GetPath(type, mod.ProfilePictureName);
           
            if(mod == null) return Task.FromResult(new ImageResponse { ImageAdress = GetDefaultPath(type) });
            if (!File.Exists(Path.Combine(_environment.WebRootPath, path)))
            {
                return Task.FromResult(new ImageResponse { ImageAdress = GetDefaultPath(type) });

            }

            return Task.FromResult(new ImageResponse { ImageAdress = path });
        }

        private String GetRelativePath(ImageTypeEnum type, String name)
        {
            var path = "";
            switch (type)
            {
                case ImageTypeEnum.PROFILE_PICTURE: { path = Path.Combine("images","avatars", name); break; }
                case ImageTypeEnum.BACKGROUND_PICTURE: { path = Path.Combine("images", "backgrounds", name); break; }
            }

            return path;
        }

        private void DeleteImageFromServer(String path)
        {
            File.Delete(path);
        }
       
        private async Task<String> UploadImageToServer(IFormFile file, String path)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return path;
        }

        private String GetPath(ImageTypeEnum type, String name)
        {
            var path = "";
            switch (type)
            {
                case ImageTypeEnum.PROFILE_PICTURE: { path = Path.Combine(AVATAR_ROOT, name); break; }
                case ImageTypeEnum.BACKGROUND_PICTURE: { path = Path.Combine(BACKGROUND_ROOT, name); break; }
            }

            return path;
        }

        private String GetDefaultPath(ImageTypeEnum type)
        {
            var path = "";
            switch (type)
            {
                case ImageTypeEnum.PROFILE_PICTURE: { path = Path.Combine(AVATAR_ROOT, "default.png"); break; }
                case ImageTypeEnum.BACKGROUND_PICTURE: { path = Path.Combine(BACKGROUND_ROOT, "default.png"); break; }
            }

            return path;
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
