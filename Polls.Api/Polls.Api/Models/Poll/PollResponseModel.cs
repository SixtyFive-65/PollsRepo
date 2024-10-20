﻿using Polls.Api.Data.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace Polls.Api.Models.Poll
{
    public class PollResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Question { get; set; }
        public ICollection<Question> Questions { get; set; } = [];
    }
}
