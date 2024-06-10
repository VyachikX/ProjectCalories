namespace ProjectCalories.Core.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public UserGoal Goal { get; set; }
        public int DailyCalorieIntake { get; set; }

        public enum UserGoal
        {
            LoseWeight,
            GainWeight,
            MaintainWeight
        }
    }  
}