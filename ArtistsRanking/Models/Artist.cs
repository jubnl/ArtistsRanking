using System;
using ArtistsRanking.Interfaces;

namespace ArtistsRanking.Models
{
    public class Artist : IArtist
    {
        #region properties

        // used for the autoincrement
        private static readonly object Sync = new();
        private static int _globalCount;
        public int Id { get; set; }
        public string Name { get; set; }
        public Style Style { get; set; }

        // store average in Artist object
        public decimal? Average { get; set; }

        #endregion

        #region constructors

        /// <summary>
        /// Artist instance that is really used
        /// </summary>
        /// <param name="id">Artist's Id, if 0 passed, it will create a new Id</param>
        /// <param name="name">Artist's Name</param>
        /// <param name="style">Artist's style (Style enum)</param>
        /// <param name="average">Average Rank (null by default)</param>
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
            Average = average == null ? null : Math.Round((decimal)average, 2);
        }

        /// <summary>
        /// Only used in the unit tests
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="style"></param>
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

        #endregion
    }
}