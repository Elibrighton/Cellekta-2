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
                new Chart { Artist = "Ed Sheeran", Title = "Shape of You" },
                new Chart { Artist = "Ed Sheeran", Title = "Galway Girl" },
                new Chart { Artist = "Kendrick Lamar", Title = "HUMBLE." },
                new Chart { Artist = "Clean Bandit Feat. Zara Larsson", Title = "Symphony" },
                new Chart { Artist = "The Chainsmokers &amp; Coldplay", Title = "Something Just Like This" },
                new Chart { Artist = "Harry Styles", Title = "Sign Of The Times" },
                new Chart { Artist = "Zedd Feat. Alessia Cara", Title = "Stay" },
                new Chart { Artist = "Shawn Mendes", Title = "There&#39;s Nothing Holdin&#39; Me Back" },
                new Chart { Artist = "Lorde", Title = "Green Light" },
                new Chart { Artist = "Lady Gaga", Title = "The Cure" },
                new Chart { Artist = "Kygo &amp; Selena Gomez", Title = "It Ain&#39;t Me" },
                new Chart { Artist = "Bruno Mars", Title = "That&#39;s What I Like" },
                new Chart { Artist = "Drake", Title = "Passionfruit" },
                new Chart { Artist = "Julia Michaels", Title = "Issues" },
                new Chart { Artist = "Ed Sheeran", Title = "Castle On The Hill" },
                new Chart { Artist = "Calvin Harris Feat. Frank Ocean &amp; Migos", Title = "Slide" },
                new Chart { Artist = "Dean Lewis", Title = "Waves" },
                new Chart { Artist = "Jax Jones Feat. Raye", Title = "You Don&#39;t Know Me" },
                new Chart { Artist = "Kendrick Lamar", Title = "DNA." },
                new Chart { Artist = "Jon Bellion", Title = "All Time Low" },
                new Chart { Artist = "Martin Garrix &amp; Dua Lipa", Title = "Scared To Be Lonely" },
                new Chart { Artist = "Future", Title = "Mask Off" },
                new Chart { Artist = "G-Eazy &amp; Kehlani", Title = "Good Life" },
                new Chart { Artist = "Halsey", Title = "Now Or Never" },
                new Chart { Artist = "Jason Derulo Feat. Nicki Minaj &amp; Ty Dolla $ign", Title = "Swalla" },
                new Chart { Artist = "Luis Fonsi Feat. Daddy Yankee", Title = "Despacito" },
                new Chart { Artist = "Amy Shark", Title = "Adore" },
                new Chart { Artist = "Kendrick Lamar Feat. Rihanna", Title = "LOYALTY." },
                new Chart { Artist = "The Chainsmokers", Title = "Paris" },
                new Chart { Artist = "Snakehips &amp; M&#216;", Title = "Don&#39;t Leave" },
                new Chart { Artist = "Calvin Harris Feat. Young Thug, Pharrell Williams &amp; Ariana Grande", Title = "Heatstroke" },
                new Chart { Artist = "Little Mix", Title = "Touch" },
                new Chart { Artist = "Starley", Title = "Call On Me - Ryan Riback Remix" },
                new Chart { Artist = "Zayn Feat. Partynextdoor", Title = "Still Got Time" },
                new Chart { Artist = "Kyle", Title = "iSpy" },
                new Chart { Artist = "Kendrick Lamar", Title = "LOVE." },
                new Chart { Artist = "Bliss N Eso Feat. Gavin James", Title = "Moments" },
                new Chart { Artist = "Katy Perry Feat. Skip Marley", Title = "Chained To the Rhythm" },
                new Chart { Artist = "Andy Grammer", Title = "Fresh Eyes" },
                new Chart { Artist = "Kaleo", Title = "Way Down We Go" },
                new Chart { Artist = "Cheat Codes Feat. Demi Lovato", Title = "No Promises" },
                new Chart { Artist = "Pnau", Title = "Chameleon" },
                new Chart { Artist = "Martin Jensen", Title = "Solo Dance" },
                new Chart { Artist = "Lana Del Rey Feat. The Weeknd", Title = "Lust for Life" },
                new Chart { Artist = "Zayn &amp; Taylor Swift", Title = "I Don&#39;t Wanna Live Forever" },
                new Chart { Artist = "Future Feat. Rihanna", Title = "Selfish" },
                new Chart { Artist = "James Arthur", Title = "Say You Won&#39;t Let Go" },
                new Chart { Artist = "The Weeknd Feat. Daft Punk", Title = "I Feel It Coming" },
                new Chart { Artist = "Maroon 5 Feat. Future", Title = "Cold" },
                new Chart { Artist = "Ed Sheeran", Title = "Perfect" },

                // aria urban
                new Chart { Artist = "Kendrick Lamar", Title = "HUMBLE." },
                new Chart { Artist = "Kendrick Lamar", Title = "DNA." },
                new Chart { Artist = "Future", Title = "Mask Off" },
                new Chart { Artist = "Kendrick Lamar Feat. Rihanna", Title = "LOYALTY." },
                new Chart { Artist = "Kendrick Lamar", Title = "LOVE." },
                new Chart { Artist = "Bliss N Eso Feat. Gavin James", Title = "Moments" },
                new Chart { Artist = "Future Feat. Rihanna", Title = "Selfish" },
                new Chart { Artist = "The Weeknd Feat. Daft Punk", Title = "Starboy" },
                new Chart { Artist = "Childish Gambino", Title = "Redbone" },
                new Chart { Artist = "Big Sean", Title = "Bounce Back" },
                new Chart { Artist = "Drake", Title = "Fake Love" },
                new Chart { Artist = "Migos Feat. Lil Uzi Vert", Title = "Bad and Boujee" },
                new Chart { Artist = "Chris Brown", Title = "Privacy" },
                new Chart { Artist = "Sage The Gemini", Title = "Now And Later" },
                new Chart { Artist = "Mark Ronson Feat. Bruno Mars", Title = "Uptown Funk" },
                new Chart { Artist = "Maroon 5 Feat. Kendrick Lamar", Title = "Don&#39;t Wanna Know" },
                new Chart { Artist = "Hilltop Hoods Feat. Montaigne &amp; Tom Thum", Title = "1955" },
                new Chart { Artist = "Machine Gun Kelly Feat. Hailee Steinfeld", Title = "At My Best" },
                new Chart { Artist = "Illy Feat. Vera Blue", Title = "Papercuts" },
                new Chart { Artist = "Fifth Harmony Feat. Ty Dolla $ign", Title = "Work From Home" },
                new Chart { Artist = "Allday Feat. Japanese Wallpaper", Title = "In Motion" },
                new Chart { Artist = "Rae Sremmurd", Title = "Black Beatles" },
                new Chart { Artist = "Kendrick Lamar", Title = "King Kunta" },
                new Chart { Artist = "John Legend", Title = "All of Me" },
                new Chart { Artist = "Illy Feat. Anne-Marie", Title = "Catch 22" },
                new Chart { Artist = "Iggy Azalea", Title = "Mo Bounce" },
                new Chart { Artist = "Kanye West", Title = "Stronger" },
                new Chart { Artist = "Thundamentals Feat. Mataya", Title = "Sally" },
                new Chart { Artist = "Drake Feat. Rihanna", Title = "Too Good" },
                new Chart { Artist = "Nicki Minaj, Drake &amp; Lil Wayne", Title = "No Frauds" },
                new Chart { Artist = "Chris Brown Feat. Gucci Mane &amp; Usher", Title = "Party" },
                new Chart { Artist = "Wiz Khalifa Feat. Charlie Puth", Title = "See You Again" },
                new Chart { Artist = "Lil Wayne, Wiz Khalifa &amp; Imagine Dragons, X Ambassadors, Ty Dolla $ign, Logic", Title = "Sucker For Pain" },
                new Chart { Artist = "Eminem", Title = "Without Me" },
                new Chart { Artist = "J. Cole", Title = "Deja Vu" },
                new Chart { Artist = "Beyonce", Title = "Halo" },
                new Chart { Artist = "The Weeknd", Title = "The Hills" },
                new Chart { Artist = "The Weeknd", Title = "Can&#39;t Feel My Face" },
                new Chart { Artist = "Eminem", Title = "Rap God" },
                new Chart { Artist = "Eminem", Title = "The Real Slim Shady" },

                // aria dance 
                new Chart { Artist = "Clean Bandit Feat. Zara Larsson", Title = "Symphony" },
                new Chart { Artist = "Zedd Feat. Alessia Cara", Title = "Stay" },
                new Chart { Artist = "Calvin Harris Feat. Frank Ocean &amp; Migos", Title = "Slide" },
                new Chart { Artist = "Jax Jones Feat. Raye", Title = "You Don&#39;t Know Me" },
                new Chart { Artist = "The Chainsmokers", Title = "Paris" },
                new Chart { Artist = "Calvin Harris Feat. Young Thug, Pharrell Williams &amp; Ariana Grande", Title = "Heatstroke" },
                new Chart { Artist = "Starley", Title = "Call On Me - Ryan Riback Remix" },
                new Chart { Artist = "Cheat Codes Feat. Demi Lovato", Title = "No Promises" },
                new Chart { Artist = "Pnau", Title = "Chameleon" },
                new Chart { Artist = "Martin Jensen", Title = "Solo Dance" },
                new Chart { Artist = "Clean Bandit Feat. Sean Paul &amp; Anne-Marie", Title = "Rockabye" },
                new Chart { Artist = "The Chainsmokers Feat. Halsey", Title = "Closer" },
                new Chart { Artist = "Mura Masa Feat. A$ap Rocky", Title = "Love$ick" },
                new Chart { Artist = "Major Lazer Feat. PartyNextDoor &amp; Nicki Minaj", Title = "Run Up" },
                new Chart { Artist = "Peking Duk Feat. Elliphant", Title = "Stranger" },
                new Chart { Artist = "Robin Schulz &amp; David Guetta Feat. Cheat Codes", Title = "Shed A Light" },
                new Chart { Artist = "The Chainsmokers", Title = "The One" },
                new Chart { Artist = "Flume Feat. Kai", Title = "Never Be Like You" },
                new Chart { Artist = "Sia", Title = "Move Your Body" },
                new Chart { Artist = "DJ Snake Feat. Justin Bieber", Title = "Let Me Love You" },

                // billboard hot 100
                new Chart { Artist = "Kendrick Lamar", Title = "Humble." },
                new Chart { Artist = "Ed Sheeran", Title = "Shape Of You" },
                new Chart { Artist = "Bruno Mars", Title = "That's What I Like" },
                new Chart { Artist = "Kendrick Lamar", Title = "DNA." },
                new Chart { Artist = "Future", Title = "Mask Off" },
                new Chart { Artist = "KYLE Featuring Lil Yachty", Title = "iSpy" },
                new Chart { Artist = "Zedd Alessia Cara", Title = "Stay" },
                new Chart { Artist = "The Chainsmokers Coldplay", Title = "Something Just Like This" },
                new Chart { Artist = "Luis Fonsi Daddy Yankee Featuring Justin Bieber", Title = "Despacito" },
                new Chart { Artist = "Lil Uzi Vert", Title = "XO TOUR Llif3" },
                new Chart { Artist = "Sam Hunt", Title = "Body Like A Back Road" },
                new Chart { Artist = "Julia Michaels", Title = "Issues" },
                new Chart { Artist = "Kygo x Selena Gomez", Title = "It Ain't Me" },
                new Chart { Artist = "Kendrick Lamar Featuring Rihanna", Title = "Loyalty." },
                new Chart { Artist = "Post Malone Featuring Quavo", Title = "Congratulations" },
                new Chart { Artist = "Kendrick Lamar", Title = "Element." },
                new Chart { Artist = "James Arthur", Title = "Say You Won't Let Go" },
                new Chart { Artist = "Kendrick Lamar Featuring Zacari", Title = "Love." },
                new Chart { Artist = "The Chainsmokers", Title = "Paris" },
                new Chart { Artist = "Clean Bandit Featuring Sean Paul Anne-Marie", Title = "Rockabye" },
                new Chart { Artist = "Kodak Black", Title = "Tunnel Vision" },
                new Chart { Artist = "Harry Styles", Title = "Sign Of The Times" },
                new Chart { Artist = "Maroon 5 Featuring Future", Title = "Cold" },
                new Chart { Artist = "The Weeknd Featuring Daft Punk", Title = "I Feel It Coming" },
                new Chart { Artist = "Khalid", Title = "Location" },
                new Chart { Artist = "Migos Featuring Lil Uzi Vert", Title = "Bad And Boujee" },
                new Chart { Artist = "Drake", Title = "Passionfruit" },
                new Chart { Artist = "The Chainsmokers Featuring Halsey", Title = "Closer" },
                new Chart { Artist = "Migos", Title = "T-Shirt" },
                new Chart { Artist = "Big Sean", Title = "Bounce Back" },
                new Chart { Artist = "Rihanna", Title = "Love On The Brain" },
                new Chart { Artist = "Kendrick Lamar", Title = "Yah." },
                new Chart { Artist = "Kendrick Lamar Featuring U2", Title = "XXX." },
                new Chart { Artist = "Rae Sremmurd", Title = "Swang" },
                new Chart { Artist = "Kendrick Lamar", Title = "Feel." },
                new Chart { Artist = "Zayn / Taylor Swift", Title = "I Don't Wanna Live Forever (Fifty Shades Darker)" },
                new Chart { Artist = "Kendrick Lamar", Title = "Pride." },
                new Chart { Artist = "Katy Perry Featuring Skip Marley", Title = "Chained To The Rhythm" },
                new Chart { Artist = "Lady Gaga", Title = "The Cure" },
                new Chart { Artist = "Ayo Teo", Title = "Rolex" },
                new Chart { Artist = "Bruno Mars", Title = "24K Magic" },
                new Chart { Artist = "Kendrick Lamar", Title = "Lust." },
                new Chart { Artist = "Alessia Cara", Title = "Scars To Your Beautiful" },
                new Chart { Artist = "Calvin Harris Featuring Frank Ocean Migos", Title = "Slide" },
                new Chart { Artist = "Brett Young", Title = "In Case You Didn't Know" },
                new Chart { Artist = "Travis Scott", Title = "Goosebumps" },
                new Chart { Artist = "Justin Timberlake", Title = "Can't Stop The Feeling!" },
                new Chart { Artist = "Gucci Mane Featuring Drake", Title = "Both" },
                new Chart { Artist = "Shawn Mendes", Title = "Mercy" },
                new Chart { Artist = "Kendrick Lamar", Title = "Fear." },
                new Chart { Artist = "Imagine Dragons", Title = "Believer" },
                new Chart { Artist = "XXXTENTACION", Title = "Look At Me!" },
                new Chart { Artist = "Jason Derulo Featuring Nicki Minaj Ty Dolla $ign", Title = "Swalla" },
                new Chart { Artist = "Kendrick Lamar", Title = "Blood." },
                new Chart { Artist = "Luke Combs", Title = "Hurricane" },
                new Chart { Artist = "Childish Gambino", Title = "Redbone" },
                new Chart { Artist = "Marian Hill", Title = "Down" },
                new Chart { Artist = "Kendrick Lamar", Title = "God." },
                new Chart { Artist = "French Montana Featuring Swae Lee", Title = "Unforgettable" },
                new Chart { Artist = "Drake Featuring Quavo Travis Scott", Title = "Portland" },
                new Chart { Artist = "Ed Sheeran", Title = "Castle On The Hill" },
                new Chart { Artist = "Jon Pardi", Title = "Dirt On My Boots" },
                new Chart { Artist = "Kendrick Lamar", Title = "Duckworth." },
                new Chart { Artist = "Josh Turner", Title = "Hometown Girl" },
                new Chart { Artist = "Auli'i Cravalho", Title = "How Far I'll Go" },
                new Chart { Artist = "Halsey", Title = "Now Or Never" },
                new Chart { Artist = "Keith Urban Featuring Carrie Underwood", Title = "The Fighter" },
                new Chart { Artist = "Linkin Park Featuring Kiiara", Title = "Heavy" },
                new Chart { Artist = "Jason Aldean", Title = "Any Ol' Barstool" },
                new Chart { Artist = "DJ Khaled Featuring Beyonce JAY Z", Title = "Shining" },
                new Chart { Artist = "Chris Brown Featuring Usher Gucci Mane", Title = "Party" },
                new Chart { Artist = "A Boogie Wit da Hoodie Featuring Kodak Black", Title = "Drowning" },
                new Chart { Artist = "Flo Rida 99 Percent", Title = "Cake" },
                new Chart { Artist = "Lorde", Title = "Green Light" },
                new Chart { Artist = "Dierks Bentley", Title = "Black" },
                new Chart { Artist = "G-Eazy Kehlani", Title = "Good Life" },
                new Chart { Artist = "Brantley Gilbert", Title = "The Weekend" },
                new Chart { Artist = "Lil Yachty Featuring Migos", Title = "Peek A Boo" },
                new Chart { Artist = "Russ", Title = "Losin Control" },
                new Chart { Artist = "Nicki Minaj, Drake Lil Wayne", Title = "No Frauds" },
                new Chart { Artist = "Kelsea Ballerini", Title = "Yeah Boy" },
                new Chart { Artist = "Florida Georgia Line Featuring Backstreet Boys", Title = "God, Your Mama, And Me" },
                new Chart { Artist = "Starley", Title = "Call On Me" },
                new Chart { Artist = "Big Sean", Title = "Moves" },
                new Chart { Artist = "Luke Bryan", Title = "Fast" },
                new Chart { Artist = "Tee Grizzley", Title = "First Day Out" },
                new Chart { Artist = "Logic Featuring Damian Lemar Hudson", Title = "Black Spiderman" },
                new Chart { Artist = "Future Featuring Rihanna", Title = "Selfish" },
                new Chart { Artist = "J. Cole", Title = "Deja Vu" },
                new Chart { Artist = "YFN Lucci Featuring PnB Rock", Title = "Everyday We Lit" },
                new Chart { Artist = "Martin Garrix Dua Lipa", Title = "Scared To Be Lonely" },
                new Chart { Artist = "Drake", Title = "Gyalchester" },
                new Chart { Artist = "Chris Stapleton", Title = "Broken Halos" },
                new Chart { Artist = "AJR", Title = "Weak" },
                new Chart { Artist = "Dan + Shay", Title = "How Not To" },
                new Chart { Artist = "2 Chainz x Gucci Mane x Quavo", Title = "Good Drank" },
                new Chart { Artist = "Lady Antebellum", Title = "You Look Good" },
                new Chart { Artist = "Machine Gun Kelly Featuring Hailee Steinfeld", Title = "At My Best" },
                new Chart { Artist = "Lord Huron", Title = "The Night We Met" },
                new Chart { Artist = "Thomas Rhett Featuring Maren Morris", Title = "Craving You" },

                // uk top 40 singles
                new Chart { Artist = "Clean Bandit Ft. Zara Larsson", Title = "Symphony" },
                new Chart { Artist = "Ed Sheeran", Title = "Shape Of You" },
                new Chart { Artist = "Ed Sheeran", Title = "Galway Girl" },
                new Chart { Artist = "Harry Styles", Title = "Sign Of The Times" },
                new Chart { Artist = "Drake", Title = "Passionfruit" },
                new Chart { Artist = "Jason Derulo Ft. Nicki Minaj & Ty Dolla $ign", Title = "Swalla" },
                new Chart { Artist = "Shawn Mendes", Title = "There's Nothing Holdin' Me Back" },
                new Chart { Artist = "Martin Jensen", Title = "Solo Dance" },
                new Chart { Artist = "The Chainsmokers & Coldplay", Title = "Something Just Like This" },
                new Chart { Artist = "Kendrick Lamar", Title = "HUMBLE." },
                new Chart { Artist = "Zedd & Alessia Cara", Title = "Stay" },
                new Chart { Artist = "Bruno Mars", Title = "That's What I Like" },
                new Chart { Artist = "Julia Michaels", Title = "Issues" },
                new Chart { Artist = "Kygo & Selena Gomez", Title = "It Ain't Me" },
                new Chart { Artist = "Little Mix Ft. Machine Gun Kelly", Title = "No More Sad Songs" },
                new Chart { Artist = "Rag'N'Bone Man", Title = "Skin" },
                new Chart { Artist = "Anne-Marie", Title = "Ciao Adios" },
                new Chart { Artist = "Ed Sheeran", Title = "Castle On The Hill" },
                new Chart { Artist = "Lady Gaga", Title = "The Cure" },
                new Chart { Artist = "J Hus", Title = "Did You See" },
                new Chart { Artist = "Calvin Harris Ft. Frank Ocean & Migos", Title = "Slide" },
                new Chart { Artist = "Luis Fonsi Ft. Daddy Yankee", Title = "Despacito" },
                new Chart { Artist = "Jax Jones Ft. RAYE", Title = "You Don't Know Me" },
                new Chart { Artist = "French Montana Ft. Swae Lee", Title = "Unforgettable" },
                new Chart { Artist = "Future", Title = "Mask Off" },
                new Chart { Artist = "Lorde", Title = "Green Light" },
                new Chart { Artist = "Zayn Malik Ft. PARTYNEXTDOOR", Title = "Still Got Time" },
                new Chart { Artist = "Disciples", Title = "On My Mind" },
                new Chart { Artist = "Ed Sheeran", Title = "Perfect" },
                new Chart { Artist = "Martin Garrix & Dua Lipa", Title = "Scared To Be Lonely" },
                new Chart { Artist = "Rag'N'Bone Man", Title = "Human" },
                new Chart { Artist = "Martin Solveig Ft. Ina Wroldsen", Title = "Places" },
                new Chart { Artist = "Kendrick Lamar", Title = "DNA." },
                new Chart { Artist = "Paramore", Title = "Hard Times" },
                new Chart { Artist = "Little Mix", Title = "Touch" },
                new Chart { Artist = "Katy Perry Ft. Skip Marley", Title = "Chained To The Rhythm" },
                new Chart { Artist = "Starley", Title = "Call On Me" },
                new Chart { Artist = "Lana Del Rey Ft. The Weeknd", Title = "Lust For Life" },
                new Chart { Artist = "Cheat Codes Ft. Demi Lovato", Title = "No Promises" },
                new Chart { Artist = "The Chainsmokers", Title = "Paris" }
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
