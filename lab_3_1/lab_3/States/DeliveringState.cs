public class DeliveringState : ITicketState
{
    public void Preparing(Ticket ticket)
    {
        throw new InvalidOperationException("Из 'доставляется' нельзя вернуться в 'готовится'");
    }
    
    public void Canceling(Ticket ticket)
    {
        ticket.SetState(new CanceledState());
        Console.WriteLine("Заказ отменён во время доставки");
    }

    public void Delivering(Ticket ticket)
    {
        Console.WriteLine("в дороге");
    }
    
    public void AwaitingPayment(Ticket ticket)
    {
        ticket.SetState(new AwaitingPaymentState());
        Console.WriteLine("Заказ доставлен, ожидает оплаты");
    }

    public void Complete(Ticket ticket)
    {
        throw new InvalidOperationException("Сначала нужно перейти в 'ожидает оплаты'");
    }
}