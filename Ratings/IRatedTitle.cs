using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratings
{
    public interface IRatedTitle
    {
        string Artist { get; set; }
        string Title { get; set; }
    }
}
