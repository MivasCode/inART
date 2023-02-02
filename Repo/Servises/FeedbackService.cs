using Data;
using Data.Enums;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using PublishingHouse.Interfaces.Extensions.Pagination;
using Repo.Enums;
using Repo.Interfaces;
using Repo.Models;
using Repo.Models.Feedback;

namespace Repo.Servises;

public class FeedbackService : IFeedback
{
    private readonly AplicationContext _db;

    public FeedbackService(AplicationContext db)
    {
        _db = db;
    }
    public async Task<Feedback> Add(EnumRate rate, string whatliked, string improvements)
    {
        var feedback = new Feedback
        {
            Rate = rate,
            WhatLiked = whatliked,
            Improvements = improvements
        };
        await _db.AddAsync(feedback);
        await _db.SaveChangesAsync();
		
        return feedback;
    }

    public async Task<GetFeedbackResponse> GetAllFeedbackAsync(GetFeedbackRequest request)
    {
        return await _db.Feedbacks.GetPageAsync<GetFeedbackResponse, Feedback, FeedbackShortModel>(request, feedback =>
            new FeedbackShortModel
            {
                ID = feedback.ID,
                Rate = feedback.Rate,
                WhatLiked = feedback.WhatLiked,
                Improvements = feedback.Improvements
            });
    }

    public async Task<Feedback> GetFeedbackAsync(long feedbackId)
    {
        return await _db.Feedbacks.FirstOrDefaultAsync(x => x.ID == feedbackId)
               ?? throw new TirException($"Feedback {feedbackId} is not found!",
                   EnumErrorCode.EntityIsNotFound);
    }

    public async Task DeleteFeedbackAsync(long id)
    {
        if (await _db.Feedbacks.AnyAsync(x => x.ID == id))
            throw new TirException("Feedback is not exists!", EnumErrorCode.EntityIsNotFound);

        _db.Feedbacks.Remove(new Feedback {ID = id});
        await _db.SaveChangesAsync();
    }
}