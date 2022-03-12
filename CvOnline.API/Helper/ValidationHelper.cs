using CvOnline.API.Dtos;
using CvOnline.API.Validation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvOnline.API.Helper
{
    public static class ValidationHelper
    {
        /// <summary>
        /// Method to validate that the input that isnot null.
        /// </summary>
        /// <param name="cvItemsDto"></param>
        /// <returns></returns>
        public static bool ValidationInputDataNotNull(CvItemsDto cvItemsDto)
        {
            return cvItemsDto == null || cvItemsDto.Certifications == null || cvItemsDto.Educations == null || cvItemsDto.Experiances == null ||
                 cvItemsDto.Identity == null || cvItemsDto.Interests == null || cvItemsDto.Skills == null ||
                 cvItemsDto.Socials == null || !cvItemsDto.Skills.Any(s => s.SkillItems.Any()) ||
                 cvItemsDto.Identity.Address == null;
        }

        /// <summary>
        /// Method to validate the input data
        /// </summary>
        /// <param name="cvItemsDto"></param>
        /// <returns></returns>
        public static async Task<List<ValidationFailure>> ValidationInputData(CvItemsDto cvItemsDto)
        {
            List<ValidationFailure> errors = new List<ValidationFailure>();

             var validation = await new SaveCertificationCollectionValidator().ValidateAsync(cvItemsDto.Certifications);
            if (!validation.IsValid) errors.AddRange(validation.Errors);
            validation = await new SaveEducationCollectionValidator().ValidateAsync(cvItemsDto.Educations);
            if (!validation.IsValid) errors.AddRange(validation.Errors);
            validation = await new SaveExperianceCollectionValidator().ValidateAsync(cvItemsDto.Experiances);
            if (!validation.IsValid) errors.AddRange(validation.Errors);
            validation = await new SaveIdentityValidator().ValidateAsync(cvItemsDto.Identity);
            if (!validation.IsValid) errors.AddRange(validation.Errors);
            validation = await new SaveInterestCollectionValidator().ValidateAsync(cvItemsDto.Interests);
            if (!validation.IsValid) errors.AddRange(validation.Errors);
            validation = await new SaveSkillCollectionValidator().ValidateAsync(cvItemsDto.Skills);
            if (!validation.IsValid) errors.AddRange(validation.Errors);

            foreach (var s in cvItemsDto.Skills)
            {
                validation = await new SaveSkillItemsCollectionValidator().ValidateAsync(s.SkillItems);
                if (!validation.IsValid) errors.AddRange(validation.Errors);
            }

            validation = await new SaveSocialCollectionValidator().ValidateAsync(cvItemsDto.Socials);
            if (!validation.IsValid) errors.AddRange(validation.Errors);
            validation = await new SaveAddressRessourceValidator().ValidateAsync(cvItemsDto.Identity.Address);
            if (!validation.IsValid) errors.AddRange(validation.Errors);


            return errors;
        }
    }
}
