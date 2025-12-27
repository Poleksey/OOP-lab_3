public class CanceledState : ITicketState
{
    public void Preparing(Ticket ticket) 
    {
        throw new InvalidOperationException("Заказ отменён");
    }
    public void Canceling(Ticket ticket) 
    {
        Console.WriteLine("Заказ уже отменён");
    }
    public void Delivering(Ticket ticket) 
    {
        throw new InvalidOperationException("Заказ отменён");
    }
    public void AwaitingPayment(Ticket ticket) 
    {
        throw new InvalidOperationException("Заказ отменён");
    }
    public void Complete(Ticket ticket) 
    {
        throw new InvalidOperationException("Заказ отменён");
    }
}