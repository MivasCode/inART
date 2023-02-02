using Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps;

public class ArtistMap
{
    public ArtistMap(EntityTypeBuilder<Artist> builder)
    {
        builder.HasKey(x => x.ID);
    }
}