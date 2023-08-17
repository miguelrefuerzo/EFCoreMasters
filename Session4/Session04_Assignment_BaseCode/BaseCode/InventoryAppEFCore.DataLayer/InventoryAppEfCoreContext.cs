using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAppEFCore.DataLayer
{
    public class InventoryAppEfCoreContext : DbContext
    {
      
        public InventoryAppEfCoreContext(DbContextOptions<InventoryAppEfCoreContext> options)
          : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ClientView> CientViews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TO DO Fluent API
            //modelBuilder.Ignore<NotMappedAttribute>();

            ////Product
            //modelBuilder.Entity<Product>()
            //    .HasKey(p => p.ProductId);
            //modelBuilder.Entity<Product>()
            //    .Property(p => p.Name)
            //    .HasMaxLength(50)
            //    .IsRequired();
            //modelBuilder.Entity<Product>()
            //    .Property<DateTime>("ReleaseDate");
            //modelBuilder.Entity<Product>() //value conversion
            //    .Property(p => p.IsDeleted)
            //    .HasConversion<int>();
            //modelBuilder.Entity<Product>()
            //    .HasMany(p => p.Tags)
            //    .WithMany(p => p.Products)
            //    .UsingEntity(p => p.ToTable("ProductTag"));
            //modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);

            ////Client
            //modelBuilder.Entity<Client>()
            //    .HasKey(p => p.ClientId);
            //modelBuilder.Entity<Client>()
            //    .Property(p => p.Name)
            //    .HasMaxLength(50)
            //    .IsRequired();
            //modelBuilder.Entity<Client>() //value conversion
            //    .Property(p => p.IsDeleted)
            //    .HasConversion<int>();

            ////ExcludeClass
            //modelBuilder.Entity<ExcludeClass>()
            //    .HasKey(p => p.Id);
            //modelBuilder.Entity<ExcludeClass>()
            //    .Property(p => p.Name)
            //    .HasMaxLength(50)
            //    .IsRequired();
            
            ////LineItem
            //modelBuilder.Entity<LineItem>()
            //    .HasKey(p => p.LineItemId);
            //modelBuilder.Entity<LineItem>()
            //    .HasOne(p => p.SelectedProduct)
            //    .WithOne()
            //    .HasForeignKey<Product>(p => p.ProductId);
            
            ////Order
            //modelBuilder.Entity<Order>()
            //    .HasKey(p => p.OrderId);
            //modelBuilder.Entity<Order>()
            //    .HasMany(p => p.LineItems)
            //    .WithOne()
            //    .HasForeignKey(p => p.OrderId);
            
            ////PriceOffer
            //modelBuilder.Entity<PriceOffer>()
            //    .HasKey(p => p.PriceOfferId);
            
            ////Review
            //modelBuilder.Entity<Review>()
            //    .HasKey(p => p.ReviewId);
            //modelBuilder.Entity<Review>()
            //    .Property(p => p.VoterName)
            //    .HasMaxLength(50)
            //    .IsRequired();
            
            ////Supplier
            //modelBuilder.Entity<Supplier>()
            //    .HasKey(p => p.SupplierId);
            //modelBuilder.Entity<Supplier>()
            //    .Property(p => p.Name)
            //    .HasMaxLength(50)
            //    .HasField("_Name")
            //    .IsRequired();

            ////Tag
            //modelBuilder.Entity<Tag>()
            //    .HasKey(p => p.TagId);


            //Session7 seed data
            modelBuilder.Entity<Client>().HasData(
                new { ClientId = 1, Name = "Client 1", IsDeleted = false },
                new { ClientId = 2, Name = "Client 2", IsDeleted = false},
                new { ClientId = 3, Name = "Client 3", IsDeleted = false}
                );

            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<ClientView>().ToView("ClientView").HasNoKey();
        }

    }
}