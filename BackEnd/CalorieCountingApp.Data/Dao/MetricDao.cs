using System;
using System.Collections.Generic;
using System.Data;
using BackEnd.CalorieCountingApp.Domain;
using CalorieCountingApp.Data.Dao;
using CalorieCountingApp.Domain.Enums;
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
            using (MySqlCommand cmd = new MySqlCommand("GetMetrics", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader rdr = cmd.ExecuteReader();

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