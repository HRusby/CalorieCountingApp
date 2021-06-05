using System;
namespace CalorieCountingApp.Domain.Enums
{
    public enum MetricId
    {
        Gram = 1,
        Kilogram = 2,
        Millilitre = 3,
        Litre = 4
    }

    public class MetricIdHelper
    {
        public static string GetShortName(MetricId metricId)
        {
            switch (metricId)
            {
                case MetricId.Gram:
                    return "g";
                case MetricId.Kilogram:
                    return "kg";
                case MetricId.Millilitre:
                    return "ml";
                case MetricId.Litre:
                    return "l";
                default:
                    throw new NotImplementedException($"MetricId {metricId} hasn't been implemented in the Helper Method.");
            }
        }
    }
}
