using PublishingHouse.Interfaces.Extensions.Pagination;
using System.Collections.Generic;
using Data.Models;

namespace Repo.Models.Feedback;

public class GetFeedbackResponse : IPaginationResponse<FeedbackShortModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<FeedbackShortModel> Items { get; set; }
}