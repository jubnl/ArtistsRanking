using System;
using System.Windows.Forms;
using ArtistsRanking.Controllers;
using ArtistsRanking.Exceptions;
using ArtistsRanking.Models;

namespace ArtistsRanking.Views
{
    public partial class frmArtist : Form
    {
        private readonly ArtistController _ac = new();
        private readonly VoteController _vc = new();

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

            comboBoxArtistStyle.DataSource = Enum.GetValues(typeof(Style));

            comboBoxVoteArtist.DataSource = _ac.Artists;
            comboBoxVoteArtist.DisplayMember = "Name";
            comboBoxVoteArtist.ValueMember = "Id";
        }

        private void OnClickChangeIndex(object sender, EventArgs e)
        {
            Artist artist;
            try
            {
                artist = (Artist)dataGridViewArtist.CurrentRow.DataBoundItem;
            }
            catch (NullReferenceException)
            {
                return;
            }

            labelIdArtist.Text = artist.Id.ToString();
            textBoxArtistName.Text = artist.Name;
            comboBoxArtistStyle.SelectedItem = artist.Style;
        }

        private void OnClickAddArtist(object sender, EventArgs e)
        {
            var artistName = textBoxArtistName.Text;
            if (string.IsNullOrEmpty(artistName))
            {
                MessageBox.Show(@"Please specify the artist's name.");
                return;
            }

            textBoxArtistName.Text = "";
            labelIdArtist.Text = @"0";
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

        private void OnClickEditArtist(object sender, EventArgs e)
        {
            if (!int.TryParse(labelIdArtist.Text, out var id))
                return;

            if (id == 0)
            {
                MessageBox.Show(@"Please select an artist to edit.");
                return;
            }

            var artistName = textBoxArtistName.Text;
            if (string.IsNullOrEmpty(artistName))
            {
                MessageBox.Show(@"Please specify the artist's name.");
                return;
            }

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

        private void OnClickDeleteArtist(object sender, EventArgs e)
        {
            if (!int.TryParse(labelIdArtist.Text, out var id))
                return;

            if (id == 0)
            {
                MessageBox.Show(@"Please select an artist to delete.");
                return;
            }

            _ac.Delete(id);
            textBoxArtistName.Text = "";
        }

        private void OnClickAddVote(object sender, EventArgs e)
        {
            if (_ac.Artists.Count == 0)
            {
                MessageBox.Show(@"Please create at least an artist before voting.");
                return;
            }

            var fname = textBoxFname.Text;
            var lname = textBoxLname.Text;
            textBoxFname.Text = "";
            textBoxLname.Text = "";
            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname))
            {
                MessageBox.Show(@"Please specify your first name and your last name.");
                return;
            }

            try
            {
                _vc.Save(0, fname, lname, (int)numericUpDownRank.Value, (Artist)comboBoxVoteArtist.SelectedItem);
            }
            catch (VoteAlreadyExistsException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}