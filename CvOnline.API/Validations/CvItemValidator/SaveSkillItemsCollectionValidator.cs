using CvOnline.API.Dtos.CvItmDto;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace CvOnline.API.Validation
{

    public class SaveSkillItemsCollectionValidator : AbstractValidator<IEnumerable<SkillItemsDto>>
    {
        public SaveSkillItemsCollectionValidator()
        {
            RuleForEach(x => x).Must(CustumValidate);
        }

        public static bool CustumValidate(SkillItemsDto skillItemsDto)
        {
            return
                !string.IsNullOrEmpty(skillItemsDto.Name);
        }
    }
}
