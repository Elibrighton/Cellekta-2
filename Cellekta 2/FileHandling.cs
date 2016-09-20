using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Cellekta_2
{
    public class FileHandling
    {
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

        public static Music ImportCollection(string collectionPath)
        {
            Music music = new Music();

            if (music.collection == null)
                music.collection = new List<Song>();

            XmlDocument doc = new XmlDocument();
            try { doc.Load(collectionPath); }
            catch (Exception ex) { }
            XmlElement root = doc.DocumentElement;

            foreach (XmlNode node in root.SelectNodes("/NML/COLLECTION"))
            {
                foreach (XmlNode entryNode in node.SelectNodes("ENTRY"))
                {
                    var song = ImportSong(entryNode);

                    //if (!song.FullName.Contains("Wedding"))
                    //    continue;

                    if (song.Artist != "Loopmasters" && song.Artist != "Native Instruments" && song.Artist != "Subb-an")
                        music.collection.Add(song);
                }
            }

            return music;
        }

        public static Song ImportSong(XmlNode xmlNode)
        {
            var artist = string.Empty;
            var title = string.Empty;
            var fullName = string.Empty;
            var playTime = 0;
            var key = string.Empty;
            var leadingBpm = 0;
            var trailingBpm = 0;
            var playlist = string.Empty;

            if (xmlNode != null)
            {
                artist = FileHandling.ImportAttribute(xmlNode.Attributes["ARTIST"]);
                title = FileHandling.ImportAttribute(xmlNode.Attributes["TITLE"]);

                XmlNode locationNode = xmlNode.SelectSingleNode("LOCATION");

                var file = string.Empty;

                if (locationNode != null)
                {
                    var dir = FileHandling.ImportAttribute(locationNode.Attributes["DIR"]).Replace("/:", "\\");
                    playlist = GetPlaylist(dir);
                    file = FileHandling.ImportAttribute(locationNode.Attributes["FILE"]);
                    var volume = FileHandling.ImportAttribute(locationNode.Attributes["VOLUME"]);
                    fullName = string.Concat(volume, dir, file);
                }

                XmlNode infoNode = xmlNode.SelectSingleNode("INFO");

                if (infoNode != null)
                    Int32.TryParse(FileHandling.ImportAttribute(infoNode.Attributes["PLAYTIME"]), out playTime);

                if (fullName.Contains(@"C:\Dj Music\Tranny")
                    || fullName.Contains(@"C:\Dj Music\Selections\S_Tranny"))
                {
                    var tagTitle = Song.GetTagTitle(fullName);
                    var tagArtist = Song.GetTagArtist(fullName);
                    leadingBpm = Song.GetLeadingBpm(tagTitle);
                    trailingBpm = Song.GetTrailingBpm(tagArtist);
                }

                if (leadingBpm == 0)
                {
                    XmlNode tempoNode = xmlNode.SelectSingleNode("TEMPO");

                    if (tempoNode != null)
                        leadingBpm = FileHandling.ImportBpm(tempoNode.Attributes["BPM"]);
                }

                XmlNode musicalKeyNode = xmlNode.SelectSingleNode("MUSICAL_KEY");

                if (musicalKeyNode != null)
                {
                    key = FileHandling.ImportKey(musicalKeyNode.Attributes["VALUE"]);
                }
            }

            return new Song
            {
                Artist = artist,
                Title = title,
                FullName = fullName,
                PlayTime = playTime,
                Key = key,
                LeadingBpm = leadingBpm,
                TrailingBpm = trailingBpm,
                Playlist = playlist,
            };
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

        public static string GetPlaylist(string dir)
        {
            string[] directories = dir.Split(new char[] { '\\', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            var directoriesCount = directories.Length;

            return directories[directoriesCount - 1];
        }

        public static int ImportBpm(XmlAttribute xmlAttributes)
        {
            decimal bpm = 0;
            Decimal.TryParse(FileHandling.ImportAttribute(xmlAttributes), out bpm);

            return (int)Math.Round(bpm, 0);
        }

        public static string ImportKey(XmlAttribute xmlAttributes)
        {
            var musicalKey = 0;
            var key = string.Empty;

            Int32.TryParse(FileHandling.ImportAttribute(xmlAttributes), out musicalKey);
            traktorKeys.TryGetValue(musicalKey, out key);

            return key;
        }

        public static string CreateTempCollection(string fileName)
        {
            var tempPath = Path.GetTempPath();
            var dir = System.IO.Path.GetDirectoryName(fileName);

            string[] directories = fileName.Split(new char[] { '\\', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            var directoriesCount = directories.Length;

            var name = directories[directoriesCount - 1];

            var sourceFile = System.IO.Path.Combine(dir, name);
            var destFile = System.IO.Path.Combine(tempPath, name);

            if (!System.IO.Directory.Exists(tempPath))
                System.IO.Directory.CreateDirectory(tempPath);

            System.IO.File.Copy(sourceFile, destFile, true);

            return destFile;
        }

        public static bool DeleteTempCollection()
        {
            var tempPath = Path.GetTempPath();
            var tempCollection = String.Concat(tempPath, "collection.nml");

            File.Delete(tempCollection);

            return !File.Exists(tempCollection);
        }
    }
}
