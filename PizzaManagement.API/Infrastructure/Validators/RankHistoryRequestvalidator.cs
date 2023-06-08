using FluentValidation;
using PizzaManagement.API.Infrastructure.Localization;
using PizzaManagement.Application.RankHistories.Requests;

namespace PizzaManagement.API.Infrastructure.Validators
{
    public class RankHistoryRequestvalidator : AbstractValidator<RankHistoryRequestModel>
    {
        public RankHistoryRequestvalidator()
        {
            //უზერ აიდი და პიცა აიდის ვალიდაცია ბიზნეს ლეიერში

            //RuleSet("Rank", () =>
            //{
            //    RuleFor(r => r.rank)
            //    .InclusiveBetween(1, 10).WithMessage(ErrorMessages.Rank);
            //});
            
            RuleFor(r => r.rank)
                .InclusiveBetween(1, 10).WithMessage(ErrorMessages.Rank);
        }
    }
}
