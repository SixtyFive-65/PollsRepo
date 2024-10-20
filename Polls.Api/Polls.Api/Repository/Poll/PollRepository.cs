using Microsoft.EntityFrameworkCore;
using Polls.Api.Data;
using Polls.Api.Data.DomainModels;
using Polls.Api.Models.Poll;

using Serilog;

namespace Polls.Api.Repository.Poll
{
    public class PollRepository : IPollRepository
    {
        private readonly PollingDbContext pollingDbContext;

        public PollRepository(PollingDbContext pollingDbContext)
        {
            this.pollingDbContext = pollingDbContext;
        }

        public async Task<IEnumerable<PollResponseModel>> GetAllPolls()
        {
            try
            {
                var polls = await pollingDbContext.Polls
                            .Include(p => p.Questions)
                                .ThenInclude(q => q.Options)
                                .ThenInclude(q => q.Votes)
                            .ToListAsync();

                var pollswithquestions = polls.Select(p => new PollResponseModel
                {
                    Id = p.Id,
                    UserId = p.UserId,
                    Question = p.Question,
                    Options = p.Questions.SelectMany(o => o.Options).Select(o => new Models.Poll.Option // Mapping to the response model
                    {
                        Id = o.Id,
                        OptionText = o.OptionText,
                        VoteCount = o.Votes.Count()

                    }).ToList(),
                });

                return pollswithquestions.ToList();
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

                Log.Information($"Successfully added {model.Question} poll!");

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

        public async Task<bool> Vote(VoteModel model)
        {
            try
            {
                bool voteResponse = false;

                var option = await pollingDbContext.Options.Include(o => o.Votes)
                                        .FirstOrDefaultAsync(o => o.Id == model.OptionId);

                if (option == null)
                {
                    Log.Warning($"{model.OptionId} does not exist");

                    return false;
                }

                var vote = new Vote
                {
                    OptionId = model.OptionId
                };

                pollingDbContext.Votes.Add(vote);

                var voteResult = await pollingDbContext.SaveChangesAsync();

                if (voteResult > 0)
                {
                    voteResponse = true;
                }

                return voteResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);

                return false;
            }
        }
    }
}
