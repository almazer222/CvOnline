using CvOnline.API.Dtos.CvItmDto;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace CvOnline.API.Validation
{

    public class SaveSocialCollectionValidator : AbstractValidator<IEnumerable<SocialDto>>
    {
        public SaveSocialCollectionValidator()
        {
            RuleForEach(x => x).Must(CustumValidate);
        }

        public static bool CustumValidate(SocialDto socialDto)
        {
            return
                !string.IsNullOrEmpty(socialDto.Name) &&
                !string.IsNullOrEmpty(socialDto.Url);
        }
    }
}
