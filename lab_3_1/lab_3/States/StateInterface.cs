public interface ITicketState
{
    void Preparing(Ticket ticket);
    void Canceling(Ticket ticket);
    void Delivering(Ticket ticket);  
    void AwaitingPayment(Ticket ticket);
    void Complete(Ticket ticket);
}
