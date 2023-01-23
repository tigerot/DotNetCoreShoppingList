using System.ComponentModel.DataAnnotations;

namespace ShoppingListProject.Models
{
    public class List
    {
        public List()
        {
            ListDetails = new HashSet<ListDetail>();
        }
     
        public int ListId { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Lütfen Listenize bir isim giriniz")]
        public string ListName { get; set; }
        public bool isActive { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<ListDetail> ListDetails { get; set; }
    }
}
