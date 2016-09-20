using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cellekta_2
{
    public class Song
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public int PlayTime { get; set; }
        public string Key { get; set; }
        public int LeadingBpm { get; set; }
        public int TrailingBpm { get; set; }
        public string Playlist { get; set; }

        public static List<string> GetKeyRange(string key)
        {
            var keyRange = new List<string>();

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

            return keyRange;
        }

        public static List<int> GetBpmRange(int bpm)
        {
            var bpmRange = new List<int>();

            var upperBPM = bpm + 3;
            var lowerBPM = bpm - 3;
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

        public static int GetLeadingBpm(string tagTitle)
        {
            var leadingBpm = 0;
            if (!string.IsNullOrEmpty(tagTitle))
            {
                if (!IsArtistWithLeadingNumber(tagTitle))
                {
                    Match match = Regex.Match(tagTitle, @"^[0-9][0-9][0-9]?", RegexOptions.IgnoreCase);

                    if (match.Success)
                        leadingBpm = Convert.ToInt32(match.Value);
                }
            }

            return leadingBpm;
        }

        public static int GetTrailingBpm(string tagArtist)
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

        public static string GetTagTitle(string fullName)
        {
            TagLib.File f = TagLib.File.Create(fullName);

            return f.Tag.Title;

        }

        public static string GetTagArtist(string fullName)
        {
            TagLib.File f = TagLib.File.Create(fullName);

            return f.Tag.FirstArtist;

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
    }
}
