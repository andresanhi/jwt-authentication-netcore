using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Jwt.Authentication.Manager.Api.Config
{
    public class CustomOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.OperationId == "authenticate")
            {
                operation.RequestBody = new OpenApiRequestBody()
                {
                    Content = new Dictionary<string, OpenApiMediaType> {
                    {"application/json",
                        new OpenApiMediaType()
                        {
                            Schema = new OpenApiSchema(){
                                Example = new OpenApiObject
                                    {
                                        ["userName"] = new OpenApiString("string"),
                                        ["password"] = new OpenApiString("string"),
                                        ["encryptedPassword"] = new OpenApiString("string"),
                                    }
                            }
                        }
                    }
                    }
                };
            } else
            {

            }
        }
    }
}
