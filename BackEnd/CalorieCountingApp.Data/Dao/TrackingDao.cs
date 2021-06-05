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

        public int AddNewIndividualTrackingRecord(TrackingRecord record)
        {
            return AddTrackingRecord(record, "AddIndividualTrackingRecord");
        }

        public int AddNewMealTrackingRecord(TrackingRecord record)
        {
            return AddTrackingRecord(record, "AddMealTrackingRecord");
        }

        public bool UpdateNewIndividualTrackingRecord(TrackingRecord record)
        {
            return UpdateTrackingRecord(record, "UpdateIndividualTrackingRecord");
        }

        public bool UpdateNewMealTrackingRecord(TrackingRecord record)
        {
            return UpdateTrackingRecord(record, "UpdateMealTrackingRecord");
        }

        public List<DisplayableTrackingRecord> GetTrackingDataForDateAndUser(TrackingDataRequest request)
        {
            using (MySqlCommand cmd = new MySqlCommand("GetTrackingDataForDateAndUser", Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$UserId", request.UserId));
                cmd.Parameters.Add(new MySqlParameter("$Date", request.Date));
                MySqlDataReader rdr = cmd.ExecuteReader();

                List<DisplayableTrackingRecord> records = new List<DisplayableTrackingRecord>();
                while (rdr.Read())
                {
                    DisplayableTrackingRecord record = new DisplayableTrackingRecord(
                        rdr.GetInt32("TrackingId"),
                        rdr.GetInt32("MealOrIngredientId"),
                        rdr.GetInt32("UserId"),
                        (TrackingTypeId)rdr.GetInt32("TypeId"),
                        rdr.GetDouble("Quantity"),
                        rdr.GetDouble("Calories"),
                        rdr.GetDateTime("DateTime"),
                        rdr.GetString("MealOrIngredientName"),
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

        private int AddTrackingRecord(TrackingRecord record, string storedProcName)
        {
            using (MySqlCommand cmd = new MySqlCommand(storedProcName, Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter generatedId = CreateOutputParameter("$GeneratedId", MySqlDbType.Int32);
                cmd.Parameters.Add(new MySqlParameter("$UserId", record.UserId));
                cmd.Parameters.Add(new MySqlParameter("$Quantity", record.Quantity));
                cmd.Parameters.Add(new MySqlParameter("$Calories", record.Calories));
                cmd.Parameters.Add(new MySqlParameter("$DateTime", record.DateTime));
                cmd.Parameters.Add(new MySqlParameter("$MealOrIngredientId", record.MealOrIngredientId));
                cmd.Parameters.Add(generatedId);
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(generatedId.Value);
            }
        }

        private bool UpdateTrackingRecord(TrackingRecord updatedRecord, string storedProcName)
        {
            using (MySqlCommand cmd = new MySqlCommand(storedProcName, Connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$IndividualTrackingId", updatedRecord.Id));
                cmd.Parameters.Add(new MySqlParameter("$Quantity", updatedRecord.Quantity));
                cmd.Parameters.Add(new MySqlParameter("$Calories", updatedRecord.Calories));
                cmd.Parameters.Add(new MySqlParameter("$DateTime", updatedRecord.DateTime));
                cmd.Parameters.Add(new MySqlParameter("$MealOrIngredientId", updatedRecord.MealOrIngredientId));
                int affectedRows = cmd.ExecuteNonQuery();
                return affectedRows == 1;
            }
        }
    }
}