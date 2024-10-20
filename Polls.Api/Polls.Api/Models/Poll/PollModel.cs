using System.ComponentModel.DataAnnotations;

namespace Polls.Api.Models.Poll
{
    public class PollModel
    {
        [Required]
        public string Question { get; set; } // Represents the poll question

        [Required]
        public List<Option> Options { get; set; } // Represents a list of options for the poll
    }

    public class Option
    {
        [Required]
        public string OptionText { get; set; } // Represents the text of an individual option
    }
}
