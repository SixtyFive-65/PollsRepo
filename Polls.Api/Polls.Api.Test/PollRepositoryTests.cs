using Microsoft.EntityFrameworkCore;
using Polls.Api.Data;
using Polls.Api.Data.DomainModels;
using Polls.Api.Repository.Poll;

namespace Polls.Api.Tests
{
    public class PollRepositoryTests
    {
        private readonly PollingDbContext _dbContext;
        private readonly PollRepository _pollRepository;

        public PollRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<PollingDbContext>()
                .UseInMemoryDatabase(databaseName: "PollingDb")
                .Options;

            _dbContext = new PollingDbContext(options);
            _pollRepository = new PollRepository(_dbContext);

            SeedData();
        }

        private void SeedData()
        {
            _dbContext.Polls.RemoveRange(_dbContext.Polls);
            _dbContext.Questions.RemoveRange(_dbContext.Questions);
            _dbContext.Options.RemoveRange(_dbContext.Options);
            _dbContext.Votes.RemoveRange(_dbContext.Votes);
            _dbContext.SaveChanges();

            var poll = new Polls.Api.Data.DomainModels.Poll
            {
                UserId = 1,
                Question = "Sample Poll",
                Questions = new List<Question>
                {
                    new Question
                    {
                        QuestionText = "Sample Poll",
                        Options = new List<Option>
                        {
                            new Option { OptionText = "Option 1", Votes = new List<Vote>() },
                            new Option { OptionText = "Option 2", Votes = new List<Vote>() }
                        }
                    }
                }
            };

            _dbContext.Polls.Add(poll);
            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task GetAllPolls_ShouldReturnPolls_WithQuestionsAndOptions()
        {
            // Act
            var result = await _pollRepository.GetAllPolls();

            Assert.NotNull(result);

            var poll = result.First();
            Assert.Equal("Sample Poll", poll.Question);
            Assert.Equal(2, poll.Options.Count);
        }

        [Fact]
        public async Task CreatePoll_ShouldAddNewPoll()
        {
            // Arrange
            var newPoll = new Models.Poll.PollModel
            {
                Question = "New Poll",
                Options = new List<Models.Poll.Option>
                {
                    new Models.Poll.Option { OptionText = "New Option 1" },
                    new Models.Poll.Option { OptionText = "New Option 2" }
                }
            };

            // Act
            var result = await _pollRepository.CreatePoll(newPoll);
            var createdPoll = await _dbContext.Polls.FirstOrDefaultAsync(p => p.Question == newPoll.Question);

            // Assert
            Assert.True(result);
            Assert.NotNull(createdPoll);
            Assert.Equal(newPoll.Question, createdPoll.Question);
            Assert.Equal(2, createdPoll.Questions.First().Options.Count());
        }

        [Fact]
        public async Task Vote_ShouldIncrementVoteCountForOption()
        {
            // Arrange
            var optionId = 1;

            var voteModel = new Polls.Api.Models.Poll.VoteModel
            {
                OptionId = optionId
            };

            // Act
            var result = await _pollRepository.Vote(voteModel);
            var option = await _dbContext.Options.Include(o => o.Votes).FirstOrDefaultAsync(o => o.Id == optionId);

            // Assert
            Assert.True(result);
            Assert.NotNull(option);
            Assert.Single(option.Votes);
        }
    }
}
