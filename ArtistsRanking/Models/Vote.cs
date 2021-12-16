using ArtistsRanking.Interfaces;

namespace ArtistsRanking.Models
{
    public class Vote : IVote
    {
        #region properties

        // used for auto increment
        private static readonly object Sync = new();
        private static int _globalCount;
        public int Id { get; set; }
        public string Firstname { get; }
        public string Lastname { get; }
        public int Rank { get; set; }
        public Artist Artist { get; }

        // public needed because it is displayed in the view
        public string ArtistName { get; }

        #endregion

        #region constructor

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
            ArtistName = artist != null ? artist.Name : "";
        }

        #endregion
    }
}