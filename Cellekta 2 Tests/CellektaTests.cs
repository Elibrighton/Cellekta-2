using Cellekta_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System;
using System.IO;
using System.Collections.Generic;

namespace Cellekta_2_Tests
{
    [TestClass]
    public class CellektaTests
    {
        [TestMethod]
        public void GetPlaylist_PlaylistReturned_Test()
        {
            var testDir = "\\Dj Music\\Dance\\";

            var testPlaylist = FileHandling.GetPlaylist(testDir);

            Assert.IsTrue(testPlaylist == "Dance");
        }

        [TestMethod]
        public void ImportArtist_ArtistReturned_Test()
        {
            var testArtist = string.Empty;

            string collection = @"<COLLECTION ENTRIES=""39452""><ENTRY MODIFIED_DATE=""2015 / 1 / 10"" MODIFIED_TIME=""36660"" AUDIO_ID=""AWY1REVURGplREVUeZqYd3h3eMl3d4eImcudqequvtm8m8nMzcrbnrrr7avazazt7KzJ667O6q2r2s / uyLp8p9utmMicitzNvMrcrt3rrarav + 7s3c3b7t / b7M / c / O672s2t / eytuv3P3evOvevv79vsv8z + 7s3s7s7d / b267L / u2Ix5x6ydp7p8p9zNq9m9m9zrrMrbru7sravsvry6qpq6qr3K2666 + 92r2s2t7P2duvuv3fzOvfze79rcr8r937vazt3 + 7b7b7b / u6q2r2s7e3O3O3P3fy + rOvf7qh4mZqavJqZqZvN2ph4hoeKh4dndnabdlRERDNEQzREMzMA == "" TITLE=""To The Beat!(Original Mix)"" ARTIST=""Sharam Jey""><LOCATION DIR=""/:Dj Music/:Dance/:"" FILE=""Sharam Jey - To The Beat! (Original Mix).mp3"" VOLUME=""C:"" VOLUMEID=""defbd1ba""></LOCATION><INFO BITRATE=""320000"" GENRE=""Progressive House, Deep House, Tech House, Electro House, Indie Dance / Nu Disco"" COVERARTID=""037/FFOYCSCS0YMCZAYXI1F5ACKPEYXB"" KEY=""4m"" PLAYTIME=""359"" PLAYTIME_FLOAT=""358.191"" IMPORT_DATE=""2015/8/13"" RELEASE_DATE=""2014/1/1"" FLAGS=""14"" FILESIZE=""14118""></INFO><TEMPO BPM=""118"" BPM_QUALITY=""100""></TEMPO><MUSICAL_KEY VALUE=""18""></MUSICAL_KEY></ENTRY></COLLECTION>";

            XmlDocument xm = new XmlDocument();
            xm.LoadXml(collection);

            XmlElement root = xm.DocumentElement;

            foreach (XmlNode entryNode in root.SelectNodes("ENTRY"))
            {
                if (entryNode != null)
                    testArtist = FileHandling.ImportAttribute(entryNode.Attributes["ARTIST"]);
            }

            Assert.IsTrue(testArtist == "Sharam Jey");
        }

        [TestMethod]
        public void ImportTitle_TitleReturned_Test()
        {
            var testTitle = string.Empty;

            string collection = @"<COLLECTION ENTRIES=""39452""><ENTRY MODIFIED_DATE=""2015 / 1 / 10"" MODIFIED_TIME=""36660"" AUDIO_ID=""AWY1REVURGplREVUeZqYd3h3eMl3d4eImcudqequvtm8m8nMzcrbnrrr7avazazt7KzJ667O6q2r2s / uyLp8p9utmMicitzNvMrcrt3rrarav + 7s3c3b7t / b7M / c / O672s2t / eytuv3P3evOvevv79vsv8z + 7s3s7s7d / b267L / u2Ix5x6ydp7p8p9zNq9m9m9zrrMrbru7sravsvry6qpq6qr3K2666 + 92r2s2t7P2duvuv3fzOvfze79rcr8r937vazt3 + 7b7b7b / u6q2r2s7e3O3O3P3fy + rOvf7qh4mZqavJqZqZvN2ph4hoeKh4dndnabdlRERDNEQzREMzMA == "" TITLE=""To The Beat!(Original Mix)"" ARTIST=""Sharam Jey""><LOCATION DIR=""/:Dj Music/:Dance/:"" FILE=""Sharam Jey - To The Beat! (Original Mix).mp3"" VOLUME=""C:"" VOLUMEID=""defbd1ba""></LOCATION><INFO BITRATE=""320000"" GENRE=""Progressive House, Deep House, Tech House, Electro House, Indie Dance / Nu Disco"" COVERARTID=""037/FFOYCSCS0YMCZAYXI1F5ACKPEYXB"" KEY=""4m"" PLAYTIME=""359"" PLAYTIME_FLOAT=""358.191"" IMPORT_DATE=""2015/8/13"" RELEASE_DATE=""2014/1/1"" FLAGS=""14"" FILESIZE=""14118""></INFO><TEMPO BPM=""118"" BPM_QUALITY=""100""></TEMPO><MUSICAL_KEY VALUE=""18""></MUSICAL_KEY></ENTRY></COLLECTION>";

            XmlDocument xm = new XmlDocument();
            xm.LoadXml(collection);

            XmlElement root = xm.DocumentElement;

            foreach (XmlNode entryNode in root.SelectNodes("ENTRY"))
            {
                if (entryNode != null)
                    testTitle = FileHandling.ImportAttribute(entryNode.Attributes["TITLE"]);
            }

            Assert.IsTrue(testTitle == "To The Beat!(Original Mix)");
        }

        [TestMethod]
        public void ImportFullName_FullNameReturned_Test()
        {
            var testDir = string.Empty;
            var testFile = string.Empty;
            var testVolume = string.Empty;
            var testFullName = string.Empty;

            string collection = @"<COLLECTION ENTRIES=""39452""><ENTRY MODIFIED_DATE=""2015 / 1 / 10"" MODIFIED_TIME=""36660"" AUDIO_ID=""AWY1REVURGplREVUeZqYd3h3eMl3d4eImcudqequvtm8m8nMzcrbnrrr7avazazt7KzJ667O6q2r2s / uyLp8p9utmMicitzNvMrcrt3rrarav + 7s3c3b7t / b7M / c / O672s2t / eytuv3P3evOvevv79vsv8z + 7s3s7s7d / b267L / u2Ix5x6ydp7p8p9zNq9m9m9zrrMrbru7sravsvry6qpq6qr3K2666 + 92r2s2t7P2duvuv3fzOvfze79rcr8r937vazt3 + 7b7b7b / u6q2r2s7e3O3O3P3fy + rOvf7qh4mZqavJqZqZvN2ph4hoeKh4dndnabdlRERDNEQzREMzMA == "" TITLE=""To The Beat!(Original Mix)"" ARTIST=""Sharam Jey""><LOCATION DIR=""/:Dj Music/:Dance/:"" FILE=""Sharam Jey - To The Beat! (Original Mix).mp3"" VOLUME=""C:"" VOLUMEID=""defbd1ba""></LOCATION><INFO BITRATE=""320000"" GENRE=""Progressive House, Deep House, Tech House, Electro House, Indie Dance / Nu Disco"" COVERARTID=""037/FFOYCSCS0YMCZAYXI1F5ACKPEYXB"" KEY=""4m"" PLAYTIME=""359"" PLAYTIME_FLOAT=""358.191"" IMPORT_DATE=""2015/8/13"" RELEASE_DATE=""2014/1/1"" FLAGS=""14"" FILESIZE=""14118""></INFO><TEMPO BPM=""118"" BPM_QUALITY=""100""></TEMPO><MUSICAL_KEY VALUE=""18""></MUSICAL_KEY></ENTRY></COLLECTION>";

            XmlDocument xm = new XmlDocument();
            xm.LoadXml(collection);

            XmlElement root = xm.DocumentElement;

            foreach (XmlNode entryNode in root.SelectNodes("ENTRY"))
            {
                if (entryNode != null)
                {
                    XmlNode locationNode = entryNode.SelectSingleNode("LOCATION");

                    if (locationNode != null)
                    {
                        testDir = FileHandling.ImportAttribute(locationNode.Attributes["DIR"]).Replace("/:", "\\");
                        testFile = FileHandling.ImportAttribute(locationNode.Attributes["FILE"]);
                        testVolume = FileHandling.ImportAttribute(locationNode.Attributes["VOLUME"]);
                        testFullName = string.Concat(testVolume, testDir, testFile);
                    }
                }
            }

            Assert.IsTrue(testDir == "\\Dj Music\\Dance\\");
            Assert.IsTrue(testFile == "Sharam Jey - To The Beat! (Original Mix).mp3");
            Assert.IsTrue(testVolume == "C:");
            Assert.IsTrue(testFullName == "C:\\Dj Music\\Dance\\Sharam Jey - To The Beat! (Original Mix).mp3");
        }

        [TestMethod]
        public void ImportPlayTime_PlayTimeReturned_Test()
        {
            var testPlayTime = 0;

            string collection = @"<COLLECTION ENTRIES=""39452""><ENTRY MODIFIED_DATE=""2015 / 1 / 10"" MODIFIED_TIME=""36660"" AUDIO_ID=""AWY1REVURGplREVUeZqYd3h3eMl3d4eImcudqequvtm8m8nMzcrbnrrr7avazazt7KzJ667O6q2r2s / uyLp8p9utmMicitzNvMrcrt3rrarav + 7s3c3b7t / b7M / c / O672s2t / eytuv3P3evOvevv79vsv8z + 7s3s7s7d / b267L / u2Ix5x6ydp7p8p9zNq9m9m9zrrMrbru7sravsvry6qpq6qr3K2666 + 92r2s2t7P2duvuv3fzOvfze79rcr8r937vazt3 + 7b7b7b / u6q2r2s7e3O3O3P3fy + rOvf7qh4mZqavJqZqZvN2ph4hoeKh4dndnabdlRERDNEQzREMzMA == "" TITLE=""To The Beat!(Original Mix)"" ARTIST=""Sharam Jey""><LOCATION DIR=""/:Dj Music/:Dance/:"" FILE=""Sharam Jey - To The Beat! (Original Mix).mp3"" VOLUME=""C:"" VOLUMEID=""defbd1ba""></LOCATION><INFO BITRATE=""320000"" GENRE=""Progressive House, Deep House, Tech House, Electro House, Indie Dance / Nu Disco"" COVERARTID=""037/FFOYCSCS0YMCZAYXI1F5ACKPEYXB"" KEY=""4m"" PLAYTIME=""359"" PLAYTIME_FLOAT=""358.191"" IMPORT_DATE=""2015/8/13"" RELEASE_DATE=""2014/1/1"" FLAGS=""14"" FILESIZE=""14118""></INFO><TEMPO BPM=""118"" BPM_QUALITY=""100""></TEMPO><MUSICAL_KEY VALUE=""18""></MUSICAL_KEY></ENTRY></COLLECTION>";

            XmlDocument xm = new XmlDocument();
            xm.LoadXml(collection);

            XmlElement root = xm.DocumentElement;

            foreach (XmlNode entryNode in root.SelectNodes("ENTRY"))
            {
                if (entryNode != null)
                {
                    XmlNode infoNode = entryNode.SelectSingleNode("INFO");

                    if (infoNode != null)
                        Int32.TryParse(FileHandling.ImportAttribute(infoNode.Attributes["PLAYTIME"]), out testPlayTime);
                }
            }

            Assert.IsTrue(testPlayTime == 359);
        }

        [TestMethod]
        public void ImportBpm_BpmReturned_Test()
        {
            var testBpm = 0;

            string collection = @"<COLLECTION ENTRIES=""39452""><ENTRY MODIFIED_DATE=""2015 / 1 / 10"" MODIFIED_TIME=""36660"" AUDIO_ID=""AWY1REVURGplREVUeZqYd3h3eMl3d4eImcudqequvtm8m8nMzcrbnrrr7avazazt7KzJ667O6q2r2s / uyLp8p9utmMicitzNvMrcrt3rrarav + 7s3c3b7t / b7M / c / O672s2t / eytuv3P3evOvevv79vsv8z + 7s3s7s7d / b267L / u2Ix5x6ydp7p8p9zNq9m9m9zrrMrbru7sravsvry6qpq6qr3K2666 + 92r2s2t7P2duvuv3fzOvfze79rcr8r937vazt3 + 7b7b7b / u6q2r2s7e3O3O3P3fy + rOvf7qh4mZqavJqZqZvN2ph4hoeKh4dndnabdlRERDNEQzREMzMA == "" TITLE=""To The Beat!(Original Mix)"" ARTIST=""Sharam Jey""><LOCATION DIR=""/:Dj Music/:Dance/:"" FILE=""Sharam Jey - To The Beat! (Original Mix).mp3"" VOLUME=""C:"" VOLUMEID=""defbd1ba""></LOCATION><INFO BITRATE=""320000"" GENRE=""Progressive House, Deep House, Tech House, Electro House, Indie Dance / Nu Disco"" COVERARTID=""037/FFOYCSCS0YMCZAYXI1F5ACKPEYXB"" KEY=""4m"" PLAYTIME=""359"" PLAYTIME_FLOAT=""358.191"" IMPORT_DATE=""2015/8/13"" RELEASE_DATE=""2014/1/1"" FLAGS=""14"" FILESIZE=""14118""></INFO><TEMPO BPM=""118"" BPM_QUALITY=""100""></TEMPO><MUSICAL_KEY VALUE=""18""></MUSICAL_KEY></ENTRY></COLLECTION>";

            XmlDocument xm = new XmlDocument();
            xm.LoadXml(collection);

            XmlElement root = xm.DocumentElement;

            foreach (XmlNode entryNode in root.SelectNodes("ENTRY"))
            {
                if (entryNode != null)
                {
                    XmlNode tempoNode = entryNode.SelectSingleNode("TEMPO");

                    if (tempoNode != null)
                        testBpm = FileHandling.ImportBpm(tempoNode.Attributes["BPM"]);
                }
            }

            Assert.IsTrue(testBpm == 118);
        }

        [TestMethod]
        public void ImportKey_KeyReturned_Test()
        {
            var testKey = string.Empty;

            string collection = @"<COLLECTION ENTRIES=""39452""><ENTRY MODIFIED_DATE=""2015 / 1 / 10"" MODIFIED_TIME=""36660"" AUDIO_ID=""AWY1REVURGplREVUeZqYd3h3eMl3d4eImcudqequvtm8m8nMzcrbnrrr7avazazt7KzJ667O6q2r2s / uyLp8p9utmMicitzNvMrcrt3rrarav + 7s3c3b7t / b7M / c / O672s2t / eytuv3P3evOvevv79vsv8z + 7s3s7s7d / b267L / u2Ix5x6ydp7p8p9zNq9m9m9zrrMrbru7sravsvry6qpq6qr3K2666 + 92r2s2t7P2duvuv3fzOvfze79rcr8r937vazt3 + 7b7b7b / u6q2r2s7e3O3O3P3fy + rOvf7qh4mZqavJqZqZvN2ph4hoeKh4dndnabdlRERDNEQzREMzMA == "" TITLE=""To The Beat!(Original Mix)"" ARTIST=""Sharam Jey""><LOCATION DIR=""/:Dj Music/:Dance/:"" FILE=""Sharam Jey - To The Beat! (Original Mix).mp3"" VOLUME=""C:"" VOLUMEID=""defbd1ba""></LOCATION><INFO BITRATE=""320000"" GENRE=""Progressive House, Deep House, Tech House, Electro House, Indie Dance / Nu Disco"" COVERARTID=""037/FFOYCSCS0YMCZAYXI1F5ACKPEYXB"" KEY=""4m"" PLAYTIME=""359"" PLAYTIME_FLOAT=""358.191"" IMPORT_DATE=""2015/8/13"" RELEASE_DATE=""2014/1/1"" FLAGS=""14"" FILESIZE=""14118""></INFO><TEMPO BPM=""118"" BPM_QUALITY=""100""></TEMPO><MUSICAL_KEY VALUE=""18""></MUSICAL_KEY></ENTRY></COLLECTION>";

            XmlDocument xm = new XmlDocument();
            xm.LoadXml(collection);

            XmlElement root = xm.DocumentElement;

            foreach (XmlNode entryNode in root.SelectNodes("ENTRY"))
            {
                if (entryNode != null)
                {
                    XmlNode musicalKeyNode = entryNode.SelectSingleNode("MUSICAL_KEY");

                    if (musicalKeyNode != null)
                        testKey = FileHandling.ImportKey(musicalKeyNode.Attributes["VALUE"]);
                }
            }

            Assert.IsTrue(testKey == "4m");
        }

        [TestMethod]
        public void ImportSong_SongReturned_Test()
        {
            var song = new Song();

            string collection = @"<COLLECTION ENTRIES=""39452""><ENTRY MODIFIED_DATE=""2015 / 1 / 10"" MODIFIED_TIME=""36660"" AUDIO_ID=""AWY1REVURGplREVUeZqYd3h3eMl3d4eImcudqequvtm8m8nMzcrbnrrr7avazazt7KzJ667O6q2r2s / uyLp8p9utmMicitzNvMrcrt3rrarav + 7s3c3b7t / b7M / c / O672s2t / eytuv3P3evOvevv79vsv8z + 7s3s7s7d / b267L / u2Ix5x6ydp7p8p9zNq9m9m9zrrMrbru7sravsvry6qpq6qr3K2666 + 92r2s2t7P2duvuv3fzOvfze79rcr8r937vazt3 + 7b7b7b / u6q2r2s7e3O3O3P3fy + rOvf7qh4mZqavJqZqZvN2ph4hoeKh4dndnabdlRERDNEQzREMzMA == "" TITLE=""To The Beat!(Original Mix)"" ARTIST=""Sharam Jey""><LOCATION DIR=""/:Dj Music/:Dance/:"" FILE=""Sharam Jey - To The Beat! (Original Mix).mp3"" VOLUME=""C:"" VOLUMEID=""defbd1ba""></LOCATION><INFO BITRATE=""320000"" GENRE=""Progressive House, Deep House, Tech House, Electro House, Indie Dance / Nu Disco"" COVERARTID=""037/FFOYCSCS0YMCZAYXI1F5ACKPEYXB"" KEY=""4m"" PLAYTIME=""359"" PLAYTIME_FLOAT=""358.191"" IMPORT_DATE=""2015/8/13"" RELEASE_DATE=""2014/1/1"" FLAGS=""14"" FILESIZE=""14118""></INFO><TEMPO BPM=""118"" BPM_QUALITY=""100""></TEMPO><MUSICAL_KEY VALUE=""18""></MUSICAL_KEY></ENTRY></COLLECTION>";

            XmlDocument xm = new XmlDocument();
            xm.LoadXml(collection);

            XmlElement root = xm.DocumentElement;

            foreach (XmlNode entryNode in root.SelectNodes("ENTRY"))
            {
                song = FileHandling.ImportSong(entryNode);
            }

            Assert.IsNotNull(song);
            Assert.IsTrue(song.Artist == "Sharam Jey");
            Assert.IsTrue(song.Title == "To The Beat!(Original Mix)");
            Assert.IsTrue(song.FullName == "C:\\Dj Music\\Dance\\Sharam Jey - To The Beat! (Original Mix).mp3");
            Assert.IsTrue(song.PlayTime == 359);
            Assert.IsTrue(song.LeadingBpm == 118);
            Assert.IsTrue(song.Key == "4m");

        }

        [TestMethod]
        public void ImportCollection_CollectionReturned_Test()
        {
            var testTempCollection = "C:\\Users\\Dj Music\\AppData\\Local\\Temp\\collection.nml";

            CreateTempCollection_FileCreated_Test();

            var testMusic = FileHandling.ImportCollection(testTempCollection);

            Assert.IsNotNull(testMusic);
        }

        [TestMethod]
        public void CreateTempCollection_FileCreated_Test()
        {
            var testFileName = "C:\\Users\\Dj Music\\Documents\\Native Instruments\\Traktor 2.9.0\\collection.nml";
            var testTempFileName = string.Empty;

            testTempFileName = FileHandling.CreateTempCollection(testFileName);

            Assert.IsTrue(testTempFileName == "C:\\Users\\Dj Music\\AppData\\Local\\Temp\\collection.nml");
            Assert.IsTrue(File.Exists(testTempFileName));
        }

        [TestMethod]
        public void DeleteTempCollection_FileDeleted_Test()
        {
            var testTempCollection = "C:\\Users\\Dj Music\\AppData\\Local\\Temp\\collection.nml";

            CreateTempCollection_FileCreated_Test();

            Assert.IsTrue(File.Exists(testTempCollection));

            var testCollectionDeleted = FileHandling.DeleteTempCollection();

            Assert.IsTrue(testCollectionDeleted);
            Assert.IsFalse(File.Exists(testTempCollection));
        }

        [TestMethod]
        public void GetPlaylistList_ListReturned_Test()
        {
            Music testMusic = new Music();

            if (testMusic.collection == null)
                testMusic.collection = new List<Song>();

            testMusic.collection.Add(new Song { Artist = "", LeadingBpm = 128, FullName = "C:\\Dj Music\\Electro house\\#OMW2SYPYRAMIDS (Sharkweek Bootleg).mp3", Key = "9m", Playlist = "Electro house", PlayTime = 216, Title = "#OMW2SYPYRAMIDS (Sharkweek Bootleg)" });
            testMusic.collection.Add(new Song { Artist = "20 Fingers vs. Massivedrum", LeadingBpm = 128, FullName = "C:\\Dj Music\\Electro house\\20 Fingers vs. Massivedrum - Short Dick Man (DJ Jerias vs. John Karoll Mashup).mp3", Key = "3m", Playlist = "Electro house", PlayTime = 236, Title = "Short Dick Man (DJ Jerias vs. John Karoll Mashup)" });
            testMusic.collection.Add(new Song { Artist = "100 2 Chainz Vs Run DMC", LeadingBpm = 100, FullName = "C:\\Dj Music\\Tranny\\2 Chainz Vs Run DMC - Im Different (Dynamiq Tranny Edit 106-100bpm) (Fashen Booty Mash) [Dirty].mp3", Key = "12d", Playlist = "Tranny", PlayTime = 211, Title = "106 Im Different (Dynamiq Tranny Edit 106-100bpm) (Fashen Booty Mash) [Dirty]" });

            var testPlaylists = testMusic.GetPlaylistsList();

            Assert.IsNotNull(testPlaylists);
            Assert.IsTrue(testPlaylists.Count == 2);
            Assert.IsTrue(testPlaylists[0] == "Electro house");
            Assert.IsTrue(testPlaylists[1] == "Tranny");
        }

        [TestMethod]
        public void GetKeyList_ListReturned_Test()
        {
            Music testMusic = new Music();

            if (testMusic.collection == null)
                testMusic.collection = new List<Song>();

            testMusic.collection.Add(new Song { Artist = "", LeadingBpm = 128, FullName = "C:\\Dj Music\\Electro house\\#OMW2SYPYRAMIDS (Sharkweek Bootleg).mp3", Key = "9m", Playlist = "Electro house", PlayTime = 216, Title = "#OMW2SYPYRAMIDS (Sharkweek Bootleg)" });
            testMusic.collection.Add(new Song { Artist = "20 Fingers vs. Massivedrum", LeadingBpm = 128, FullName = "C:\\Dj Music\\Electro house\\20 Fingers vs. Massivedrum - Short Dick Man (DJ Jerias vs. John Karoll Mashup).mp3", Key = "3m", Playlist = "Electro house", PlayTime = 236, Title = "Short Dick Man (DJ Jerias vs. John Karoll Mashup)" });
            testMusic.collection.Add(new Song { Artist = "100 2 Chainz Vs Run DMC", LeadingBpm = 100, FullName = "C:\\Dj Music\\Tranny\\2 Chainz Vs Run DMC - Im Different (Dynamiq Tranny Edit 106-100bpm) (Fashen Booty Mash) [Dirty].mp3", Key = "12d", Playlist = "Tranny", PlayTime = 211, Title = "106 Im Different (Dynamiq Tranny Edit 106-100bpm) (Fashen Booty Mash) [Dirty]" });

            var testKeyList = testMusic.GetKeyList();

            Assert.IsNotNull(testKeyList);
            Assert.IsTrue(testKeyList.Count == 3);
            Assert.IsTrue(testKeyList.Contains("9m"));
            Assert.IsTrue(testKeyList.Contains("3m"));
            Assert.IsTrue(testKeyList.Contains("12d"));
        }

        [TestMethod]
        public void GetKeyDictionary_DictionaryReturned_Test()
        {
            Music testMusic = new Music();

            if (testMusic.collection == null)
                testMusic.collection = new List<Song>();

            testMusic.collection.Add(new Song { Artist = "", LeadingBpm = 128, FullName = "C:\\Dj Music\\Electro house\\#OMW2SYPYRAMIDS (Sharkweek Bootleg).mp3", Key = "9m", Playlist = "Electro house", PlayTime = 216, Title = "#OMW2SYPYRAMIDS (Sharkweek Bootleg)" });
            testMusic.collection.Add(new Song { Artist = "20 Fingers vs. Massivedrum", LeadingBpm = 128, FullName = "C:\\Dj Music\\Electro house\\20 Fingers vs. Massivedrum - Short Dick Man (DJ Jerias vs. John Karoll Mashup).mp3", Key = "3m", Playlist = "Electro house", PlayTime = 236, Title = "Short Dick Man (DJ Jerias vs. John Karoll Mashup)" });
            testMusic.collection.Add(new Song { Artist = "100 2 Chainz Vs Run DMC", LeadingBpm = 100, FullName = "C:\\Dj Music\\Tranny\\2 Chainz Vs Run DMC - Im Different (Dynamiq Tranny Edit 106-100bpm) (Fashen Booty Mash) [Dirty].mp3", Key = "12d", Playlist = "Tranny", PlayTime = 211, Title = "106 Im Different (Dynamiq Tranny Edit 106-100bpm) (Fashen Booty Mash) [Dirty]" });

            var testKeyDictionary = testMusic.GetKeyDictionary();

            Assert.IsNotNull(testKeyDictionary);
            Assert.IsTrue(testKeyDictionary.Count == 3);
            Assert.IsTrue(testKeyDictionary.ContainsKey("9m"));
            Assert.IsTrue(testKeyDictionary.ContainsKey("3m"));
            Assert.IsTrue(testKeyDictionary.ContainsKey("12d"));
        }
        [TestMethod]
        public void GetBpmList_ListReturned_Test()
        {
            Music testMusic = new Music();

            if (testMusic.collection == null)
                testMusic.collection = new List<Song>();

            testMusic.collection.Add(new Song { Artist = "", LeadingBpm = 128, FullName = "C:\\Dj Music\\Electro house\\#OMW2SYPYRAMIDS (Sharkweek Bootleg).mp3", Key = "9m", Playlist = "Electro house", PlayTime = 216, Title = "#OMW2SYPYRAMIDS (Sharkweek Bootleg)" });
            testMusic.collection.Add(new Song { Artist = "20 Fingers vs. Massivedrum", LeadingBpm = 128, FullName = "C:\\Dj Music\\Electro house\\20 Fingers vs. Massivedrum - Short Dick Man (DJ Jerias vs. John Karoll Mashup).mp3", Key = "3m", Playlist = "Electro house", PlayTime = 236, Title = "Short Dick Man (DJ Jerias vs. John Karoll Mashup)" });
            testMusic.collection.Add(new Song { Artist = "100 2 Chainz Vs Run DMC", LeadingBpm = 100, FullName = "C:\\Dj Music\\Tranny\\2 Chainz Vs Run DMC - Im Different (Dynamiq Tranny Edit 106-100bpm) (Fashen Booty Mash) [Dirty].mp3", Key = "12d", Playlist = "Tranny", PlayTime = 211, Title = "106 Im Different (Dynamiq Tranny Edit 106-100bpm) (Fashen Booty Mash) [Dirty]" });

            var testBpmList = testMusic.GetBpmList();

            Assert.IsNotNull(testBpmList);
            Assert.IsTrue(testBpmList.Count == 2);
            Assert.IsTrue(testBpmList.Contains("128"));
            Assert.IsTrue(testBpmList.Contains("100"));
        }

        [TestMethod]
        public void GetBpmDictionary_DictionaryReturned_Test()
        {
            Music testMusic = new Music();

            if (testMusic.collection == null)
                testMusic.collection = new List<Song>();

            testMusic.collection.Add(new Song { Artist = "", LeadingBpm = 128, FullName = "C:\\Dj Music\\Electro house\\#OMW2SYPYRAMIDS (Sharkweek Bootleg).mp3", Key = "9m", Playlist = "Electro house", PlayTime = 216, Title = "#OMW2SYPYRAMIDS (Sharkweek Bootleg)" });
            testMusic.collection.Add(new Song { Artist = "20 Fingers vs. Massivedrum", LeadingBpm = 128, FullName = "C:\\Dj Music\\Electro house\\20 Fingers vs. Massivedrum - Short Dick Man (DJ Jerias vs. John Karoll Mashup).mp3", Key = "3m", Playlist = "Electro house", PlayTime = 236, Title = "Short Dick Man (DJ Jerias vs. John Karoll Mashup)" });
            testMusic.collection.Add(new Song { Artist = "100 2 Chainz Vs Run DMC", LeadingBpm = 100, FullName = "C:\\Dj Music\\Tranny\\2 Chainz Vs Run DMC - Im Different (Dynamiq Tranny Edit 106-100bpm) (Fashen Booty Mash) [Dirty].mp3", Key = "12d", Playlist = "Tranny", PlayTime = 211, Title = "106 Im Different (Dynamiq Tranny Edit 106-100bpm) (Fashen Booty Mash) [Dirty]" });

            var testBpmDictionary = testMusic.GetBpmDictionary();

            Assert.IsNotNull(testBpmDictionary);
            Assert.IsTrue(testBpmDictionary.Count == 2);
            Assert.IsTrue(testBpmDictionary.ContainsKey(128));
            Assert.IsTrue(testBpmDictionary.ContainsKey(100));
        }

        [TestMethod]
        public void GetKeyRange_ListReturned()
        {
            var testKey = "9m";

            var testRange = Song.GetKeyRange(testKey);

            Assert.IsNotNull(testRange);
            Assert.IsTrue(testRange[0] == "10m");
            Assert.IsTrue(testRange[1] == "9m");
            Assert.IsTrue(testRange[2] == "8m");
            Assert.IsTrue(testRange[3] == "9d");

            testKey = "3m";

            testRange = Song.GetKeyRange(testKey);

            Assert.IsNotNull(testRange);
            Assert.IsTrue(testRange[0] == "4m");
            Assert.IsTrue(testRange[1] == "3m");
            Assert.IsTrue(testRange[2] == "2m");
            Assert.IsTrue(testRange[3] == "3d");

            testKey = "12d";

            testRange = Song.GetKeyRange(testKey);

            Assert.IsNotNull(testRange);
            Assert.IsTrue(testRange[0] == "1d");
            Assert.IsTrue(testRange[1] == "12d");
            Assert.IsTrue(testRange[2] == "11d");
            Assert.IsTrue(testRange[3] == "12m");
        }

        [TestMethod]
        public void GetBpmRange_ListReturned_Test()
        {
            var testBpm = 128;

            var testRange = Song.GetBpmRange(testBpm);

            Assert.IsNotNull(testRange);
            Assert.IsTrue(testRange[0] == 125);
            Assert.IsTrue(testRange[1] == 126);
            Assert.IsTrue(testRange[2] == 127);
            Assert.IsTrue(testRange[3] == 128);
            Assert.IsTrue(testRange[4] == 129);
            Assert.IsTrue(testRange[5] == 130);
            Assert.IsTrue(testRange[6] == 131);
            Assert.IsTrue(testRange[7] == 250);
            Assert.IsTrue(testRange[8] == 251);
            Assert.IsTrue(testRange[9] == 252);
            Assert.IsTrue(testRange[10] == 253);
            Assert.IsTrue(testRange[11] == 254);
            Assert.IsTrue(testRange[12] == 255);
            Assert.IsTrue(testRange[13] == 256);
            Assert.IsTrue(testRange[14] == 257);
            Assert.IsTrue(testRange[15] == 258);
            Assert.IsTrue(testRange[16] == 259);
            Assert.IsTrue(testRange[17] == 260);
            Assert.IsTrue(testRange[18] == 261);
            Assert.IsTrue(testRange[19] == 262);
            Assert.IsTrue(testRange[20] == 62);
            Assert.IsTrue(testRange[21] == 63);
            Assert.IsTrue(testRange[22] == 64);
            Assert.IsTrue(testRange[23] == 65);

            testBpm = 100;

            testRange = Song.GetBpmRange(testBpm);

            Assert.IsNotNull(testRange);
            Assert.IsTrue(testRange[0] == 97);
            Assert.IsTrue(testRange[1] == 98);
            Assert.IsTrue(testRange[2] == 99);
            Assert.IsTrue(testRange[3] == 100);
            Assert.IsTrue(testRange[4] == 101);
            Assert.IsTrue(testRange[5] == 102);
            Assert.IsTrue(testRange[6] == 103);
            Assert.IsTrue(testRange[7] == 194);
            Assert.IsTrue(testRange[8] == 195);
            Assert.IsTrue(testRange[9] == 196);
            Assert.IsTrue(testRange[10] == 197);
            Assert.IsTrue(testRange[11] == 198);
            Assert.IsTrue(testRange[12] == 199);
            Assert.IsTrue(testRange[13] == 200);
            Assert.IsTrue(testRange[14] == 201);
            Assert.IsTrue(testRange[15] == 202);
            Assert.IsTrue(testRange[16] == 203);
            Assert.IsTrue(testRange[17] == 204);
            Assert.IsTrue(testRange[18] == 205);
            Assert.IsTrue(testRange[19] == 206);
            Assert.IsTrue(testRange[20] == 48);
            Assert.IsTrue(testRange[21] == 49);
            Assert.IsTrue(testRange[22] == 50);
            Assert.IsTrue(testRange[23] == 51);
        }

        [TestMethod]
        public void GetRandomRow_IntReturned_Test()
        {
            var testRowCount = 100;

            var randomRow = Music.GetRandomRow(testRowCount);

            Assert.IsTrue(randomRow <= 100);
            Assert.IsTrue(randomRow >= 0);
        }

        [TestMethod]
        public void GetRandomKey_KeyReturned_Test()
        {
            var testKeyDictionary = new Dictionary<string, int>();

            testKeyDictionary.Add("9m", testKeyDictionary.Count + 1);
            testKeyDictionary.Add("3m", testKeyDictionary.Count + 1);
            testKeyDictionary.Add("12d", testKeyDictionary.Count + 1);

            var randomKey = Music.GetRandomKey(testKeyDictionary);

            Assert.IsNotNull(randomKey);
            Assert.IsTrue(randomKey == "9m" || randomKey == "3m" || randomKey == "12d");
        }

        [TestMethod]
        public void GetRandomBpm_BpmReturned_Test()
        {
            var testBpmDictionary = new Dictionary<int, int>();

            testBpmDictionary.Add(128, testBpmDictionary.Count + 1);
            testBpmDictionary.Add(100, testBpmDictionary.Count + 1);

            var randomBpm = Music.GetRandomBpm(testBpmDictionary);

            Assert.IsNotNull(randomBpm);
            Assert.IsTrue(randomBpm == 128 || randomBpm == 100);
        }

        [TestMethod]
        public void GetLeadingBpm_BpmReturned_Test()
        {
            var testTagTitle = "85 50 Cent";

            var testLeadingBpm = Song.GetLeadingBpm(testTagTitle);

            Assert.IsTrue(testLeadingBpm != 0);
            Assert.IsTrue(testLeadingBpm == 85);
        }

        [TestMethod]
        public void GetTrailingBpm_BpmReturned_Test()
        {
            var testTagArtist= "108 PIMP (DIRTY) (Transition 108-85) (Aca Out) (Marty Mar Edit)";

            var testTrailingBpm = Song.GetTrailingBpm(testTagArtist);

            Assert.IsTrue(testTrailingBpm != 0);
            Assert.IsTrue(testTrailingBpm == 108);
        }


        [TestMethod]
        public void IsArtistWIthLeadingNumber_BoolReturned_Test()
        {
            var testTagTitle = "85 50 Cent";

            var testTitleHasLeadingNumber = Song.IsArtistWithLeadingNumber(testTagTitle);

            Assert.IsFalse(testTitleHasLeadingNumber);

            testTagTitle = "50 Cent";

            testTitleHasLeadingNumber = Song.IsArtistWithLeadingNumber(testTagTitle);

            Assert.IsTrue(testTitleHasLeadingNumber);
        }

        [TestMethod]
        public void GetTagTitle()
        {
            var testFullName = @"C:\\Dj Music\\Selections\\S_Tranny\\50 Cent  - PIMP (DIRTY) (Transition 108-85) (Aca Out) (Marty Mar Edit).mp3";

            var testTagTitle = Song.GetTagTitle(testFullName);

            Assert.IsTrue(!string.IsNullOrEmpty(testTagTitle));
            Assert.IsTrue(testTagTitle == "108 PIMP (DIRTY) (Transition 108-85) (Aca Out) (Marty Mar Edit)");
        }

        [TestMethod]
        public void GetTagArtist()
        {
            var testFullName = @"C:\\Dj Music\\Selections\\S_Tranny\\50 Cent  - PIMP (DIRTY) (Transition 108-85) (Aca Out) (Marty Mar Edit).mp3";

            var testTagArtist = Song.GetTagArtist(testFullName);

            Assert.IsTrue(!string.IsNullOrEmpty(testTagArtist));
            Assert.IsTrue(testTagArtist == "85 50 Cent");
        }
    }
}
