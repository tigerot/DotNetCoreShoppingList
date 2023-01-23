using FluentValidation;
using ShoppingListProject.Models;

namespace ShoppingListProject.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
          
            RuleFor(p => p.CategoryName)
              .NotEmpty().WithMessage("Kategori adı giriniz")
            .NotNull().WithMessage("Kategori adı giriniz");
          

            


        }
    }
}
