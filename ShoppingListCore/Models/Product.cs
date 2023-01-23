using System.ComponentModel.DataAnnotations;

namespace ShoppingListProject.Models
{
    public class Product
    {
        public Product()
        {
            ListDetails = new HashSet<ListDetail>();
        }
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Lütfen Ürün Adı giriniz")]
        public string ProductName { get; set; } 
        public string? Image { get; set; }=null;
  
        public virtual Category? Category { get; set; }
        public virtual ICollection<ListDetail> ListDetails { get; set; }
    }
}
