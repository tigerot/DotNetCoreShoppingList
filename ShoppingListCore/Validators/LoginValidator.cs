using FluentValidation;
using ShoppingListCore.Models;
using ShoppingListProject.Models;

namespace ShoppingListProject.Validators
{
    public class LoginValidator : AbstractValidator<UserSignInViewModel>
    {
        public LoginValidator()
        {
            RuleFor(p => p.email)
              .NotEmpty().WithMessage("Kullanıcı adı giriniz")
            .NotNull().WithMessage("Kullanıcı adı giriniz");


            RuleFor(p => p.password)
                .NotEmpty().WithMessage("Parola giriniz")
           .NotNull().WithMessage("Parola giriniz");
          

            


        }
    }
}
