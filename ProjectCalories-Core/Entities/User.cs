namespace ProjectCalories.Core.Entities 
{ 
    public class User 
    { 
        public int Id { get; set; } 
        public string Name { get; set; } 
        public int Age { get; set; } 
        public double Weight { get; set; } 
        public double Height { get; set; } 
 
        // Используем enum для выбора цели 
        public UserGoal Goal { get; set; } 
        public int DailyCalorieIntake { get; set; } 
 
        // Enum для выбора цели 
        public enum UserGoal 
        { 
            LoseWeight, 
            GainWeight,
            MaintainWeight
        } 
    } 
}
