using Data.Enums;
using Data.Models;
using Repo.Models.Feedback;

namespace Repo.Interfaces;

public interface IFeedback
{
    Task<Feedback> Add(EnumRate rate, string whatliked, string improvements);

    Task<GetFeedbackResponse> GetAllFeedbackAsync(GetFeedbackRequest model);

    Task<Feedback> GetFeedbackAsync(long id);
    
    Task DeleteFeedbackAsync(long id);
}