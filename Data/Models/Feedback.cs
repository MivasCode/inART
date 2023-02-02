using Data.Enums;

namespace Data.Models;

public class Feedback
{
    public long ID { get; set; }
    public EnumRate Rate { get; set; }
    public string WhatLiked { get; set; }
    public string Improvements { get; set; }
}