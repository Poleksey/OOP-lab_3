
public interface IOrderBuilder
{
    void Reset();

    void SetCustomer(User customer);
    void SetRestaurant(Restaurant restaurant);
    void AddDish(Dish dish);
    Ticket GetResult();
}


public class OrderBuilder: IOrderBuilder
{
    private Ticket _ticket = new Ticket();

    public void Reset()
    {
        _ticket = new Ticket(); 
    }

    public void SetCustomer(User customer) => _ticket.Customer = customer;
    public void SetRestaurant(Restaurant restaurant) => _ticket.Restaurant = restaurant;
    public void AddDish(Dish dish) => _ticket.Items.Add(dish);
    public Ticket GetResult() => return _ticket;
}
