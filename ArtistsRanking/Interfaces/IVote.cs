using ArtistsRanking.Models;

namespace ArtistsRanking.Interfaces
{
    public interface IVote
    {
        int Id { get; set; }
        string Firstname { get; }
        string Lastname { get; }
        int Rank { get; set; }
        Artist Artist { get; }
    }
}