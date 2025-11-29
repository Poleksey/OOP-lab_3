public class Dish
{
    private static int _nextDishId = 1;
    public int DishId { get; } = _nextDishId++;
    public decimal Price { get; set; } 
}