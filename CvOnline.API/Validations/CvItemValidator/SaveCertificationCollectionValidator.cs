using CvOnline.API.Dtos;
using CvOnline.API.Dtos.CvItmDto;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvOnline.API.Validation
{
    public class SaveCertificationCollectionValidator : AbstractValidator<IEnumerable<CertificationDto>>
    {
        public SaveCertificationCollectionValidator()
        {
            RuleForEach(x => x).Must(CustumValidate);
        }

        public static bool CustumValidate(CertificationDto certificationDto)
        {
            return !string.IsNullOrEmpty(certificationDto.Name);
        }
    }
}
