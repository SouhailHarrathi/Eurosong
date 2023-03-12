using Eurosong.Models;
using LiteDB;

namespace Eurosong.Data
{
    public class DataList : DataContext
    {
        // Song 

        List<Song> list = new List<Song>();

        public void AddSong(Song song)
        {
            list.Add(song);
        }
        public Song GetSongById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> GetSongs()
        {
            return list;
        }

        public IEnumerable<Song> GetSongsByTitle(string word)
        {
            return list.Where(x => x.Title.Contains(word));
        }
        public void RemoveSong(int id)
        {
            throw new NotImplementedException();
        }
        public void UpdateSong(int id, Song Value)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Vote> GetSongVotes(int id)
        {
            throw new NotImplementedException();
        }
        public List<int> GetSongPoints(int id)
        {
            throw new NotImplementedException();
        }


        // Artist 
        public void AddArtist(Artist artist)
        {
            throw new NotImplementedException();
        }

        public Artist GetArtistById(int id)
        {
            throw new NotImplementedException();
        }
        public void UpdateArtist(int id, Artist Value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Artist> GetArtistByTitle(string word)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Artist> GetArtists()
        {
            throw new NotImplementedException();
        }
        public void RemoveArtist(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> GetArtistSongs(int id)
        {
            throw new NotImplementedException();
        }


        // Vote 

        public void AddVote(Vote vote)
        {
            throw new NotImplementedException();
        }

         public IEnumerable<Vote> GetVotes()
        {
            throw new NotImplementedException();
        }

        public Vote GetVoteById(int id)
        {
            throw new NotImplementedException();
        }


        public void RemoveVote(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateVote(int id, Vote Value)
        {
            throw new NotImplementedException();
        }

        
    }
}