using FluentValidation;
using ShoppingListProject.Models;

namespace ShoppingListProject.Validators
{
    public class ListValidator : AbstractValidator<List>
    {
        public ListValidator()
        {
          
            RuleFor(p => p.ListName)
              .NotEmpty().WithMessage("Liste adı giriniz")
            .NotNull().WithMessage("Liste adı giriniz");
          

            


        }
    }
}
