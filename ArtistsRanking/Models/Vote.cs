using ArtistsRanking.Interfaces;

namespace ArtistsRanking.Models
{
    public class Vote : IVote
    {
        private static readonly object Sync = new();
        private static int _globalCount;
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Rank { get; set; }
        public Artist Artist { get; set; }
        public string ArtistName { get; set; }

        public Vote(int id, string firstname, string lastname, int rank, Artist artist)
        {
            // autoincrement
            if (id == 0)
            {
                lock (Sync)
                {
                    Id = ++_globalCount;
                }
            }
            else
            {
                Id = id;
            }

            Firstname = firstname;
            Lastname = lastname;
            Rank = rank;
            Artist = artist;
            ArtistName = artist != null? artist.Name: "";
            
        }
    }
}