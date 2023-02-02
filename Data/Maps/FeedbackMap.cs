using Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps;

public class FeedbackMap
{
    public FeedbackMap(EntityTypeBuilder<Feedback> builder)
    {
        builder.HasKey(x => x.ID);
    }
}