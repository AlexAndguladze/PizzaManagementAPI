using FluentValidation;
using PizzaManagement.Application.Users.Requests;
using PizzaManagement.API.Infrastructure.Localization;
using System.Net.Mail;

namespace PizzaManagement.API.Infrastructure.Validators
{
    public class UserRequestValidator:AbstractValidator<UserRequestModel>
    {
        public UserRequestValidator()
        {
            //RuleSet("FullName", () =>
            //{
            //    RuleFor(u => u.FirstName)
            //    .NotEmpty().WithMessage(ErrorMessages.FieldIsEmptyOrNull)
            //    .MinimumLength(2)
            //    .MaximumLength(20).WithMessage(ErrorMessages.MaxLength);

            //    RuleFor(u => u.LastName)
            //    .NotEmpty().WithMessage(ErrorMessages.FieldIsEmptyOrNull)
            //    .MinimumLength(2)
            //    .MaximumLength(30).WithMessage(ErrorMessages.MaxLength);
            //});
            //RuleSet("Email", () =>
            //{
            //    RuleFor(u => u.Email)
            //    .Must((email) =>
            //    {
            //        return MailAddress.TryCreate(email, out var mailAddress);
            //    }).WithMessage(ErrorMessages.MailFormat);
            //});
            //RuleSet("PhoneNumber", () =>
            //{
            //    RuleFor(u => u.PhoneNumber)
            //    .NotEmpty().WithMessage(ErrorMessages.FieldIsEmptyOrNull)
            //    .Matches(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$").WithMessage(ErrorMessages.PhoneNumber);
            //});

            RuleFor(u => u.FirstName)
               .NotEmpty().WithMessage(ErrorMessages.FieldIsEmptyOrNull)
               .MinimumLength(2)
               .MaximumLength(20).WithMessage(ErrorMessages.MaxLength);

            RuleFor(u => u.LastName)
            .NotEmpty().WithMessage(ErrorMessages.FieldIsEmptyOrNull)
            .MinimumLength(2)
            .MaximumLength(30).WithMessage(ErrorMessages.MaxLength);

            RuleFor(u => u.Email)
               .Must((email) =>
               {
                   return MailAddress.TryCreate(email, out var mailAddress);
               }).WithMessage(ErrorMessages.MailFormat);

            RuleFor(u => u.PhoneNumber)
                .NotEmpty().WithMessage(ErrorMessages.FieldIsEmptyOrNull)
                .Matches(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{2})[-. ]?([0-9]{2})?[-. ]?([0-9]{2})$").WithMessage(ErrorMessages.PhoneNumber);
        }
    }
}
