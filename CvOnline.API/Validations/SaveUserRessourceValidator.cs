using CvOnline.API.Ressources;
using FluentValidation;

namespace CvOnline.API.Validation
{
    public class SaveUserRessourceValidator : AbstractValidator<UserDto>
    {
        public SaveUserRessourceValidator()
        {
            RuleFor(m => m.Email)
                .EmailAddress()
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(m => m.FirstName)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(m => m.LastName)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(m => m.Password)
                .NotEmpty();
            RuleFor(m => m.PhoneNumber)
                .NotEmpty();
        }
    }
}
