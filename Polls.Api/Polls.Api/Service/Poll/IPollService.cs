using Polls.Api.Models.Poll;

namespace Polls.Api.Service.Poll
{
    public interface IPollService
    {
        Task<IEnumerable<PollResponseModel>> GetAllPolls();
        Task<bool> CreatePoll(PollModel model);
        Task<bool> Vote(PollModel model);
    }
}
