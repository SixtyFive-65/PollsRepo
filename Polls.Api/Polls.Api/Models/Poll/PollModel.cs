using System.ComponentModel.DataAnnotations;

namespace Polls.Api.Models.Poll
{
    public class PollModel
    {
        [Required]
        public string Question { get; set; } 

        [Required]
        public List<Option> Options { get; set; }
    }

    public class Option
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string OptionText { get; set; } 
    }
}
