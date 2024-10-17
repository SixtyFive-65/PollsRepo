using Polls.Api.Data.DomainModels;

namespace Polls.Api.Models.Poll
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int PollId { get; set; }
        public List<Option> Options { get; set; } = [];
    }
}
