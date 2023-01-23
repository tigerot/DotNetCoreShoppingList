using FluentValidation;
using ShoppingListCore.Models;
using ShoppingListProject.Models;

namespace ShoppingListCore.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {

            RuleFor(p => p.ProductName)
              .NotEmpty().WithMessage("Ürün adı giriniz")
            .NotNull().WithMessage("Ürün adı giriniz");


        }
    }
}
