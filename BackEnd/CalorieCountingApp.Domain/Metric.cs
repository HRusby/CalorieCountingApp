using CalorieCountingApp.Domain.Enums;

namespace BackEnd.CalorieCountingApp.Domain
{
    public class Metric
    {
        public MetricId Id { get; private set;}
        public string ShortName { get; private set; }
        public string Name { get; private set; }
        public Metric(int id, string shortName, string name)
        {
            this.Id = (MetricId)id;
            this.ShortName = shortName;
            this.Name = name;
        }
    }
}