using FluentValidation;
using GeoImagerApi.DataTransferObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.DataTransferObjects.Validation
{
    public class AuthenticateRequestValidator : AbstractValidator<AuthenticateRequest>
    {
        public AuthenticateRequestValidator()
        {
            RuleFor(req => req.Email).EmailAddress();
            RuleFor(req => req.Password).NotEmpty().MinimumLength(6);
        }
    }
}
