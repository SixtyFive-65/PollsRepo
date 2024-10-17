using Microsoft.EntityFrameworkCore;
using Polls.Api.Data;
using Polls.Api.Models.Poll;

namespace Polls.Api.Repository.Poll
{
    public class PollRepository : IPollRepository
    {
        private readonly PollingDbContext pollingDbContext;
        private readonly IConfiguration configuration;

        public PollRepository(PollingDbContext pollingDbContext, IConfiguration configuration)
        {
            this.pollingDbContext = pollingDbContext;
            this.configuration = configuration;
        }

        public Task<bool> CreatePoll(PollModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PollModel>> GetAllPolls()
        {

           var polls = await pollingDbContext.Polls.ToListAsync();

            return new List<PollModel>();
        }
    }
}
