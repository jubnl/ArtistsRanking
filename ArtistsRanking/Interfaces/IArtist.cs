using ArtistsRanking.Models;

namespace ArtistsRanking.Interfaces
{
    public interface IArtist
    {
        int Id { get; set; }
        string Name { get; set; }
        Style Style { get; set; }
        decimal? Average { get; set; }
    }
}