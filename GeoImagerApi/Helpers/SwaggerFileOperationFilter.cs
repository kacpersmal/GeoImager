using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace GeoImagerApi.Helpers
{
    public class SwaggerFileOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fileParams = context.MethodInfo.GetParameters().Where(p => p.ParameterType.FullName?.Equals(typeof(Microsoft.AspNetCore.Http.IFormFile).FullName) == true);

            if (fileParams.Any() && fileParams.Count() == 1)
            {
                var title = "The file to be uploaded";
                var description = "The file to be uploaded";
                int? maxLength = 5_242_880;
                bool required = true;

                var descriptionAttribute = fileParams.First().CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(FormFileDescriptorAttribute));
                if (descriptionAttribute?.ConstructorArguments.Count > 3)
                {
                    title = descriptionAttribute.ConstructorArguments[0].Value.ToString();
                    description = descriptionAttribute.ConstructorArguments[1].Value.ToString();
                    required = (bool)descriptionAttribute.ConstructorArguments[2].Value;
                    maxLength = (int)descriptionAttribute.ConstructorArguments[3].Value;
                }

                var uploadFileMediaType = new OpenApiMediaType()
                {
                    Schema = new OpenApiSchema()
                    {
                        Type = "object",
                        Properties =
            {
              [fileParams.First().Name] = new OpenApiSchema()
              {
                  Description = description,
                  Type = "file",
                  Format = "binary",
                  Title = title,
                  MaxLength = maxLength
              }
            }
                    }
                };

                if (required)
                {
                    uploadFileMediaType.Schema.Required = new HashSet<string>() { fileParams.First().Name };
                }

                operation.RequestBody = new OpenApiRequestBody
                {
                    Content = { ["multipart/form-data"] = uploadFileMediaType }
                };
            }
        }
    }
}
