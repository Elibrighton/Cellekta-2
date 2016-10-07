using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratings
{
    public interface IRatedTitles
    {
        List<IRatedTitle> GetRatedTitles();
        bool IsRatedTitle(string artist, string title);
    }
}
