using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PackIT.Infrastructure.EF.Models;

namespace PackIT.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration :
        IEntityTypeConfiguration<PackingListReadModel>, IEntityTypeConfiguration<PackingItemReadModel>
    {
        public void Configure(EntityTypeBuilder<PackingListReadModel> builder)
        {
            builder.ToTable("PackingLists");
            builder.HasKey(pl => pl.Id);
            // To save Localization into one column
            builder
                .Property(pl => pl.Localization)
                .HasConversion(l => l.ToString(), l => LocalizationReadModel.Create(l));
            // Relation between Packing Lists and Packing Items
            builder
                .HasMany(pl => pl.Items)
                .WithOne(pi => pi.PackingList);
        }

        public void Configure(EntityTypeBuilder<PackingItemReadModel> builder)
        {
            builder.ToTable("PackingItems");
        }
    }
}