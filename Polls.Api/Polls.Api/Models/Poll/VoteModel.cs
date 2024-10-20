using System.ComponentModel.DataAnnotations;

namespace Polls.Api.Models.Poll
{
    public class VoteModel
    {
        public int PollId { get; set; }
        [Required]
        public int OptionId { get; set; }
    }
}
