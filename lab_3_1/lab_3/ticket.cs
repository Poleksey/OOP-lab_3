
public class Ticket
{
    // идентификация
    private static int TicketIdCount = 1;
    public int TicketId {get;} = TicketIdCount++;  


    // связи с другими сущностями
    public User Customer {get; set;}          
    public List<Dish> Items {get;} = new();   
    public Restaurant Restaurant {get; set;}  


    // Блок с ценообразованием
    public decimal TaxScaler {get; set;} = 0.22m;  //ндс.. 
    public decimal DiscountValue {get; set;} = 0; 
    public decimal DeliveryFee {get; set;} = 0;
    public decimal AdditionalFee {get; set;} = 0;

    public decimal FinalPrice {get; private set;}
    
    public decimal CalculateTotal()
    {
               
        decimal priceBase = Items.Sum(dish => dish.Price);
        decimal afterDiscount = Math.Max(0, priceBase - DiscountValue);
        decimal afterTax = afterDiscount * (1 + TaxScaler);
        
        FinalPrice = afterTax + DeliveryFee + AdditionalFee;
        return FinalPrice;
    }


    public IDeliveryStrategy DeliveryStrategy { get; set; }
    private ITicketState _state;
    private List<IOrderStrategy> _orderStrategies = new();



    public void CalculateDeliveryFee()
    {
        if (DeliveryStrategy != null && Restaurant != null && Customer != null)
        {
            DeliveryFee = DeliveryStrategy.CalculateFee(
                Restaurant.Location,
                Customer.Address
            );
        }
    }
    public void SetDeliveryStrategy(IDeliveryStrategy strategy)
    {
        DeliveryStrategy = strategy;
        CalculateDeliveryFee();
    }
    public void AddOrderStrategy(IOrderStrategy strategy)
    {
    if (strategy != null)
    {
        _orderStrategies.Add(strategy);
        strategy.Apply(this);
        CalculateTotal(); 
    }
    }
    
    public void ClearOrderStrategies()
    {
        _orderStrategies.Clear();
    }

    public Ticket()
    {
        _state = new PreparingState(); 
    }
   

    public void SetState(ITicketState state)
    {
        _state = state;
    }
   


    public void Preparing() => _state.Preparing(this);
    public void Canceling() => _state.Canceling(this);
    public void Delivering() => _state.Delivering(this);
    public void AwaitingPayment() => _state.AwaitingPayment(this);
    public void Complete() => _state.Complete(this);

    // Prototype для повторного заказа в контексте конкретного пользователя
    public Ticket CloneForUser(User requestingUser)
    {
        if (requestingUser.UserId != this.Customer.UserId)
            return null; 
        
        var clone = new Ticket
        {
            Customer = requestingUser,
            Restaurant = this.Restaurant,
            TaxScaler = this.TaxScaler,
            DiscountValue = this.DiscountValue,
            DeliveryFee = this.DeliveryFee,
            DeliveryStrategy = this.DeliveryStrategy
        };
        
        foreach (var dish in this.Items)
        {
            clone.Items.Add(dish);
        }
        
        foreach (var strategy in this._orderStrategies)
        {
            clone.AddOrderStrategy(strategy);
        }
        
        return clone;
    }
}








