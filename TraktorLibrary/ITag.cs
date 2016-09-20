using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraktorLibrary
{
    public interface ITag
    {
        string Artist { get; }
        string Title { get; }
    }
}
