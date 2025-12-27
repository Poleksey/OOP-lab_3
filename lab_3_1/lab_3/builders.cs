
public interface IOrderBuilder
{
    void Reset();
    void SetCustomer(User customer);
    void SetRestaurant(Restaurant restaurant);
    void AddDish(Dish dish);
    void SetDeliveryStrategy(IDeliveryStrategy strategy); 
    void AddOrderStrategy(IOrderStrategy strategy);
    Ticket GetResult();
}


public class OrderBuilder: IOrderBuilder
{
    private Ticket _ticket = new Ticket();

    public void AddOrderStrategy(IOrderStrategy strategy)
    {
        _ticket.AddOrderStrategy(strategy);
    }

    public void Reset()
    {
        _ticket = new Ticket(); 
    }
    
    public Ticket GetResult()
    {
        var result = _ticket;
        Reset();
        return result;
    }

    public void SetCustomer(User customer) => _ticket.Customer = customer;
    public void SetRestaurant(Restaurant restaurant) => _ticket.Restaurant = restaurant;
    public void AddDish(Dish dish) => _ticket.Items.Add(dish);

    public void SetDeliveryStrategy(IDeliveryStrategy strategy)
    {
        _ticket.DeliveryStrategy = strategy;
    }
}
