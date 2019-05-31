using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Videotheque.utils
{
    class StatistiqueUtils
    {
        public static SeriesCollection BuildSeriesCollection(Dictionary<string, int> data)
        {
            SeriesCollection stat = new SeriesCollection();
            foreach (KeyValuePair<string, int> entry in data)
            {
                stat.Add(new PieSeries()
                {
                    Title = entry.Key,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(entry.Value) },
                    DataLabels = true
                });
            }
            return stat;
        }
    }
}