namespace Polls.Api.Models.Poll
{
    public class PollModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public List<QuestionModel> Questions { get; set; } = [];
    }
}
