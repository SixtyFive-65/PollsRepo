namespace Polls.Api.Models.Poll
{
    public class PollResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Question { get; set; }
        public List<Option> Options { get; set; } =new List<Option>();
    }
}
