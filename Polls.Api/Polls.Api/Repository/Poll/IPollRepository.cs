using Polls.Api.Models.Poll;

namespace Polls.Api.Repository.Poll
{
    public interface IPollRepository
    {
        Task<IEnumerable<PollResponseModel>> GetAllPolls();
        Task<bool> CreatePoll(PollModel model);
        Task<bool> Vote(PollModel model);
    }
}
