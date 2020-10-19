using FluentValidation;
using Gaurav.Danani.WooliesX.Application.Trolleys.Queries.GetTrolleyTotal;

namespace Gaurav.Danani.WooliesX.ServiceHost.Validators
{
    public class TrolleyTotalRequestValidator : AbstractValidator<TrolleyTotalRequest>
    {
        public TrolleyTotalRequestValidator()
        {
            RuleFor(t => t).NotEmpty();
            
            RuleFor(t => t.Products)
                .NotEmpty();
            
            RuleFor(t => t.Quantities)
                .NotEmpty();
            
            //TODO: Add more validation
        }
    }
}