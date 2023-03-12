using Eurosong.Data;
using Eurosong.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eurosong.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ArtistController : ControllerBase
    {
        private DataContext _data;

        public ArtistController(DataContext data)
        {
            this._data = data;
        }

        // adding new artists to the DB
        [HttpPost]
        public ActionResult Post(Models.Artist artist)
        {
            _data.AddArtist(artist);
            return Ok("Aritst posted!");
        }

        // Deleting artist from the DB
        [HttpDelete]
        public ActionResult DELETE(int id)
        {
            _data.RemoveArtist(id);
            return Ok("Artist Removed!");
        }

        // Updating Artist using id and saving it on the DB
        [HttpPut("update/{id}")]
        public ActionResult Put(int id, Artist Value)
        {
            _data.UpdateArtist(id, Value);
            return Ok("Artist Updated!");
        }

        // get all artists in the db 
        [HttpGet("list")]
        public ActionResult<List<Models.Artist>> Get()
        {
            return Ok(_data.GetArtists());
        }



        // search GET artist by name
        [HttpGet("Search")]
        public ActionResult<List<Models.Artist>> GetByTitle(string word)
        {
            return Ok(_data.GetArtistByTitle(word));
        }

        // search GET artist by ID
        [HttpGet("{id}")]
        public ActionResult<Models.Artist> Get(int id)
        {
            Models.Artist artist = _data.GetArtistById(id);
            if (artist == null) return NotFound("Wrong id? Id not found in database");
            return Ok(artist);

        }

        // Get artist songs 
        [HttpGet("{id}/Songs")]
        public ActionResult<List<Models.Song>> GetArtistSongs(int id)
        {
            return Ok(_data.GetArtistSongs(id));
        }

    }
}
