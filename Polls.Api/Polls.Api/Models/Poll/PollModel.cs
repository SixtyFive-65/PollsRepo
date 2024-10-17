using Polls.Api.Data.DomainModels;

namespace Polls.Api.Models.Poll
{
    public class PollModel
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<Question> Questions { get; set; } = [];
    }
}
