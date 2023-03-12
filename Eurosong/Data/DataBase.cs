using Eurosong.Models;
using LiteDB;

namespace Eurosong.Data
{
    public class DataBase : DataContext
    {

        // DB Service 
        // creating our Litedb ( noSql) 
        LiteDatabase db = new LiteDatabase("data.db");



        // SONG

        // adding table Sogns to our DB 
        const string songs = "Songs";

        // add a song to the db
        public void AddSong(Song song)
        {
            db.GetCollection<Song>(songs).Insert(song);
        }

        // Remove song  from db 
        public void RemoveSong(int id)
        {
            Song s = GetSongById(id);
            if (s == null)
            {
                throw new ArgumentException("Song with the specified ID does not exist.");
            }
            else
            {
                db.GetCollection(songs).Delete(id);

            }
        }

        // Update song  
        public void UpdateSong(int id, Song value)
        {
            Song s = GetSongById(id);
            if (s != null && value != null)
            {
                s.Artist = value.Artist;
                s.Title = value.Title;
                s.Spootify = value.Spootify;
                db.GetCollection<Song>(songs).Update(s);
            }
            else
            {
                throw new ArgumentException("Song with the specified ID does not exist.");
            }

        }



        // Method for getting all the songs for an artist

        // making a new tables to store the result in it every time we get a request 
        const string artistsongs = "artistsongs";

        public IEnumerable<Song> GetArtistSongs(int id)
        {
            // Deleting the previous data in the table 
            db.GetCollection<Song>(artistsongs).DeleteAll();

            var songslist = GetSongs();
            // loop over songs and check if one if them belong to our artist so we add it to our result table
            foreach (Song s in songslist)
            {
                if (s.Artist == id) 
                {   
                    db.GetCollection<Song>(artistsongs).Insert(s);
                }
            }

            return db.GetCollection<Song>(artistsongs).FindAll();
        }

        // Method for geting all the songs in the db 
        public IEnumerable<Song> GetSongs()
        {
            return db.GetCollection<Song>(songs).FindAll();
        }
        // Method for geting  song by title 

        public IEnumerable<Song> GetSongsByTitle(string word)
        {
            return db.GetCollection<Song>(songs).FindAll().Where(s => s.Title.Contains(word));
        }
        // Method for geting  song by id 

        public Song GetSongById(int id)
        {
            return db.GetCollection<Song>(songs).FindById(id);
        }

        // ARTIST 
        // adding table artists to our DB 
        const string artists = "Artists";

        // adding an artist to the db 
        public void AddArtist(Eurosong.Models.Artist artist)
        {
            db.GetCollection<Eurosong.Models.Artist>(artists).Insert(artist);
        }

        // Remove artist  from db 
        public void RemoveArtist(int id)
        {
            Artist a = GetArtistById(id);
            if (a == null)
            {
                throw new ArgumentException("Artist with the specified ID does not exist.");
            }
            else
            {
                db.GetCollection(artists).Delete(id);

            }
        }
        // Update Artist  
        public void UpdateArtist(int id, Artist value)
        {
            Artist a = GetArtistById(id);
            if (a != null && value != null)
            {
                a.Name = value.Name;
                db.GetCollection<Artist>(artists).Update(a);
            }
            else
            {
                throw new ArgumentException("Song with the specified ID does not exist.");
            }

        }
        // Method for geting all the artists in the db 
        public IEnumerable<Eurosong.Models.Artist> GetArtists()
        {
            return db.GetCollection<Eurosong.Models.Artist>(artists).FindAll();
        }
        // Method for geting  artist by title 
        public IEnumerable<Artist> GetArtistByTitle(string word)
        {
            return db.GetCollection<Eurosong.Models.Artist>(artists).FindAll().Where(s => s.Name.Contains(word));
        }

        // Method for geting  artist by id 

        public Eurosong.Models.Artist GetArtistById(int id)
        {
            return db.GetCollection<Eurosong.Models.Artist>(artists).FindById(id);
        }


        // adding table Votes to our DB 
        const string votes = "Votes";

        // adding vote to the db 
        public void AddVote(Eurosong.Models.Vote vote)
        {
            db.GetCollection<Eurosong.Models.Vote>(votes).Insert(vote);
        }

        // Remove Vote  from db 
        public void RemoveVote(int id)
        {
            Vote v = GetVoteById(id);
            if (v == null)
            {
                throw new ArgumentException("Vote with the specified ID does not exist.");
            }
            else
            {
                db.GetCollection(votes).Delete(id);

            }
        }
        // Update Vote  
        public void UpdateVote(int id, Vote value)
        {
            Vote v = GetVoteById(id);
            if (v != null && value != null)
            {
                v.SongID = value.SongID;
                v.ip = value.ip;
                v.points = value.points;

                db.GetCollection<Vote>(artists).Update(v);
            }
            else
            {
                throw new ArgumentException("Song with the specified ID does not exist.");
            }

        }
        // Method for geting all the Votes in the db 
        public IEnumerable<Eurosong.Models.Vote> GetVotes()
        {
            return db.GetCollection<Eurosong.Models.Vote>(votes).FindAll();
        }

        // Method for geting  Vote by id 

        public Eurosong.Models.Vote GetVoteById(int id)
        {
            return db.GetCollection<Eurosong.Models.Vote>(votes).FindById(id);
        }



        // Method for getting all the Votes for a song

        // making a new tables to store the result in it every time we get a request 
        const string songvotes = "songvotes";

        public IEnumerable<Vote> GetSongVotes(int id)
        {
            // Deleting the previous data in the table 
            db.GetCollection<Song>(songvotes).DeleteAll();

            var voteslist = GetVotes();
            // loop over songs and check if one if them belong to our artist so we add it to our result table
            foreach (Vote V in voteslist)
            {
                if (V.SongID == id)
                {
                    db.GetCollection<Vote>(songvotes).Insert(V);
                }
                else
                {
                    throw new ArgumentException("Song with the specified ID does not have any votes .");
                }
            }

            return db.GetCollection<Vote>(songvotes).FindAll();
        }

        // Method for getting all the Votes for a song


        public List<int> GetSongPoints(int id)
        {

            // making a list to store our points in 
            var points = new List<int>();

            var voteslist = GetVotes();
            // loop over songs and check if one if them belong to our artist so we add it to our result table
            foreach (Vote V in voteslist)
            {
                if (V.SongID == id)
                {
                    points.Add(V.points);
                }
                else
                {
                    throw new ArgumentException("Song with the specified ID does not have any votes .");
                }
            }

        return points;
            
        }


    }
}