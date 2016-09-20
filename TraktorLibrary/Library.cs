using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TraktorLibrary
{
    public class Library : ILibrary
    {
        string _traktorLibraryPath;
        string _tempLibraryPath;
        List<ISong> _music;
        List<string> _ratedArtists = new List<string>();
        string _ratedArtistsPath;

        //public List<ISong> Music { get { return _music; } }

        public Library()
        {
            _traktorLibraryPath = ReadSetting("LibraryPath");
            _tempLibraryPath = string.Concat(System.IO.Path.GetTempPath(), "collection.nml");
            _ratedArtists = GetRatedArtists();
            _ratedArtistsPath = ReadSetting("RatedArtistsPath");
        }

        private List<string> GetRatedArtists()
        {
            List<string> ratedArtists = new List<string>();



            return ratedArtists;
        }

        public void CreateTemp()
        {
            var tempPath = Path.GetTempPath();
            var dir = System.IO.Path.GetDirectoryName(_traktorLibraryPath);

            string[] directories = _traktorLibraryPath.Split(new char[] { '\\', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            var directoriesCount = directories.Length;

            var name = directories[directoriesCount - 1];

            var sourceFile = System.IO.Path.Combine(dir, name);
            _tempLibraryPath = System.IO.Path.Combine(tempPath, name);

            if (!System.IO.Directory.Exists(tempPath))
                System.IO.Directory.CreateDirectory(tempPath);

            System.IO.File.Copy(sourceFile, _tempLibraryPath, true);

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
                    ISong song = new Song(_ratedArtists);
                    song.Populate(entryNode);
                    song.GetRating();

                    if (song.Artist != "Loopmasters" && song.Artist != "Native Instruments" && song.Artist != "Subb-an")
                        _music.Add(song);
                }
            }
        }

        private static string ReadSetting(string key)
        {
            string result = string.Empty;

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

        public bool RatedArtistsExists()
        {
            return File.Exists(_ratedArtistsPath);
        }

        public void CreateRatedArtists()
        {
            try
            {
                using (FileStream fs = File.Create(_ratedArtistsPath))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("<?xml version='1.0' encoding='us-ascii'?>");
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public List<ISong> GetMusic()
        {
            return _music;
        }
    }
}
