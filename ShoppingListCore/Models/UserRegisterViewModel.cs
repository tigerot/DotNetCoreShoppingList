using System.ComponentModel.DataAnnotations;

namespace ShoppingListCore.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen mail adresi giriniz")]
        public string UserMail { get; set; }
        [Required(ErrorMessage = "Lütfen adınızı giriniz")]
        public string UserSurname { get; set; }
        [Required(ErrorMessage = "Lütfen soyadınızı giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen parola giriniz")]
        public string UserPassword { get; set; }
        [Required(ErrorMessage = "Lütfen parola tekrarını giriniz")]
        public string ConfirmPassword { get; set; }
    }
}
