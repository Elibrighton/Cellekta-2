using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraktorLibrary
{
    public class Tag : ITag
    {
        string _fullName;
        string _title;
        string _artist;
        TagLib.File _f;

        public string Artist { get { return _artist; } }
        public string Title { get { return _title; } }

        public Tag(string fullName)
        {
            _fullName = fullName;
            _f = TagLib.File.Create(_fullName);
            _title = _f.Tag.Title;
            _artist = _f.Tag.FirstArtist;
        }
    }
}
