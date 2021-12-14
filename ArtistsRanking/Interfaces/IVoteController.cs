using System.Collections.Generic;
using System.ComponentModel;
using ArtistsRanking.Models;

namespace ArtistsRanking.Interfaces
{
    public interface IVoteController
    {
        public void Save(int id, string firstname, string lastname, int rank, Artist artist);
        public IEnumerable<Vote> GetVotes();
        public IEnumerable<Vote> GetVotesByArtist(int id);
        public decimal GetAverageByArtist(int id);
    }
}