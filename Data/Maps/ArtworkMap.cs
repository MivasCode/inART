using Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps;

public class ArtworkMap
{
    public ArtworkMap(EntityTypeBuilder<Artwork> builder)
    {
        builder.HasKey(x => x.ID);
        builder.HasOne(x => x.Style).WithMany(z => z.Artworks).HasForeignKey(y => y.StyleID);
        builder.HasOne(x => x.Artist).WithMany(z => z.Artworks).HasForeignKey(y => y.ArtistID);
    }
}