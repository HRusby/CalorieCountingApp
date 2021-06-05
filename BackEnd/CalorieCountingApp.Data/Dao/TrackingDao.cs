using System;
using System.Collections.Generic;
using System.Data;
using BackEnd.CalorieCountingApp.Domain;
using CalorieCountingApp.Domain;
using CalorieCountingApp.Domain.Enums;
using MySql.Data.MySqlClient;

namespace CalorieCountingApp.Data.Dao
{
    public class TrackingDao : ADao
    {
        public TrackingDao(string connectionString)
            : base(connectionString)
        {
        }

        public int AddNewTrackingRecord(
            int userId,
            int ingredientId,
            MetricId metricId,
            double quantity,
            DateTime dateTime)
        {
            using (MySqlCommand cmd = new MySqlCommand("UpdateTrackingRecord", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter generatedId = CreateOutputParameter("$GeneratedId", MySqlDbType.Int32);
                cmd.Parameters.Add(new MySqlParameter("$UserId", userId));
                cmd.Parameters.Add(new MySqlParameter("$IngredientId", ingredientId));
                cmd.Parameters.Add(new MySqlParameter("$MetricId", (int)metricId));
                cmd.Parameters.Add(new MySqlParameter("$Quantity", quantity));                
                cmd.Parameters.Add(new MySqlParameter("$DateTime", dateTime));
                cmd.Parameters.Add(generatedId);
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(generatedId.Value);
            }
        }

        public bool UpdateTrackingRecord(DisplayableTrackingRecord updatedRecord){
            using (MySqlCommand cmd = new MySqlCommand("UpdateMeal", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$TrackingId", updatedRecord.Id));
                cmd.Parameters.Add(new MySqlParameter("$UserId", updatedRecord.UserId));
                cmd.Parameters.Add(new MySqlParameter("$IngredientId", updatedRecord.IngredientId));
                cmd.Parameters.Add(new MySqlParameter("$MetricId", (int)updatedRecord.MetricId));
                cmd.Parameters.Add(new MySqlParameter("$Quantity", updatedRecord.Quantity));
                cmd.Parameters.Add(new MySqlParameter("$DateTime", updatedRecord.DateTime));
                int affectedRows = cmd.ExecuteNonQuery();
                return affectedRows == 1;
            }
        }

        public List<DisplayableTrackingRecord> GetTrackingDataForDateAndUser(TrackingDataRequest request)
        {
            using(MySqlCommand cmd = new MySqlCommand("GetTrackingDataForDateAndUser", Connection)){
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$UserId", request.UserId));
                cmd.Parameters.Add(new MySqlParameter("$Date", request.Date));
                MySqlDataReader rdr = cmd.ExecuteReader();

                List<DisplayableTrackingRecord> records = new List<DisplayableTrackingRecord>();
                while(rdr.Read()){
                    DisplayableTrackingRecord record = new DisplayableTrackingRecord(
                        rdr.GetInt32("Id"),
                        rdr.GetInt32("UserId"),
                        rdr.GetInt32("IngredientId"),
                        (MetricId) rdr.GetInt32("MetricId"),
                        rdr.GetDouble("Quantity"),
                        rdr.GetDateTime("DateTime"),
                        rdr.GetString("IngredientName"),      
                        rdr.GetString("MetricShortName")
                    );
                    records.Add(record);
                }
                return records;
            }
        }

        public bool DeleteTrackingRecord(int trackingId)
        {
            using (MySqlCommand cmd = new MySqlCommand("DeleteTrackingRecord", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$TrackingId", trackingId));
                int affectedRows = cmd.ExecuteNonQuery();
                return affectedRows == 1;
            }
        }
    }
}