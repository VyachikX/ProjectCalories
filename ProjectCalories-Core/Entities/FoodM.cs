namespace ProjectCalories.Core.Entities
{
    public class FoodM // Вспомогательная сущность
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double ProteinGrams { get; set; }
        public double FatGrams { get; set; }
        public double CarbohydrateGrams { get; set; }

    }
}