using CvOnline.API.Dtos;
using FluentValidation;

namespace CvOnline.API.Validation
{
    public class SaveEntrepriseRessourceValidator : AbstractValidator<EntrepriseDto>
    {
        public SaveEntrepriseRessourceValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
