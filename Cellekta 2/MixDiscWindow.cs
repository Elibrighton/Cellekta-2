using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraktorLibrary;

namespace Cellekta_2
{
    public partial class MixDiscWindow : Form
    {
        public MixDiscWindow()
        {
            InitializeComponent();

            // set defaults
            intensityStypeComboBox.SelectedIndex = 0;
            totalPlaytimeComboBox.SelectedIndex = 0;
            mixLengthComboBox.SelectedIndex = 0;
            bpmRangeComboBox.SelectedIndex = 0;
        }

        public List<string> PlaylistList { get; set; }
        public ILibrary Library { get; set; }
        public List<ISong> Matched { get; set; }

        public void PopulatePlaylistList()
        {
            playlistComboBox.Items.Clear();
            playlistComboBox.Items.Add("");

            foreach (string playlist in PlaylistList)
                playlistComboBox.Items.Add(playlist);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //var isMixingByBpm = bpmCheckBox.Checked;
            //var isMixingByKey = keyCheckBox.Checked;
            //var isMixingByIntensity = intensityCheckBox.Checked;
            //var totalPlaytime = Convert.ToInt32(totalPlaytimeComboBox.Text.Replace(" minutes", "")) * 60;
            //var mixLength = Convert.ToInt32(mixLengthComboBox.Text.Replace(" seconds", ""));

            searchButton.Enabled = false;
            var matchingSongCombinations = GetMatchingSongCombinations();
            var matchedMixDisc = new List<ISong>();

            if (matchingSongCombinations.Count > 0)
            {
                var intensityStyle = intensityStypeComboBox.Text;

                if (intensityStyle == "Highest")
                {
                    // need to implement
                }
                else if (intensityStyle == "Lowest")
                {
                    // need to implement
                }
                else
                {
                    var randomMatch = TraktorLibrary.Library.GetRandomRow(matchingSongCombinations.Count);
                    Matched = matchingSongCombinations[randomMatch - 1]; // do i need to -1?
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                searchButton.Enabled = true;
                MessageBox.Show("There are no matching song combinations to make a MixDisc.");
            }
        }

        private List<List<ISong>> GetMatchingSongCombinations()
        {
            var matchingSongCombinations = new List<List<ISong>>();
            var playlist = playlistComboBox.Text;
            var playlistMusic = Library.Music.Where(x => x.Playlist == playlist);

            foreach (var song in playlistMusic)
            {
                foreach (var song1 in playlistMusic)
                {
                    if (!AreSongsSame(song, song1))
                    {
                        if (IsSongMixable(song, song1))
                        {
                            matchingSongCombinations.Add(new List<ISong>
                                    {
                                        song,
                                        song1
                                    });
                        }
                    }
                }
            }

            long i = 1;
            var isMatchFound = true;
            var totalPlaytime = Convert.ToInt32(totalPlaytimeComboBox.Text.Replace(" minutes", "")) * 60;
            var songCombinationsMatchingLength = new List<List<ISong>>();

            while (isMatchFound || i < matchingSongCombinations.Count)
            {
                isMatchFound = false;

                foreach (var songCombo in matchingSongCombinations)
                {
                    var currentPlaytime = GetCurrentPlaytime(songCombo);

                    if (currentPlaytime > totalPlaytime)
                    {
                        if (!IsSongComboAlreadyAdded(songCombinationsMatchingLength, songCombo))
                        {
                            songCombinationsMatchingLength.Add(songCombo);
                        }
                    }
                    else
                    {
                        if (i < songCombo.Count)
                        {
                            var song = songCombo[Convert.ToInt32(i)];

                            foreach (var song1 in playlistMusic)
                            {
                                if (!AreSongsSame(song, song1))
                                {
                                    if (!IsSongAlreadyAdded(songCombo, song1))
                                    {
                                        if (IsSongMixable(song, song1))
                                        {
                                            songCombo.Add(song1);
                                            isMatchFound = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                i++;
            }

            return songCombinationsMatchingLength;
        }

        private int GetCurrentPlaytime(List<ISong> songCombo)
        {
            var mixLength = Convert.ToInt32(mixLengthComboBox.Text.Replace(" seconds", ""));

            var currentPlaytime = 0;
            var tempSongCombo = new List<ISong>();

            foreach (var song in songCombo)
            {
                tempSongCombo.Add(song);
                currentPlaytime += song.PlayTime - mixLength;
            }

            return currentPlaytime + mixLength;
        }

        private bool IsSongComboAlreadyAdded(List<List<ISong>> songCombinationsMatchingLength, List<ISong> tempSongCombo)
        {
            var isSongComboAlreadyAdded = false;

            foreach (var songCombo in songCombinationsMatchingLength)
            {
                if (AreSongCombosSame(songCombo, tempSongCombo))
                {
                    isSongComboAlreadyAdded = true;
                    break;
                }
            }

            return isSongComboAlreadyAdded;
        }

        private bool AreSongCombosSame(List<ISong> songCombo, List<ISong> tempSongCombo)
        {
            var areSongCombosSame = true;

            for (int i = 0; i < tempSongCombo.Count; i++)
            {
                if (i < songCombo.Count)
                {
                    var song = songCombo[i];
                    var song1 = tempSongCombo[i];

                    if (!AreSongsSame(song, song1))
                    {
                        areSongCombosSame = false;
                        break;
                    }
                }
            }

            return areSongCombosSame;
        }

        private bool IsSongAlreadyAdded(List<ISong> songCombo, ISong song1)
        {
            var isSongAlreadyAdded = false;

            foreach (var song in songCombo)
            {
                if (AreSongsSame(song, song1))
                {
                    isSongAlreadyAdded = true;
                    break;
                }
            }

            return isSongAlreadyAdded;
        }

        private bool IsSongMixable(ISong song, ISong song1)
        {
            var isSongBpmInRange = true;
            var isSongKeyInRange = true;
            var isSongIntensityInRange = true;

            if (bpmCheckBox.Checked)
            {
                var songBpm = GetSongBpm(song);
                var song1Bpm = GetSongBpm(song1);
                isSongBpmInRange = IsSongBpmInRange(songBpm, song1Bpm);
            }

            if (keyCheckBox.Checked)
            {
                var songKey = GetSongKey(song);
                var song1Key = GetSongKey(song1);
                isSongKeyInRange = IsSongKeyInRange(songKey, song1Key);
            }

            if (intensityCheckBox.Checked)
            {
                isSongIntensityInRange = IsSongIntensityInRange(song.Intensity, song1.Intensity);
            }

            return isSongBpmInRange && isSongKeyInRange && isSongIntensityInRange;
        }

        private bool IsSongIntensityInRange(int songIntensity, int song1Intensity)
        {
            return (song1Intensity == songIntensity) ||
                (song1Intensity - 1 == songIntensity) ||
                (song1Intensity + 1 == songIntensity);
        }

        private bool IsSongKeyInRange(string songKey, string song1Key)
        {
            var songKeyRange = Song.GetKeyRange(songKey);

            return songKeyRange.Contains(song1Key);
        }

        private string GetSongKey(ISong song)
        {
            return string.IsNullOrEmpty(song.TrailingKey) ? song.LeadingKey : song.TrailingKey;
        }

        private bool IsSongBpmInRange(int songBpm, int song1Bpm)
        {
            var songBpmRange = Song.GetBpmRange(songBpm, Convert.ToInt32(bpmRangeComboBox.Text));

            return songBpmRange.Contains(song1Bpm);
        }

        private int GetSongBpm(ISong song)
        {
            return song.TrailingBpm == 0 ? song.LeadingBpm : song.TrailingBpm;
        }

        private bool AreSongsSame(ISong song, ISong song1)
        {
            return song.FullName == song1.FullName;
        }
    }
}
