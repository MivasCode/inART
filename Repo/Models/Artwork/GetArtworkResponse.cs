using PublishingHouse.Interfaces.Extensions.Pagination;
using System.Collections.Generic;
using Data.Models;

namespace Repo.Models.Artwork;

public class GetArtworkResponse : IPaginationResponse<ArtworkShortModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<ArtworkShortModel> Items { get; set; }
}