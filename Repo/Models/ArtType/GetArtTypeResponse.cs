using PublishingHouse.Interfaces.Extensions.Pagination;
using System.Collections.Generic;
using Data.Models;

namespace Repo.Models.ArtType;

public class GetArtTypeResponse : IPaginationResponse<ArtTypeShortModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<ArtTypeShortModel> Items { get; set; }
}