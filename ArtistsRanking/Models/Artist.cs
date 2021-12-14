using ArtistsRanking.Interfaces;

namespace ArtistsRanking.Models
{
    public class Artist : IArtist
    {
        private static readonly object Sync = new();
        private static int _globalCount;
        public int Id { get; set; }
        public string Name { get; set; }
        public Style Style { get; set; }
        public decimal? Average { get; set; }

        public Artist(int id, string name, Style style, decimal? average = null)
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

            Name = name;
            Style = style;
            Average = average;
        }

        public Artist(int id, string name, Style style)
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

            Name = name;
            Style = style;
            Average = 0;
        }
    }
}