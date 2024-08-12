using CeyhunApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CeyhunApplication.Configurations;


//public class CategoryMapping : IEntityTypeConfiguration<Category>
public class CategoryMapping : BaseEntityMapping<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        //builder.ToTable("Kategoriler");

        builder.Property(c => c.Title)
            //.HasColumnName("Baslik")
            .HasMaxLength(100)
            .IsRequired();

        //  Configure the relationship between Post and Category  
        builder.HasMany(c => c.Posts)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);


        //  Configure self-referencing relationship for Category
        builder.HasOne(c => c.ParentCategory)
            .WithMany(c => c!.SubCategories)
            .HasForeignKey(c => c.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
public class PopularTagMapping : BaseEntityMapping<PopularTag>
{
    public override void Configure(EntityTypeBuilder<PopularTag> builder)
    {
        base.Configure(builder);

        //builder.ToTable("PopulerEtiketler");

        builder.Property(pt => pt.Title)
            .HasMaxLength(50)
            .IsRequired();
    }
}
public class PostMapping : BaseEntityMapping<Post>
{
    public override void Configure(EntityTypeBuilder<Post> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Content)
            .IsRequired();

        builder.HasOne(p => p.Category)
            .WithMany(c => c!.Posts)
            .HasForeignKey(p => p.CategoryId);
    }
}


public class PopularTagPostMapping : IEntityTypeConfiguration<PopularTagPost>
{
    public void Configure(EntityTypeBuilder<PopularTagPost> builder)
    {

        builder.HasKey(pt => new { pt.PostId, pt.PopularTagId });

        builder.HasOne(pt => pt.Post)
            .WithMany(p => p!.PostPopularTags)
            .HasForeignKey(pt => pt.PostId);

        builder.HasOne(pt => pt.PopularTag)
            .WithMany(p => p!.PopularTagPosts)
            .HasForeignKey(pt => pt.PopularTagId);
    }
}

// CategoryMapping  +
// PostMapping      +
// PopularTagMapping +
// PopularTagPostMapping
// ++


