using FluentValidation;
using ShoppingListCore.Models;
using ShoppingListProject.Models;

namespace ShoppingListProject.Validators
{
    public class UserValidator:AbstractValidator<UserRegisterViewModel>
    {
        public UserValidator()
        {
            RuleFor(p => p.UserMail)
              .NotEmpty().WithMessage("Kullanıcı adı giriniz")
              .EmailAddress().WithMessage("Geçerli bir email adresi giriniz")
            .NotNull().WithMessage("Kullanıcı adı giriniz");
            RuleFor(p => p.UserName)
              .NotEmpty().WithMessage("Kullanıcı adı giriniz")
            .NotNull().WithMessage("Kullanıcı adı giriniz");
            RuleFor(p => p.UserSurname)
             .NotEmpty().WithMessage("Kullanıcı adı giriniz")
           .NotNull().WithMessage("Kullanıcı adı giriniz");
           
            RuleFor(p => p.UserPassword)
                .NotEmpty().WithMessage("Parola giriniz")
           .NotNull().WithMessage("Parola giriniz")
               .MinimumLength(8) .WithMessage("Parola 8 karakterden az olmaz")
              .Matches("[A-Z]").WithMessage("Parola en az 1 büyük harf içermeli")
                .Matches("[a-z]").WithMessage("Parola en az 1 küçük harf içermeli")
                .Matches("[0-9]").WithMessage("Parola en az 1 rakam içermeli");

            RuleFor(p => p.ConfirmPassword)
                .Equal(x => x.UserPassword).WithMessage("Parolalar eşleşmiyor");

            


        }
    }
}
