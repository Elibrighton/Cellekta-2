using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratings
{
    public class RatedArtist : IRatedArtist
    {
        string _artist;

        public string Artist { get { return _artist; } set { _artist = value; } }
    }
}
