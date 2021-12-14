using System;

namespace ArtistsRanking.Models;

/// <summary>
/// Event args for the VoteAddedEvent
/// </summary>
public class VoteAddedEventArgs: EventArgs
{
    public Artist Artist { get; set; }
    public decimal Average { get; set; }
}