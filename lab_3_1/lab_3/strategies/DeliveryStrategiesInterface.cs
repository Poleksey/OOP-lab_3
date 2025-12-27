public interface IDeliveryStrategy
{
    //предполагается вычисление на основе сервиса карты
    decimal CalculateFee(string restaurantAddress, string customerAddress);
    string GetDeliveryType();
}
