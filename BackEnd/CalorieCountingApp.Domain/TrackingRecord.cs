using System.Collections.Immutable;
using System.Text;
using System;
using CalorieCountingApp.Domain.Enums;

namespace CalorieCountingApp.Domain
{
    public class TrackingRecord
    {
        public int? Id { get; private set; }
        public int MealOrIngredientId { get; private set; }
        public int UserId { get; private set; }
        public TrackingTypeId TypeId { get; private set;}
        public double Quantity { get; private set; }
        public double Calories { get; private set; }
        public DateTime DateTime { get; private set; }

        public TrackingRecord(
            int id,
            int mealOrIngredientId,
            int userId,
            TrackingTypeId typeId,
            double quantity,         
            double calories,   
            DateTime dateTime)
        {
            Id = id;
            MealOrIngredientId = mealOrIngredientId;
            UserId = userId;
            TypeId = typeId;
            Quantity = quantity;
            Calories = calories;    
            DateTime = dateTime;
        }

        public override string ToString(){
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");
            builder.AppendLine("\tId: " + Id);
            builder.AppendLine("\tMealOrIngredientId: " + Id);
            builder.AppendLine("\tUserId: " + UserId);
            builder.AppendLine("\tTypeId: " + TypeId);
            builder.AppendLine("\tQuantity: " + Quantity);
            builder.AppendLine("\tCalories: " + Calories);
            builder.AppendLine("\tDateTime: " + DateTime);
            builder.AppendLine("}");
            return builder.ToString();
        }
    }
}