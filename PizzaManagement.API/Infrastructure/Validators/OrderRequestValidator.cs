using FluentValidation;
using PizzaManagement.Application.Orders.Requests;

namespace PizzaManagement.API.Infrastructure.Validators
{
    public class OrderRequestValidator:AbstractValidator<OrderRequestModel>
    {
        public OrderRequestValidator()
        {
            /*RuleSet("PizzaList", () =>
            {
                პიცის List რახან არ გვაქვს ამ ეტაპზე ყველა ვალიდაცია სერვის ლეიერში მოხდება 
                რაც მონაცემთა ბაზაში გადამოწმებას მოითხოვს, უკეთესი ვარიანტია 
                ბიზნეს ლეიერში მოხდეს ეგენი როგორც წავიკითხე
            });*/
        }
    }
}
