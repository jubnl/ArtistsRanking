using System;

namespace ArtistsRanking.Models;

public class ArtistDeletedEventArgs: EventArgs
{
    public int ArtistId { get; set; }
}