using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Repo.Models.Artwork;

public class SearchArtworkResponse : IPaginationResponse<ArtworkShortModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<ArtworkShortModel> Items { get; set; }
}
