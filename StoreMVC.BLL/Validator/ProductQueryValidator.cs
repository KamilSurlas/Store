using FluentValidation;
using StoreMVC.BLL.Query;
using StoreMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace StoreMVC.BLL.Validator
{
    public class ProductQueryValidator : AbstractValidator<ProductQuery>
    {
        private int[] allowedPageSizes = { 5, 10, 15 };
        private string[] allowedSortByNames = { nameof(Product.Name), nameof(Product.IsActive)
        };
        public ProductQueryValidator()
        {
            RuleFor(q => q.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(q => q.PageSize).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"PageSize must be in [{string.Join(",", allowedPageSizes)}]");
                }
            });
            RuleFor(q => q.SortBy).Must(value => string.IsNullOrEmpty(value) || allowedSortByNames.Contains(value))
            .WithMessage($"Sort by is optional or must be in [{string.Join(", ", allowedSortByNames)}]");
        }

    }
}
