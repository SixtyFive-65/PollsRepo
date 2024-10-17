using Polls.Api.Models.Poll;

namespace Polls.Api.Repository.Poll
{
    public interface IPollRepository
    {
        Task<IEnumerable<PollModel>> GetAllPolls();
        Task<bool> CreatePoll(PollModel model);
    }
}
