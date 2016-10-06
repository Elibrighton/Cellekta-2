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
                new Chart { Artist = "Drake", Title = "Controlla" }
            };

            for (int i = 0; i < _charts.Count; i++)
            {
                IChart chart = new Chart();
                chart = _charts[i];

                var index = chart.Artist.IndexOf(" Feat. ", StringComparison.OrdinalIgnoreCase);

                if (index > 0)
                    chart.Artist = chart.Artist.Substring(0, index - 1);
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
