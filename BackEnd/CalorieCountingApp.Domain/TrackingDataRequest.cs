using System;
namespace BackEnd.CalorieCountingApp.Domain
{
    public class TrackingDataRequest
    {
        public int UserId { get; private set; }
        public DateTime Date { get; private set; }

        public TrackingDataRequest(int userId, DateTime date)
        {
            UserId = userId;
            Date = date;
        }
    }
}