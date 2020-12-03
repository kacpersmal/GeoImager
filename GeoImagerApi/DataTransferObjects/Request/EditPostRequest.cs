using System;

namespace GeoImagerApi.DataTransferObjects.Request
{
    public class EditPostRequest
    {
        public int? UserId { get; set; }
        public int PostId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public String PostDescription { get; set; }
    }
}
