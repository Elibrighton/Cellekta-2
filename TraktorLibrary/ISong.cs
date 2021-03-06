﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TraktorLibrary
{
    public interface ISong
    {
        string Artist { get; }
        string Title { get; }
        string Playlist { get; }
        string FullName { get; }
        int PlayTime { get; }
        int LeadingBpm { get; }
        int TrailingBpm { get; }
        string LeadingKey { get; }
        string TrailingKey { get; }
        int Intensity { get; }
        void Populate(XmlNode xmlNode);
        void GetRating();
        int Rating { get; set; }
    }
}
