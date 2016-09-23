using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraktorLibrary;

namespace Cellekta_2
{
    public partial class Cellekta : Form
    {
        //private List<ISong> music;
        private ILibrary library;
        public bool isInserting { get; set; }
        public int listRowInsertIndex { get; set; }
        public int listRowReplaceIndex { get; set; }
        public bool isReplacing { get; set; }
        public bool isPopulating;
        public bool isRangeSelection;
        public static Dictionary<string, int> keyDictionary = new Dictionary<string, int> { };
        public static Dictionary<int, int> bpmDictionary = new Dictionary<int, int> { };

        public Cellekta()
        {
            InitializeComponent();

            library = new Library(new List<ISong>());

            if (library.TraktorExists())
            {
                library.DeleteTemp();
                library.CreateTemp();

                if (library.TempExists())
                {
                    library.Import();
                    PopulateSongs();
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
                keyComboBox.Items.Add(item);
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

        public void PopulateSongs()
        {
            var bpm = 0;
            var key = string.Empty;
            var playlist = string.Empty;
            var searchText = searchTextBox.Text;
            var bpmRange = new List<int>();
            var keyRange = new List<string>();

            ClearMusic();
            AddHeadings();

            if (bpmComboBox.SelectedItem != null)
            {
                if (!String.IsNullOrEmpty(bpmComboBox.SelectedItem.ToString()))
                    bpm = Convert.ToInt32(bpmComboBox.SelectedItem);
            }

            if (keyComboBox.SelectedItem != null)
                key = keyComboBox.SelectedItem.ToString();

            if (playlistComboBox.SelectedItem != null)
                playlist = playlistComboBox.SelectedItem.ToString();

            if (isRangeSelection)
            {
                bpmRange = Song.GetBpmRange(bpm);

                if (!string.IsNullOrEmpty(key))
                    keyRange = Song.GetKeyRange(key);
            }

            foreach (ISong song in library.Music)
            {
                var trannyBpm = string.Empty;

                if (song.TrailingBpm > 0)
                    trannyBpm = string.Format("{0} - {1}", song.LeadingBpm, song.TrailingBpm);
                else
                    trannyBpm = song.LeadingBpm.ToString();

                string[] row = new string[] { song.Artist, song.Title, trannyBpm, song.Key, song.Playlist };

                var isAdding = false;

                if (isRangeSelection)
                    isAdding = (bpm == 0 || bpmRange.Contains(song.LeadingBpm));
                else
                    isAdding = (bpm == 0 || song.LeadingBpm == bpm);

                if (isAdding
                    && (string.IsNullOrEmpty(searchText) || song.Artist.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 || song.Title.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    && (String.IsNullOrEmpty(key) || song.Key == key)
                    && (String.IsNullOrEmpty(playlist) || song.Playlist == playlist)
                    && (weddingMenuItem.Checked || (!weddingMenuItem.Checked && !song.FullName.Contains(@"C:\Dj Music\Wedding")))
                    && (electroHouseMenuItem.Checked || (!electroHouseMenuItem.Checked && !song.FullName.Contains(@"C:\Dj Music\Electro house")))
                    && (everythingElseMenuItem.Checked | (!everythingElseMenuItem.Checked && (song.FullName.Contains(@"C:\Dj Music\Wedding") || song.FullName.Contains(@"C:\Dj Music\Electro house")))))
                    songsGridView.Rows.Add(row);

            }
            // takes too long while debugging
            songsGridView.Sort(songsGridView.Columns[4], ListSortDirection.Ascending);
            songsGridView.Rows[0].Selected = true;
        }

        private void AddHeadings()
        {
            songsGridView.ColumnCount = 5;
            songsGridView.Columns[0].Name = "Artist";
            songsGridView.Columns[1].Name = "Title";
            songsGridView.Columns[2].Name = "BPM";
            songsGridView.Columns[3].Name = "Key";
            songsGridView.Columns[4].Name = "Playlist";

            songsGridView.Columns[1].Width = 350;

            listGridView.ColumnCount = 5;
            listGridView.Columns[0].Name = "Artist";
            listGridView.Columns[1].Name = "Title";
            listGridView.Columns[2].Name = "BPM";
            listGridView.Columns[3].Name = "Key";
            listGridView.Columns[4].Name = "Playlist";

            listGridView.Columns[1].Width = 350;
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
                var bpmText = row.Cells[2].Value.ToString();
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

                AddSongToList(new Song()
                {
                    Artist = row.Cells[0].Value.ToString(),
                    Title = row.Cells[1].Value.ToString(),
                    LeadingBpm = leadingBpm,
                    TrailingBpm = trailingBpm,
                    Key = Convert.ToString(row.Cells[3].Value),
                    Playlist = Convert.ToString(row.Cells[4].Value)
                });
            }
        }

        private void AddSongToList(ISong song)
        {
            string[] row = new string[] { song.Artist, song.Title, song.LeadingBpm.ToString(), song.Key, song.Playlist };

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

        private void clearListMenuItem_Click(object sender, EventArgs e)
        {
            bpmComboBox.SelectedIndex = 0;
            keyComboBox.SelectedIndex = 0;
            playlistComboBox.SelectedIndex = 0;
            searchTextBox.Text = "";

            PopulateSongs();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (listGridView.Rows.Count > 1 && listGridView.SelectedRows.Count > 0)
            {
                int rowindex = listGridView.SelectedCells[0].RowIndex;

                DataGridViewRow row = listGridView.Rows[rowindex];

                var bpm = Convert.ToString(row.Cells[2].Value);
                bpmComboBox.SelectedItem = bpm;

                var key = Convert.ToString(row.Cells[3].Value);
                keyComboBox.SelectedItem = key;

                playlistComboBox.SelectedIndex = 0;
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

                    var bpm = Convert.ToString(row.Cells[2].Value);
                    var key = Convert.ToString(row.Cells[3].Value);

                    isPopulating = true;
                    bpmComboBox.SelectedItem = bpm;
                    keyComboBox.SelectedItem = key;
                    isPopulating = false;

                    SetRangeSelection();
                    PopulateSongs();

                    SelectRandomRow();

                    // add the song
                    GetSongSelection();

                    i++;
                }
            }

            SelectListRow();
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

                var bpm = Convert.ToString(row.Cells[2].Value);
                var key = Convert.ToString(row.Cells[3].Value);

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

        //private void clearAllMenuItem_Click(object sender, EventArgs e)
        //{
        //    listGridView.Rows.Clear();
        //    listGridView.Refresh();

        //    musicTabControl.SelectedTab = listTabPage;
        //}

        //private void clearAfterMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (listGridView.Rows.Count > 1 && listGridView.SelectedRows.Count > 0)
        //    {
        //        var selectedListRowIndex = listGridView.SelectedRows[0].Index;

        //        for (int i = 0; i < listGridView.Rows.Count; i++) //&& listGridView.Rows.Count > 2
        //        {
        //            if (i > selectedListRowIndex && i < listGridView.Rows.Count - 1)
        //            {
        //                listGridView.Rows.RemoveAt(i);
        //                listGridView.Refresh();
        //                i--;
        //            }
        //        }

        //        musicTabControl.SelectedTab = listTabPage;
        //    }
        //}

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

                var bpm = Convert.ToString(row.Cells[2].Value);
                var key = Convert.ToString(row.Cells[3].Value);

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

        //private void rangeMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (rangeMenuItem.Checked)
        //        rangeMenuItem.Checked = false;
        //    else
        //        rangeMenuItem.Checked = true;

        //    //isRangeSelection = rangeMenuItem.Checked;
        //    PopulateSongs();
        //}
    }
}
