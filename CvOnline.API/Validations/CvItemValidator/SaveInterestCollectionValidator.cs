using CvOnline.API.Dtos.CvItmDto;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace CvOnline.API.Validation
{

    public class SaveInterestCollectionValidator : AbstractValidator<IEnumerable<InterestDto>>
    {
        public SaveInterestCollectionValidator()
        {
            RuleForEach(x => x).Must(CustumValidate);
        }

        public static bool CustumValidate(InterestDto interestDto)
        {
            return
                !string.IsNullOrEmpty(interestDto.Name) &&
                !string.IsNullOrEmpty(interestDto.Description) && interestDto.Description.Length < 200;
        }
    }
}