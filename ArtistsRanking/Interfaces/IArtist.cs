using ArtistsRanking.Models;

namespace ArtistsRanking.Interfaces
{
    public interface IArtist
    {
        int Id { get; set; }
        string Name { get; }
        Style Style { get; }
        decimal? Average { get; set; }
    }
}