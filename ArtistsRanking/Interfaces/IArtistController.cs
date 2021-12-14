using System.Collections.Generic;
using ArtistsRanking.Models;

namespace ArtistsRanking.Interfaces
{
    public interface IArtistController
    {
        public void PSave(int id, string name, Style style, decimal? average, bool averageUpdate);
        public void Save(int id, string name, Style style);
        public void Delete(int id);
        public IEnumerable<Artist> GetArtists();
        public Artist GetSelectedArtist(int id);
    }
}