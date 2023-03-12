using Eurosong.Data;
using Eurosong.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eurosong.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private DataContext _data;

        public SongController(DataContext data)
        {
            this._data = data;
        }

        // adding new songs to the DB
        [HttpPost]
        public ActionResult Post(Song song)
        {
            _data.AddSong(song);
            return Ok("Song posted!");
        }
        // Deleting song from the DB
        [HttpDelete]
        public ActionResult DELETE(int id)
        {
            _data.RemoveSong(id);
            return Ok("Song Removed!");
        }
        // Updating song using id and saving it on the DB
        [HttpPut("update/{id}")]
        public ActionResult Put(int id , Song Value)
        {
            _data.UpdateSong(id, Value);
            return Ok("Song Updated!");
        }  

        // get all songs list 
        [HttpGet("list")]
        public ActionResult<List<Song>> Get()
        {
            return Ok(_data.GetSongs());
        }

        /* Other possible solution
           [HttpGet]
            public ActionResult<List<Song>> Get(string word)
            {
                return Ok(_data.GetSongsByTitle(word));
            }
         */


        [HttpGet("Search")]
        public ActionResult<List<Song>> GetByTitle(string word)
        {
            return Ok(_data.GetSongsByTitle(word));
        }
        // search GET by ID

        [HttpGet("{id}")]
        public ActionResult<Song> Get(int id)
        {
            Song song = _data.GetSongById(id);
            if (song == null) return NotFound("Wrong id? Id not found in database");
            return Ok(song);

        }
        // Get Song Votes 
        [HttpGet("{id}/Votes")]
        public ActionResult<List<Models.Vote>> GetSongVotes(int id)
        {
            return Ok(_data.GetSongVotes(id));
        }

        // Get Song Points 
        [HttpGet("{id}/Points")]
        public ActionResult<List<int>> GetSongPoints(int id)
        {
            return Ok(_data.GetSongPoints(id));
        }
    }
}