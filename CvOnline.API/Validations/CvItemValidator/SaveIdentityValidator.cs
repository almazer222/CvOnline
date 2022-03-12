using CvOnline.API.Dtos.CvItmDto;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace CvOnline.API.Validation
{

    public class SaveIdentityValidator : AbstractValidator<IdentityDto>
    {
        public SaveIdentityValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.KindOfWork).NotEmpty();
        }
    }
}
