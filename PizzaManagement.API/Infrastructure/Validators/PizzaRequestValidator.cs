using FluentValidation;
using PizzaManagement.API.Infrastructure.Localization;
using PizzaManagement.Application.Pizzas.Requests;

namespace PizzaManagement.API.Infrastructure.Validators
{
    public class PizzaRequestValidator:AbstractValidator<PizzaRequestModel>
    {
        public PizzaRequestValidator()
        {
            //RuleSet("Name", () =>
            //{
            //    RuleFor(p => p.Name)
            //    .NotEmpty().WithMessage(ErrorMessages.FieldIsEmptyOrNull)
            //    .MinimumLength(3).WithMessage(ErrorMessages.MinLength)
            //    .MaximumLength(20).WithMessage(ErrorMessages.MaxLength);
            //});
            //RuleSet("Price", () =>
            //{
            //    RuleFor(p => p.Price)
            //    .NotEmpty().WithMessage(ErrorMessages.FieldIsEmptyOrNull)
            //    .GreaterThan(0);
            //});
            //RuleSet("Description", () =>
            //{
            //    RuleFor(p => p.Description)
            //    .MaximumLength(100);
            //});
            //RuleSet("CaloryCount", ()=>
            //{
            //    RuleFor(p => p.CaloryCount)
            //    .NotEmpty().WithMessage(ErrorMessages.FieldIsEmptyOrNull)
            //    .GreaterThan(0);
            //});
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage(ErrorMessages.FieldIsEmptyOrNull)
                .MinimumLength(3).WithMessage(ErrorMessages.MinLength)
                .MaximumLength(20).WithMessage(ErrorMessages.MaxLength);

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage(ErrorMessages.FieldIsEmptyOrNull)
                .GreaterThan(0);

            RuleFor(p => p.Description)
               .MaximumLength(100);

            RuleFor(p => p.CaloryCount)
                .NotEmpty().WithMessage(ErrorMessages.FieldIsEmptyOrNull)
                .GreaterThan(0);
        }
    }
}
