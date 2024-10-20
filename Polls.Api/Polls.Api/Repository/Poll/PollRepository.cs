using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Polls.Api.Data;
using Polls.Api.Data.DomainModels;
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

        public async Task<IEnumerable<PollResponseModel>> GetAllPolls()
        {
            try
            {
                var polls = await pollingDbContext.Polls
                            .Include(p => p.Questions)
                                .ThenInclude(q => q.Options)
                            .ToListAsync();

                return polls.Select(p => new PollResponseModel
                {
                    Question = p.Question,
                    Id = p.Id,
                    Questions = p.Questions,
                    UserId = p.UserId
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return new List<PollResponseModel>();
            }
        }
        public async Task<bool> CreatePoll(PollModel model)
        {
            try
            {
                var poll = new Polls.Api.Data.DomainModels.Poll
                {
                    Question = model.Question,
                    Questions = new List<Question>
                    {
                        new Question
                        {
                            QuestionText = model.Question,
                            Options = model.Options.Select(p => new Data.DomainModels.Option
                            {
                                OptionText = p.OptionText,

                            }).ToList()
                        }
                    }
                };

                pollingDbContext.Polls.Add(poll);

                var savePollResult = await pollingDbContext.SaveChangesAsync();

                if (savePollResult > 0)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

            }

            return false;
        }

        public Task<bool> Vote(PollModel model)
        {
            throw new NotImplementedException();
        }
    }
}
