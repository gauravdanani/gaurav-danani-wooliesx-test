using System;
using System.Collections.Generic;
using FluentValidation;
using Gaurav.Danani.WooliesX.ServiceHost.Requests;

namespace Gaurav.Danani.WooliesX.ServiceHost.Validators
{
    public class GetProductsListRequestValidator : AbstractValidator<GetProductsListRequest>
    {
        public GetProductsListRequestValidator()
        {
            RuleFor(x => x.SortOption).NotEmpty();

            RuleFor(x => x.SortOption)
                .Must(BeValidSortOption)
                .When(x => !string.IsNullOrEmpty(x.SortOption))
                .WithMessage(x => $"Invalid SortOption: {x.SortOption}");
        }

        private bool BeValidSortOption(string sortOption)
        {
            var validSortOptions = new List<string>{"low", "high", "ascending", "descending", "recommended"};
            return validSortOptions.Contains(sortOption.ToLowerInvariant());
        }
    }
}