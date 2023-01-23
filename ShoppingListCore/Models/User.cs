using System.ComponentModel.DataAnnotations;

namespace ShoppingListProject.Models
{
    public class User
    {
        public User()
        {
            Lists = new HashSet<List>();
         
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserMail { get; set; }
        public string UserPassword { get; set; }
        public bool UserAdminStatus { get; set; }
        public virtual ICollection<List> Lists { get; set; }
    }
}
