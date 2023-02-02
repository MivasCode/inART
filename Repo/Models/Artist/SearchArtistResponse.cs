using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Repo.Models.Artist;

public class SearchArtistResponse : IPaginationResponse<ArtistShortModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<ArtistShortModel> Items { get; set; }
}
