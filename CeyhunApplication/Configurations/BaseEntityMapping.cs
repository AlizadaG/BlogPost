using CeyhunApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CeyhunApplication.Configurations;

public class BaseEntityMapping<T>
    : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);
    }
}

// CategoryMapping
// PostMapping
// PopularTagMapping
// PopularTagPostMapping
// ++


