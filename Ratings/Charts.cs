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
                new Chart { Artist = "The Chainsmokers Feat. Halsey", Title = "Closer" },
                new Chart { Artist = "Calum Scott", Title = "Dancing on My Own" },
                new Chart { Artist = "James Arthur", Title = "Say You Won't Let Go" },
                new Chart { Artist = "Ariana Grande Feat. Nicki Minaj", Title = "Side to Side" },
                new Chart { Artist = "Sia Feat. Kendrick Lamar", Title = "The Greatest" },
                new Chart { Artist = "Hailee Steinfeld", Title = "Starving" },
                new Chart { Artist = "Twenty One Pilots", Title = "Heathens" },
                new Chart { Artist = "DJ Snake Feat. Justin Bieber", Title = "Let Me Love You" },
                new Chart { Artist = "The Weeknd Feat. Daft Punk", Title = "Starboy" },
                new Chart { Artist = "Major Lazer Feat. Justin Bieber & MØ", Title = "Cold Water" },
                new Chart { Artist = "Lil Wayne, Wiz Khalifa & Imagine Dragons, X Ambassadors, Ty Dolla $ign, Logic", Title = "Sucker For Pain" },
                new Chart { Artist = "Calvin Harris", Title = "My Way" },
                new Chart { Artist = "Jonas Blue", Title = "Perfect Strangers" },
                new Chart { Artist = "Illy Feat. Vera Blue", Title = "Papercuts" },
                new Chart { Artist = "Betty Who", Title = "I Love You Always Forever" },
                new Chart { Artist = "Martin Garrix & Bebe Rexha", Title = "In The Name Of Love" },
                new Chart { Artist = "Shawn Mendes", Title = "Treat You Better" },
                new Chart { Artist = "Mike Perry", Title = "The Ocean" },
                new Chart { Artist = "Anne-Marie", Title = "Alarm" },
                new Chart { Artist = "Justin Timberlake", Title = "Can't Stop The Feeling!" },
                new Chart { Artist = "Ellie Goulding", Title = "Still Falling For You" },
                new Chart { Artist = "Shawn Mendes", Title = "Mercy" },
                new Chart { Artist = "MØ", Title = "Final Song" },
                new Chart { Artist = "Zara Larsson", Title = "Ain't My Fault" },
                new Chart { Artist = "Adele", Title = "Send My Love (To Your New Lover)" },
                new Chart { Artist = "Artists Of Then, Now & Forever", Title = "Forever Country" },
                new Chart { Artist = "Calvin Harris Feat. Rihanna", Title = "This Is What You Came For" },
                new Chart { Artist = "Drake Feat. Wizkid & Kyla", Title = "One Dance" },
                new Chart { Artist = "The Chainsmokers Feat. Daya", Title = "Don't Let Me Down" },
                new Chart { Artist = "Charlie Puth Feat. Selena Gomez", Title = "We Don't Talk Anymore" },
                new Chart { Artist = "Drake Feat. Rihanna", Title = "Too Good" },
                new Chart { Artist = "Ariana Grande", Title = "Into You" },
                new Chart { Artist = "Tove Lo", Title = "Cool Girl" },
                new Chart { Artist = "The Black Eyed Peas Feat. The World", Title = "#Wheresthelove" },
                new Chart { Artist = "Usher", Title = "Crash" },
                new Chart { Artist = "The Veronicas", Title = "In My Blood" },
                new Chart { Artist = "Flume Feat. Tove Lo", Title = "Say It" },
                new Chart { Artist = "Kungs vs. Cookin' On 3 Burners", Title = "This Girl" },
                new Chart { Artist = "DNCE", Title = "Toothbrush" },
                new Chart { Artist = "Lady Gaga", Title = "Perfect Illusion" },
                new Chart { Artist = "Sia", Title = "Cheap Thrills" },
                new Chart { Artist = "Twenty One Pilots", Title = "Ride" },
                new Chart { Artist = "Gnash Feat. Olivia O'Brien", Title = "I Hate U, I Love U" },
                new Chart { Artist = "Flume Feat. Kai", Title = "Never Be Like You" },
                new Chart { Artist = "DNCE", Title = "Cake By The Ocean" },
                new Chart { Artist = "Passenger", Title = "Anywhere" },
                new Chart { Artist = "Mike Posner", Title = "I Took A Pill In Ibiza" },
                new Chart { Artist = "Rihanna", Title = "Needed Me" },
                new Chart { Artist = "Desiigner", Title = "Panda" },
                new Chart { Artist = "Drake", Title = "Controlla" },

                // aria urban
                new Chart { Title = "Starboy", Artist = "The Weeknd Feat. Daft Punk" },
                new Chart { Title = "Sucker For Pain", Artist = "Lil Wayne, Wiz Khalifa & Imagine Dragons, X Ambassadors, Ty Dolla $ign, Logic" },
                new Chart { Title = "Papercuts", Artist = "Illy Feat. Vera Blue" },
                new Chart { Title = "Too Good", Artist = "Drake Feat. Rihanna" },
                new Chart { Title = "Crash", Artist = "Usher" },
                new Chart { Title = "Don't Mind", Artist = "Kent Jones" },
                new Chart { Title = "Work From Home", Artist = "Fifth Harmony Feat. Ty Dolla $ign" },
                new Chart { Title = "1955", Artist = "Hilltop Hoods Feat. Montaigne & Tom Thum" },
                new Chart { Title = "All In My Head (Flex)", Artist = "Fifth Harmony Feat. Fetty Wap" },
                new Chart { Title = "Uptown Funk", Artist = "Mark Ronson Feat. Bruno Mars" },
                new Chart { Title = "Do You Mind", Artist = "DJ Khaled Feat. Nicki Minaj, Chris Brown, August Alsina, Jeremih, Future & Rick Ross" },
                new Chart { Title = "Can't Feel My Face", Artist = "The Weeknd" },
                new Chart { Title = "Wavy", Artist = "Ty Dolla $ign Feat. Joe Moses" },
                new Chart { Title = "The Hills", Artist = "The Weeknd" },
                new Chart { Title = "Dang!", Artist = "Mac Miller" },
                new Chart { Title = "Hotline Bling", Artist = "Drake" },
                new Chart { Title = "All of Me", Artist = "John Legend" },
                new Chart { Title = "Without Me", Artist = "Eminem" },
                new Chart { Title = "Ni**as In Paris", Artist = "Jay-Z & Kanye West" },
                new Chart { Title = "In My Mind", Artist = "Maty Noyes" },
                new Chart { Title = "See You Again", Artist = "Wiz Khalifa Feat. Charlie Puth" },
                new Chart { Title = "Pick Up The Phone", Artist = "Young Thug & Travis Scott Feat. Quavo" },
                new Chart { Title = "King Kunta", Artist = "Kendrick Lamar" },
                new Chart { Title = "Downtown", Artist = "Macklemore & Ryan Lewis Feat. Eric Nally, Melle Mel, Kool Moe Dee & Grandmaster Caz" },
                new Chart { Title = "Never Say Never", Artist = "Thundamentals" },
                new Chart { Title = "For Free", Artist = "DJ Khaled Feat. Drake" },
                new Chart { Title = "679", Artist = "Fetty Wap Feat. Remy Boyz" },
                new Chart { Title = "Stronger", Artist = "Kanye West" },
                new Chart { Title = "We Found Love", Artist = "Rihanna Feat. Calvin Harris" },
                new Chart { Title = "Brad Pitt's Cousin", Artist = "Macklemore & Ryan Lewis Feat. Xperience" },
                new Chart { Title = "Love The Way You Lie", Artist = "Eminem Feat. Rihanna" },
                new Chart { Title = "Halo", Artist = "Beyonce" },
                new Chart { Title = "Hold Up", Artist = "Beyonce" },
                new Chart { Title = "The Monster", Artist = "Eminem Feat. Rihanna" },
                new Chart { Title = "Calling Out", Artist = "PEZ Feat. Paul Dempsey" },
                new Chart { Title = "Bang Bang", Artist = "Jessie J Feat. Nicki Minaj & Ariana Grande" },
                new Chart { Title = "The Real Slim Shady", Artist = "Eminem" },
                new Chart { Title = "Diamonds", Artist = "Rihanna" },
                new Chart { Title = "FourFiveSeconds", Artist = "Rihanna, Paul McCartney & Kanye West" },
                new Chart { Title = "Rap God", Artist = "Eminem" },

                // aria dance 
                new Chart { Title = "Closer", Artist = "The Chainsmokers Feat. Halsey" },
                new Chart { Title = "The Greatest", Artist = "Sia Feat. Kendrick Lamar" },
                new Chart { Title = "Cold Water", Artist = "Major Lazer Feat. Justin Bieber & MØ" },
                new Chart { Title = "My Way", Artist = "Calvin Harris" },
                new Chart { Title = "Perfect Strangers", Artist = "Jonas Blue" },
                new Chart { Title = "In The Name Of Love", Artist = "Martin Garrix & Bebe Rexha" },
                new Chart { Title = "The Ocean", Artist = "Mike Perry" },
                new Chart { Title = "This Is What You Came For", Artist = "Calvin Harris Feat. Rihanna" },
                new Chart { Title = "Say It", Artist = "Flume Feat. Tove Lo" },
                new Chart { Title = "Cheap Thrills", Artist = "Sia" },
                new Chart { Title = "I Hate U, I Love U", Artist = "Gnash Feat. Olivia O'Brien" },
                new Chart { Title = "Never Be Like You", Artist = "Flume Feat. Kai" },
                new Chart { Title = "Let Me Hold You (Turn Me On)", Artist = "Cheat Codes & Dante Klein" },
                new Chart { Title = "Don't Be So Shy (Filatov & Karas Remix)", Artist = "Imany" },
                new Chart { Title = "Sex", Artist = "Cheat Codes Feat. Kris Kross Amsterdam" },
                new Chart { Title = "Money Maker", Artist = "Throttle Feat. LunchMoney Lewis & Aston Merrygold" },
                new Chart { Title = "No Money", Artist = "Galantis" },
                new Chart { Title = "Purple Lamborghini", Artist = "Skrillex & Rick Ross" },
                new Chart { Title = "Fast Car", Artist = "Jonas Blue Feat. Dakota" },
                new Chart { Title = "Home", Artist = "Topic Feat. Nico Santos" }
            };

            for (int i = 0; i < _charts.Count; i++)
            {
                IChart chart = new Chart();
                chart = _charts[i];

                var index = chart.Artist.IndexOf(" Feat. ", StringComparison.OrdinalIgnoreCase);

                if (index > 0)
                    chart.Artist = chart.Artist.Substring(0, index - 1);

                index = chart.Artist.IndexOf(" & ", StringComparison.OrdinalIgnoreCase);

                if (index > 0)
                    chart.Artist = chart.Artist.Substring(0, index - 1);

                index = chart.Artist.IndexOf(", ", StringComparison.OrdinalIgnoreCase);

                if (index > 0)
                    chart.Artist = chart.Artist.Substring(0, index - 1);

                index = chart.Title.IndexOf(" (", StringComparison.OrdinalIgnoreCase);

                if (index > 0)
                    chart.Artist = chart.Title.Substring(0, index - 1);

                chart.Artist.Trim();
                chart.Title.Trim();
            }

            return _charts;
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
