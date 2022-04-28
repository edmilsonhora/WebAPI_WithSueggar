using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace WebApi_With_Swagger_Teste0
{
    public class AuthOperationAttibute : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            //https://www.youtube.com/watch?v=mBIFiAtIxqs

            var att = context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Distinct();
            if (att.Any())
            {
                var jwtBarearSchema = new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference()
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "bearerAuth",
                    },

                };

                operation.Security = new List<OpenApiSecurityRequirement>()
                {
                    new OpenApiSecurityRequirement()
                    {
                        [jwtBarearSchema] = new string[]{},
                    }
                };

            };
        }
    }
}
