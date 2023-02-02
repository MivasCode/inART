using Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps;

public class StyleMap
{
    public StyleMap(EntityTypeBuilder<Style> builder)
    {
        builder.HasKey(x => x.ID);
        builder.HasOne(x => x.ArtType).WithMany(z => z.Styles).HasForeignKey(x => x.ArtTypeID);
    }
}