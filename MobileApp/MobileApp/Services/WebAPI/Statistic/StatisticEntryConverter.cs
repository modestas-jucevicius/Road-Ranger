using Models.Statistics;
using SkiaSharp;
using System.Collections.Generic;

namespace MobileApp.Services.WebAPI.Statistic
{
    public class StatisticEntryConverter
    {
        public List<Microcharts.Entry> ToMicrochartEntries(List<StatisticEntry> entries)
        {
            List<Microcharts.Entry> list = new List<Microcharts.Entry>();
            foreach (var entry in entries)
            {
                list.Add(ToMicrochartEntry(entry));
            }
            return list;
        }

        private Microcharts.Entry ToMicrochartEntry(StatisticEntry entry)
        {
            return new Microcharts.Entry(entry.Value)
            {
                Label = entry.Label,
                ValueLabel = entry.Value.ToString(),
                Color = SKColor.Parse(entry.Color)
            };
        }
    }
}
