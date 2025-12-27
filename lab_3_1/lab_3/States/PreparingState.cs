public class PreparingState : ITicketState
{
    public void Preparing(Ticket ticket)
    {
        Console.WriteLine("готовится");
    }
    
    public void Canceling(Ticket ticket) 
    {
        ticket.SetState(new CanceledState());
        Console.WriteLine("Заказ отменён");
    }
    
    public void Delivering(Ticket ticket)
    {
        ticket.SetState(new DeliveringState());
        Console.WriteLine("Заказ передан на доставку");
    }
    
    public void AwaitingPayment(Ticket ticket) 
    {
        throw new InvalidOperationException("Из 'готовится' нельзя перейти в 'ожидает оплаты'");
    }

    public void Complete(Ticket ticket)
    {
        throw new InvalidOperationException("Из 'готовится' нельзя перейти в 'завершён'");
    }
}