using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Eurosong.Data;
using Eurosong.Models;

namespace Eurosong.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoteController : ControllerBase
    {
        private DataContext _data;

        public VoteController(DataContext data)
        {
            this._data = data;
        }

        // adding new Vote to the DB
        [HttpPost]
        public ActionResult Post(Models.Vote vote)
        {
            _data.AddVote(vote);
            return Ok("Vote posted!");
        }
        // Deleting Vote from the DB
        [HttpDelete]
        public ActionResult DELETE(int id)
        {
            _data.RemoveVote(id);
            return Ok("Vote Removed!");
        }

        // Updating song using id and saving it on the DB
        [HttpPut("update/{id}")]
        public ActionResult Put(int id, Vote Value)
        {
            _data.UpdateVote(id, Value);
            return Ok("Vote Updated!");
        }

        // Getting all the votes 


        [HttpGet("list")]
        public ActionResult<List<Models.Vote>> Get()
        {
            return Ok(_data.GetVotes());
        }

        // search GET Vote by ID

        [HttpGet("{id}")]
        public ActionResult<Models.Vote> Get(int id)
        {
            Models.Vote vote = _data.GetVoteById(id);
            if (vote == null) return NotFound("Wrong id? Id not found in database");
            return Ok(vote);

        }

    }
}
