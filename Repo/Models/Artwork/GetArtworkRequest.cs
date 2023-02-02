using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Repo.Models.Artwork;

public class GetArtworkRequest : IPaginationRequest
{
    public long? Id { get; set; } = null;

    public Page Page { get; set; } = new Page();
}