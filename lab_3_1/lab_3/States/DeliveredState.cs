public class DeliveredState : ITicketState
{
    public void Preparing(Ticket ticket) 
    {
        throw new InvalidOperationException("Заказ уже доставлен");
    }
    public void Canceling(Ticket ticket) 
    {
        throw new InvalidOperationException("Заказ уже доставлен");
    }
    public void Delivering(Ticket ticket) 
    {
        throw new InvalidOperationException("Заказ уже доставлен");
    }
    public void AwaitingPayment(Ticket ticket) 
    {
        throw new InvalidOperationException("Заказ уже доставлен и оплачен");
    }
    public void Complete(Ticket ticket) 
    {
        Console.WriteLine("Заказ уже доставлен");
    }
}