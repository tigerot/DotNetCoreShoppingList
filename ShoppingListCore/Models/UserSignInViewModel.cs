using System.ComponentModel.DataAnnotations;

namespace ShoppingListCore.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını giriniz")]
        public string email { get; set; }
       
        [Required(ErrorMessage ="Lütfen Parolanızı giriniz")]
        public string password { get; set; }
    }
}
