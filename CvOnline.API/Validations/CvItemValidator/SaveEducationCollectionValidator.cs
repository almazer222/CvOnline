using CvOnline.API.Dtos.CvItmDto;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace CvOnline.API.Validation
{
    public class SaveEducationCollectionValidator : AbstractValidator<IEnumerable<EducationDto>>
    {
        public SaveEducationCollectionValidator()
        {
            RuleForEach(x => x).Must(CustumValidate);
        }

        public static bool CustumValidate(EducationDto educationDto)
        {
            return educationDto.StartDate != new DateTime() &&
                educationDto.EndDate != new DateTime() &&
                !string.IsNullOrEmpty(educationDto.School) &&
                !string.IsNullOrEmpty(educationDto.KindOfStudy) &&
                !string.IsNullOrEmpty(educationDto.Degres);
        }
    }
}
