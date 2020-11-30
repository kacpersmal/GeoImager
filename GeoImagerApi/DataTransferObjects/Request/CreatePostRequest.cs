using GeoImagerApi.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.DataTransferObjects.Request
{
    public class CreatePostRequest
    {
        public int? UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public String PostDescription { get; set; }
        public ICollection<IFormFile> PostImages { get; set; }
    }
}
