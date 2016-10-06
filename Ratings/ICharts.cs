using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ratings
{
    public interface ICharts
    {
        List<IChart> GetCharts();
        bool IsChartedSong(string artist, string title);
    }
}
