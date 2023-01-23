using System.ComponentModel.DataAnnotations;

namespace ShoppingListProject.Models
{
      public class ListDetail
    {
       public int Id { get; set; }
        public int ListId { get; set; }
        public int ProductId { get; set; }
        public string? Detail { get; set; }
        public virtual List List { get; set; } 
        public virtual Product? Product { get; set; }
    }
}
