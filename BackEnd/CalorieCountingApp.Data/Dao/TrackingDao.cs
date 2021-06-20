using System;
using System.Collections.Generic;
using System.Data;
using BackEnd.CalorieCountingApp.Data.Dao;
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

        public List<DisplayableTrackingRecord> GetTrackingDataForDateAndUser(TrackingDataRequest request)
        {
            String commandText = "CALL CalorieCounting.GetTrackingDataForDateAndUser(@$UserId, @$Date)";
            MySqlParameter[] sqlParameters = new MySqlParameter[2]{
                new MySqlParameter("$UserId", request.UserId),
                new MySqlParameter("$Date", request.Date)
            };
            using (MySqlDataReader rdr = MySqlHelper.ExecuteReader(ConnectionString, commandText, sqlParameters))
            {
                List<DisplayableTrackingRecord> records = new List<DisplayableTrackingRecord>();
                while (rdr.Read())
                {
                    DisplayableTrackingRecord record = new DisplayableTrackingRecord(
                        rdr.GetInt32("TrackingId"),
                        rdr.GetInt32("MealOrIngredientId"),
                        rdr.GetInt32("UserId"),
                        (TrackingTypeId)rdr.GetInt32("TypeId"),
                        rdr.GetDouble("Quantity"),
                        rdr.GetDecimal("Calories"),
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
            String commandText = "DeleteTrackingRecord";

            int affectedRows = MySqlHelperExtensions.ExecuteNonQuery(ConnectionString, commandText, CommandType.StoredProcedure, new MySqlParameter("$TrackingId", trackingId));
            return affectedRows == 1;
        }

        public int AddTrackingRecord(TrackingRecord record, string storedProcName)
        {
            MySqlParameter generatedId = CreateOutputParameter("$GeneratedId", MySqlDbType.Int32);
            MySqlParameter[] sqlParams = new MySqlParameter[6]{
                new MySqlParameter("$UserId", record.UserId),
                new MySqlParameter("$Quantity", record.Quantity),
                new MySqlParameter("$Calories", record.Calories),
                new MySqlParameter("$DateTime", record.DateTime),
                new MySqlParameter("$MealOrIngredientId", record.MealOrIngredientId),
                generatedId
            };

            MySqlHelperExtensions.ExecuteNonQuery(ConnectionString, storedProcName, CommandType.StoredProcedure, sqlParams);
            return Convert.ToInt32(generatedId.Value);
        }

        public bool UpdateTrackingRecord(TrackingRecord updatedRecord, string storedProcName)
        {
            MySqlParameter[] sqlParams = new MySqlParameter[5]{
                new MySqlParameter("$IndividualTrackingId", updatedRecord.Id),
                new MySqlParameter("$Quantity", updatedRecord.Quantity),
                new MySqlParameter("$Calories", updatedRecord.Calories),
                new MySqlParameter("$DateTime", updatedRecord.DateTime),
                new MySqlParameter("$MealOrIngredientId", updatedRecord.MealOrIngredientId)
            };

            int affectedRows = MySqlHelperExtensions.ExecuteNonQuery(ConnectionString, storedProcName, CommandType.StoredProcedure, sqlParams);
            return affectedRows == 1;
        }
    }
}