using CvOnline.API.Dtos.CvItmDto;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace CvOnline.API.Validation
{

    public class SaveExperianceCollectionValidator : AbstractValidator<IEnumerable<ExperianceDto>>
    {
        public SaveExperianceCollectionValidator()
        {
            RuleForEach(x => x).Must(CustumValidate);
        }

        public static bool CustumValidate(ExperianceDto experianceDto)
        {
            return experianceDto.StartDate != null &&
                    experianceDto.EndDate != null &&
                    !string.IsNullOrEmpty(experianceDto.Title) &&
                    !string.IsNullOrEmpty(experianceDto.Description) && experianceDto.Description.Length < 100 &&
                    !string.IsNullOrEmpty(experianceDto.Poste);
        }
    }
}
