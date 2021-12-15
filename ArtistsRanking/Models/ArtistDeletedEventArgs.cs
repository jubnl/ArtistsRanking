using System;

namespace ArtistsRanking.Models
{
    /// <summary>
    /// Event args for ArtistDeletedEvent
    /// </summary>
    public class ArtistDeletedEventArgs : EventArgs
    {
        public int ArtistId { get; set; }
    }
}