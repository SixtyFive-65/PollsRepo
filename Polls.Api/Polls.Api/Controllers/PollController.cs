using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polls.Api.Models.Poll;
using Polls.Api.Service.Poll;

namespace Polls.Api.Controllers
{
    //[Authorize]
    public class PollController : Controller
    {
        private readonly IPollService pollService;
        public PollController(IPollService pollService)
        {
            this.pollService = pollService;
        }

        [HttpGet("GetPolls")]
        public async Task<IActionResult> GetAllPolls()
        {
            var polls = await pollService.GetAllPolls();

            return Ok(polls);
        }

        [HttpPost("CreatePoll")]
        public async Task<IActionResult> CreatePoll([FromBody]PollModel model)
        {
            var createPollResult = await pollService.CreatePoll(model);

            if (createPollResult)
            {
                return Ok(createPollResult);
            }
            else
            {
                return BadRequest(createPollResult);
            }
        }


        [HttpPost("Vote")]
        public async Task<IActionResult> Vote(PollModel model)
        {
            var createPollResult = await pollService.CreatePoll(model);

            if (createPollResult)
            {
                return Ok(createPollResult);
            }
            else
            {
                return BadRequest(createPollResult);
            }
        }
    }
}
