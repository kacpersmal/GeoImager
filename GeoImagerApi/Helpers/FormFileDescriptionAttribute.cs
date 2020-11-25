using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.Helpers
{
    public class FormFileDescriptorAttribute : Attribute
    {
        public FormFileDescriptorAttribute(string title, string description, bool required, int maxLength)
        {
            Title = title;
            Description = description;
            Required = required;
            MaxLength = maxLength;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public int MaxLength { get; set; }

        public bool Required { get; set; }
    }
}
