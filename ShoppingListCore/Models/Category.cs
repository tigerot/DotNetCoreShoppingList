using System.ComponentModel.DataAnnotations;

namespace ShoppingListProject.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Lütfen Kategori adı giriniz")]
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
