public class AwaitingPaymentState : ITicketState
{
    public void Preparing(Ticket ticket) 
    {
        throw new InvalidOperationException("Из 'ожидает оплаты' нельзя вернуться в 'готовится'");
    }
    
    public void Canceling(Ticket ticket) 
    {
        ticket.SetState(new CanceledState());
        Console.WriteLine("Заказ отменён (не оплачен)");
    }
    
    public void Delivering(Ticket ticket) 
    {
        throw new InvalidOperationException("Из 'ожидает оплаты' нельзя вернуться в 'доставляется'");
    }
    
    public void AwaitingPayment(Ticket ticket) 
    {
        Console.WriteLine("Ожидает оплаты");
    }
    
    public void Complete(Ticket ticket) 
    {
        //оплата реализуется сторонним сервисом.
        Console.WriteLine("Заказ оплачен");
        ticket.SetState(new DeliveredState());
    }
}