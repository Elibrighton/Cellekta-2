using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratings
{
    public interface IRatedArtists
    {
        List<IRatedArtist> GetRatedArtists();
        bool IsRatedArtist(string artist);
    }
}
