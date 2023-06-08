using FluentValidation;
using PizzaManagement.API.Infrastructure.Localization;
using PizzaManagement.Application.Addresses.Requests;

namespace PizzaManagement.API.Infrastructure.Validators
{
    public class AddressRequestValidator:AbstractValidator<AddressRequestModel>
    {
        public AddressRequestValidator()
        {
            //RuleSet("Address", () =>
            //{
            //    //იუზერის აიდის ვალიდაცია მოხდება ბიზნეს ლეიერის დონეზე თუმცა აქაც შეიძლებოდა როგორც ვნახე

            //    RuleFor(a => a.City)
            //    .NotEmpty().WithMessage(ErrorMessages.FieldIsEmptyOrNull)
            //    .MaximumLength(15).WithMessage(ErrorMessages.MaxLength);

            //    RuleFor(a=>a.Country)
            //    .NotEmpty().WithMessage(ErrorMessages.FieldIsEmptyOrNull)
            //    .MaximumLength(15).WithMessage(ErrorMessages.MaxLength);

            //    RuleFor(a=>a.Region)
            //    .MaximumLength(15).WithMessage(ErrorMessages.MaxLength);

            //    RuleFor(a=>a.Description)
            //    .MaximumLength(100).WithMessage(ErrorMessages.MaxLength);
            //});
            RuleFor(a => a.City)
            .NotEmpty().WithMessage(ErrorMessages.FieldIsEmptyOrNull)
            .MaximumLength(15).WithMessage(ErrorMessages.MaxLength);

            RuleFor(a => a.Country)
            .NotEmpty().WithMessage(ErrorMessages.FieldIsEmptyOrNull)
            .MaximumLength(15).WithMessage(ErrorMessages.MaxLength);

            RuleFor(a => a.Region)
            .MaximumLength(15).WithMessage(ErrorMessages.MaxLength);

            RuleFor(a => a.Description)
            .MaximumLength(100).WithMessage(ErrorMessages.MaxLength);
        }
    }
}
