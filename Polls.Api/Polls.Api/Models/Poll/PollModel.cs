namespace Polls.Api.Models.Poll
{
    public class PollModel
    {
        public string Name { get; set; }
        public List<QuestionModel> Questions { get; set; } = [];
    }
}
