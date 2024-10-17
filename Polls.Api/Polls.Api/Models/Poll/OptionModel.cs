namespace Polls.Api.Models.Poll
{
    public class OptionModel
    {
        public int Id { get; set; }
        public string OptionText { get; set; }
        public int QuestionId { get; set; }
    }
}
