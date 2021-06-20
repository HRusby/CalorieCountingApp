using System;
using System.Collections.Generic;
using BackEnd.CalorieCountingApp.Domain;
using CalorieCountingApp.Data.Dao;
using MySql.Data.MySqlClient;

namespace BackEnd.CalorieCountingApp.Data.Dao
{
    public class MetricDao : ADao
    {
        public MetricDao(string connectionString) : base(connectionString)
        {
        }

        public List<Metric> GetMetrics()
        {
            String commandText = "CALL CalorieCounting.GetMetrics()";
            using (MySqlDataReader rdr = MySqlHelper.ExecuteReader(ConnectionString, commandText))
            {
                List<Metric> metrics = new List<Metric>();
                while (rdr.Read())
                {
                    // Create Metric
                    Metric metric = new Metric(
                        rdr.GetInt32("Id"),
                        rdr.GetString("ShortName"),
                        rdr.GetString("Name")
                    );
                    metrics.Add(metric);
                }

                return metrics;
            }
        }
    }
}