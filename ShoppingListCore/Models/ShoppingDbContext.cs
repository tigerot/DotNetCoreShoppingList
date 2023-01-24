
using Microsoft.EntityFrameworkCore;

using ShoppingListProject.Models;

namespace ShoppingListCoreProject.Models
{
    public class ShoppingDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-7UP8BRH;Database=ShoppingListDb;Integrated Security=True;Trusted_Connection=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Added the admin user while creating the database
            modelBuilder.Entity<User>().HasData(
        new User
        {
            UserId=1,
            UserName = "Administrator",
            UserSurname = "Admin",
            UserMail = "admin@mail.com",
            UserPassword="Admin123+-"  ,
            UserAdminStatus=true
            
        });

            modelBuilder.Entity<Category>().HasData(new Category { CategoryId=1,CategoryName = "Meyve&Sebze" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Et&Tavuk&Balık" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Temel Gıda" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 4, CategoryName = "Kahvaltılık" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 5, CategoryName = "İçecek" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 6, CategoryName = "Fırın" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 7, CategoryName = "Atıştırmalık" });

            modelBuilder.Entity<Product>().HasData(new Product { ProductId=1,ProductName="Yumurta",CategoryId=4, Image="yumurta.jpeg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 2, ProductName ="Zeytin",CategoryId=4, Image="zeytin.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 3, ProductName ="Salça",CategoryId=3, Image="salca.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 4, ProductName ="Ekmek",CategoryId=6, Image="ekmek.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 5, ProductName ="Muz",CategoryId=1, Image="muz.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 6, ProductName ="Elma",CategoryId=1, Image="elma.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 7, ProductName ="Domates",CategoryId=1, Image="domates.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 8, ProductName ="Çikolata",CategoryId=7, Image="cikolata.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 9, ProductName ="Balık",CategoryId=2, Image="balik.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 10, ProductName ="Tavuk",CategoryId=2, Image="tavuk.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 11, ProductName ="Peynir",CategoryId=4, Image="peynir.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 12, ProductName ="Kabak",CategoryId=1, Image="kabak.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 13, ProductName ="Kavurmalık Et",CategoryId=2, Image="kavurmalıket.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 14, ProductName ="Un",CategoryId=3, Image="un.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 15, ProductName ="Su",CategoryId=5, Image="su.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 16, ProductName ="Süt",CategoryId=5, Image="süt.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 17, ProductName ="Maden Suyu",CategoryId=5, Image="soda.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 18, ProductName ="Meyve Suyu",CategoryId=5, Image="meyvesuyu.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 19, ProductName ="Sucuk",CategoryId=4, Image="sucuk.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 20, ProductName ="Makarna",CategoryId=3, Image="makarna.jpg"});
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 21, ProductName ="Cips",CategoryId=7, Image="cips.jpeg"});



        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<ListDetail> ListDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

       
       
    }
}
