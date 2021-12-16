using System;
using System.Windows.Forms;
using ArtistsRanking.Controllers;
using ArtistsRanking.Exceptions;
using ArtistsRanking.Models;

namespace ArtistsRanking.Views
{
    public partial class frmArtist : Form
    {
        #region private properties

        private readonly ArtistController _ac = new();
        private readonly VoteController _vc = new();

        #endregion

        #region constructor

        /// <summary>
        /// Initialize the main form
        /// </summary>
        public frmArtist()
        {
            InitializeComponent();

            // define votes columns
            dataGridViewVote.AutoGenerateColumns = false;
            dataGridViewVote.Columns.Add("Firstname", "First name");
            dataGridViewVote.Columns.Add("Lastname", "Last name");
            dataGridViewVote.Columns.Add("Artist", "Artist");
            dataGridViewVote.Columns.Add("Rank", "Rank");
            dataGridViewVote.Columns["Firstname"]!.DataPropertyName = "Firstname";
            dataGridViewVote.Columns["Lastname"]!.DataPropertyName = "Lastname";
            dataGridViewVote.Columns["Rank"]!.DataPropertyName = "Rank";
            dataGridViewVote.Columns["Artist"]!.DataPropertyName = "ArtistName";

            // define artists columns
            dataGridViewArtist.AutoGenerateColumns = false;
            dataGridViewArtist.Columns.Add("Name", "Name");
            dataGridViewArtist.Columns.Add("Style", "Style");
            dataGridViewArtist.Columns.Add("Average", "Average");
            dataGridViewArtist.Columns["Name"]!.DataPropertyName = "Name";
            dataGridViewArtist.Columns["Style"]!.DataPropertyName = "Style";
            dataGridViewArtist.Columns["Average"]!.DataPropertyName = "Average";

            // doesn't freaking work...
            dataGridViewArtist.Columns["Average"].HeaderCell.SortGlyphDirection = SortOrder.Descending;
            // dataGridViewArtist.Sort(dataGridViewArtist.Columns["Average"], ListSortDirection.Descending);

            // define data source
            dataGridViewVote.DataSource = _vc.Votes;
            dataGridViewArtist.DataSource = _ac.Artists;

            // define Artist style combobox data source
            comboBoxArtistStyle.DataSource = Enum.GetValues(typeof(Style));

            // define VoteArtist combobox data source and set the display member
            comboBoxVoteArtist.DataSource = _ac.Artists;
            comboBoxVoteArtist.DisplayMember = "Name";
            comboBoxVoteArtist.ValueMember = "Id";
        }

        #endregion

        #region actions on the main form

        /// <summary>
        /// Change the selected index on click on the dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickChangeIndex(object sender, EventArgs e)
        {
            var artist = (Artist)dataGridViewArtist.CurrentRow?.DataBoundItem;

            // fill fields from the selected artist
            labelIdArtist.Text = artist?.Id.ToString();
            textBoxArtistName.Text = artist?.Name;
            comboBoxArtistStyle.SelectedItem = artist?.Style;
        }

        /// <summary>
        /// Button add artist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickAddArtist(object sender, EventArgs e)
        {
            // check if artist's name text box is empty
            var artistName = textBoxArtistName.Text;
            if (string.IsNullOrEmpty(artistName))
            {
                MessageBox.Show(@"Please specify the artist's name.");
                return;
            }

            // empty text box and set the selected artist id to 0
            textBoxArtistName.Text = "";
            labelIdArtist.Text = @"0";

            // save the artist
            Enum.TryParse(comboBoxArtistStyle.SelectedItem.ToString(), out Style style);
            try
            {
                _ac.Save(0, artistName, style);
            }
            catch (ArtistAlreadyExistsException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Edit the selected artist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickEditArtist(object sender, EventArgs e)
        {
            // in case something went wrong but it can't be the case
            if (!int.TryParse(labelIdArtist.Text, out var id))
                return;

            // ask to select an artist if no artist is selected
            if (id == 0)
            {
                MessageBox.Show(@"Please select an artist to edit.");
                return;
            }

            // check if the artist's name is empty
            var artistName = textBoxArtistName.Text;
            if (string.IsNullOrEmpty(artistName))
            {
                MessageBox.Show(@"Please specify the artist's name.");
                return;
            }

            // save the edited artist
            Enum.TryParse(comboBoxArtistStyle.SelectedItem.ToString(), out Style style);
            try
            {
                _ac.Save(id, artistName, style);
            }
            catch (ArtistAlreadyExistsException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Delete the selected artist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickDeleteArtist(object sender, EventArgs e)
        {
            // in case something went wrong but it can't be the case
            if (!int.TryParse(labelIdArtist.Text, out var id))
                return;

            // ask to select an artist if no artist is selected
            if (id == 0)
            {
                MessageBox.Show(@"Please select an artist to delete.");
                return;
            }

            _ac.Delete(id);
            textBoxArtistName.Text = "";
        }

        /// <summary>
        /// Add a vote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickAddVote(object sender, EventArgs e)
        {
            // if there isn't any artist, ask to create one
            if (_ac.Artists.Count == 0)
            {
                MessageBox.Show(@"Please create at least an artist before voting.");
                return;
            }

            // extract fname and lname, empty the fields
            var fname = textBoxFname.Text;
            var lname = textBoxLname.Text;
            textBoxFname.Text = "";
            textBoxLname.Text = "";

            // check if the fname or the lname is empty
            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname))
            {
                MessageBox.Show(@"Please specify your first name and your last name.");
                return;
            }

            // save the vote
            try
            {
                _vc.Save(0, fname, lname, (int)numericUpDownRank.Value, (Artist)comboBoxVoteArtist.SelectedItem);
            }
            catch (VoteAlreadyExistsException ex)
            {
                MessageBox.Show(ex.Message);
            }

            // reset numericUpDownRank value
            numericUpDownRank.Value = 4;
        }

        #endregion
    }
}