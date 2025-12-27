public class Restaurant
{
    private static int RestaurantIdCount = 1;
    public int RestaurantId {get; } = RestaurantIdCount++;
    public string Name {get; set; }
    public string Location {get; set;}
    public Menu Menu {get; set;} = new Menu();
}
