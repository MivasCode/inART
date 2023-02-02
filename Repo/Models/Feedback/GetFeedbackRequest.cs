using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Repo.Models.Feedback;

public class GetFeedbackRequest : IPaginationRequest
{
    public long? Id { get; set; } = null;

    public Page Page { get; set; } = new Page();
}