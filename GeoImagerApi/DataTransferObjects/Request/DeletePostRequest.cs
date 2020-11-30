using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.DataTransferObjects.Request
{
    public class DeletePostRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
