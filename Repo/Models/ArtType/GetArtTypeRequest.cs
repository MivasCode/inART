using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Repo.Models.ArtType;

public class GetArtTypeRequest : IPaginationRequest
{
    public long? Id { get; set; } = null;

    public Page Page { get; set; } = new Page();
}