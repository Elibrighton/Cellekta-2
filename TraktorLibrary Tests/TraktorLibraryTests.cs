using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraktorLibrary;
using System.Collections.Generic;
using System.Xml;
using System.IO;

namespace TraktorLibrary_Tests
{
    [TestClass]
    public class TraktorLibraryTests
    {
        ILibrary testLibrary;

        [TestInitialize]
        public void TestInitialise()
        {
            testLibrary = new Library(new List<ISong>()
            {
                new Song() { Playlist = "Tools", LeadingBpm = 128 },
                new Song() { Playlist = "Electro house", LeadingBpm = 130 },
                new Song() { Playlist = "Electro house", LeadingBpm = 130 }
            });
        }

        [TestCleanup]
        public void TestCleanup()
        {
            testLibrary = null;
        }

        [TestMethod]
        public void GetPlaylists_NullReturned_Test()
        {
            // Arrage
            testLibrary = new Library(new List<ISong>());

            // Act
            var testPlaylists = testLibrary.GetPlaylists();

            // Assert
            Assert.IsNotNull(testPlaylists);
            Assert.IsTrue(testPlaylists.Count == 0);
        }

        [TestMethod]
        public void GetPlaylists_ListReturned_Test()
        {
            // Arrange

            // Act
            var testPlaylists = testLibrary.GetPlaylists();

            // Assert
            Assert.IsNotNull(testPlaylists);
            Assert.IsTrue(testPlaylists.Count == 2);
        }

        [TestMethod]
        public void GetBpms_NullReturned_Test()
        {
            // Arrange
            testLibrary = new Library(new List<ISong>());

            // Act
            var testBpms = testLibrary.GetBpms();

            // Assert
            Assert.IsNotNull(testBpms);
            Assert.IsTrue(testBpms.Count == 0);
        }

        [TestMethod]
        public void GetBpms_BpmsReturned_Test()
        {
            // Arrange

            // Act
            var testBpms = testLibrary.GetBpms();

            // Assert
            Assert.IsNotNull(testBpms);
            Assert.IsTrue(testBpms.Count == 2);
        }

        [TestMethod]
        public void GetKeyRange_NullReturned_Test()
        {
            // Arrange
            testLibrary = new Library(new List<ISong>());
            var testKey = string.Empty;

            // Act
            var testKeys = Song.GetKeyRange(testKey);

            // Assert
            Assert.IsNotNull(testKeys);
            Assert.IsTrue(testKeys.Count == 0);
        }

        [TestMethod]
        public void GetKeyRange_KeysReturned_Test()
        {
            // Arrange
            var testKey = "9D";

            // Act
            var testKeys = Song.GetKeyRange(testKey);

            // Assert
            Assert.IsNotNull(testKeys);
            Assert.IsTrue(testKeys.Count == 4);
        }

        [TestMethod]
        public void GetPlaylist_PlaylistReturned_Test()
        {
            var testDir = "\\Dj Music\\Dance\\";

            var testPlaylist = Library.GetPlaylist(testDir);

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
                    testArtist = Library.ImportAttribute(entryNode.Attributes["ARTIST"]);
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
                    testTitle = Library.ImportAttribute(entryNode.Attributes["TITLE"]);
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
                        testDir = Library.ImportAttribute(locationNode.Attributes["DIR"]).Replace("/:", "\\");
                        testFile = Library.ImportAttribute(locationNode.Attributes["FILE"]);
                        testVolume = Library.ImportAttribute(locationNode.Attributes["VOLUME"]);
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
                        Int32.TryParse(Library.ImportAttribute(infoNode.Attributes["PLAYTIME"]), out testPlayTime);
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
                        testBpm = Library.ImportBpm(tempoNode.Attributes["BPM"]);
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
                        testKey = Library.ImportKey(musicalKeyNode.Attributes["VALUE"]);
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
                song = Library.ImportSong(entryNode);
            }

            Assert.IsNotNull(song);
            Assert.IsTrue(song.Artist == "Sharam Jey");
            Assert.IsTrue(song.Title == "To The Beat!(Original Mix)");
            Assert.IsTrue(song.FullName == "C:\\Dj Music\\Dance\\Sharam Jey - To The Beat! (Original Mix).mp3");
            Assert.IsTrue(song.PlayTime == 359);
            Assert.IsTrue(song.LeadingBpm == 118);
            Assert.IsTrue(song.Key == "4m");
        }
    }
}
