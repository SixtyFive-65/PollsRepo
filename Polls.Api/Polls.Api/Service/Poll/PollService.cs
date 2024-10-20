using Polls.Api.Models.Poll;
using Polls.Api.Repository.Poll;

namespace Polls.Api.Service.Poll
{
    public class PollService : IPollService
    {
        private readonly IPollRepository pollRepository;
        public PollService(IPollRepository pollRepository)
        {
            this.pollRepository = pollRepository;
        }
        public async Task<bool> CreatePoll(PollModel model)
        {
            return await pollRepository.CreatePoll(model);
        }

        public async Task<bool> Vote(VoteModel model)
        {
            return await pollRepository.Vote(model);
        }


        public async Task<IEnumerable<PollResponseModel>> GetAllPolls()
        {
            return await pollRepository.GetAllPolls();
        }
    }
}
