using CvOnline.API.Dtos;
using FluentValidation;

namespace CvOnline.API.Validation
{
    public class SaveAddressRessourceValidator : AbstractValidator<AddressDto>
    {
        public SaveAddressRessourceValidator()
        {
            RuleFor(a => a.Number)
                .NotEmpty();
            RuleFor(a => a.PostalCode)
                .NotEmpty();
            RuleFor(a => a.Street)
                .NotEmpty();
            RuleFor(a => a.Town)
                .NotEmpty();
            RuleFor(a => a.Contry)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
