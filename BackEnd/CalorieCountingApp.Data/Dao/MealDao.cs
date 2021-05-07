using CalorieCountingApp.Domain;

namespace CalorieCountingApp.Data.Dao
{
    public class MealDao : ADao
    {
        public MealDao(string connectionString) 
            : base(connectionString)
        {}

        public int AddNewMeal(){
            return -1;
        }

        public bool UpdateMeal(Meal updateMeal){
            return false;
        }

        public bool DeleteMeal(int mealId){
            return false;
        }
    }
}