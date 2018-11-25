namespace Services.Statistic
{
    public class StatisticEntry
    {
        public string Label { get; set; }
        public int Value { get; set; }
        public string Color { get; set; }

        public StatisticEntry(string label, int value, string color)
        {
            this.Label = label;
            this.Value = value;
            this.Color = color;
        }
    }
}
