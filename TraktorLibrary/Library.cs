using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml;

namespace TraktorLibrary
{
    public class Library : ILibrary
    {
        private string _traktorLibraryPath;
        private string _tempLibraryPath;
        private List<ISong> _music;

        public Library(List<ISong> music)
        {
            _music = music;
            _traktorLibraryPath = ReadSetting("LibraryPath");
            _tempLibraryPath = string.Concat(System.IO.Path.GetTempPath(), "collection.nml");
        }
        
        public List<ISong> Music { get { return _music; } }

        public static Dictionary<int, string> traktorKeys = new Dictionary<int, string>()
        {
            { 0, "1d" },
            { 1, "8d" },
            { 2, "3d" },
            { 3, "10d" },
            { 4, "5d" },
            { 5, "12d" },
            { 6, "7d" },
            { 7, "2d" },
            { 8, "9d" },
            { 9, "4d" },
            { 10, "11d" },
            { 11, "6d" },
            { 12, "10m" },
            { 13, "5m" },
            { 14, "12m" },
            { 15, "7m" },
            { 16, "2m" },
            { 17, "9m" },
            { 18, "4m" },
            { 19, "11m" },
            { 20, "6m" },
            { 21, "1m" },
            { 22, "8m" },
            { 23, "3m" }
        };

        public void CreateTemp()
        {
            var tempPath = Path.GetTempPath();
            var dir = Path.GetDirectoryName(_traktorLibraryPath);

            string[] directories = _traktorLibraryPath.Split(new char[] { '\\', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            var directoriesCount = directories.Length;

            var name = directories[directoriesCount - 1];

            var sourceFile = Path.Combine(dir, name);
            _tempLibraryPath = Path.Combine(tempPath, name);

            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);

            File.Copy(sourceFile, _tempLibraryPath, true);

            return;
        }

        public bool DeleteTemp()
        {
            if (File.Exists(_tempLibraryPath))
                File.Delete(_tempLibraryPath);

            return !File.Exists(_tempLibraryPath);
        }

        public bool TraktorExists()
        {
            return File.Exists(_traktorLibraryPath);
        }

        public bool TempExists()
        {
            return File.Exists(_tempLibraryPath);
        }

        public void Import()
        {
            if (_music == null)
                _music = new List<ISong>();
            
            XmlDocument doc = new XmlDocument();
            try { doc.Load(_tempLibraryPath); }
            catch (Exception ex) { }
            XmlElement root = doc.DocumentElement;

            foreach (XmlNode node in root.SelectNodes("/NML/COLLECTION"))
            {
                foreach (XmlNode entryNode in node.SelectNodes("ENTRY"))
                {
                    ISong song = new Song();
                    song.Populate(entryNode);
                    song.GetRating();

                    if (song.Artist != "Loopmasters" 
                        && song.Artist != "Native Instruments" 
                        && song.Artist != "Subb-an")
                        _music.Add(song);
                }
            }
        }

        private static string ReadSetting(string key)
        {
            var result = string.Empty;

            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? "Not Found";
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }

            return result;
        }
        
        public List<string> GetPlaylists()
        {
            List<string> playlists = new List<string>();

            if (_music != null)
            {
                var orderedMusic = _music.OrderBy(song => song.Playlist);

                foreach (ISong song in orderedMusic)
                {
                    var playlist = song.Playlist;

                    if (!playlists.Contains(playlist))
                        playlists.Add(playlist);
                }
            }

            return playlists;
        }

        public List<string> GetKeys()
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

            var orderedMusic = _music.OrderBy(song => song.Key);

            foreach (ISong song in orderedMusic)
            {
                var key = song.Key;

                if (!string.IsNullOrEmpty(key))
                {
                    if (!keys.ContainsKey(key))
                        keys.Add(key, keys.Count + 1);
                }
            }

            // fix the sort order of the keys

            return keys;
        }

        public List<string> GetBpms()
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
            Dictionary<int, int> bpmDictionary = new Dictionary<int, int>(); // turn into class property

            var orderedMusic = _music.OrderBy(song => song.LeadingBpm);

            foreach (ISong song in orderedMusic)
            {
                var bpm = song.LeadingBpm;

                if (!bpmDictionary.ContainsKey(bpm) && bpm != 0)
                    bpmDictionary.Add(bpm, bpmDictionary.Count + 1);
            }

            return bpmDictionary;
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

        public static int GetRandomRow(int rowCount)
        {
            var nextRow = string.Empty;

            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int n = 0;

            while (n == 0)
                n = rand.Next(rowCount);

            return n;
        }

        public static string GetPlaylist(string dir)
        {
            string[] directories = dir.Split(new char[] { '\\', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            var directoriesCount = directories.Length;

            return directories[directoriesCount - 1];
        }

        public static string ImportAttribute(XmlAttribute xmlAttributes)
        {
            string artist = string.Empty;

            if (xmlAttributes != null)
            {
                if (xmlAttributes.Value != null)
                    artist = xmlAttributes.Value;
            }

            return artist;
        }

        public static int ImportBpm(XmlAttribute xmlAttributes)
        {
            decimal bpm = 0;
            decimal.TryParse(ImportAttribute(xmlAttributes), out bpm);

            return (int)Math.Round(bpm, 0);
        }

        public static string ImportKey(XmlAttribute xmlAttributes)
        {
            var musicalKey = 0;
            var key = string.Empty;

            int.TryParse(ImportAttribute(xmlAttributes), out musicalKey);
            traktorKeys.TryGetValue(musicalKey, out key);

            return key;
        }

        public static string CreateTempCollection(string fileName)
        {
            var tempPath = Path.GetTempPath();
            var dir = Path.GetDirectoryName(fileName);

            string[] directories = fileName.Split(new char[] { '\\', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            var directoriesCount = directories.Length;

            var name = directories[directoriesCount - 1];

            var sourceFile = Path.Combine(dir, name);
            var destFile = Path.Combine(tempPath, name);

            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);

            File.Copy(sourceFile, destFile, true);

            return destFile;
        }

        public static bool DeleteTempCollection()
        {
            var tempPath = Path.GetTempPath();
            var tempCollection = string.Concat(tempPath, "collection.nml");

            File.Delete(tempCollection);

            return !File.Exists(tempCollection);
        }
    }
}
