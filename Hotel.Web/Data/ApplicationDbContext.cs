using Hotel.Web.Models;
using Microsoft.EntityFrameworkCore;


namespace Hotel.Web.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Category> Categories { get; set; }

       

        public DbSet<Menu> Menus { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }


        public DbSet<Hotel.Web.Models.Payment> Payment { get; set; }

    }
}