using Data.Enums;

namespace Repo.Models.Feedback;

public class FeedbackShortModel
{
    public long ID { get; set; }
    public EnumRate Rate { get; set; }
    public string WhatLiked { get; set; }
    public string Improvements { get; set; }
}