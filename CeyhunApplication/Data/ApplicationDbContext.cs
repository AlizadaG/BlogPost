using CeyhunApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CeyhunApplication.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Post> Posts { get; set; } = default!;
    public virtual DbSet<Category> Categories { get; set; } = default!;
    public virtual DbSet<PopularTag> PopularTags { get; set; } = default!;
    public virtual DbSet<PopularTagPost> PopularTagPost { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Old
        //// ToTable eklemezseniz, dbset'in adını alır, eklerseniz override eder.
        //modelBuilder.Entity<Category>().ToTable("Kategoriler");
        //modelBuilder.Entity<Category>()
        //    .Property(c => c.Title)
        //    .HasColumnName("Baslik") // Adını değiştirmek için ekliyoruz, eklemezseniz default property adını alır.
        //    .HasMaxLength(100)
        //    .IsRequired();

        ////  Configure the relationship between Post and Category  
        //modelBuilder.Entity<Category>()
        //    .HasMany(c => c.Posts)      // -> bir kategorinin, birden fazla postu vardır
        //    .WithOne(p => p.Category)   // -> bir postun bir kategorisi vardır  - p => p.Category bu alan opsiyonel
        //    .HasForeignKey(p => p.CategoryId);


        ////  Configure self-referencing relationship for Category
        //modelBuilder.Entity<Category>()
        //    .HasOne(c => c.ParentCategory)                // Bir kategori bir üst kategoriye sahip olabilir
        //    .WithMany(c => c!.SubCategories)              // Bir üst kategorinin birçok alt kategorisi olabilir
        //    .HasForeignKey(c => c.ParentCategoryId)       // ParentCategoryId, alt kategorinin üst kategorisini belirtir
        //    .OnDelete(DeleteBehavior.Restrict);           // Eğer alt kategoriler varsa, üst kategori silinmesin


        // Configure many-to-many relationship between Post and PopularTag
        //modelBuilder.Entity<PopularTagPost>()
        //    .HasKey(pt => new { pt.PostId, pt.PopularTagId });


        //modelBuilder.Entity<PopularTagPost>()
        //    .HasOne(pt => pt.Post)
        //    .WithMany(p => p!.PostPopularTags)
        //    .HasForeignKey(pt => pt.PostId);


        //modelBuilder.Entity<PopularTagPost>()
        //    .HasOne(pt => pt.PopularTag)
        //    .WithMany(p => p!.PopularTagPosts)
        //    .HasForeignKey(pt => pt.PopularTagId); 
        #endregion

        //modelBuilder.ApplyConfiguration(new CategoryMapping());
        //modelBuilder.ApplyConfiguration(new PostMapping());
        //modelBuilder.ApplyConfiguration(new PopularTagMapping());
        //modelBuilder.ApplyConfiguration(new PopularTagPostMapping());

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        base.OnModelCreating(modelBuilder);
    }
}
