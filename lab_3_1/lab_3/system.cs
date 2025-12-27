public interface IOrderSystem
{
    Ticket CreateOrder(User customer, Restaurant restaurant, List<Dish> dishes, List<IOrderStrategy> strategies= null );   
    void StartPreparing(int orderId);
    void StartDelivery(int orderId);
    void GetDelivery(int orderId);
    void CompleteOrder(int orderId);
    void CancelOrder(int orderId);
    
    
}
public class OrderSystem: IOrderSystem
{
    private readonly OrderBuilder _orderBuilder;
    private readonly List<Ticket> _activeOrders;
    
    public OrderSystem()
    {
        _orderBuilder = new OrderBuilder();
        _activeOrders = new List<Ticket>();
    }
    
    public Ticket CreateOrder(User customer, Restaurant restaurant, 
                             List<Dish> dishes,List<IOrderStrategy> strategies = null)
    {
        _orderBuilder.Reset();
        _orderBuilder.SetCustomer(customer);
        _orderBuilder.SetRestaurant(restaurant);
        _orderBuilder.SetDeliveryStrategy(new StandardDeliveryStrategy()); 


        foreach (var dish in dishes)
        {
            _orderBuilder.AddDish(dish);
        }
        
        if (strategies == null || strategies.Count == 0)
        {
            _orderBuilder.AddOrderStrategy(new NoDiscountStrategy());
        }
        else
        {
        foreach (var strategy in strategies)
            {
                _orderBuilder.AddOrderStrategy(strategy);
            }
         }
        
        var order = _orderBuilder.GetResult();
        _activeOrders.Add(order);
        
        return order;
    }
    
    public void StartPreparing(int orderId)
    {
        var order = FindOrder(orderId);
        order.Preparing();
    }
    
    public void StartDelivery(int orderId)
    {
        var order = FindOrder(orderId);
        order.Delivering();
    }
    
    public void GetDelivery(int orderId)
    {
        var order = FindOrder(orderId);
        // возможно логика проверки оплаты
        order.AwaitingPayment(); 
    }

    public void CompleteOrder(int orderId)
    {
        var order = FindOrder(orderId);
        order.Complete();
    }
    public void CancelOrder(int orderId)
    {
        var order = FindOrder(orderId);
        order.Canceling();       
    }
    
    
    private Ticket FindOrder(int orderId)
    {
        return _activeOrders.FirstOrDefault(o => o.TicketId == orderId);
    }

    public Ticket RepeatOrder(int orderId, User user)
    {
        var originalOrder = FindOrder(orderId);
        if (originalOrder == null) return null;
        
        return originalOrder.CloneForUser(user);
    }
}