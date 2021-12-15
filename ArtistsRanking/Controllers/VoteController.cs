using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ArtistsRanking.Exceptions;
using ArtistsRanking.Interfaces;
using ArtistsRanking.Models;

namespace ArtistsRanking.Controllers
{
    public sealed class VoteController : IVoteController
    {
        #region public properties

        /// <summary>
        /// Binding list that contains all votes
        /// </summary>
        public BindingList<Vote> Votes { get; set; } = new();

        #endregion

        #region event declaration

        /// <summary>
        /// Event invoked when a vote is added
        /// </summary>
        public static event EventHandler<VoteAddedEventArgs> VoteAdded;

        #endregion

        #region Constructor

        /// <summary>
        /// subscribe to the ArtistDeleted event
        /// </summary>
        public VoteController()
        {
            // subscribe to the artist deleted event
            ArtistController.ArtistDeleted += OnArtistDeleted;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Save a new vote in the binding list
        /// </summary>
        /// <param name="id">0 to autoincrement</param>
        /// <param name="firstname">voter's first name</param>
        /// <param name="lastname">voter's last name</param>
        /// <param name="rank">artist's rank defined by the voter</param>
        /// <param name="artist">artist instance</param>
        /// <exception cref="VoteAlreadyExistsException">throw an exception if the vote already exists</exception>
        public void Save(int id, string firstname, string lastname, int rank, Artist artist)
        {
            Vote vote = new(id, firstname, lastname, rank, artist);

            if (VoteExists(vote))
                throw new VoteAlreadyExistsException(
                    $"The vote made by {vote.Firstname} {vote.Lastname} for {vote.Artist.Name} already exists.");

            try
            {
                // throw an invalid operation exception if .First does not find an artists
                Votes[Votes.IndexOf(Votes.First(v => v.Id == vote.Id))] = vote;
            }
            catch (InvalidOperationException)
            {
                Votes.Add(vote);
            }

            // invoke the VoteAdded event
            OnVoteAdded(new VoteAddedEventArgs { Artist = artist, Average = GetAverageByArtist(artist.Id) });
        }

        /// <summary>
        /// Get all votes
        /// </summary>
        /// <returns>a binding list of votes</returns>
        public IEnumerable<Vote> GetVotes() => Votes;

        /// <summary>
        /// Get all votes for a specific artist
        /// </summary>
        /// <param name="id">artist's id</param>
        /// <returns>an IEnumerable that contains all votes for the specified artist</returns>
        public IEnumerable<Vote> GetVotesByArtist(int id) => Votes.Where(v => v.Id == id);

        /// <summary>
        /// Get average rank for a specific artist
        /// </summary>
        /// <param name="id">artist's id</param>
        /// <returns></returns>
        public decimal GetAverageByArtist(int id)
        {
            var votes = Votes.Where(v => v.Artist.Id == id).ToList();
            if (!votes.Any())
                return 0;

            return votes.Aggregate<Vote, decimal>(0, (current, vote) => current + vote.Rank) / votes.Count;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Check if a vote exists
        /// </summary>
        /// <param name="vote">the vote to check</param>
        /// <returns>true if the vote exists else false</returns>
        private bool VoteExists(IVote vote) => Votes.Any(v =>
            v.Firstname == vote.Firstname && v.Lastname == vote.Lastname && v.Artist.Name == vote.Artist.Name);

        /// <summary>
        /// Delete all vote related to the deleted artist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">ArtistDeletedEventArgs</param>
        private void OnArtistDeleted(object sender, ArtistDeletedEventArgs e)
        {
            // extract all the votes that needs to be removed
            IReadOnlyList<Vote> votes = Votes.Where(v => v.Artist.Id == e.ArtistId).ToList();
            foreach (var vote in votes)
            {
                Votes.Remove(vote);
            }
        }

        #endregion

        #region invoke event

        /// <summary>
        /// Invoke the VoteAdded event
        /// </summary>
        /// <param name="e">VoteAddedEventArgs</param>
        private void OnVoteAdded(VoteAddedEventArgs e) => VoteAdded?.Invoke(this, e);

        #endregion
    }
}