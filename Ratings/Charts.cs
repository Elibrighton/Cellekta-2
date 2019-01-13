using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratings
{
    public class Charts : ICharts
    {
        List<IChart> _charts;

        public List<IChart> GetCharts()
        {
            _charts = new List<IChart>
            {
                // aria singles
                new Chart { Artist = "Post Malone & Swae Lee", Title = "Sunflower" },
                new Chart { Artist = "Ava Max", Title = "Sweet But Psycho" },
                new Chart { Artist = "Halsey", Title = "Without Me" },
                new Chart { Artist = "Post Malone", Title = "Wow." },
                new Chart { Artist = "Ariana Grande", Title = "Thank U, Next" },
                new Chart { Artist = "George Ezra", Title = "Shotgun" },
                new Chart { Artist = "Lady Gaga & Bradley Cooper", Title = "Shallow" },
                new Chart { Artist = "Benny Blanco Feat. Halsey & Khalid", Title = "Eastside" },
                new Chart { Artist = "Mark Ronson Feat. Miley Cyrus", Title = "Nothing Breaks Like A Heart" },
                new Chart { Artist = "Travis Scott & Drake", Title = "Sicko Mode" },
                new Chart { Artist = "Marshmello & Bastille", Title = "Happier" },
                new Chart { Artist = "Loud Luxury", Title = "Body" },
                new Chart { Artist = "Khalid", Title = "Better" },
                new Chart { Artist = "Dean Lewis", Title = "Be Alright" },
                new Chart { Artist = "5 Seconds Of Summer", Title = "Youngblood" },
                new Chart { Artist = "Rita Ora", Title = "Let You Love Me" },
                new Chart { Artist = "Kian", Title = "Waiting" },
                new Chart { Artist = "Hilltop Hoods", Title = "Leave Me Lonely" },
                new Chart { Artist = "Charli XCX & Troye Sivan", Title = "1999" },
                new Chart { Artist = "Imagine Dragons", Title = "Bad Liar	" },
                new Chart { Artist = "Lukas Graham", Title = "Love Someone" },
                new Chart { Artist = "Billie Eilish", Title = "when the party's over" },
                new Chart { Artist = "Dynoro", Title = "In My Mind" },
                new Chart { Artist = "Calvin Harris & Sam Smith", Title = "Promises" },
                new Chart { Artist = "Panic! At The Disco", Title = "High Hopes" },
                new Chart { Artist = "Ellie Goulding, Diplo & Swae Lee", Title = "Close To Me" },
                new Chart { Artist = "Maroon 5 Feat. Cardi B", Title = "Girls Like You" },
                new Chart { Artist = "Morgan Evans", Title = "Day Drunk" },
                new Chart { Artist = "Ariana Grande", Title = "Imagine" },
                new Chart { Artist = "Jonas Blue", Title = "Rise" },
                new Chart { Artist = "Post Malone", Title = "Better Now" },
                new Chart { Artist = "Khalid", Title = "Saturday Nights" },
                new Chart { Artist = "Zara Larsson", Title = "Ruin My Life" },
                new Chart { Artist = "Kodak Black Feat. Travis Scott & Offset", Title = "ZEZE" },
                new Chart { Artist = "Meek Mill Feat. Drake", Title = "Going Bad" },
                new Chart { Artist = "Queen", Title = "Bohemian Rhapsody" },
                new Chart { Artist = "XXXTentacion x Lil Pump Feat. Swae Lee & Maluma", Title = "Arms Around You" },
                new Chart { Artist = "Ed Sheeran", Title = "Perfect" },
                new Chart { Artist = "Sheck Wes", Title = "Mo Bamba" },
                new Chart { Artist = "Shawn Mendes", Title = "Lost In Japan" },
                new Chart { Artist = "Anne-Marie", Title = "2002" },
                new Chart { Artist = "Post Malone", Title = "I Fall Apart" },
                new Chart { Artist = "Guy Sebastian", Title = "Before I Go" },
                new Chart { Artist = "Juice WRLD", Title = "Lucid Dreams" },
                new Chart { Artist = "NOTD, Felix Jaehn & Captain Cuts Feat. Georgia Ku", Title = "So Close" },
                new Chart { Artist = "The Chainsmokers Feat. Kelsea Ballerini", Title = "This Feeling" },
                new Chart { Artist = "Post Malone Feat. 21 Savage", Title = "Rockstar" },
                new Chart { Artist = "Billie Eilish Feat. Khalid", Title = "Lovely" },
                new Chart { Artist = "Drake", Title = "God's Plan" },
                new Chart { Artist = "Post Malone Feat. Ty Dolla $ign", Title = "Psycho" },

                // aria urban
                new Chart { Artist = "Post Malone & Swae Lee", Title = "Sunflower" },
                new Chart { Artist = "Post Malone", Title = "Wow." },
                new Chart { Artist = "Travis Scott & Drake", Title = "Sicko Mode" },
                new Chart { Artist = "Khalid", Title = "Better" },
                new Chart { Artist = "Hilltop Hoods", Title = "Leave Me Lonely" },
                new Chart { Artist = "Post Malone", Title = "Better Now" },
                new Chart { Artist = "Khalid", Title = "Saturday Nights" },
                new Chart { Artist = "Kodak Black Feat. Travis Scott & Offset", Title = "ZEZE" },
                new Chart { Artist = "Meek Mill Feat. Drake", Title = "Going Bad" },
                new Chart { Artist = "XXXTentacion x Lil Pump Feat. Swae Lee & Maluma", Title = "Arms Around You" },
                new Chart { Artist = "Sheck Wes", Title = "Mo Bamba" },
                new Chart { Artist = "Post Malone", Title = "I Fall Apart" },
                new Chart { Artist = "Juice WRLD", Title = "Lucid Dreams" },
                new Chart { Artist = "Post Malone Feat. 21 Savage", Title = "Rockstar" },
                new Chart { Artist = "Billie Eilish Feat. Khalid", Title = "Lovely" },
                new Chart { Artist = "Drake", Title = "God's Plan" },
                new Chart { Artist = "Post Malone Feat. Ty Dolla $ign", Title = "Psycho" },
                new Chart { Artist = "Lil Pump & Kanye West", Title = "I Love It" },
                new Chart { Artist = "Cardi B Feat. J Balvin & Bad Bunny", Title = "I Like It" },
                new Chart { Artist = "Drake", Title = "In My Feelings" },
                new Chart { Artist = "Chris Brown", Title = "Undecided" },
                new Chart { Artist = "XXXTentacion", Title = "Sad!" },
                new Chart { Artist = "Cardi B", Title = "Money" },
                new Chart { Artist = "Kendrick Lamar & Skrillex", Title = "HUMBLE." },
                new Chart { Artist = "Drake", Title = "Nonstop" },
                new Chart { Artist = "Khalid & Normani", Title = "Love Lies" },
                new Chart { Artist = "Drake", Title = "Nice For What" },
                new Chart { Artist = "A$AP Rocky Feat. Skepta", Title = "Praise The Lord (Da Shine)" },
                new Chart { Artist = "Kendrick Lamar & SZA", Title = "All The Stars" },
                new Chart { Artist = "Khalid", Title = "Young Dumb & Broke" },
                new Chart { Artist = "Flipp Dinero", Title = "Leave Me Alone" },
                new Chart { Artist = "Khalid Feat. Empress Of", Title = "Suncity" },
                new Chart { Artist = "21 Savage Feat. J. Cole", Title = "A Lot" },
                new Chart { Artist = "21 Savage Feat. Childish Gambino", Title = "Monster" },
                new Chart { Artist = "Gucci Mane, Bruno Mars, Kodak Black", Title = "Wake Up In The Sky" },
                new Chart { Artist = "Eminem Feat. Joyner Lucas", Title = "Lucky You" },
                new Chart { Artist = "DJ Khaled, Justin Bieber & Quavo Feat. Chance the Rapper", Title = "No Brainer" },
                new Chart { Artist = "6ix9ine Feat. Tory Lanez", Title = "KIKA" },
                new Chart { Artist = "Eminem Feat. Ed Sheeran", Title = "River" },
                new Chart { Artist = "Khalid x Ty Dolla $ign x 6lack", Title = "OTW" },

                // aria dance 
                new Chart { Artist = "Mark Ronson Feat. Miley Cyrus", Title = "Nothing Breaks Like A Heart" },
                new Chart { Artist = "Loud Luxury", Title = "Body" },
                new Chart { Artist = "Dynoro", Title = "In My Mind" },
                new Chart { Artist = "Calvin Harris & Sam Smith", Title = "Promises" },
                new Chart { Artist = "Jonas Blue", Title = "Rise" },
                new Chart { Artist = "The Chainsmokers Feat. Kelsea Ballerini", Title = "This Feeling" },
                new Chart { Artist = "Peking Duk", Title = "Fire/Reprisal" },
                new Chart { Artist = "Silk City & Dua Lipa Feat. Diplo & Mark Ronson", Title = "Electricity" },
                new Chart { Artist = "Calvin Harris & Dua Lipa", Title = "One Kiss" },
                new Chart { Artist = "Hayden James Feat. Running Touch", Title = "Better Together" },
                new Chart { Artist = "The Chainsmokers Feat. Winona Oak", Title = "Hope" },
                new Chart { Artist = "DJ Snake Feat. Selena Gomez, Ozuna & Cardi B", Title = "Taki Taki" },
                new Chart { Artist = "Kygo Feat. Sandro Cavazza", Title = "Happy Now" },
                new Chart { Artist = "Rudimental Feat. Jess Glynne, Macklemore & Dan Caplen", Title = "These Days" },
                new Chart { Artist = "Tiesto & Dzeko Feat. Preme & Post Malone", Title = "Jackie Chan" },
                new Chart { Artist = "Martin Garrix Feat. Khalid", Title = "Ocean" },
                new Chart { Artist = "Dennis Lloyd", Title = "Nevermind" },
                new Chart { Artist = "The Chainsmokers Feat. Halsey", Title = "Closer" },
                new Chart { Artist = "Marshmello x Khalid", Title = "Silence" },
                new Chart { Artist = "Kygo & Imagine Dragons", Title = "Born To Be Yours" },

                // billboard hot 100
                new Chart { Artist = "Halsey", Title = "Without Me" },
                new Chart { Artist = "Ariana Grande", Title = "Thank U, Next" },
                new Chart { Artist = "Post Malone & Swae Lee", Title = "Sunflower (Spider-Man: Into The Spider-Verse)" },
                new Chart { Artist = "Travis Scott", Title = "Sicko Mode" },
                new Chart { Artist = "Panic! At The Disco", Title = "High Hopes" },
                new Chart { Artist = "Marshmello & Bastille", Title = "Happier" },
                new Chart { Artist = "Maroon 5 Featuring Cardi B", Title = "Girls Like You" },
                new Chart { Artist = "Lil Baby & Gunna", Title = "Drip Too Hard" },
                new Chart { Artist = "Kodak Black Featuring Travis Scott & Offset", Title = "ZEZE" },
                new Chart { Artist = "Post Malone", Title = "Better Now" },
                new Chart { Artist = "Benny Blanco, Halsey & Khalid", Title = "Eastside" },
                new Chart { Artist = "Gucci Mane X Bruno Mars X Kodak Black", Title = "Wake Up In The Sky" },
                new Chart { Artist = "Post Malone", Title = "Wow." },
                new Chart { Artist = "5 Seconds Of Summer", Title = "Youngblood" },
                new Chart { Artist = "Sheck Wes", Title = "Mo Bamba" },
                new Chart { Artist = "Ariana Grande", Title = "Breathin" },
                new Chart { Artist = "Cardi B", Title = "Money" },
                new Chart { Artist = "Juice WRLD", Title = "Lucid Dreams" },
                new Chart { Artist = "DJ Snake Featuring Selena Gomez, Ozuna & Cardi B", Title = "Taki Taki" },
                new Chart { Artist = "Bad Bunny Featuring Drake", Title = "MIA" },
                new Chart { Artist = "Meek Mill Featuring Drake", Title = "Going Bad" },
                new Chart { Artist = "Flipp Dinero", Title = "Leave Me Alone" },
                new Chart { Artist = "Ella Mai", Title = "Trip" },
                new Chart { Artist = "Dan + Shay", Title = "Speechless" },
                new Chart { Artist = "Imagine Dragons", Title = "Natural" },
                new Chart { Artist = "Cardi B, Bad Bunny & J Balvin", Title = "I Like It" },
                new Chart { Artist = "Khalid & Normani", Title = "Love Lies" },
                new Chart { Artist = "Bazzi Featuring Camila Cabello", Title = "Beautiful" },
                new Chart { Artist = "Lady Gaga & Bradley Cooper", Title = "Shallow" },
                new Chart { Artist = "Khalid", Title = "Better" },
                new Chart { Artist = "Luke Combs", Title = "She Got The Best Of Me" },
                new Chart { Artist = "Pinkfong", Title = "Baby Shark" },
                new Chart { Artist = "Ellie Goulding X Diplo Featuring Swae Lee", Title = "Close To Me" },
                new Chart { Artist = "Lauren Daigle", Title = "You Say" },
                new Chart { Artist = "Lil Wayne", Title = "Uproar" },
                new Chart { Artist = "21 Savage", Title = "A Lot" },
                new Chart { Artist = "Jimmie Allen", Title = "Best Shot" },
                new Chart { Artist = "A Boogie Wit da Hoodie Featuring 6ix9ine", Title = "Swervin" },
                new Chart { Artist = "Mitchell Tenpenny", Title = "Drunk Me" },
                new Chart { Artist = "Dean Lewis", Title = "Be Alright" },
                new Chart { Artist = "Ava Max", Title = "Sweet But Psycho" },
                new Chart { Artist = "Thomas Rhett", Title = "Sixteen" },
                new Chart { Artist = "Tory Lanez & Rich The Kid", Title = "Talk To Me" },
                new Chart { Artist = "Pardison Fontaine Featuring Cardi B", Title = "Backin' It Up" },
                new Chart { Artist = "Dierks Bentley Featuring Brothers Osborne", Title = "Burning Man" },
                new Chart { Artist = "Meek Mill Featuring Jeremih & PnB Rock", Title = "Dangerous" },
                new Chart { Artist = "Dustin Lynch", Title = "Good Girl" },
                new Chart { Artist = "Luke Combs", Title = "Beautiful Crazy" },
                new Chart { Artist = "Mark Ronson Featuring Miley Cyrus", Title = "Nothing Breaks Like A Heart" },
                new Chart { Artist = "The Chainsmokers Featuring Kelsea Ballerini", Title = "This Feeling" },
                new Chart { Artist = "Camila Cabello", Title = "Consequences" },
                new Chart { Artist = "Jason Aldean", Title = "Girl Like You" },
                new Chart { Artist = "Kip Moore", Title = "Last Shot" },
                new Chart { Artist = "A Boogie Wit da Hoodie", Title = "Look Back At It" },
                new Chart { Artist = "XXXTENTACION x Lil Pump Featuring Maluma & Swae Lee", Title = "Arms Around You" },
                new Chart { Artist = "Juice WRLD", Title = "Armed And Dangerous" },
                new Chart { Artist = "Scotty McCreery", Title = "This Is It" },
                new Chart { Artist = "Kodak Black", Title = "Calling My Spirit" },
                new Chart { Artist = "Jacquees", Title = "You" },
                new Chart { Artist = "French Montana Featuring Drake", Title = "No Stylist" },
                new Chart { Artist = "A Boogie Wit da Hoodie Featuring Offset & Tyga", Title = "Startender" },
                new Chart { Artist = "Silk City x Dua Lipa", Title = "Electricity" },
                new Chart { Artist = "Ariana Grande", Title = "Imagine" },
                new Chart { Artist = "Anuel AA & Romeo Santos", Title = "Ella Quiere Beber" },
                new Chart { Artist = "21 Savage", Title = "Can't Leave Without It" },
                new Chart { Artist = "Calboy", Title = "Envy Me" },
                new Chart { Artist = "Lil' Duval Featuring Snoop Dogg & Ball Greezy", Title = "Smile (Living My Best Life)" },
                new Chart { Artist = "Billie Eilish", Title = "When The Party's Over" },
                new Chart { Artist = "Chris Stapleton", Title = "Millionaire" },
                new Chart { Artist = "XXXTENTACION", Title = "BAD!" },
                new Chart { Artist = "Shawn Mendes X Zedd", Title = "Lost In Japan" },
                new Chart { Artist = "Lil Baby", Title = "Pure Cocaine" },
                new Chart { Artist = "Billie Eilish & Khalid", Title = "Lovely" },
                new Chart { Artist = "Future & Juice WRLD", Title = "Fine China" },
                new Chart { Artist = "Jordan Davis", Title = "Take It From Me" },
                new Chart { Artist = "Luke Bryan", Title = "What Makes You Country" },
                new Chart { Artist = "Travis Scott", Title = "Yosemite" },
                new Chart { Artist = "21 Savage", Title = "Monster" },
                new Chart { Artist = "Russell Dickerson", Title = "Blue Tacoma" },
                new Chart { Artist = "Jake Owen", Title = "Down To The Honkytonk" },
                new Chart { Artist = "Lil Baby", Title = "Close Friends" },
                new Chart { Artist = "Lukas Graham", Title = "Love Someone" },
                new Chart { Artist = "Carrie Underwood", Title = "Love Wins" },
                new Chart { Artist = "6ix9ine Featuring Tory Lanez", Title = "KIKA" },
                new Chart { Artist = "Ski Mask The Slump God Featuring Juice WRLD", Title = "Nuketown" },
                new Chart { Artist = "Zara Larsson", Title = "Ruin My Life" },
                new Chart { Artist = "Loud Luxury Featuring Brando", Title = "Body" },
                new Chart { Artist = "Tyga & Nicki Minaj", Title = "Dip" },
                new Chart { Artist = "Nicki Minaj Featuring Lil Wayne", Title = "Good Form" },
                new Chart { Artist = "A Boogie Wit da Hoodie Featuring Juice WRLD", Title = "Demons And Angels" },
                new Chart { Artist = "Midland", Title = "Burn Out" },
                new Chart { Artist = "Bad Bunny", Title = "Solo de Mi" },
                new Chart { Artist = "Eminem Featuring Joyner Lucas", Title = "Lucky You" },
                new Chart { Artist = "benny blanco & Juice WRLD Featuring Brendon Urie", Title = "Roses" },
                new Chart { Artist = "XXXTENTACION", Title = "whoa (mind in awe)" },
                new Chart { Artist = "21 Savage", Title = "All My Friends" },
                new Chart { Artist = "Old Dominion", Title = "Make It Sweet" },
                new Chart { Artist = "Billie Eilish", Title = "Ocean Eyes" },
                new Chart { Artist = "Billie Eilish", Title = "idontwannabeyouanymore" },

                // uk top 40 singles
                new Chart { Artist = "Ava Max", Title = "Sweet But Psycho" },
                new Chart { Artist = "Ariana Grande", Title = "thank u, next" },
                new Chart { Artist = "Mark Ronson", Title = "Nothing Breaks Like A Heart (feat. Miley Cyrus)" },
                new Chart { Artist = "Post Malone", Title = "Wow." },
                new Chart { Artist = "Post Malone & Swae Lee", Title = "Sunflower (Spider-Man: Into the Spider-Verse)" },
                new Chart { Artist = "Headie One", Title = "18HUNNA (feat. Dave)" },
                new Chart { Artist = "James Arthur & Anne‐Marie", Title = "Rewrite The Stars" },
                new Chart { Artist = "George Ezra", Title = "Hold My Girl" },
                new Chart { Artist = "Freya Ridings", Title = "Lost Without You" },
                new Chart { Artist = "Halsey", Title = "Without Me" },
                new Chart { Artist = "Jax Jones & Years & Years", Title = "Play" },
                new Chart { Artist = "Zara Larsson", Title = "Ruin My Life" },
                new Chart { Artist = "Kodak Black", Title = "ZEZE (feat. Travis Scott & Offset)" },
                new Chart { Artist = "Pinkfong", Title = "Baby Shark" },
                new Chart { Artist = "Chris Brown", Title = "Undecided" },
                new Chart { Artist = "George Ezra", Title = "Shotgun" },
                new Chart { Artist = "Clean Bandit, Marina & Luis Fonsi", Title = "Baby" },
                new Chart { Artist = "Meek Mill", Title = "Going Bad (feat. Drake)" },
                new Chart { Artist = "Jess Glynne", Title = "Thursday" },
                new Chart { Artist = "Ariana Grande", Title = "Imagine" },
                new Chart { Artist = "Lady Gaga & Bradley Cooper", Title = "Shallow" },
                new Chart { Artist = "Calvin Harris & Dua Lipa", Title = "One Kiss" },
                new Chart { Artist = "Keala Settle & The Greatest Showman Ensemble", Title = "This Is Me" },
                new Chart { Artist = "P!nk", Title = "A Million Dreams" },
                new Chart { Artist = "NSG", Title = "Options (feat. Tion Wayne)" },
                new Chart { Artist = "Sheck Wes", Title = "Mo Bamba" },
                new Chart { Artist = "Calvin Harris & Sam Smith", Title = "Promises" },
                new Chart { Artist = "Little Mix", Title = "Woman Like Me" },
                new Chart { Artist = "Rita Ora", Title = "Let You Love Me" },
                new Chart { Artist = "Cadet x Deno Driz", Title = "Advice" },
                new Chart { Artist = "benny blanco", Title = "Eastside (feat. Khalid & Halsey)" },
                new Chart { Artist = "6ix9ine", Title = "Kika (feat. Tory Lanez)" },
                new Chart { Artist = "Lewis Capaldi", Title = "Grace" },
                new Chart { Artist = "Tom Walker", Title = "Leave A Light On" },
                new Chart { Artist = "Marshmello & Bastille", Title = "Happier" },
                new Chart { Artist = "Travis Scott", Title = "SICKO MODE" },
                new Chart { Artist = "Anne‐Marie", Title = "2002" },
                new Chart { Artist = "Hugh Jackman, Keala Settle, Zac Efron, Zendaya & The Greatest Showman Ensemble", Title = "The Greatest Show" },
                new Chart { Artist = "Russ", Title = "Gun Lean" },
                new Chart { Artist = "Jess Glynne", Title = "Ill Be There" }
            };

            for (int i = 0; i < _charts.Count; i++)
            {
                IChart chart = new Chart();
                chart = _charts[i];

                chart = RemoveFeaturingArtists(chart, "&");
                chart = RemoveFeaturingArtists(chart, ",");
                chart = RemoveFeaturingArtists(chart, "(");
                chart = RemoveFeaturingArtists(chart, "[");
                chart = RemoveFeaturingArtists(chart, "-");
                chart = RemoveFeaturingArtists(chart, "Featuring");
                chart = RemoveFeaturingArtists(chart, "Feat.");
                chart = RemoveFeaturingArtists(chart, "Feat ");
                chart = RemoveFeaturingArtists(chart, "Ft.");
                chart = RemoveFeaturingArtists(chart, "Ft ");
                chart = RemoveFeaturingArtists(chart, "Fe.");
                chart = RemoveFeaturingArtists(chart, "F ");

                chart.Artist.Trim();
                chart.Title.Trim();
            }

            return _charts;
        }

        private IChart RemoveFeaturingArtists(IChart chart, string extra)
        {
            var index = chart.Artist.IndexOf(extra, StringComparison.OrdinalIgnoreCase);

            if (index > 0)
                chart.Artist = chart.Artist.Substring(0, index - 1);


            index = chart.Title.IndexOf(extra, StringComparison.OrdinalIgnoreCase);

            if (index > 0)
                chart.Title = chart.Title.Substring(0, index - 1);

            return chart;
        }

        public bool IsChartedSong(string artist, string title)
        {
            var isCharted = false;

            foreach (var chart in _charts)
            {
                if (artist.IndexOf(chart.Artist, StringComparison.OrdinalIgnoreCase) >= 0
                    && title.IndexOf(chart.Title, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    isCharted = true;
                    break;
                }
            }

            return isCharted;
        }
    }
}
