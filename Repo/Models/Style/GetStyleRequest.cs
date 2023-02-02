using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Repo.Models.Style;

public class GetStyleRequest : IPaginationRequest
{
    public long? Id { get; set; } = null;

    public Page Page { get; set; } = new Page();
}