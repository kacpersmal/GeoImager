using FluentValidation;
using GeoImagerApi.DataTransferObjects.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.DataTransferObjects.Validation
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(req => req.Email).EmailAddress();
            RuleFor(req => req.Password).NotEmpty().MinimumLength(6).Equal(x => x.PasswordConfirmation);
            RuleFor(req => req.PasswordConfirmation).NotEmpty().MinimumLength(6);
            RuleFor(req => req.Username).NotEmpty().MinimumLength(6);
        }
    }
}
