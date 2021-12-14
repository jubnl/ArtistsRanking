using System;

namespace ArtistsRanking.Models;

public class VoteAddedEventArgs: EventArgs
{
    public Artist Artist { get; set; }
    public decimal Average { get; set; }
}