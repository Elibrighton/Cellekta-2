using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellekta_2
{
    public class Music
    {
        public List<Song> collection { get; set; }

        public List<string> GetPlaylistsList()
        {
            List<string> playlists = new List<string>();

            var musicOrderedByPlaylist = collection.OrderBy(song => song.Playlist);

            foreach (Song track in musicOrderedByPlaylist)
            {
                var playlist = track.Playlist;

                if (!playlists.Contains(playlist))
                    playlists.Add(playlist);
            }

            return playlists;
        }

        public List<string> GetKeyList()
        {
            var keys = new List<string>();

            var keyDictionary = GetKeyDictionary();

            foreach (var item in keyDictionary)
            {
                if (!string.IsNullOrEmpty(item.Key))
                {
                    var key = item.Key.ToString();

                    if (!keys.Contains(key))
                        keys.Add(key);
                }
            }

            return keys;
        }

        public Dictionary<string, int> GetKeyDictionary()
        {
            Dictionary<string, int> keys = new Dictionary<string, int>();
            
            var musicOrderedByKey = collection.OrderBy(song => song.Key);

            foreach (Song track in musicOrderedByKey)
            {
                var key = track.Key;

                if (!string.IsNullOrEmpty(key))
                {
                    if (!keys.ContainsKey(key))
                        keys.Add(key, keys.Count + 1);
                }
            }

            // fix the sort order of the keys

            return keys;
        }

        public List<string> GetBpmList()
        {
            var bpms = new List<string>();

            var bpmDictionary = GetBpmDictionary();

            foreach (var item in bpmDictionary)
            {
                if (item.Key != 0)
                {
                    var bpm = item.Key.ToString();

                    if (!bpms.Contains(bpm))
                        bpms.Add(bpm);
                }
            }

            return bpms;
        }
        
        public Dictionary<int, int> GetBpmDictionary()
        {
            Dictionary<int, int> bpmDictionary = new Dictionary<int, int>();

            var musicOrderedByBpm = collection.OrderBy(song => song.LeadingBpm);

            foreach (Song track in musicOrderedByBpm)
            {
                var bpm = track.LeadingBpm;

                if (!bpmDictionary.ContainsKey(bpm) && bpm != 0)
                    bpmDictionary.Add(bpm, bpmDictionary.Count + 1);
            }

            return bpmDictionary;
        }

        public static int GetRandomRow(int rowCount)
        {
            var nextRow = string.Empty;

            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int n = 0;

            while (n == 0)
                n = rand.Next(rowCount);

            return n;
        }

        public static string GetRandomKey(Dictionary<string, int> keyDictionary)
        {
            var nextKey = string.Empty;

            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int n = 0;

            while (n == 0)
                n = rand.Next(keyDictionary.Count);

            var count = 0;

            foreach (string item in keyDictionary.Keys)
            {
                if (count == n)
                {
                    nextKey = item;
                    break;
                }
                count++;
            }

            return nextKey;
        }

        public static int GetRandomBpm(Dictionary<int, int> bpmDictionary)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int n = 0;

            while (n == 0)
                n = rand.Next(bpmDictionary.Count);

            var randomBeat = 0;
            var count = 0;

            foreach (int item in bpmDictionary.Keys)
            {
                if (count == n)
                {
                    randomBeat = item;
                    break;
                }
                count++;
            }

            return randomBeat;
        }
    }
}
