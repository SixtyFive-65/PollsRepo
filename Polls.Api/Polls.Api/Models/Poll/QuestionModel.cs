namespace Polls.Api.Models.Poll
{
    public class QuestionModel
    {
        public string QuestionText { get; set; }
        public int PollId { get; set; }
        public List<OptionModel> Options { get; set; } = [];
    }
}
