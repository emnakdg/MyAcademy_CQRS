using CQRSProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-7CKJMG6;database=MyAcademyCQRSDb;integrated security=true;trustServerCertificate=true");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<ThreeStepService> ThreeStepServices { get; set; }
        public DbSet<OurHistory> OurHistories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<PhotoGallery> PhotoGalleries { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
    }
}

