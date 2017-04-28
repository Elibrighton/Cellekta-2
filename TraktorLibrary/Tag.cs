using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TraktorLibrary
{
    public class Tag : ITag
    {
        string fullName;
        string title;
        string artist;
        TagLib.File file;

        public string Artist { get { return artist; } }
        public string Title { get { return title; } }

        public Tag(string fullName)
        {
            if (string.IsNullOrEmpty(fullName)) throw new ArgumentNullException("fullName is null or empty");

            this.fullName = fullName;
            file = TagLib.File.Create(this.fullName);
            title = file.Tag.Title;
            artist = file.Tag.FirstArtist;
        }

        public int GetBpm(string tagName)
        {
            if (string.IsNullOrEmpty(tagName)) throw new ArgumentNullException("tagName is null or empty");

            var bpm = 0;

            if (!Song.IsArtistWithLeadingNumber(tagName))
            {
                var match = Regex.Match(tagName, @"^[0-9][0-9][0-9]?", RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    bpm = Convert.ToInt32(match.Value);
                }
            }

            return bpm;
        }
    }
}
