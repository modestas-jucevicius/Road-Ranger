namespace WebAPI.Services.Statistic.Statistics
{
    public class StatisticFactory
    {
        public static IStatistic GetStatistic(int type)
        {
            switch (type)
            {
                case 0:
                    return new CarDateStatistic();
                case 1:
                    return new CarYearsStatistic();
                case 2:
                    return new CarModelStatistic();
                default:
                    return new CarStatusStatistic();
            }
        }
    }
}
