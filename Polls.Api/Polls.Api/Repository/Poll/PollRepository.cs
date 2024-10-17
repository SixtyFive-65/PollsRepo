using Microsoft.EntityFrameworkCore;
using Polls.Api.Data;
using Polls.Api.Models.Poll;
using Serilog;

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

        public async Task<bool> CreatePoll(PollModel model)
        {
            try
            {
              
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

            }
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PollModel>> GetAllPolls()
        {
            try
            {
                var polls = await pollingDbContext.Polls.ToListAsync();

                return new List<PollModel>();
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message, ex);

                return new List<PollModel>();
            }
        }
    }
}
