using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ArtistsRanking.Interfaces;
using ArtistsRanking.Models;
using ArtistsRanking.Exceptions;

namespace ArtistsRanking.Controllers
{
    public class ArtistController : IArtistController
    {
        #region public properties

        /// <summary>
        /// Binding list that contains every artists
        /// </summary>
        public readonly BindingList<Artist> Artists = new(Backing);

        #endregion

        #region private properties

        /// <summary>
        /// An attempt to sort the binding list, see private void SortBindingList()
        /// </summary>
        private static readonly List<Artist> Backing = new();

        #endregion

        #region event declaration

        public static event EventHandler<ArtistDeletedEventArgs> ArtistDeleted;

        #endregion

        #region constructor

        /// <summary>
        /// subscribe to the VoteAdded event
        /// </summary>
        public ArtistController()
        {
            VoteController.VoteAdded += VoteAdded;
        }

        #endregion

        #region public methods
        
        /// <summary>
        /// Used to make the unit test pass
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="style"></param>
        public void Save(int id, string name, Style style)
        {
            PSave(id, name, style);
        }

        /// <summary>
        /// Save / update an artist
        /// </summary>
        /// <param name="id">0 for new Id</param>
        /// <param name="name">artist's name</param>
        /// <param name="style">artist's style</param>
        /// <param name="average">average rank</param>
        /// <param name="averageUpdate">true if you perform an update, default to false</param>
        /// <exception cref="ArtistAlreadyExistsException">Thrown if the artists already exists</exception>
        public void PSave(int id, string name, Style style, decimal? average = null, bool averageUpdate = false)
        {
            Artist artist = new(id, name, style, average);

            if (!averageUpdate)
            {
                if (ArtistExists(artist))
                    throw new ArtistAlreadyExistsException($"Artist \"{artist.Name}\" already exists.");
            }

            try
            {
                // throw an invalid operation exception if .First does not find an artists
                Artists[Artists.IndexOf(Artists.First(a => a.Id == artist.Id))] = artist;
            }
            catch (InvalidOperationException)
            {
                Artists.Add(artist);
            }
            
            // doesn't work..
            // SortBindingList();
        }

        /// <summary>
        /// Delete an artist if its Id is in the binding list
        /// </summary>
        /// <param name="id">artist's Id</param>
        public void Delete(int id)
        {
            if (Artists.All(a => a.Id != id)) return;
            {
                Artists.RemoveAt(Artists.IndexOf(Artists.First(a => a.Id == id)));
                OnDeletedArtist(new ArtistDeletedEventArgs { ArtistId = id });
            }
        }

        /// <summary>
        /// Get every artists
        /// </summary>
        /// <returns>the binding list that contains all artists</returns>
        public IEnumerable<Artist> GetArtists() => Artists;

        /// <summary>
        /// Return an artist object if found, else null
        /// </summary>
        /// <param name="id">artist's Id</param>
        /// <returns>an artist object if found, else null</returns>
        public Artist GetSelectedArtist(int id)
        {
            try
            {
                // .First raise an InvalidOperationException if the artist isn't found
                return Artists.First(a => a.Id == id);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        #endregion

        #region private methods

        /// <summary>
        /// Check if an artist already exists in the binding list
        /// </summary>
        /// <param name="artist">an artist object</param>
        /// <returns>true if artist exists else false</returns>
        private bool ArtistExists(IArtist artist)
        {
            return Artists.Any(a => a.Name == artist.Name && a.Style == artist.Style);
        }

        /// <summary>
        /// Sort the binding list
        /// </summary>
        private void SortBindingList()
        {
            // don't freaking work...
            // var tmp = Artists.ToList();
            // Artists = new BindingList<Artist>(tmp.OrderByDescending(a => a.Average).ToList());

            // Backing = Backing.OrderByDescending(a => a.Average).ToList();
            // Artists.ResetBindings();
        }

        /// <summary>
        /// If a vote is added, update the concerned artist with the new average
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">VoteAddedEventArgs</param>
        private void VoteAdded(object sender, VoteAddedEventArgs e)
        {
            PSave(e.Artist.Id, e.Artist.Name, e.Artist.Style, e.Average, true);
        }

        #endregion

        #region invoke event

        /// <summary>
        /// Invoke the ArtistDeleted event
        /// </summary>
        /// <param name="e">ArtistDeletedEventArgs</param>
        private void OnDeletedArtist(ArtistDeletedEventArgs e) => ArtistDeleted?.Invoke(this, e);

        #endregion
    }
}