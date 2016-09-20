﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace TraktorLibrary
{
    public class Song : ISong
    {
        string _artist;
        string _title;
        string _playlist;
        string _fullName;
        int _playTime;
        int _leadingBpm;
        int _trailingBpm;
        string _key;
        int _rating;
        List<String> _ratedArtists = new List<string>();

        Dictionary<int, string> _traktorKeys = new Dictionary<int, string>()
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

        public string Artist { get { return _artist; } set { _artist = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public string Playlist { get { return _playlist; } set { _playlist = value; } }
        public string FullName { get { return _fullName; } set { _fullName = value; } }
        //public int PlayTime { get { return _playTime; } }
        //public int LeadingBpm { get { return _leadingBpm; } }
        //public int TrailingBpm { get { return _trailingBpm; } }
        //public string Key { get { return _key; } }

        public Song(List<string> ratedArtists)
        {
            _ratedArtists = ratedArtists;
        }

        public void Populate(XmlNode xmlNode)
        {
            if (xmlNode != null)
            {
                var file = string.Empty;

                _artist = GetAttribute(xmlNode.Attributes["ARTIST"]);
                _title = GetAttribute(xmlNode.Attributes["TITLE"]);

                var locationNode = xmlNode.SelectSingleNode("LOCATION");

                if (locationNode != null)
                {
                    var dir = GetAttribute(locationNode.Attributes["DIR"]).Replace("/:", "\\");
                    _playlist = GetPlaylist(dir);
                    file = GetAttribute(locationNode.Attributes["FILE"]);
                    var volume = GetAttribute(locationNode.Attributes["VOLUME"]);
                    _fullName = string.Concat(volume, dir, file);
                }

                var infoNode = xmlNode.SelectSingleNode("INFO");

                if (infoNode != null)
                    Int32.TryParse(GetAttribute(infoNode.Attributes["PLAYTIME"]), out _playTime);

                if (_fullName.Contains(@"C:\Dj Music\Tranny")
                    || _fullName.Contains(@"C:\Dj Music\Selections\S_Tranny"))
                {
                    ITag tag = new Tag(_fullName);
                    var tagTitle = tag.Title;
                    var tagArtist = tag.Artist;
                    _leadingBpm = GetLeadingBpm(tagTitle);
                    _trailingBpm = GetTrailingBpm(tagArtist);
                }

                if (_leadingBpm == 0)
                {
                    var tempoNode = xmlNode.SelectSingleNode("TEMPO");

                    if (tempoNode != null)
                        _leadingBpm = GetBpm(tempoNode.Attributes["BPM"]);
                }

                var musicalKeyNode = xmlNode.SelectSingleNode("MUSICAL_KEY");

                if (musicalKeyNode != null)
                {
                    var musicalKey = GetKey(musicalKeyNode.Attributes["VALUE"]);
                    _traktorKeys.TryGetValue(musicalKey, out _key);
                }
            }
        }

        private static string GetPlaylist(string dir)
        {
            string[] directories = dir.Split(new char[] { '\\', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            var directoriesCount = directories.Length;

            return directories[directoriesCount - 1];
        }

        private static int GetLeadingBpm(string tagTitle)
        {
            var leadingBpm = 0;

            if (!string.IsNullOrEmpty(tagTitle))
            {
                if (!IsArtistWithLeadingNumber(tagTitle))
                {
                    var match = Regex.Match(tagTitle, @"^[0-9][0-9][0-9]?", RegexOptions.IgnoreCase);

                    if (match.Success)
                        leadingBpm = Convert.ToInt32(match.Value);
                }
            }

            return leadingBpm;
        }

        private static int GetTrailingBpm(string tagArtist)
        {
            var trailingBpm = 0;

            if (!string.IsNullOrEmpty(tagArtist))
            {
                if (!IsArtistWithLeadingNumber(tagArtist))
                {
                    Match match = Regex.Match(tagArtist, @"^[0-9][0-9][0-9]?", RegexOptions.IgnoreCase);

                    if (match.Success)
                        trailingBpm = Convert.ToInt32(match.Value);
                }
            }

            return trailingBpm;
        }

        private static bool IsArtistWithLeadingNumber(string artistName)
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

        private static string GetAttribute(XmlAttribute xmlAttributes)
        {
            var attribute = string.Empty;

            if (xmlAttributes != null)
            {
                if (xmlAttributes.Value != null)
                    attribute = xmlAttributes.Value;
            }

            return attribute;
        }

        private static int GetBpm(XmlAttribute xmlAttributes)
        {
            decimal bpm = 0;
            Decimal.TryParse(GetAttribute(xmlAttributes), out bpm);

            return (int)Math.Round(bpm, 0);
        }

        private static int GetKey(XmlAttribute xmlAttributes)
        {
            var musicalKey = 0;
            var key = string.Empty;

            Int32.TryParse(GetAttribute(xmlAttributes), out musicalKey);

            return musicalKey;
        }

        public void GetRating()
        {
            if (IsArtistRated())
            {
                _rating += 1;
            }
        }

        private bool IsArtistRated()
        {
            return _ratedArtists.Contains(_artist);
        }
    }
}