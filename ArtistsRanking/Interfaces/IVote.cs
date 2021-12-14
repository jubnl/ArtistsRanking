using ArtistsRanking.Models;

namespace ArtistsRanking.Interfaces
{
    public interface IVote
    {
        int Id { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
        int Rank { get; set; }
        Artist Artist { get; set; }
    }
}