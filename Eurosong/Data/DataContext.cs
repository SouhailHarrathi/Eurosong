using Eurosong.Models;
using LiteDB;

namespace Eurosong.Data
{
    public interface DataContext
    {
        // Song Interface
        void AddSong(Song song);
        void RemoveSong(int id);
        void UpdateSong(int id ,Song Value) ;
        IEnumerable<Song> GetSongs();
        IEnumerable<Song> GetSongsByTitle(string word);
        Song GetSongById(int id);
        public IEnumerable<Vote> GetSongVotes(int id);
        public List<int> GetSongPoints(int id);

        // Artist interface
        void AddArtist(Artist artist);
        void RemoveArtist(int id);
        void UpdateArtist (int id ,Artist Value) ;  
        IEnumerable<Artist> GetArtists();
        IEnumerable<Artist> GetArtistByTitle(string word);
        Artist GetArtistById(int id);
        public IEnumerable<Song> GetArtistSongs(int id);


        // Vote interface
        void AddVote(Vote vote);
        void RemoveVote(int id);
        void UpdateVote(int id, Vote Value);
        IEnumerable<Vote> GetVotes();
        Vote GetVoteById(int id);
    }
}