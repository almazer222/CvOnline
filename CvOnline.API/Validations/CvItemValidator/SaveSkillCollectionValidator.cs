using CvOnline.API.Dtos.CvItmDto;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace CvOnline.API.Validation
{

    public class SaveSkillCollectionValidator : AbstractValidator<IEnumerable<SkillDto>>
    {
        public SaveSkillCollectionValidator()
        {
            RuleForEach(x => x).Must(CustumValidate);
        }

        public static bool CustumValidate(SkillDto skillDto)
        {
            return
                !string.IsNullOrEmpty(skillDto.Name);
        }
    }
}
