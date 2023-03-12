namespace Eurosong.Models
{
    public class Vote
    {
        public int id { get; private set; }
        public int SongID { get; set; }
        public string ip { get; set; }
        public int points { get; set; }

    }
}
