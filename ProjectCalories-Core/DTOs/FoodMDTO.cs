namespace ProjectCalories.Core.DTOs
{ 
    public class FoodMDTO // Важная ДТО для добавления продукта по БЖУ (последующая конвертация в калории)
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double ProteinGrams { get; set; }
        public double FatGrams { get; set; }
        public double CarbohydrateGrams { get; set; }
    }
}
