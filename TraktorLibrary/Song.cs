using Ratings;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace TraktorLibrary
{
    public class Song : ISong
    {
        private List<string> ratedArtists;
        private Dictionary<int, string> traktorKeys;

        public string Artist { get; set; }
        public string Title { get; set; }
        public string Playlist { get; set; }
        public string FullName { get; set; }
        public int LeadingBpm { get; set; }
        public string Key { get; set; }
        public int PlayTime { get; set; }
        public int TrailingBpm { get; set; }
        public int Rating { get; set; }

        public Song()
        {
            ratedArtists = new List<string>();
            traktorKeys = new Dictionary<int, string>()
            {
                { 0, "1d" },
                { 1, "8d" },
                { 2, "3d" },
                { 3, "10d" },
                { 4, "5d" },
                { 5, "12d" },
                { 6, "7d" },
                { 7, "2d" },
                { 8, "9d" },
                { 9, "4d" },
                { 10, "11d" },
                { 11, "6d" },
                { 12, "10m" },
                { 13, "5m" },
                { 14, "12m" },
                { 15, "7m" },
                { 16, "2m" },
                { 17, "9m" },
                { 18, "4m" },
                { 19, "11m" },
                { 20, "6m" },
                { 21, "1m" },
                { 22, "8m" },
                { 23, "3m" }
            };
        }

        public string GetPlayList(XmlNode locationNode)
        {
            if (locationNode == null) throw new ArgumentNullException("locationNode is null");

            var directory = GetDirectory(locationNode);
            var directories = directory.Split(new char[] { '\\', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            var directoriesCount = directories.Length;

            return directories[directoriesCount - 1];
        }

        public static string GetDirectory(XmlNode locationNode)
        {
            if (locationNode == null) throw new ArgumentNullException("locationNode is null");

            return GetAttribute(locationNode.Attributes["DIR"]).Replace("/:", "\\");
        }

        public string GetFullName(XmlNode locationNode)
        {
            if (locationNode == null) throw new ArgumentNullException("locationNode is null");

            var directory = GetDirectory(locationNode);
            var file = GetAttribute(locationNode.Attributes["FILE"]);
            var volume = GetAttribute(locationNode.Attributes["VOLUME"]);

            return string.Concat(volume, directory, file);
        }

        public void Populate(XmlNode xmlNode)
        {
            if (xmlNode == null) throw new ArgumentNullException("xmlNode is null");

            Artist = GetAttribute(xmlNode.Attributes["ARTIST"]);
            Title = GetAttribute(xmlNode.Attributes["TITLE"]);
            var locationNode = xmlNode.SelectSingleNode("LOCATION");
            Playlist = GetPlayList(locationNode);
            FullName = GetFullName(locationNode);
            PlayTime = GetPlayTime(xmlNode.SelectSingleNode("INFO"));

            try
            {
                LeadingBpm = GetLeadingBpm(xmlNode.SelectSingleNode("TEMPO"), FullName);
            }
            catch (ArgumentNullException)
            {
                LeadingBpm = 0;
            }
            catch (Exception)
            {
                throw;
            }

            TrailingBpm = GetTrailingBpm(FullName);

            try
            {
                Key = GetKey(xmlNode.SelectSingleNode("MUSICAL_KEY"));
            }
            catch (ArgumentNullException)
            {
                Key = string.Empty;
            }
            catch (Exception)
            {

                throw;
            }


        }

        private string GetKey(XmlNode musicalKeyNode)
        {
            if (musicalKeyNode == null) throw new ArgumentNullException("musicalKeyNode is null");

            var key = string.Empty;
            var musicalKey = GetKeyValue(musicalKeyNode.Attributes["VALUE"]);
            traktorKeys.TryGetValue(musicalKey, out key);

            return key;
        }

        public static int GetKeyValue(XmlAttribute musicalKeyAttribute)
        {
            if (musicalKeyAttribute == null) throw new ArgumentNullException("musicalKeyAttribute is null");

            var musicalKey = 0;
            var key = string.Empty;

            int.TryParse(GetAttribute(musicalKeyAttribute), out musicalKey);

            return musicalKey;
        }

        public int GetTrailingBpm(string fullName)
        {
            if (string.IsNullOrEmpty(fullName)) throw new ArgumentNullException("fullName is null or empty");

            var trailingBpm = 0;

            if (IsTransitionPlaylist(fullName))
            {
                var tag = new Tag(fullName);

                try
                {
                    trailingBpm = tag.GetBpm(tag.Artist);
                }
                catch (ArgumentNullException)
                {
                    trailingBpm = 0;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return trailingBpm;
        }

        public bool IsTransitionPlaylist(string fullName)
        {
            if (string.IsNullOrEmpty(fullName)) throw new ArgumentNullException("fullName is null or empty");

            return (fullName.Contains(@"C:\Dj Music\Tranny") || fullName.Contains(@"C:\Dj Music\Selections\S_Tranny"));
        }

        public int GetLeadingBpm(XmlNode tempoNode, string fullName)
        {
            if (tempoNode == null) throw new ArgumentNullException("tempoNode is null");
            if (string.IsNullOrEmpty(fullName)) throw new ArgumentNullException("fullName is null or empty");

            var leadingBpm = 0;

            if (IsTransitionPlaylist(fullName))
            {
                var tag = new Tag(fullName);

                try
                {
                    leadingBpm = tag.GetBpm(tag.Title);
                }
                catch (ArgumentNullException)
                {
                    leadingBpm = 0;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            if (leadingBpm == 0)
            {
                if (tempoNode != null)
                {
                    leadingBpm = GetBpm(tempoNode.Attributes["BPM"]);
                }
            }

            return leadingBpm;
        }

        public int GetPlayTime(XmlNode infoNode)
        {
            if (infoNode == null) throw new ArgumentNullException("infoNode is null");

            var playTime = 0;
            int.TryParse(GetAttribute(infoNode.Attributes["PLAYTIME"]), out playTime);

            return playTime;
        }

        public static string GetPlaylist(string dir)
        {
            string[] directories = dir.Split(new char[] { '\\', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            var directoriesCount = directories.Length;

            return directories[directoriesCount - 1];
        }

        public static bool IsArtistWithLeadingNumber(string artistName)
        {
            var isArtistName = false;

            if (!string.IsNullOrEmpty(artistName))
            {
                string[] numberedArtist = { @"^50\scent",
                                        @"^5\sSeconds\sOf\sSummer",
                                        @"^360",
                                        @"^50\sWays\sTo\sSay\sGoodbye",
                                        @"^20 fingers" };

                foreach (string artist in numberedArtist)
                {
                    if (Regex.IsMatch(artistName, artist, RegexOptions.IgnoreCase))
                        isArtistName = true;
                }
            }
            return isArtistName;
        }

        public static string GetAttribute(XmlAttribute xmlAttributes)
        {
            var attribute = string.Empty;

            if (xmlAttributes != null)
            {
                if (xmlAttributes.Value != null)
                    attribute = xmlAttributes.Value;
            }

            return attribute;
        }

        public static int GetBpm(XmlAttribute xmlAttributes)
        {
            decimal bpm = 0;
            decimal.TryParse(GetAttribute(xmlAttributes), out bpm);

            return (int)Math.Round(bpm, 0);
        }

        public void GetRating()
        {
            // move this to the Library class so that the object is not instantiated for each song
            ICharts charts = new Charts();
            charts.GetCharts();

            if (charts.IsChartedSong(Artist, Title))
                Rating++;

            IRatedArtists ratedArtists = new RatedArtists();
            ratedArtists.GetRatedArtists();

            if (ratedArtists.IsRatedArtist(Artist))
            {
                Rating++;
            }

            IRatedTitles ratedTitles = new RatedTitles();
            ratedTitles.GetRatedTitles();

            if (ratedTitles.IsRatedTitle(Artist, Title))
            {
                Rating++;
            }
        }

        private bool IsArtistRated()
        {
            return ratedArtists.Contains(Artist);
        }

        public static List<int> GetBpmRange(int bpm, int bpmRangeSelector)
        {
            var bpmRange = new List<int>();
            var upperBPM = bpm + bpmRangeSelector;
            var lowerBPM = bpm - bpmRangeSelector;
            var upperDoubleBPM = upperBPM * 2;
            var lowerDoubleBPM = lowerBPM * 2;
            var upperHalfBPM = upperBPM / 2;
            var lowerHalfBPM = lowerBPM / 2;

            for (int i = lowerBPM; i <= upperBPM; i++)
                bpmRange.Add(i);

            for (int i = lowerDoubleBPM; i <= upperDoubleBPM; i++)
                bpmRange.Add(i);

            for (int i = lowerHalfBPM; i <= upperHalfBPM; i++)
                bpmRange.Add(i);

            return bpmRange;
        }

        public static List<string> GetKeyRange(string key)
        {
            var keyRange = new List<string>();

            if (key != string.Empty)
            {
                key = key.ToLower();
                // write a method to valide the key string
                var keyLetter = key.Contains("d") ? "d" : "m";

                var keyNumber = Convert.ToInt32(key.Replace("d", "").Replace("m", ""));

                var upperKeyNumber = keyNumber == 12 ? 1 : keyNumber + 1;
                var lowerKeyNumber = keyNumber == 1 ? 12 : keyNumber - 1;

                var upperKey = String.Concat(upperKeyNumber, keyLetter);
                var lowerKey = String.Concat(lowerKeyNumber, keyLetter);

                var otherKey = String.Concat(keyNumber, keyLetter == "d" ? "m" : "d");

                keyRange.Add(upperKey);
                keyRange.Add(key);
                keyRange.Add(lowerKey);
                keyRange.Add(otherKey);
            }

            return keyRange;
        }

        public static string GetTagTitle(string fullName)
        {
            if (string.IsNullOrEmpty(fullName)) throw new ArgumentNullException("fullName is null or empty");

            TagLib.File file = TagLib.File.Create(fullName);

            return file.Tag.Title;

        }

        public static string GetTagArtist(string fullName)
        {
            if (string.IsNullOrEmpty(fullName)) throw new ArgumentNullException("fullName is null or empty");

            TagLib.File file = TagLib.File.Create(fullName);

            return file.Tag.FirstArtist;
        }
    }
}