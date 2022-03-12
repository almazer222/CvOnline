using CvOnline.API.Dtos;
using FluentValidation;

namespace CvOnline.API.Validation
{
    public class SaveAuthenticateRessourceValidator : AbstractValidator<AuthenticateDto>
    {
        public SaveAuthenticateRessourceValidator()
        {
            RuleFor(m => m.Email)
                .EmailAddress()
                .NotEmpty();
            RuleFor(m => m.Password)
                .NotEmpty();
        }
    }
}
