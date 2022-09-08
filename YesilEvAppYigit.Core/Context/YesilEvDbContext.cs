using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace YesilEvAppYigit.Core
{
    public partial class YesilEvDbContext : DbContext
    {
        public YesilEvDbContext()
            : base("name=YesilEvDB")
        {
        }
        public virtual DbSet<Allergen> Allergens { get; set; }
        public virtual DbSet<Blacklist> Blacklists { get; set; }
        public virtual DbSet<BlacklistAllergen> BlacklistAllergens { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Risk> Risks { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Search> Searches { get; set; }
        public virtual DbSet<ProductAllergen> ProductAllergens { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Allergen>()
                .HasMany(e => e.BlacklistAllergens)
                .WithRequired(e => e.Allergen)
                .HasForeignKey(e => e.AllergenID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Allergen>()
                .HasMany(e => e.ProductAllergens)
                .WithRequired(e => e.Allergen)
                .HasForeignKey(e => e.AllergenID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Blacklist>()
                .HasMany(e => e.BlacklistAllergens)
                .WithRequired(e => e.Blacklist)
                .HasForeignKey(e => e.BlacklistID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Favorite>()
                .HasMany(e => e.FavoriteProducts)
                .WithRequired(e => e.Favorite)
                .HasForeignKey(e => e.FavoriteID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.FavoriteProducts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductAllergens)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Favorites)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.AddedBy)
                .WillCascadeOnDelete(false);
        }
    }
}
