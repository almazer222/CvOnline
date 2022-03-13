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
            var o = educationDto.StartDate != null;
            var k = educationDto.EndDate != null;
            var x = !string.IsNullOrEmpty(educationDto.School);
            var w = !string.IsNullOrEmpty(educationDto.KindOfStudy);
            var m = !string.IsNullOrEmpty(educationDto.Degres);



            return educationDto.StartDate != null &&
                educationDto.EndDate != null &&
                !string.IsNullOrEmpty(educationDto.School) &&
                !string.IsNullOrEmpty(educationDto.KindOfStudy) &&
                !string.IsNullOrEmpty(educationDto.Degres);
        }
    }
}
