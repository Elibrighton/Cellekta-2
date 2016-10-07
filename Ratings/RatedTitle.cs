using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratings
{
    public class RatedTitle : IRatedTitle
    {
        string _artist;
        string _title;

        public string Artist { get { return _artist; } set { _artist = value; } }
        public string Title { get { return _title; } set { _title = value; } }

        public RatedTitle()
        {
        }
    }
}
