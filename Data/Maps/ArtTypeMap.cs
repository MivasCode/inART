using Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps;

public class ArtTypeMap
{
    public ArtTypeMap(EntityTypeBuilder<ArtType> builder)
    {
        builder.HasKey(x => x.ID);
    }
}