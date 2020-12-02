using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.DataTransferObjects.Response
{
    public class GetPostResponse
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public String PostDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<ImageResponse> Photos { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
