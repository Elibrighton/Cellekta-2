using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraktorLibrary
{
    public interface ILibrary
    {
        bool DeleteTemp();
        void CreateTemp();
        bool TraktorExists();
        bool TempExists();
        void Import();
        List<string> GetPlaylists();
        List<string> GetKeys();
        List<string> GetBpms();
        List<ISong> Music { get; }
        Dictionary<string, int> GetKeyDictionary();
        Dictionary<int, int> GetBpmDictionary();
    }
}
