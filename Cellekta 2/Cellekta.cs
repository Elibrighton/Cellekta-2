using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TraktorLibrary;

namespace Cellekta_2
{
    public partial class Cellekta : Form
    {
        const int COLUMN_RATING = 0;
        const int COLUMN_ARTIST = 1;
        const int COLUMN_TITLE = 2;
        const int COLUMN_BPM = 3;
        const int COLUMN_KEY = 4;
        const int COLUMN_INTENSITY = 5;
        const int COLUMN_PLAYLIST = 6;

        ILibrary library;
        bool isInserting;
        int listRowInsertIndex;
        int listRowReplaceIndex;
        bool isReplacing;
        bool isPopulating;
        bool isRangeSelection;
        bool isRatedSelection;
        string custom1Playlist;
        static Dictionary<string, int> keyDictionary = new Dictionary<string, int> { };
        static Dictionary<int, int> bpmDictionary = new Dictionary<int, int> { };
        int bpmRangeSelector = 3;

        public Cellekta()
        {
            InitializeComponent();

            custom1MenuItem.Text = "Drum and bass";
            custom1Playlist = string.Concat(@"C:\Dj Music\", custom1MenuItem.Text);

            library = new Library(new List<ISong>());

            if (library.TraktorExists())
            {
                library.DeleteTemp();
                library.CreateTemp();

                if (library.TempExists())
                {
                    library.Import();
                    //CreateOrderArtistsTxt();
                    //CreatePreviouslyPlayedTxt();
                    PopulateSongs();
                    isRangeSelection = true;
                    rangeCheckBox.Checked = true;
                    bpmDictionary = library.GetBpmDictionary();
                    PopulateBpmList();
                    keyDictionary = library.GetKeyDictionary();
                    PopulateKeyList();
                    PopulatePlaylistList();

                    musicTabControl.SelectedTab = songsTabPage;
                }
                else
                {
                    MessageBox.Show("Unable to create library.");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Unable to open the Traktor library.");
                Close();
            }
        }

        private void PopulatePlaylistList()
        {
            playlistComboBox.Items.Clear();
            playlistComboBox.Items.Add("");

            var playlistsList = library.GetPlaylists();

            foreach (string playlist in playlistsList)
                playlistComboBox.Items.Add(playlist);
        }

        private void PopulateKeyList()
        {
            keyComboBox.Items.Clear();
            keyComboBox.Items.Add("");

            var keyList = library.GetKeys();

            foreach (string item in keyList)
            {
                keyComboBox.Items.Add(item);
            }

            keyComboBox.Sorted = true;
        }

        private void PopulateBpmList()
        {
            bpmComboBox.Items.Clear();
            bpmComboBox.Items.Add("");

            var bpmList = library.GetBpms();

            foreach (string item in bpmList)
            {
                bpmComboBox.Items.Add(item);
            }
        }

        public int GetSelectedBpm()
        {
            var bpm = 0;

            if (bpmComboBox.SelectedItem != null)
            {
                if (!String.IsNullOrEmpty(bpmComboBox.SelectedItem.ToString()))
                    bpm = Convert.ToInt32(bpmComboBox.SelectedItem);
            }

            return bpm;
        }

        public string GetSelectedKey()
        {
            var key = string.Empty;

            if (keyComboBox.SelectedItem != null)
            {
                key = keyComboBox.SelectedItem.ToString();
            }

            return key;
        }

        public string GetSelectedPlaylist()
        {
            var playlist = string.Empty;

            if (playlistComboBox.SelectedItem != null)
            {
                playlist = playlistComboBox.SelectedItem.ToString();
            }

            return playlist;
        }

        public List<int> GetBpmRange(int bpm)
        {
            var bpmRange = new List<int>();

            if (isRangeSelection)
            {
                bpmRange = Song.GetBpmRange(bpm, bpmRangeSelector);
            }

            return bpmRange;
        }

        public List<string> GetKeyRange(string key)
        {
            var keyRange = new List<string>();

            if (isRangeSelection)
            {
                if (!string.IsNullOrEmpty(key))
                {
                    keyRange = Song.GetKeyRange(key);
                }
            }

            return keyRange;
        }

        public string GetTrannyBpm(ISong song)
        {
            var trannyBpm = string.Empty;

            if (song.TrailingBpm > 0)
            {
                trannyBpm = string.Format("{0} - {1}", song.LeadingBpm, song.TrailingBpm);
            }
            else
            {
                trannyBpm = song.LeadingBpm.ToString();
            }

            return trannyBpm;
        }

        public bool IsAddingRow(int bpm, List<int> bpmRange, ISong song)
        {
            var isAddingRow = false;

            if (isRangeSelection)
                isAddingRow = (bpm == 0 || bpmRange.Contains(song.LeadingBpm));
            else
                isAddingRow = (bpm == 0 || song.LeadingBpm == bpm);

            if (isAddingRow)
            {
                if (!isRatedSelection)
                    isAddingRow = true;
                else if (isRatedSelection && song.Rating > 0)
                    isAddingRow = true;
                else
                    isAddingRow = false;
            }

            return isAddingRow;
        }

        public string[] CreateRowFromSong(ISong song)
        {
            return new string[]
            {
                    song.Rating.ToString(),
                    song.Artist,
                    song.Title,
                    GetTrannyBpm(song),
                    string.Concat(song.LeadingKey, !string.IsNullOrEmpty(song.TrailingKey) ? string.Concat("/", song.TrailingKey) : ""),
                    song.Intensity.ToString(),
                    song.Playlist
            };
        }

        public bool IsKeyCriteriaMet(string key, List<string> keyRange, string leadingKey)
        {
            var isKeyCriteriaMet = false;

            if (isRangeSelection)
            {
                if (string.IsNullOrEmpty(key) || keyRange.Contains(leadingKey))
                {
                    isKeyCriteriaMet = true;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(key) || leadingKey == key)
                {
                    isKeyCriteriaMet = true;
                }
            }

            return isKeyCriteriaMet;
        }

        public bool IsSearchCriteriaMet(string searchText, int bpm, string key, string playlist, List<int> bpmRange, List<string> keyRange, ISong song)
        {
            var isSearchCriteriaMet = false;

            if (IsAddingRow(bpm, bpmRange, song))
            {
                if ((string.IsNullOrEmpty(searchText) || song.Artist.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 || song.Title.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    && (string.IsNullOrEmpty(key) || keyRange.Contains(song.LeadingKey))
                    && (string.IsNullOrEmpty(playlist) || song.Playlist == playlist)
                    && (weddingMenuItem.Checked || (!weddingMenuItem.Checked && !song.FullName.Contains(@"C:\Dj Music\Wedding")))
                    && (electroHouseMenuItem.Checked || (!electroHouseMenuItem.Checked && !song.FullName.Contains(@"C:\Dj Music\Electro house")))
                    && (custom1MenuItem.Checked || (!custom1MenuItem.Checked && !song.FullName.Contains(custom1Playlist)))
                    && (everythingElseMenuItem.Checked | (!everythingElseMenuItem.Checked && (song.FullName.Contains(@"C:\Dj Music\Wedding") || song.FullName.Contains(@"C:\Dj Music\Electro house") || song.FullName.Contains(custom1Playlist)))))
                {
                    if (IsKeyCriteriaMet(key, keyRange, song.LeadingKey))
                    {
                        isSearchCriteriaMet = true;
                    }
                }
            }

            return isSearchCriteriaMet;
        }

        public void PopulateSongs()
        {
            ClearMusic();
            AddHeadings();

            var bpm = GetSelectedBpm();
            var key = GetSelectedKey();
            var playlist = GetSelectedPlaylist();
            var bpmRange = GetBpmRange(bpm);
            var keyRange = GetKeyRange(key);

            foreach (ISong song in library.Music)
            {
                if (IsSearchCriteriaMet(searchTextBox.Text, bpm, key, playlist, bpmRange, keyRange, song))
                {
                    var row = CreateRowFromSong(song);
                    songsGridView.Rows.Add(row);
                }
            }

            songsGridView.Sort(songsGridView.Columns[COLUMN_PLAYLIST], ListSortDirection.Ascending); // Comment out while debuggin to improve performance
            songsGridView.Rows[0].Selected = true;
        }

        private void AddHeadings()
        {
            songsGridView.ColumnCount = 7;
            songsGridView.Columns[0].Name = "Rating";
            songsGridView.Columns[1].Name = "Artist";
            songsGridView.Columns[2].Name = "Title";
            songsGridView.Columns[3].Name = "BPM";
            songsGridView.Columns[4].Name = "Key";
            songsGridView.Columns[5].Name = "Intensity";
            songsGridView.Columns[6].Name = "Playlist";

            songsGridView.Columns[0].Width = 50;
            songsGridView.Columns[2].Width = 300;

            listGridView.ColumnCount = 7;
            listGridView.Columns[0].Name = "Rating";
            listGridView.Columns[1].Name = "Artist";
            listGridView.Columns[2].Name = "Title";
            listGridView.Columns[3].Name = "BPM";
            listGridView.Columns[4].Name = "Key";
            listGridView.Columns[5].Name = "Intensity";
            listGridView.Columns[6].Name = "Playlist";

            listGridView.Columns[0].Width = 50;
            listGridView.Columns[2].Width = 300;
        }

        private void ClearMusic()
        {
            songsGridView.Rows.Clear();
            songsGridView.Refresh();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            GetSongSelection();
        }

        private void GetSongSelection()
        {
            if (songsGridView.SelectedCells.Count > 0)
            {
                int rowindex = songsGridView.SelectedCells[0].RowIndex;

                DataGridViewRow row = songsGridView.Rows[rowindex];

                var leadingBpm = 0;
                var trailingBpm = 0;
                var bpmText = row.Cells[COLUMN_BPM].Value.ToString();
                int index = bpmText.IndexOf(" - ");

                if (index > 0)
                {
                    leadingBpm = Convert.ToInt32(bpmText.Substring(0, index));
                    trailingBpm = Convert.ToInt32(bpmText.Substring(index + 3));
                }
                else
                {
                    leadingBpm = Convert.ToInt32(bpmText);
                }

                var keyColumnValue = Convert.ToString(row.Cells[COLUMN_KEY].Value);
                var leadingKey = GetLeadingKey(keyColumnValue);
                var trailingKey = GetTrailingKey(keyColumnValue);

                AddSongToList(new Song()
                {
                    Rating = Convert.ToInt32(row.Cells[COLUMN_RATING].Value),
                    Artist = row.Cells[COLUMN_ARTIST].Value.ToString(),
                    Title = row.Cells[COLUMN_TITLE].Value.ToString(),
                    LeadingBpm = leadingBpm,
                    TrailingBpm = trailingBpm,
                    LeadingKey = leadingKey,
                    TrailingKey = trailingKey,
                    Intensity = Convert.ToInt32(row.Cells[COLUMN_INTENSITY].Value),
                    Playlist = Convert.ToString(row.Cells[COLUMN_PLAYLIST].Value)
                });
            }
        }

        private string GetTrailingKey(string keyColumnValue)
        {
            var trailingKey = string.Empty;

            if (!string.IsNullOrEmpty(keyColumnValue))
            {
                var pattern = @"^\d\d?[AB](/\d\d?[AB])?";

                if (Regex.IsMatch(keyColumnValue, pattern, RegexOptions.IgnoreCase))
                {
                    Regex regex = new Regex(@"/\d\d?[AB]");
                    Match match = regex.Match(keyColumnValue);

                    if (match.Success)
                    {
                        trailingKey = match.Value;
                    }
                }
            }

            return trailingKey;
        }

        private string GetLeadingKey(string keyColumnValue)
        {
            var leadingKey = string.Empty;

            if (!string.IsNullOrEmpty(keyColumnValue))
            {
                var pattern = @"^\d\d?[AB]";

                if (Regex.IsMatch(keyColumnValue, pattern, RegexOptions.IgnoreCase))
                {
                    Regex regex = new Regex(@"^\d\d?[AB]");
                    Match match = regex.Match(keyColumnValue);

                    if (match.Success)
                    {
                        leadingKey = match.Value;
                    }
                }
            }

            return leadingKey;
        }

        private void AddSongToList(ISong song)
        {
            var row = new string[] {
                song.Rating.ToString(),
                song.Artist,
                song.Title,
                song.LeadingBpm.ToString(),
                string.Concat(song.LeadingKey,
                !string.IsNullOrEmpty(song.TrailingKey) ? string.Concat("/", song.TrailingKey) : ""),
                song.Intensity.ToString(),
                song.Playlist
            };

            if (isReplacing)
            {
                var rowInsertIndex = RemoveCollectionItem();
                InsertCollectionItem(rowInsertIndex, row);

                SelectReplacedListRow();
            }
            else if (isInserting)
            {
                InsertCollectionItem(listRowInsertIndex, row);

                SelectInsertedListRow();
            }
            else
            {
                listGridView.Rows.Add(row);
            }


            if (!isReplacing && !isInserting)
            {
                if (listGridView.Rows.Count > 2)
                {
                    listGridView.ClearSelection();
                    listGridView.Rows[listGridView.Rows.Count - 2].Selected = true;
                    listGridView.FirstDisplayedScrollingRowIndex = listGridView.SelectedRows[0].Index;
                }
                else // is this requried?
                {
                    listGridView.ClearSelection();
                    listGridView.Rows[listGridView.Rows.Count - 2].Selected = true;
                }
            }

            isReplacing = false;
            isInserting = false;

            musicTabControl.SelectedTab = listTabPage;
            addButton.Text = "Add";
        }

        private void InsertCollectionItem(int rowInsertIndex, string[] row)
        {
            if (listGridView.SelectedRows.Count > 0)
                rowInsertIndex = listGridView.SelectedRows[0].Index;

            if (isInserting)
                rowInsertIndex++;

            listGridView.Rows.Insert(rowInsertIndex, row);
            listGridView.Rows[rowInsertIndex].Selected = true;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            RemoveCollectionItem();
        }

        private int RemoveCollectionItem()
        {
            var selectedRow = 0;

            if (listGridView.Rows.Count > 1 && listGridView.SelectedRows.Count > 0)
            {
                selectedRow = listGridView.SelectedRows[0].Index;
                listGridView.Rows.RemoveAt(selectedRow);

                if (listGridView.Rows.Count == 1)
                    listGridView.ClearSelection();
                else if (selectedRow == listGridView.Rows.Count - 1)
                    listGridView.Rows[selectedRow - 1].Selected = true;
                else
                    listGridView.Rows[selectedRow].Selected = true;
            }

            return selectedRow;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchTextBox.Text.Length == 0 || searchTextBox.Text.Length >= 3)
                PopulateSongs();
        }

        private void bpmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isPopulating)
            {
                rangeCheckBox.Checked = !(bpmComboBox.SelectedIndex > 0);
                isRangeSelection = false;
                PopulateSongs();
            }
        }

        private void keyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isPopulating)
            {
                rangeCheckBox.Checked = !(bpmComboBox.SelectedIndex > 0);
                isRangeSelection = false;
                PopulateSongs();
            }
        }

        private void playlistComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateSongs();
        }

        private void randomiseMenuItem_Click(object sender, EventArgs e)
        {
            var i = 0;

            while (i == 0 || songsGridView.RowCount <= 1)
            {
                var randomBpm = Library.GetRandomBpm(bpmDictionary);
                bpmComboBox.SelectedItem = randomBpm.ToString();

                var randomKey = Library.GetRandomKey(keyDictionary);
                keyComboBox.SelectedItem = randomKey;

                PopulateSongs();

                i++;
            }

            SelectRandomRow();

            if (musicTabControl.SelectedTab != songsTabPage)
                musicTabControl.SelectedTab = songsTabPage;
        }

        private void SelectRandomRow()
        {
            var randomRow = Library.GetRandomRow(songsGridView.Rows.Count);

            if (songsGridView.Rows.Count > 1 && songsGridView.SelectedRows.Count > 0)
            {
                songsGridView.ClearSelection();
                songsGridView.Rows[randomRow - 1].Selected = true;
                songsGridView.FirstDisplayedScrollingRowIndex = songsGridView.SelectedRows[0].Index;
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (listGridView.Rows.Count > 1 && listGridView.SelectedRows.Count > 0)
            {
                int rowindex = listGridView.SelectedCells[0].RowIndex;

                DataGridViewRow row = listGridView.Rows[rowindex];

                var bpm = Convert.ToString(row.Cells[COLUMN_BPM].Value);
                bpmComboBox.SelectedItem = bpm;

                var key = Convert.ToString(row.Cells[COLUMN_KEY].Value);

                if (key.Contains("/"))
                {
                    var index = key.LastIndexOf('/');
                    key = key.Substring(index + 1);
                }

                keyComboBox.SelectedItem = key;
                searchTextBox.Text = string.Empty;

                rangeCheckBox.Checked = true;
                isRangeSelection = true;
                //SetRangeSelection();
                PopulateSongs();
                //isRangeSelection = false;

                SelectRandomRow();

                musicTabControl.SelectedTab = songsTabPage;
            }
        }

        private void populateButton_Click(object sender, EventArgs e)
        {
            var i = 0;

            if (listGridView.Rows.Count > 1 && listGridView.SelectedRows.Count > 0)
            {
                while (i < 10)
                {
                    int rowindex = listGridView.SelectedCells[0].RowIndex;

                    DataGridViewRow row = listGridView.Rows[rowindex];

                    var bpm = Convert.ToString(row.Cells[COLUMN_BPM].Value);
                    var key = Convert.ToString(row.Cells[COLUMN_KEY].Value);

                    isPopulating = true;
                    bpmComboBox.SelectedItem = bpm;
                    keyComboBox.SelectedItem = key;
                    isPopulating = false;

                    SetRangeSelection();
                    PopulateSongs();

                    SelectRandomRow();

                    if (!IsSongDuplicateInList())
                    {
                        // add the song
                        GetSongSelection();
                    }

                    i++;
                }
            }

            SelectListRow();
        }

        private bool IsSongDuplicateInList()
        {
            var isSongDuplicateInList = false;

            var selectedSongRow = GetSelectedSongRow();

            if (selectedSongRow != null)
            {
                var rating = Convert.ToInt32(selectedSongRow.Cells[COLUMN_RATING].Value);

                for (int i = 1; i < listGridView.Rows.Count; i++)
                {
                    isSongDuplicateInList = AreRowsDuplicate(selectedSongRow, listGridView.Rows[i - 1]);

                    if (isSongDuplicateInList)
                    {
                        break;
                    }
                }

            }

            return isSongDuplicateInList;
        }

        private bool AreRowsDuplicate(DataGridViewRow selectedSongRow, DataGridViewRow listRow)
        {
            return (Convert.ToInt32(selectedSongRow.Cells[COLUMN_RATING].Value) == Convert.ToInt32(listRow.Cells[COLUMN_RATING].Value)
                && selectedSongRow.Cells[COLUMN_ARTIST].Value.ToString() == listRow.Cells[COLUMN_ARTIST].Value.ToString()
                && selectedSongRow.Cells[COLUMN_TITLE].Value.ToString() == listRow.Cells[COLUMN_TITLE].Value.ToString()
                && selectedSongRow.Cells[COLUMN_BPM].Value.ToString() == listRow.Cells[COLUMN_BPM].Value.ToString()
                && Convert.ToString(selectedSongRow.Cells[COLUMN_KEY].Value) == Convert.ToString(listRow.Cells[COLUMN_KEY].Value)
                && Convert.ToString(selectedSongRow.Cells[COLUMN_PLAYLIST].Value) == Convert.ToString(listRow.Cells[COLUMN_PLAYLIST].Value));
        }

        private DataGridViewRow GetSelectedSongRow()
        {
            var row = new DataGridViewRow();

            if (songsGridView.SelectedCells.Count > 0)
            {
                int rowindex = songsGridView.SelectedCells[0].RowIndex;

                row = songsGridView.Rows[rowindex];
            }

            return row;
        }

        private void SelectListRow()
        {
            if (listGridView.Rows.Count > 11 && listGridView.SelectedRows.Count > 0)
            {
                listGridView.ClearSelection();
                listGridView.Rows[listGridView.Rows.Count - 12].Selected = true;
                listGridView.FirstDisplayedScrollingRowIndex = listGridView.SelectedRows[0].Index;
            }
        }

        private void replaceButton_Click(object sender, EventArgs e)
        {
            if (listGridView.Rows.Count > 1 && listGridView.SelectedRows.Count > 0)
            {
                listRowReplaceIndex = listGridView.SelectedCells[0].RowIndex;

                DataGridViewRow row = listGridView.Rows[listRowReplaceIndex];

                var bpm = Convert.ToString(row.Cells[COLUMN_BPM].Value);
                var key = Convert.ToString(row.Cells[COLUMN_KEY].Value);

                isPopulating = true;
                bpmComboBox.SelectedItem = bpm;
                keyComboBox.SelectedItem = key;
                isPopulating = false;


                isRangeSelection = false;
                rangeCheckBox.Checked = false;
                PopulateSongs();

                SelectRandomRow();

                isReplacing = true;

                addButton.Text = "Replace";
                Refresh();

                cancelButton.Visible = true;
                musicTabControl.SelectedTab = songsTabPage;
            }
        }

        private void SelectReplacedListRow()
        {
            if (listGridView.Rows.Count > 1 && listGridView.SelectedRows.Count > 0)
            {
                listGridView.ClearSelection();
                listGridView.Rows[listRowReplaceIndex].Selected = true;
                listGridView.FirstDisplayedScrollingRowIndex = listGridView.SelectedRows[0].Index;
            }
        }

        private void SelectInsertedListRow()
        {
            if (listGridView.Rows.Count > 1 && listGridView.SelectedRows.Count > 0)
            {
                listGridView.ClearSelection();
                listGridView.Rows[listRowInsertIndex + 1].Selected = true;
                listGridView.FirstDisplayedScrollingRowIndex = listGridView.SelectedRows[0].Index;
            }
        }


        private void clearSongFiltersMenuItem_Click(object sender, EventArgs e)
        {
            bpmComboBox.SelectedIndex = 0;
            keyComboBox.SelectedIndex = 0;
            playlistComboBox.SelectedIndex = 0;
            searchTextBox.Text = "";

            PopulateSongs();

            musicTabControl.SelectedTab = songsTabPage;
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (listGridView.Rows.Count > 1 && listGridView.SelectedRows.Count > 0)
            {
                listRowInsertIndex = listGridView.SelectedCells[0].RowIndex;

                DataGridViewRow row = listGridView.Rows[listRowInsertIndex];

                var bpm = Convert.ToString(row.Cells[COLUMN_BPM].Value);
                var key = Convert.ToString(row.Cells[COLUMN_KEY].Value);

                isPopulating = true;
                bpmComboBox.SelectedItem = bpm;
                keyComboBox.SelectedItem = key;
                isPopulating = false;

                isInserting = true;
                isRangeSelection = false;
                PopulateSongs();
                isInserting = false;

                SelectRandomRow();

                isInserting = true;

                addButton.Text = "Insert";
                Refresh();

                cancelButton.Visible = true;
                musicTabControl.SelectedTab = songsTabPage;
            }
        }

        private void weddingMenuItem_Click(object sender, EventArgs e)
        {
            if (weddingMenuItem.Checked)
                weddingMenuItem.Checked = false;
            else
                weddingMenuItem.Checked = true;

            PopulateSongs();
        }

        private void electroHouseMenuItem_Click(object sender, EventArgs e)
        {
            if (electroHouseMenuItem.Checked)
                electroHouseMenuItem.Checked = false;
            else
                electroHouseMenuItem.Checked = true;

            PopulateSongs();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            isInserting = false;
            isReplacing = false;

            musicTabControl.SelectedTab = listTabPage;

            cancelButton.Visible = false;
            addButton.Text = "Add";
        }

        private void afterMenuItem_Click(object sender, EventArgs e)
        {
            if (listGridView.Rows.Count > 1 && listGridView.SelectedRows.Count > 0)
            {
                var selectedListRowIndex = listGridView.SelectedRows[0].Index;

                for (int i = 0; i < listGridView.Rows.Count; i++) //&& listGridView.Rows.Count > 2
                {
                    if (i > selectedListRowIndex && i < listGridView.Rows.Count - 1)
                    {
                        listGridView.Rows.RemoveAt(i);
                        listGridView.Refresh();
                        i--;
                    }
                }

                musicTabControl.SelectedTab = listTabPage;
            }
        }

        private void allMenuItem_Click(object sender, EventArgs e)
        {
            ClearList();
        }

        private void ClearList()
        {
            listGridView.Rows.Clear();
            listGridView.Refresh();

            musicTabControl.SelectedTab = listTabPage;
        }

        private void rangeCheckBox_Click(object sender, EventArgs e)
        {
            SetRangeSelection();
            PopulateSongs();
        }

        private void SetRangeSelection()
        {
            if (rangeCheckBox.Checked)
                isRangeSelection = true;
            else
                isRangeSelection = false;
        }

        private void everythingElseMenuItem_Click(object sender, EventArgs e)
        {
            if (everythingElseMenuItem.Checked)
                everythingElseMenuItem.Checked = false;
            else
                everythingElseMenuItem.Checked = true;

            PopulateSongs();
        }

        private void rangeMenuItem3_Click(object sender, EventArgs e)
        {
            if (!rangeMenuItem3.Checked)
            {
                rangeMenuItem3.Checked = true;
                bpmRangeSelector = 3;
            }

            rangeMenuItem6.Checked = false;
            rangeMenuItem12.Checked = false;

            PopulateSongs();
        }

        private void rangeMenuItem6_Click(object sender, EventArgs e)
        {
            if (!rangeMenuItem6.Checked)
            {
                rangeMenuItem6.Checked = true;
                bpmRangeSelector = 6;
            }


            rangeMenuItem3.Checked = false;
            rangeMenuItem12.Checked = false;

            PopulateSongs();
        }

        private void rangeMenuItem12_Click(object sender, EventArgs e)
        {
            if (!rangeMenuItem12.Checked)
            {
                rangeMenuItem12.Checked = true;
                bpmRangeSelector = 12;
            }


            rangeMenuItem3.Checked = false;
            rangeMenuItem6.Checked = false;

            PopulateSongs();
        }

        private void ratedCheckBox_Click(object sender, EventArgs e)
        {
            SetRatedSelection();
            PopulateSongs();
        }

        private void SetRatedSelection()
        {
            if (ratedCheckBox.Checked)
                isRatedSelection = true;
            else
                isRatedSelection = false;
        }

        private void custom1MenuItem_Click(object sender, EventArgs e)
        {
            if (custom1MenuItem.Checked)
                custom1MenuItem.Checked = false;
            else
                custom1MenuItem.Checked = true;

            PopulateSongs();
        }

        private void createMenuItem_Click(object sender, EventArgs e)
        {
            var mixDiscWindow = new MixDiscWindow();
            mixDiscWindow.PlaylistList = library.GetPlaylists();
            mixDiscWindow.PopulatePlaylistList();
            mixDiscWindow.Library = library;
            mixDiscWindow.ShowDialog();

            if (mixDiscWindow.DialogResult == DialogResult.OK)
            {
                var matchedMixDisc = mixDiscWindow.Matched;

                if (matchedMixDisc != null && matchedMixDisc.Count > 0)
                {
                    ClearList();

                    foreach (var song in matchedMixDisc)
                    {
                        var row = new string[] {
                        song.Rating.ToString(),
                        song.Artist,
                        song.Title,
                        song.LeadingBpm.ToString(),
                        string.Concat(song.LeadingKey,
                        !string.IsNullOrEmpty(song.TrailingKey) ? string.Concat("/", song.TrailingKey) : ""),
                        song.Intensity.ToString(),
                        song.Playlist
                    };

                        listGridView.Rows.Add(row);
                    }
                }
            }
        }
    }
}
