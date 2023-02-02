using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Repo.Models.Artist;

public class GetArtistRequest : IPaginationRequest
{
    public long? Id { get; set; } = null;

    public Page Page { get; set; } = new Page();
}