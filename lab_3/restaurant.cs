public class Restaurant
{
    // public int RestaurantId { get; }
    public string Name { get; set; }
    public string Location { get; set; }
    public Menu Menu { get; set; } = new Menu();
}

public class Menu
{
    public List<Dish> Dishes { get; } = new List<Dish>();
}