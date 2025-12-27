

public class StandardDelivery : IDeliveryStrategy
{
    public decimal CalculateFee(string restaurantAddress, string customerAddress)
    {
        return 100; 
    }
    
    public string GetDeliveryType() => "Стандартная";
}
public class FastDelivery : IDeliveryStrategy
{
    public decimal CalculateFee(string restaurantAddress, string customerAddress)
    {
        return 300; 
    }
    
    public string GetDeliveryType() => "Срочная";
}
